// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Enum;

namespace ErpManager.Domain.Models;

public class ProductModel
{
    public string BranchID { get; set; } = string.Empty;

    public string ProductID { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public string Address1 { get; set; } = string.Empty;

    public string Address2 { get; set; } = string.Empty;

    public string Address3 { get; set; } = string.Empty;

    public string Address4 { get; set; } = string.Empty;

    public decimal Price1 { get; set; }

    public decimal Price2 { get; set; }

    public decimal Price3 { get; set; }

    public DisplayPriceEnum DisplayPrice { get; set;}

    public ProductStatusEnum Status { get; set; }

    public decimal Size1 { get; set; }

    public decimal Size2 { get; set; }

    public decimal Size3 { get; set; }

    public string TakeOverId { get; set; } = string.Empty;

    public DateTime? DateCreated { get; set; }

    public DateTime? DateChanged { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public string LastChanged { get; set; } = string.Empty;
}