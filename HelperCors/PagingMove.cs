namespace CompanyApi.HelperCors
{
    public class PagingMove
    {

        private int rowCount = 5;
        private int rowCountMax = 6;

        public int RowCount { get => rowCount; set => rowCount = Math.Min(rowCountMax, value); }
        public int PageNumber { get; set; } = 1;
    }
}
