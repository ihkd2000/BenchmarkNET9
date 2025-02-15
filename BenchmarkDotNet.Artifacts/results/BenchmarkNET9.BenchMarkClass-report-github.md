```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.103
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method            | Mean      | Error     | StdDev    |
|------------------ |----------:|----------:|----------:|
| Test_RecordClass  | 63.303 μs | 1.1116 μs | 1.4454 μs |
| Test_RecordStruct |  3.063 μs | 0.0492 μs | 0.0483 μs |
