// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.Data
{
	public sealed class AddressManager
	{
		private static AddressManager? _instance;
		private static readonly object lockObject = new object();

		private readonly List<AddressProvinceJsonModel> _provinces;
		private readonly List<AddressDistrictGroupJsonModel> _districts;
		private readonly List<AddressCommuneGroupListJsonModel> _communes;
		private AddressManager()
		{
			_provinces = GetProvinces();
			_districts = GetDistricts();
			_communes = GetCommunes();
		}

		/// <summary>
		/// Get provinces
		/// </summary>
		/// <returns>A collection of province</returns>
		private List<AddressProvinceJsonModel> GetProvinces()
		{
			var provinceRawData = System.IO.File.ReadAllText(
				$"{Constants.CONST_RESOURCE_PHYSICAL_PATH}/{Constants.FILE_PATH_DATA_ADDRESS_VN_PROVINCES}");
			var result = JsonConvert.DeserializeObject<List<AddressProvinceJsonModel>>(provinceRawData);
			return result ?? new List<AddressProvinceJsonModel>();
		}

		/// <summary>
		/// Get districts
		/// </summary>
		/// <returns>A collection of group district</returns>
		private List<AddressDistrictGroupJsonModel> GetDistricts()
		{
			var provinceRawData = System.IO.File.ReadAllText(
				$"{Constants.CONST_RESOURCE_PHYSICAL_PATH}/{Constants.FILE_PATH_DATA_ADDRESS_VN_DISTRICTS}");
			var result = JsonConvert.DeserializeObject<List<AddressDistrictGroupJsonModel>>(provinceRawData);
			return result ?? new List<AddressDistrictGroupJsonModel>();
		}

		/// <summary>
		/// Get communes
		/// </summary>
		/// <returns>A collection of group list commune</returns>
		private List<AddressCommuneGroupListJsonModel> GetCommunes()
		{
			var provinceRawData = System.IO.File.ReadAllText(
				$"{Constants.CONST_RESOURCE_PHYSICAL_PATH}/{Constants.FILE_PATH_DATA_ADDRESS_VN_COMMUNES}");
			var result = JsonConvert.DeserializeObject<List<AddressCommuneGroupListJsonModel>>(provinceRawData);
			return result ?? new List<AddressCommuneGroupListJsonModel>();
		}

		public List<AddressProvinceJsonModel> Provinces => _provinces;
		public List<AddressDistrictGroupJsonModel> Districts => _districts;
		public List<AddressCommuneGroupListJsonModel> Communes => _communes;

		/// <summary>Instance property</summary>
		public static AddressManager Instance
		{
			get
			{
				if (_instance != null) return _instance;

				lock (lockObject)
				{
					if (_instance == null) _instance = new AddressManager();
				}
				return _instance;
			}
		}
	}
}
