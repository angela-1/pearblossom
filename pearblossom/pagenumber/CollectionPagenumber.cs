using System;

namespace pearblossom.pagenumber
{
    class CollectionPagenumber : IPagenumberStyle
    {
        public string GetName()
        {
            return "集合";
        }

        public string GetPagenumberString(int page, int totalPage)
        {
            int len = Math.Max(totalPage.ToString().Length, 2);
            string numberString = string.Format("{0:D" + len + "}", page);
            return numberString;
        }
    }
}
