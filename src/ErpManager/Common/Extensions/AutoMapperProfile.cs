// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, LoginViewModel>();
        }
    }
}
