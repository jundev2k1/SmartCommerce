namespace ErpManager.Manager.ViewModels
{
	public class ResponseBaseViewModel<TResponse>
	{
		public TResponse? Response { get; set; }

		public bool IsSuccess { get; set; }

		public string Message { get; set; } = string.Empty;
	}
}
