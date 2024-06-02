// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Common.Extensions;
using ErpManager.Infrastructure.Common.Enum;
using ErpManager.Infrastructure.Upload;

namespace ErpManager.ERP.Controllers
{
    public sealed class CommonController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CommonController(IServiceFacade serviceFacade, IWebHostEnvironment webHostEnvironment)
        {
            _serviceFacade = serviceFacade;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("/common/get-provinces")]
        public IActionResult GetProvinces(string searchKey = "")
        {
            var provinces = AddressProvider.Instance.Provinces;

            if (string.IsNullOrEmpty(searchKey.Trim()) == false)
            {
                provinces = provinces
                    .Where(model =>
                        model.ProvinceId.ToLower().StartsWith(searchKey)
                        || model.EnglishName.ToLower().Contains(searchKey)
                        || model.VietnameseName.ToLower().Contains(searchKey)
                        || model.VietnameseName.ToLower().RemoveTextSign().Contains(searchKey)
                        || model.PlateCode.Contains(searchKey))
                    .Take(6)
                    .ToList();
            }

            return Json(provinces);
        }

        [HttpGet]
        [Route("/common/get-districts")]
        public IActionResult GetDistricts(string searchKey = "", string provinceId = "")
        {
            // Get list by province id
            var districtGroups = AddressProvider.Instance.Districts;
            var modelList = (string.IsNullOrEmpty(provinceId) == false)
                ? districtGroups.FirstOrDefault(group => group.ProvinceId == provinceId)?.Items
                : districtGroups.SelectMany(group => group.Items);
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
                .Take(6)
                .ToArray();

            return Json(modelList);
        }

        [HttpGet]
        [Route("/common/get-communes")]
        public IActionResult GetCommunes(string searchKey = "", string districtId = "")
        {
            // Get list by district id
            var modelGroupList = AddressProvider.Instance.Communes;
            var modelList = (string.IsNullOrEmpty(districtId) == false)
                ? modelGroupList.SelectMany(groups => groups.Items).FirstOrDefault(group => group.DistrictId == districtId)?.Items
                : modelGroupList.SelectMany(groups => groups.Items).SelectMany(group => group.Items);
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
                .Take(6)
                .ToArray();

            return Json(modelList);
        }

        [HttpGet]
        [Route("/common/get-users")]
        public IActionResult GetUsers(string searchKey = "")
        {
            var userSearch = new UserSearchDto
            {
                BranchId = this.OperatorBranchId,
                Keywords = searchKey
            };
            var result = _serviceFacade.Users.Search(userSearch, pageIndex: 1, pageSize: 6).Data;
            return Json(result);
        }

        [HttpPost]
        [Route("/common/upload-images")]
        public string UploadImages([FromForm] IFormFile[] files, string type, string sessionToken, string uploadFileName = "", bool isClearTempImages = false)
        {
            var typeUpload = GetTypeUploadByString(type);
            if (typeUpload == UploadEnum.None) throw new Exception("type none");

            var fileManager = new FileManager(files, typeUpload, uploadFileName, sessionToken);
            if (isClearTempImages)
            {
                fileManager.DeleteTempImages();
            }
            fileManager.ExecuteUploadImages();
            switch (typeUpload)
            {
                case UploadEnum.ProductImage:
                    var product = _serviceFacade.Products.GetProduct(this.OperatorBranchId, uploadFileName);
                    if (product == null) break;

                    var productImage = _serviceFacade.Products.UpdateNewestProductImages(this.OperatorBranchId, uploadFileName);
                    if (productImage != null) return productImage;
                    break;
            }

            return string.Join(",", fileManager.Result);
        }

        [HttpGet]
        [Route("/common/delete-image")]
        public IActionResult DeleteImage(string filePath)
        {
            try
            {
                var targetPath = $"wwwroot{filePath}";
                if (System.IO.File.Exists(targetPath))
                {
                    System.IO.File.Delete(targetPath);
                    return Json(true);
                }
                throw new Exception();
            }
            catch
            {
                return Json(false);
            }
        }

        [HttpGet]
        [Route("/common/get-exist-and-delete-not-use-temp-images")]
        public IActionResult GetExistAndDeleteNotUseTemporaryImages(string type, string sessionToken, string filePath = "")
        {
            if (string.IsNullOrEmpty(sessionToken)) throw new Exception("Session token cannot null");

            var result = new List<string>();
            var paths = filePath.Split(",");
            foreach (var path in paths)
            {
                var targetPath = _webHostEnvironment.WebRootPath + path;
                if (System.IO.File.Exists(targetPath))
                    result.Add(path);
            }
            var typeUpload = GetTypeUploadByString(type);
            if (typeUpload == UploadEnum.None)
                throw new Exception("type none");

            var fileManager = new FileManager(
                files: Array.Empty<IFormFile>(),
                @enum: typeUpload,
                fileName: string.Empty,
                sessionToken);
            fileManager.DeleteNotUseImages(
                expectImages: result.ToArray(),
                isTempDir: true);

            return Json(string.Join(",", result));
        }

        [HttpPost]
        [Route("/common/update-newest-image")]
        public IActionResult UpdateNewestImage(string type, string primaryKey)
        {
            var typeUpload = GetTypeUploadByString(type);
            if (typeUpload == UploadEnum.None)
                throw new Exception("type none");

            switch (typeUpload)
            {
                case UploadEnum.ProductImage:
                    var result = _serviceFacade.Products.UpdateNewestProductImages(this.OperatorBranchId, primaryKey);
                    return Content(result ?? string.Empty);

                default:
                    return Content(string.Empty);
            }
        }
    }
}
