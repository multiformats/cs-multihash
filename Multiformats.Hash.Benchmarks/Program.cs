using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace Mutiformats.Hash.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            new BenchmarkSwitcher(typeof(Program).GetTypeInfo().Assembly).Run(args);
        }
    }
}
