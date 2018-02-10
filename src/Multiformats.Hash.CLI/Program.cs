using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Multiformats.Base;

namespace Multiformats.Hash.CLI
{
    class Program
    {
        public class Options
        {
            public HashType Algorithm { get; set; } = HashType.SHA2_256;
            public string Checksum { get; set; } = string.Empty;
            public MultibaseEncoding Encoding { get; set; } = MultibaseEncoding.Base58Btc;
            public int Length { get; set; } = -1;
            public bool Quiet { get; set; } = false;
            public Stream Source { get; set; } = null;

            public override string ToString() => $" Algorithm: {Algorithm}\n Checksum: {Checksum}\n Encoding: {Encoding}\n Length: {Length}\n Quiet: {Quiet}\n Source: {Source != null}";
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
                DisplayHelp();

            var options = ParseOptions(args);

#if DEBUG
            Console.WriteLine($"Options:\n{options}");
#endif

            if (options.Source == null)
                DisplayError("No source");

            Process(options);
        }

        private static void Process(Options options)
        {
            using (options.Source)
            {
                byte[] data = null;
                using (var mem = new MemoryStream())
                {
                    options.Source.CopyTo(mem);

                    data = mem.ToArray();
                }

                var mh = Multihash.Sum(options.Algorithm, data, options.Length);

                if (string.IsNullOrEmpty(options.Checksum))
                {
                    Console.WriteLine(mh.ToString(options.Encoding));
                    Environment.Exit(0);
                }

                var checksum = Multibase.DecodeRaw(options.Encoding, options.Checksum);
                if (!checksum.SequenceEqual(mh.Digest))
                {
                    if (!options.Quiet)
                        Console.WriteLine($"Digest mismatch, got: {Multibase.EncodeRaw(options.Encoding, mh.Digest)}, wanted: {Multibase.EncodeRaw(options.Encoding, checksum)}");

                    Environment.Exit(1);
                }

                if (!options.Quiet)
                    Console.WriteLine("Checksum match");
            }
        }

        private static Options ParseOptions(string[] args)
        {
            var options = new Options();

            var i = 0;
            while (i < args.Length)
            {
                if (args[i] == "-h" || args[i] == "--help")
                    DisplayHelp();

                if (args[i] == "-v" || args[i] == "--version")
                    DisplayVersion();

                if (args[i].StartsWith("-a") || args[i].StartsWith("--algorithm"))
                {
                    string algo;
                    if (args[i].Contains("="))
                    {
                        algo = args[i++].Split('=').Last();
                    }
                    else
                    {
                        if (++i >= args.Length)
                            DisplayError("No algorithm specified");

                        algo = args[i++];
                    }

                    var code = Hash.Multihash.GetCode(algo);
                    if (!code.HasValue)
                        DisplayError($"Unknown algorithm: {algo}");

                    options.Algorithm = code.Value;
                    continue;
                }

                if (args[i].StartsWith("-c") || args[i].StartsWith("--check"))
                {
                    if (args[i].Contains("="))
                    {
                        options.Checksum = args[i++].Split('=').Last();
                    }
                    else
                    {
                        if (++i >= args.Length)
                            DisplayError("No checksum specified");

                        options.Checksum = args[i++];
                    }
                    continue;
                }

                if (args[i].StartsWith("-e") || args[i].StartsWith("--encoding"))
                {
                    if (args[i].Contains("="))
                    {
                        options.Encoding = ParseEncoding(args[i++].Split('=').Last());
                    }
                    else
                    {
                        if (++i >= args.Length)
                            DisplayError("No encoding specified");

                        options.Encoding = ParseEncoding(args[i++]);
                    }
                    continue;
                }

                if (args[i].StartsWith("-l") || args[i].StartsWith("--length"))
                {
                    string raw;
                    if (args[i].Contains("="))
                    {
                        raw = args[i++].Split('=').Last();
                    }
                    else
                    {
                        if (++i >= args.Length)
                            DisplayError("No length specified");

                        raw = args[i++];
                    }

                    int length = -1;
                    if (!int.TryParse(raw, out length))
                        DisplayError("Invalid length specified");

                    options.Length = length;
                    continue;
                }

                if (args[i].StartsWith("-q") || args[i].StartsWith("--quiet"))
                {
                    if (args[i].Contains("="))
                    {
                        var raw = args[i++].Split('=').Last();
                        options.Quiet = !bool.TryParse(raw, out var value) || value;
                    }
                    else
                    {
                        i++;
                        options.Quiet = true;
                    }
                    continue;
                }

                if (args[i] == "-")
                {
                    i++;
                    options.Source = Console.OpenStandardInput();
                    continue;
                }

                if (!File.Exists(args[i]))
                {
                    DisplayError($"File does not exists: {args[i]}");
                }

                options.Source = new FileStream(args[i], FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan); //File.OpenRead(args[i]);
                break;
            }

            return options;
        }

        private static void DisplayVersion()
        {
            var libversion = typeof(Multihash).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            var cliversion = typeof(Program).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();

            Console.WriteLine($"v{cliversion.Version} (library v{libversion.Version})");
            Environment.Exit(0);
        }

        private static MultibaseEncoding ParseEncoding(string s)
        {
            switch (s.ToLower().Trim())
            {
                case "base2": return MultibaseEncoding.Base2;
                case "base8": return MultibaseEncoding.Base8;
                case "hex": case "base16": return MultibaseEncoding.Base16Lower;
                case "base32": return MultibaseEncoding.Base32Lower;
                case "base58": return MultibaseEncoding.Base58Btc;
                case "base64": return MultibaseEncoding.Base64;
                default:
                    DisplayError($"Unknown or unsupported encoding: {s}");
                    return default(MultibaseEncoding);
            }
        }

        private static void DisplayError(string error)
        {
            Console.WriteLine($"Error: {error}");
            Environment.Exit(1);
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("usage: multihash [options] [FILE]");
            Console.WriteLine("Print or check multihash checksums.");
            Console.WriteLine("With no FILE, or when FILE is -, read standard input.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  -a, --algorithm string  use specified algorithm (default: sha2-256)");
            Console.WriteLine("  -c, --check string      check checksum matches");
            Console.WriteLine("  -e, --encoding string   use specified encoding (default: base58)");
            Console.WriteLine("  -l, --length int        checksum length in bits (truncate, default -1)");
            Console.WriteLine("  -q, --quiet             quiet output (no newline on checksum, no error text)");
            Console.WriteLine("  -v, --version           display version");
            Console.WriteLine("  -h, --help              show help (this)");

            Environment.Exit(1);
        }
    }
}
