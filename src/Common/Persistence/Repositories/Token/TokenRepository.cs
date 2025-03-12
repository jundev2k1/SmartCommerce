// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class TokenRepository : RepositoryBase, ITokenRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public TokenRepository(ApplicationDBContext dbContext, IFileLogger logger)
			: base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="tokenId">Token id</param>
		/// <returns>Token model</returns>
		public async Task<TokenModel?> Get(string branchId, string tokenId)
		{
			var token = await _dbContext.Tokens
				.FirstOrDefaultAsync(item =>
					(item.BranchId == branchId)
					&& (item.TokenId == tokenId));
			return token?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Token model</param>
		/// <returns>Status insert</returns>
		public async Task<bool> Insert(TokenModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var token = await _dbContext.Tokens
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.TokenId == model.TokenId));
				if (token != null) throw new NotExistInDBException();

				var insertModel = model.MapToEntity();
				await _dbContext.AddAsync(insertModel);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Token model</param>
		/// <returns>Status update</returns>
		public async Task<bool> Update(TokenModel model)
		{
			var result = await BeginTransaction(async () =>
			{
				var token = await _dbContext.Tokens
					.FirstOrDefaultAsync(item =>
						(item.BranchId == model.BranchId)
						&& (item.TokenId == model.TokenId));
				if (token == null) throw new Exception();

				var updateModel = token.MapToEntity(model);
				_dbContext.Update(updateModel);
				await _dbContext.SaveChangesAsync();
			});

			return result;
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="tokenId">Token id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public async Task<bool> Update(string branchId, string tokenId, Action<Token> UpdateAction)
		{
			var result = await BeginTransaction(async () =>
			{
				var token = await _dbContext.Tokens
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.TokenId == tokenId));
				if (token == null) throw new NotExistInDBException();

				UpdateAction(token);
				await _dbContext.SaveChangesAsync();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="tokenId">Token id</param>
		/// <returns>Delete status</returns>
		public async Task<bool> Delete(string branchId, string tokenId)
		{
			var result = await BeginTransaction(async () =>
			{
				var token = await _dbContext.Tokens
					.FirstOrDefaultAsync(item =>
						(item.BranchId == branchId)
						&& (item.TokenId == tokenId));
				if (token == null) throw new NotExistInDBException();

				_dbContext.Remove(token);
				await _dbContext.SaveChangesAsync();
			});

			return result;
		}
	}
}
