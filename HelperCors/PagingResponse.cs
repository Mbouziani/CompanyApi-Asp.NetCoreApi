

namespace CompanyApi.HelperCors
{
    public class PagingResponse<T>
    {
        public PagingResponse(IQueryable<T> Query, PagingMove ClientPaging )
        {
            Paging = new PagingDetails();

            Paging.TotalRows = Query.Count();

            Paging.TotalPages = (int)Math.Ceiling((double)Paging.TotalRows / ClientPaging.RowCount);
            Paging.CurPage = ClientPaging.PageNumber;
            Paging.HasNextPage = Paging.CurPage < Paging.TotalPages;
            Paging.HasPrevPage = Paging.CurPage > 1;

            Data = Query.Skip((ClientPaging.PageNumber - 1) *
                            ClientPaging.RowCount).Take(ClientPaging.RowCount).ToList();
             






        }
        public PagingDetails Paging { get; set; }
        public List<T> Data { get; set; }
        

    }
    
}
