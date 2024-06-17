// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Dtos.SearchDtos
{
    public class RoleSearchDto : SearchDtoBase<RoleSearchDto>
    {
        public string Keywords { get; set; } = string.Empty;

        public string BranchId { get; set; } = string.Empty;
    }
}
