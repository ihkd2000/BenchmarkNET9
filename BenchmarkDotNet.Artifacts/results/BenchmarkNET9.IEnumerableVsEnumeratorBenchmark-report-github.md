```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.103
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method                   | Mean     | Error    | StdDev   | Median   |
|------------------------- |---------:|---------:|---------:|---------:|
| TestIEnumerableIteration | 34.38 ns | 0.704 ns | 1.741 ns | 34.53 ns |
| TestIEnumeratorIteration | 17.00 ns | 0.384 ns | 0.927 ns | 16.69 ns |
