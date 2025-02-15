Introduction
Why Benchmark record struct?
Choosing the right data structure is crucial for building efficient .NET applications. This benchmark explores the performance characteristics of .NET 9's record struct, comparing it with traditional record class and struct implementations.

Key Focus Areas:
✅ Object Creation Overhead
✅ Property Access Performance
✅ Copying Costs (with expressions)
✅ Serialization Performance (System.Text.Json)

These tests help developers understand when to use record struct for maximum efficiency.

📊 Benchmark Scenarios
Scenarios Tested:
✔ Object Creation: Measures the time to create a large number of instances.
✔ Property Access: Tests retrieval speed for struct vs. class-based records.
✔ Copying with with Expression: Evaluates struct copying overhead vs. reference updates.
✔ Serialization/Deserialization: Measures JSON serialization performance using System.Text.Json.

Why These Scenarios?
record struct is stack-allocated, reducing heap pressure—but copying may introduce overhead.
record class is heap-allocated, leading to higher GC impact.
These tests provide real-world performance insights for .NET developers.
⚙️ Methodology
Benchmark Configuration:
🛠 Framework: BenchmarkDotNet
💻 Environment:

OS: Windows 11 (10.0.26100.3194)
Processor: Intel Core i7-9750H CPU @ 2.60GHz, 6 Cores / 12 Threads
.NET Version: .NET 9.0.2
📊 Metrics Measured:
Execution Time (μs/ns)
Memory Allocations (Bytes)
Garbage Collection (GC Pressure)
🔥 Benchmark Iterations: 10,000 operations

Benchmark Results
| Method              | Mean      | Error    | StdDev   | Allocated |
|-------------------- |---------:|---------:|---------:|----------:|
| Test_RecordClass   | 111.3 μs  | 3.15 μs  | 8.89 μs  | High (Heap) |
| Test_RecordStruct  | 3.0 μs    | 0.04 μs  | 0.04 μs  | 0 (Stack)  |

🚀 Key Takeaways:
record struct is up to ~37x faster for object creation due to stack allocation.
Copying record struct is more expensive for large objects due to value-type copying overhead.
record struct performs better in serialization due to reduced memory allocations.
record class is still preferable when reference semantics, inheritance, or object tracking are required.
🔍 Conclusion
✅ Use record struct when:

You need high-performance, short-lived objects.
You want to reduce GC pressure and memory overhead.
You are working with high-throughput APIs, game engines, or real-time systems.
❌ Avoid record struct when:

Your object is large and frequently copied (copying structs can be expensive).
You need inheritance or reference equality (stick to record class).
You require Entity Framework Core tracking (EF Core doesn’t track structs).
💡 Benchmarking your specific use case is always recommended! 
