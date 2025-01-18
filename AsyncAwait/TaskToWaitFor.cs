using BenchmarkDotNet.Attributes;

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
    public async Task<bool> RunItFireAndForget()
    {
        var hasWaited = false;
        _ = Task.Delay(TimeSpan.FromSeconds(5));
        return hasWaited;
    }

    [Benchmark]
    public Task<Task> RunItFromResult()
    {
        var res = Task.FromResult(Task.Delay(TimeSpan.FromSeconds(5)));
        return res;
    }

    [Benchmark]
    public async Task<bool> RunItAwaitTaskRunFromResult()
    {
        var hasWaited = false;
        await Task.Run(() => Task.FromResult(Task.Delay(TimeSpan.FromSeconds(5))));
        return hasWaited;
    }
    [Benchmark]
    public async Task<bool> RunItTaskFireAndForget()
    {
        var hasWaited = false;
        _ = Task.Run(() => Task.FromResult(Task.Delay(TimeSpan.FromSeconds(5))));
        return hasWaited;
    }

    [Benchmark]
    public async Task<bool> RunItAwaitTaskRun()
    {
        var hasWaited = false;
        await Task.Run(() => Task.Delay(TimeSpan.FromSeconds(5)));
        return hasWaited;
    }

    [Benchmark]
    public async Task<bool> RunItAwaitTaskRunInnerAwait()
    {
        var hasWaited = false;
        await Task.Run(async () => await Task.Delay(TimeSpan.FromSeconds(5)));
        return hasWaited;
    }

    [Benchmark]
    public async Task<bool> RunItTaskRunAwaitInnerAwait()
    {
        var hasWaited = false;
        await Task.Run(async () => await Task.Delay(TimeSpan.FromSeconds(5)));
        return hasWaited;
    }
}