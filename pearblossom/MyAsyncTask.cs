using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pearblossom
{
    abstract class MyAsyncTask
    {
        public async Task<string> Run()
        {
            return await RunTask(MyTask);
        }

        protected async Task<string> RunTask(Func<string> task)
        {
            string result = await Task.Run(task);
            return result;
        }
        protected abstract string MyTask();
    }
}
