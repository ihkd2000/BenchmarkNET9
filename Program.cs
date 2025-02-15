using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkNET9
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchMarkClass>();
        }
 }

    [MemoryDiagnoser]
    public class BenchMarkClass
    {
        private const int Iterations = 10_000;

        [Benchmark]
        public void Test_RecordClass()
        {
            var user = new UserClass("Ayman", 30);
            for (int i = 0; i < Iterations; i++)
            {
                var newUser = user with { Age = user.Age + 1 };
            }
        }

        [Benchmark]
        public void Test_RecordStruct()
        {
            var user = new UserStruct("Ayman", 30);
            for (int i = 0; i < Iterations; i++)
            {
                var newUser = user with { Age = user.Age + 1 };
            }
        }
    }

    public record UserClass(string Name, int Age);
    public record struct UserStruct(string Name, int Age);
}
