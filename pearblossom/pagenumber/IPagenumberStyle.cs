namespace pearblossom.pagenumber
{

    interface IPagenumberStyle
    {
        public string GetPagenumberString(int page, int totalPage);

        public string GetName();
    }
}
