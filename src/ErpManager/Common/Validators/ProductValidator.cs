// Copyright (c) 2024 - Jun Dev. All rights reserved

using FluentValidation;

namespace ErpManager.ERP.Common.Validators
{
    public sealed class ProductValidator : ValidatorBase<ProductModel>
    {
        public ProductValidator(ILocalizer localizer)
        {
            RuleFor(product => product.BranchId)
                .NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .MaximumLength(20).WithMessage("Branch ID cannot more than 20 characters");

            RuleFor(product => product.ProductId)
                .NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .MaximumLength(20).WithMessage("Product ID cannot more than 20 characters");

            RuleFor(product => product.Name)
                .NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .NotEmpty().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .MaximumLength(60).WithMessage("Product name cannot more than 20 characters");

            RuleFor(product => product.Images)
                .Must(MustBeValidImages).WithMessage("Product image are in wrong format")
                .MaximumLength(4000).WithMessage("Product images cannot more than 20 characters");

            RuleFor(product => product.Address1)
                .NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .MaximumLength(60).WithMessage("Province cannot more than 60 characters");

            RuleFor(product => product.Address2)
                .NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .MaximumLength(60).WithMessage("District cannot more than 60 characters");

            RuleFor(product => product.Address3)
                .NotNull().WithMessage(localizer.Validates["ErrorMsg_IsRequired"])
                .MaximumLength(60).WithMessage("Wards cannot more than 60 characters");

            RuleFor(product => product.Address4)
                .NotNull().WithMessage("Street/home number cannot null")
                .MaximumLength(60).WithMessage("Street/home number cannot more than 60 characters");

            RuleFor(product => product.Price1)
                .NotNull().WithMessage("Price cannot null")
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");

            RuleFor(product => product.Price2)
                .NotNull().WithMessage("Price cannot null")
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");

            RuleFor(product => product.Price3)
                .NotNull().WithMessage("Price cannot null")
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");

            RuleFor(product => product.DisplayPrice)
                .NotNull().WithMessage("Display price cannot null")
                .IsInEnum().WithMessage("Display price is invalid value");

            RuleFor(product => product.Status)
                .NotNull().WithMessage("Status cannot null")
                .IsInEnum().WithMessage("Status is invalid value");

            RuleFor(product => product.DelFlg)
                .NotNull().WithMessage("Delete flag cannot null");

            RuleFor(product => product.Size1)
                .NotNull().WithMessage("Size cannot null")
                .GreaterThanOrEqualTo(0).WithMessage("Size cannot be negative");

            RuleFor(product => product.Size2)
                .NotNull().WithMessage("Size cannot null")
                .GreaterThanOrEqualTo(0).WithMessage("Size cannot be negative");

            RuleFor(product => product.Size3)
                .NotNull().WithMessage("Size cannot null")
                .GreaterThanOrEqualTo(0).WithMessage("Size cannot be negative");

            RuleFor(product => product.TakeOverId)
                .MaximumLength(30).WithMessage("Take Over ID cannot more than 30 characters");
        }
    }
}
