using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AsyncAwait;

public class TaskToWaitFor
{
    [Benchmark]
    public async Task<bool> RunItAwait()
    {
        var hasWaited = false;
        await Task.Delay(TimeSpan.FromSeconds(5));
        return hasWaited;
    }

    [Benchmark]
    public Task<Task> RunItFromResult()
    {
        var hasWaited = false;
        var res = Task.FromResult(Task.Delay(TimeSpan.FromSeconds(5)));
        return res;
    }
}