// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Common.Validators
{
	public sealed class RoleValidator : ValidatorBase<RoleModel>
	{
		public RoleValidator(ILocalizer localizer, IServiceFacade serviceFacade) : base(serviceFacade)
		{
			AddCommonRule();

			RuleSet("Create", () =>
			{
				RuleFor(role => role.RoleId)
					.NotNull().WithMessage("Is required")
					.Must((role, roleId) => IsExistRole(role.BranchId, roleId) == false)
						.WithMessage("Role has been exist in DB");
			});

			RuleSet("Update", () =>
			{
				RuleFor(role => role.RoleId)
					.NotNull().WithMessage("Is required")
					.Must((role, roleId) => IsExistRole(role.BranchId, roleId))
						.WithMessage("Role has been not exist in DB");
			});
		}

		/// <summary>
		/// Add common rule for check input role
		/// </summary>
		private void AddCommonRule()
		{
			RuleFor(role => role.BranchId)
				.NotNull().WithMessage("Is required")
				.NotEmpty().WithMessage("Is required");

			RuleFor(role => role.Name)
				.NotNull().WithMessage("Is required")
				.NotEmpty().WithMessage("Is required")
				.MaximumLength(60).WithMessage("Greater than 60");

			RuleFor(role => role.Description)
				.NotNull().WithMessage("Is required")
				.MaximumLength(256).WithMessage("Greater than 256");

			RuleFor(role => role.Priority)
				.NotNull().WithMessage("Is required");

			RuleFor(role => role.Status)
				.NotNull().WithMessage("Is required")
				.IsInEnum().WithMessage("Not exist value");
		}

		/// <summary>
		/// Check exist role in DB
		/// </summary>
		/// <param name="branchId">Branch ID</param>
		/// <param name="roleId">Role ID</param>
		/// <returns></returns>
		private bool IsExistRole(string branchId, int roleId)
		{
			var role = _serviceFacade.Roles.Get(branchId, roleId);
			return role != null;
		}
	}
}
