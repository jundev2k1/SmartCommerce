// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Dtos.SearchDtos
{
    public class UserSearchDto : SearchDtoBase<UserSearchDto>
    {
        public string BranchId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;

        public string Address2 { get; set; } = string.Empty;

        public string Address3 { get; set; } = string.Empty;

        public string Address4 { get; set; } = string.Empty;

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public UserStatusEnum Status { get; set; }

        public bool DelFlg { get; set; } = false;

        public SexEnum? Sex { get; set; }

        public DateTime? BirthdayFrom { get; set; }

        public DateTime? BirthdayTo { get; set; }

        public DateTime? DateCreatedFrom { get; set; }

        public DateTime? DateCreatedTo { get; set; }

        public DateTime? DateChangedFrom { get; set; }

        public DateTime? DateChangedTo { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime? LastLogin { get; set; }

        public int? RoleId { get; set; }
    }
}
