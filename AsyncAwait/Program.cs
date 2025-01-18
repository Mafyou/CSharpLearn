using AsyncAwait;
using BenchmarkDotNet.Running;

var task = new TaskToWaitFor();
BenchmarkRunner.Run<TaskToWaitFor>();