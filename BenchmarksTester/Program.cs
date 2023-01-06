using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Runtime;

namespace BenchmarksTester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int test = int.MaxValue;

            BitConverter.GetBytes(test).ToList().ForEach(x => Console.Write(x + ","));
            //Console.WriteLine();

            await Task.Delay(-1);

            //BenchmarkRunner.Run<BenchTasks>();
        }
    }

    public class BenchTasks
    {
        [Benchmark]
        public void StackTest()
        {
            //Span<MyStruct> span = stackalloc MyStruct[] { new MyStruct() };
            var item = new MyStruct();

            var value = item.Value;
        }

        [Benchmark]
        public void HeapTest()
        {
            var item = new MyClass();

            var value = item.Value;
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