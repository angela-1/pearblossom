using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pearblossom.pagenumber
{
    class PagenumberDocument : MyAsyncTask
    {
        private readonly string srcFile;
        private readonly PageNumberStyle pageNumberStyle = PageNumberStyle.Normal;
        private readonly PageNumberPos pageNumberPos = PageNumberPos.Center;

        public PagenumberDocument(string srcFile, PageNumberStyle pageNumberStyle, PageNumberPos pageNumberPos)
        {
            this.srcFile = srcFile;
            this.pageNumberStyle = pageNumberStyle;
            this.pageNumberPos = pageNumberPos;
        }

        protected override Task<string> MyTask()
        {
            var task = Task.Run(() =>
            {
                string target = null;
                PageNumber pageNumber = new PageNumber(srcFile, pageNumberStyle, pageNumberPos);
                target = pageNumber.AddPageNumber();
                return target;
            });
            return task;
        }
    }
}
