namespace MyLoveFilmes.Shared.Domain.DataTable
{
    public class DataGridView<T> where T : class
	{
		public int Draw { get; set; }
		public int RecordsTotal { get; set; }
		public int RecordsFiltered { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}

