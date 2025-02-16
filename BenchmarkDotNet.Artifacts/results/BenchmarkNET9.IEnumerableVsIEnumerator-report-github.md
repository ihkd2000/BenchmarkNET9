```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.103
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method               | Mean     | Error    | StdDev   |
|--------------------- |---------:|---------:|---------:|
| BenchmarkIEnumerable | 40.88 ns | 0.858 ns | 1.085 ns |
| BenchmarkIEnumerator | 18.87 ns | 0.413 ns | 0.755 ns |
