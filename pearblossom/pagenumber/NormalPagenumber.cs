namespace pearblossom.pagenumber
{
    class NormalPagenumber : IPagenumberStyle
    {
        public string GetName()
        {
            return "普通";
        }

        public string GetPagenumberString(int page, int totalPage)
        {
            return page.ToString();
        }
    }
}
