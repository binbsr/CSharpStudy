using System;
using System.Threading.Tasks;

namespace _7_0
{
    class H_SCC_Generalized_Async_Return_Types
    {
        //Returning a Task object from async methods can introduce performance bottlenecks in certain paths. 
        //Task is a reference type, so using it means allocating an object. In cases where a method declared with the async modifier returns a cached result, 
        //or completes synchronously, the extra allocations can become a significant time cost in performance critical sections of code. 
        //It can become very costly if those allocations occur in tight loops.

        //The new language feature means that async methods may return other types in addition to Task, Task<T> and void. 
        //The returned type must still satisfy the async pattern, meaning a GetAwaiter method must be accessible.

        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }


        //Simple optimizations: Replace Task with valueTask
        //Optionally cache results for futher optimizations

        public ValueTask<int> CachedFunc()
        {
            return cache ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
        }

        private bool cache = false;
        private int cacheResult;
        private async Task<int> LoadCache()
        {
            //Simulate async work
            await Task.Delay(100);
            cacheResult = 100;
            cache = true;
            return cacheResult;
        }
    }
}
