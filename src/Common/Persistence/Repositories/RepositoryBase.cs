// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Infrastructure.Extensions.ExceptionExtension;
using System.Data.SqlClient;

namespace SmartCommerce.Persistence.Repositories
{
	public class RepositoryBase
	{
		protected ApplicationDBContext _dbContext;
		protected IFileLogger _logger;
		public RepositoryBase(ApplicationDBContext dbContext, IFileLogger logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

		/// <summary>
		/// Begin transaction
		/// </summary>
		/// <returns>Status callback</returns>
		public async Task<bool> BeginTransaction(Func<Task> Invoke)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				await Invoke();

				await transaction.CommitAsync();
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


		/// <summary>
		/// Begin transaction async
		/// </summary>
		/// <returns>Status callback async</returns>
		public async Task<bool> BeginTransactionAsync(Action Invoke)
		{
			var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				Invoke();

				await transaction.CommitAsync();
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

			await transaction.RollbackAsync();
			return false;
		}
	}
}
