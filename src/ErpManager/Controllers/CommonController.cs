using ErpManager.ERP.Common.Extensions;
using Newtonsoft.Json;

namespace ErpManager.ERP.Controllers
{
    public class CommonController : BaseController
    {
        private readonly AddressProvider _addressProvider;

        public CommonController(AddressProvider addressProvider)
        {
            _addressProvider = addressProvider;
        }

        [HttpGet]
        [Route("/common/get-provinces")]
        public IActionResult GetProvinces(string searchKey = "")
        {
            var provinces = _addressProvider.Provinces;

            if (string.IsNullOrEmpty(searchKey.Trim()) == false)
            {
                provinces = provinces
                    .Where(model =>
                        model.ProvinceId.ToLower().StartsWith(searchKey)
                        || model.EnglishName.ToLower().Contains(searchKey)
                        || model.VietnameseName.ToLower().Contains(searchKey)
                        || model.VietnameseName.ToLower().RemoveTextSign().Contains(searchKey)
                        || model.PlateCode.Contains(searchKey))
                    .Take(8)
                    .ToList();
            }

            return Json(provinces);
        }

        [HttpGet]
        [Route("/common/get-districts")]
        public IActionResult GetDistricts(string searchKey = "", string provinceId = "")
        {
            // Get list by province id
            var districtGroups = _addressProvider.Districts;
            var modelList = (string.IsNullOrEmpty(provinceId) == false)
                ? districtGroups.FirstOrDefault(group => group.ProvinceId == provinceId)?.Items
                : districtGroups.FirstOrDefault()?.Items;
            if (modelList == null) return Json(Array.Empty<AddressDistrictViewModel>());

            // Check search key 
            if ((string.IsNullOrEmpty(searchKey.Trim()))) return Json(modelList);

            // Search by search key
            modelList = modelList
                .Where(model =>
                    model.DistrictId.ToLower().StartsWith(searchKey)
                    || model.EnglishName.ToLower().Contains(searchKey)
                    || model.VietnameseName.ToLower().Contains(searchKey)
                    || model.VietnameseName.ToLower().RemoveTextSign().Contains(searchKey))
                .Take(8)
                .ToArray();

            return Json(modelList);
        }

        [HttpGet]
        [Route("/common/get-communes")]
        public IActionResult GetCommunes(string searchKey = "", string districtId = "")
        {
            // Get list by district id
            var modelGroupList = _addressProvider.Communes;
            var modelList = (string.IsNullOrEmpty(districtId) == false)
                ? modelGroupList.SelectMany(groups => groups.Items).FirstOrDefault(group => group.DistrictId == districtId)?.Items
                : modelGroupList.SelectMany(groups => groups.Items).FirstOrDefault()?.Items;
            if (modelList == null) return Json(Array.Empty<AddressCommuneViewModel>());

            // Check search key 
            if ((string.IsNullOrEmpty(searchKey.Trim())) || (modelList == null)) return Json(modelList);

            // Search by search key
            modelList = modelList
                .Where(model =>
                    model.CommuneId.ToLower().StartsWith(searchKey)
                    || model.EnglishName.ToLower().Contains(searchKey)
                    || model.VietnameseName.ToLower().Contains(searchKey)
                    || model.VietnameseName.ToLower().RemoveTextSign().Contains(searchKey))
                .Take(8)
                .ToArray();

            return Json(modelList);
        }
    }
}
