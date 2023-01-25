namespace eBusiness.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> values, int allelementscount , int elementcount, int activepage  )
        {
            this.AddRange(values);
            ActivePage = activepage;
            ElemetCount = elementcount;
            TotalPageCount = (int)Math.Ceiling((double)allelementscount/elementcount);
        }
        public int TotalPageCount { get; set; }
        public int ActivePage { get; set; }
        public int ElemetCount { get; set; }
        public bool HasPrevious { get => ActivePage > 1; }
        public bool HasNext { get => ActivePage < TotalPageCount; }


        public static PaginatedList<T> Create(IQueryable<T> query, int elementcount, int activepage)
        {
            return new PaginatedList<T>(query.Skip((activepage - 1) * elementcount).Take(elementcount).ToList(),query.Count(),elementcount,activepage);
        }
    }
}
