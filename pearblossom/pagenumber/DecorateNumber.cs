using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pearblossom.pagenumber
{
    class DecorateNumber : IPagenumberStyle
    {
        public string GetName()
        {
            return "装饰";
        }

        public string GetPagenumberString(int page, int totalPage)
        {
            return "— " + page + " —";
        }
    }
}
