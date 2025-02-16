using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace BenchmarkNET9
{
    //   public class Program
    //   {
    //       static void Main(string[] args)
    //       {
    //           //BenchmarkRunner.Run<BenchMarkClass>();

    //           BenchmarkRunner.Run<IEnumerableVsEnumeratorBenchmark>();
    //       }
    //}
    [MemoryDiagnoser] // Important for analyzing memory allocation
    public class IterationBenchmark
    {
        private List<ComplexObject> _objects;

        [Params(100, 1000, 10000)] // Test with different collection sizes
        public int CollectionSize { get; set; }

        [GlobalSetup] // Initialize the collection before each benchmark run
        public void Setup()
        {
            _objects = new List<ComplexObject>(CollectionSize);
            for (int i = 0; i < CollectionSize; i++)
            {
                var complexObject = new ComplexObject(i, $"Object {i}");
                for (int j = 0; j < 5; j++) // Add some subobjects
                {
                    complexObject.SubObjects.Add(new SubObject(j * 10));
                }
                complexObject.CalculatedValue = complexObject.CalculateValue();// Calculate value to simulate real world scenario.
                _objects.Add(complexObject);
            }
        }

        [Benchmark(Baseline = true)]
        public decimal IEnumerableForeach()
        {
            decimal sum = 0;
            foreach (var obj in _objects)
            {
                sum += obj.CalculatedValue; // Access a property to simulate real-world usage
            }

            return sum;
        }

        [Benchmark]
        public decimal IEnumeratorManual()
        {
            decimal sum = 0;
            using var enumerator = _objects.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var obj = enumerator.Current;
                sum += obj.CalculatedValue; // Access a property
            }

            return sum;
        }


        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<IterationBenchmark>();
        }
    }
    public class SubObject
    {
        public int Value { get; set; }

        public SubObject() { } //parameterless constructor for BenchmarkDotNet
        public SubObject(int value)
        {
            Value = value;
        }
    }

    public class ComplexObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubObject> SubObjects { get; set; } = new();
        public decimal CalculatedValue { get; set; }

        public ComplexObject() { } //parameterless constructor for BenchmarkDotNet

        public ComplexObject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public decimal CalculateValue()
        {
            // Simulate some computation (replace with your actual logic)
            decimal sum = 0;
            foreach (var sub in SubObjects)
            {
                sum += sub.Value;
            }
            return sum * Id;
        }
    }
 

   


    public class IEnumerableVsEnumeratorBenchmark
    {
        private List<decimal> _productPrices;

        public IEnumerableVsEnumeratorBenchmark()
        {
            _productPrices = Enumerable.Range(0, 10000).Select(x => (decimal)x).ToList();
        }



        [Benchmark]
        public decimal TestIEnumerableIteration()
        {
            var sum = 0m;
            IEnumerable<decimal> priceCollection = _productPrices;
            foreach (decimal price in priceCollection)
                sum += price;
            return sum;
        }


        [Benchmark]
        public decimal TestIEnumeratorIteration()
        {
            var sum = 0m;
            IEnumerator<decimal> priceEnumerator = _productPrices.GetEnumerator();
            while (priceEnumerator.MoveNext())
                sum += priceEnumerator.Current;
            return sum;
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
