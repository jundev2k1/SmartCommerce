﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.Common.Models
{
	internal class RateLimitInfo
	{
		public int RequestCount { get; set; }
		public DateTime LastAccessTime { get; set; }
	}
}
