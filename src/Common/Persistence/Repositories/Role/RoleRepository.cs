// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public sealed class RoleRepository : RepositoryBase, IRoleRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dbContext">Context</param>
		public RoleRepository(ApplicationDBContext dbContext, IFileLogger logger) : base(dbContext, logger)
		{
		}

		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="expression">Expression</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		public SearchResultModel<RoleModel> GetByCriteria(Expression<Func<Role, bool>> expression, int pageIndex, int pageSize)
		{
			var query = _dbContext.Roles
				.AsQueryable()
				.Where(expression)
				.OrderBy(role => role.Priority);

			var queryCount = query.Count();
			var isSurplus = (queryCount % pageSize) > 0;
			var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

			var pageSkip = (pageIndex - 1) * pageSize;
			var data = query
				.Skip(pageSkip)
				.Take(pageSize)
				.Select(role => role.MapToModel())
				.ToArray();
			var result = new SearchResultModel<RoleModel>
			{
				Items = data,
				TotalPage = totalPage,
				TotalRecord = queryCount
			};

			return result;
		}

		/// <summary>
		/// Get all role
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <returns>A collection of role</returns>
		public RoleModel[] GetAll(string branchId)
		{
			var result = _dbContext.Roles
				.Where(role =>
					(role.BranchId == branchId)
					&& (role.Status == RoleStatusEnum.Active))
				.Select(role => role.MapToModel())
				.ToArray();

			return result;
		}

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Role model</returns>
		public RoleModel? Get(string branchId, int roleId)
		{
			var result = _dbContext.Roles
				.FirstOrDefault(role =>
					(role.BranchId == branchId)
					&& (role.RoleId == roleId));

			return result?.MapToModel();
		}

		/// <summary>
		/// Get async
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Role model</returns>
		public async Task<RoleModel?> GetAsync(string branchId, int roleId)
		{
			var result = await _dbContext.Roles
				.FirstOrDefaultAsync(role =>
					(role.BranchId == branchId)
					&& (role.RoleId == roleId));

			return result?.MapToModel();
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Status insert</returns>
		public bool Insert(RoleModel model)
		{
			var result = BeginTransaction(() =>
			{
				var role = _dbContext.Roles.FirstOrDefault(item =>
					(item.BranchId == model.BranchId)
					&& (item.RoleId == model.RoleId));
				if (role != null) throw new ExistInDBException();

				var insertModel = model.MapToEntity();
				_dbContext.Add(insertModel);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Status update</returns>
		public bool Update(RoleModel model)
		{
			var result = BeginTransaction(() =>
			{
				var role = _dbContext.Roles.FirstOrDefault(item =>
					(item.BranchId == model.BranchId)
					&& (item.RoleId == model.RoleId));
				if (role == null) throw new NotExistInDBException();

				var updateModel = model.MapToEntity();
				_dbContext.Update(updateModel);
				_dbContext.SaveChanges();
			});

			return result;
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <param name="UpdateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, int roleId, Action<Role> UpdateAction)
		{
			var result = BeginTransaction(() =>
			{
				var role = _dbContext.Roles.FirstOrDefault(item =>
					(item.BranchId == branchId)
					&& (item.RoleId == roleId));
				if (role == null) throw new NotExistInDBException();

				UpdateAction(role);
				_dbContext.SaveChanges();
			});
			return result;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="roleId">Role id</param>
		/// <returns>Delete status</returns>
		public bool Delete(string branchId, int roleId)
		{
			var result = BeginTransaction(() =>
			{
				var role = _dbContext.Roles.FirstOrDefault(item =>
					(item.BranchId == branchId)
					&& (item.RoleId == roleId));
				if (role == null) throw new NotExistInDBException();

				_dbContext.Remove(role);
				_dbContext.SaveChanges();
			});

			return result;
		}
	}
}
