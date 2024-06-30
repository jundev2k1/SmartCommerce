// Copyright (c) 2024 - Jun Dev. All rights reserved

using System.Data.SqlClient;

namespace ErpManager.Persistence.Repositories
{
	public class RepositoryBase
	{
		protected DBContext _dbContext;
		protected IFileLogger _logger;
		public RepositoryBase(DBContext dbContext, IFileLogger logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		/// <summary>
		/// Begin transaction
		/// </summary>
		/// <returns>Status callback</returns>
		public bool BeginTransaction(Action Invoke)
		{
			var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				Invoke();

				transaction.Commit();
				return true;
			}
			catch (NotExistInDBException ex)
			{
				_logger.LogWarning(ex.Message);
			}
			catch (ExistInDBException ex)
			{
				_logger.LogWarning(ex.Message);
			}
			catch (SqlException ex)
			{
				var message = string.Format(
					"{0}{1}{0}",
					Environment.NewLine,
					ex.InnerException.Message);
				_logger.LogError(message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.InnerException.Message);
			}
			transaction.Rollback();
			return false;
		}
	}
}
