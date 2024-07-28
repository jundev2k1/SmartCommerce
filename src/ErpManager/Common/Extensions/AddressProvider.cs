// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.Common.Extensions
{
	public sealed class AddressProvider
	{
		private static AddressProvider? _instance;
		private static readonly object lockObject = new object();

		private readonly List<AddressProvinceViewModel> _provinces;
		private readonly List<AddressDistrictGroupViewModel> _districts;
		private readonly List<AddressCommuneGroupListViewModel> _communes;
		private AddressProvider()
		{
			_provinces = GetProvinces();
			_districts = GetDistricts();
			_communes = GetCommunes();
		}

		/// <summary>Instance property</summary>
		public static AddressProvider Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (lockObject)
					{
						if (_instance == null) _instance = new AddressProvider();
					}
				}
				return _instance;
			}
		}

		/// <summary>
		/// Get provinces
		/// </summary>
		/// <returns>A collection of province</returns>
		private List<AddressProvinceViewModel> GetProvinces()
		{
			var provinceRawData = System.IO.File.ReadAllText(
				$"{Environment.CurrentDirectory}{Constants.ERP_FILE_PATH_DATA_ADDRESS_VN_PROVINCES}");
			var result = JsonConvert.DeserializeObject<List<AddressProvinceViewModel>>(provinceRawData);
			return result ?? new List<AddressProvinceViewModel>();
		}

		/// <summary>
		/// Get districts
		/// </summary>
		/// <returns>A collection of group district</returns>
		private List<AddressDistrictGroupViewModel> GetDistricts()
		{
			var provinceRawData = System.IO.File.ReadAllText(
				$"{Environment.CurrentDirectory}{Constants.ERP_FILE_PATH_DATA_ADDRESS_VN_DISTRICTS}");
			var result = JsonConvert.DeserializeObject<List<AddressDistrictGroupViewModel>>(provinceRawData);
			return result ?? new List<AddressDistrictGroupViewModel>();
		}

		/// <summary>
		/// Get communes
		/// </summary>
		/// <returns>A collection of group list commune</returns>
		private List<AddressCommuneGroupListViewModel> GetCommunes()
		{
			var provinceRawData = System.IO.File.ReadAllText(
				$"{Environment.CurrentDirectory}{Constants.ERP_FILE_PATH_DATA_ADDRESS_VN_COMMUNES}");
			var result = JsonConvert.DeserializeObject<List<AddressCommuneGroupListViewModel>>(provinceRawData);
			return result ?? new List<AddressCommuneGroupListViewModel>();
		}

		public List<AddressProvinceViewModel> Provinces => _provinces;
		public List<AddressDistrictGroupViewModel> Districts => _districts;
		public List<AddressCommuneGroupListViewModel> Communes => _communes;
	}
}
