// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.BackgroundServices
{
	internal class DeleteTempUploadDirBackgroundService : BackgroundService
	{
		private readonly IFileLogger _logger;
		private readonly IHubContext<NotificationHub> _hubContext;

		public DeleteTempUploadDirBackgroundService(IFileLogger logger, IHubContext<NotificationHub> hubContent)
		{
			_logger = logger;
			_hubContext = hubContent;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_logger.LogInformation("Delete Temporary Upload Directory Background Service is starting.");

			while (!stoppingToken.IsCancellationRequested)
			{
				var resultCount = this.HandleFilePathModule.ToDictionary(module => module.name, _ => 0);
				foreach (var fileModule in this.HandleFilePathModule)
				{
					var isExistDir = Directory.Exists(fileModule.path);
					if (!isExistDir) continue;

					var dirPaths = Directory.GetDirectories(fileModule.path);
					foreach (var dirPath in dirPaths)
					{
						var info = new DirectoryInfo(dirPath);
						if (info.LastWriteTime < this.DateExecute)
						{
							Directory.Delete(dirPath, true);
							var count = resultCount[fileModule.name] + 1;
							resultCount[fileModule.name] = count;
						}
					}
				}
				var message = string.Join(
					",",
					resultCount.Select(result => $"Deleted {result.Value} folder in {result.Key}{Environment.NewLine}"));
				if (!string.IsNullOrEmpty(message))
					_logger.LogInformation(message);

				await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
			}

			_logger.LogInformation("Delete Temporary Upload Directory Background Service is stopping.");
		}

		/// <summary>File path to handle directory deletion</summary>
		private (string name, string path)[] HandleFilePathModule = new (string name, string path)[]
		{
			(name: "Product Temporary Image", path: Constants.ERP_FILE_UPLOAD_DIRPATH_TEMP_PRODUCT_IMAGES),
			(name: "User Temporary Image", path: Constants.ERP_FILE_UPLOAD_DIRPATH_TEMP_USER_AVATAR),
			(name: "Member Temporary Image", path: Constants.ERP_FILE_UPLOAD_DIRPATH_TEMP_MEMBER_AVATAR)
		};

		private DateTime DateExecute => DateTime.Now.AddDays(-1);
	}
}
