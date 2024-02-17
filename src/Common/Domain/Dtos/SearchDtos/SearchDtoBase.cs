// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Extensions;

namespace ErpManager.Domain.Dtos.SearchDtos
{
    public class SearchDtoBase<TModel>
    {
        public PropertyExtensions<TModel> Properties { get; } = new PropertyExtensions<TModel>();
    }
}
