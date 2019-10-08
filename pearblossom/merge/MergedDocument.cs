using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pearblossom.merge
{
    class MergedDocument : MyAsyncTask
    {
        private readonly bool withBookmark = false;
        private readonly string[] filePaths;

        public MergedDocument(bool withBookmark, string[] filePaths)
        {
            this.withBookmark = withBookmark;
            this.filePaths = filePaths;
        }

        protected override Task<string> MyTask()
        {

            var task = Task.Run(() =>
            {
                string target = null;
                if (Directory.Exists(filePaths[0])) // is folder
                {
                    target = MergeDocumentUtil.Run(filePaths[0], withBookmark);
                }
                else // is files 
                {
                    target = MergeDocumentUtil.Run(filePaths, withBookmark);
                }

                return target;
            });

            return task;
        }
    }
}
