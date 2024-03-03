// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Extensions;
using System.Runtime.CompilerServices;

namespace ErpManager.Domain.Models
{
    public class ModelBase<TModel>
    {
        public PropertyExtensions<TModel> Properties { get; } = new PropertyExtensions<TModel>();
    }
}
