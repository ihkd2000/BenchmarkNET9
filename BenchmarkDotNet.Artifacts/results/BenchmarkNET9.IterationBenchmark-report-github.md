```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.103
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method             | CollectionSize | Mean        | Error       | StdDev       | Median      | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------- |--------------- |------------:|------------:|-------------:|------------:|------:|--------:|----------:|------------:|
| **IEnumerableForeach** | **100**            |    **672.1 ns** |    **23.75 ns** |     **66.98 ns** |    **671.6 ns** |  **1.01** |    **0.14** |         **-** |          **NA** |
| IEnumeratorManual  | 100            |    692.2 ns |    44.74 ns |    129.80 ns |    668.9 ns |  1.04 |    0.22 |         - |          NA |
|                    |                |             |             |              |             |       |         |           |             |
| **IEnumerableForeach** | **1000**           |  **7,820.5 ns** |   **390.10 ns** |  **1,150.23 ns** |  **7,268.4 ns** |  **1.02** |    **0.20** |         **-** |          **NA** |
| IEnumeratorManual  | 1000           | 10,163.6 ns | 1,117.59 ns |  3,260.07 ns |  8,980.4 ns |  1.32 |    0.46 |         - |          NA |
|                    |                |             |             |              |             |       |         |           |             |
| **IEnumerableForeach** | **10000**          | **90,960.4 ns** | **3,702.37 ns** | **10,442.61 ns** | **90,024.7 ns** |  **1.01** |    **0.16** |         **-** |          **NA** |
| IEnumeratorManual  | 10000          | 96,085.2 ns | 4,829.94 ns | 13,303.05 ns | 93,566.2 ns |  1.07 |    0.19 |         - |          NA |
