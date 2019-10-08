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
            return await MyTask();
        }

        protected abstract Task<string> MyTask();
    }
}
