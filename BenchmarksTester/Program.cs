using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Runtime;
using Tdx.Net.Models;

namespace BenchmarksTester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //TdxDecimal128Value _native = new TdxDecimal128Value()
            //{
            //    Type = TdxType.Decimal128,
            //    IsNull = false,
            //    Value = 956003.3922m
            //};
            //TdxVirtualDecimal128Value _virtual = new TdxVirtualDecimal128Value()
            //{
            //    Type = TdxType.Decimal128,
            //    IsNull = false,
            //    Value = 956003.3922m
            //};
            //Console.WriteLine($"VIRTUAL:");
            //_virtual.GetBytes().ToList().ForEach(x=>Console.Write(x + ","));
            //Console.WriteLine();
            //Console.WriteLine($"NATIVE:");
            //_native.GetBytes().ToList().ForEach(x => Console.Write(x + ","));

            BenchmarkRunner.Run<BenchTasks>();

            await Task.Delay(-1);
        }
    }

    public class BenchTasks
    {
        [Benchmark]
        public void SingleAdd()
        {
            Span<byte> SPAN = stackalloc byte[12];
            List<byte> LIST = new();

            foreach (var item in SPAN)
            {
                LIST.Add(item);
            }
        }

        [Benchmark]
        public void AddRange()
        {
            Span<byte> SPAN = stackalloc byte[12];
            List<byte> LIST = new();

            LIST.AddRange(SPAN.ToArray());
        }
    }

    public struct MyStruct
    {
        public MyStruct()
        {
            Value = 100;
        }

        public int Value;
    }

    public class MyClass
    {
        public MyClass()
        {
            Value = 100;
        }

        public int Value;
    }
}