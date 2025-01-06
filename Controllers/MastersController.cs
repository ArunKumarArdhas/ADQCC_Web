using ADQCC_New.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static ADQCC_New.Models.EmergencyModel;
using System.Globalization;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using ADQCC_New.Models.Masters;
using ADQCC_New.ErrorLogs;
using ADQCC_New.Models.Emergency;

namespace ADQCC_New.Controllers
{
    [AllowAnonymous]
    [TypeFilter(typeof(SessionExpireActionFilter))]
    //[TypeFilter(typeof(ExpFilter))]
    public class MastersController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        private readonly IConfiguration configuration;
        private string conn;
        public MastersController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            client = httpClientFactory.CreateClient("API");
            this.configuration = configuration;
        }
        #region [LOCATION_MASTER]
        public async Task<IActionResult> LocationMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetLocationMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Location);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLocation(M_LocationModel model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.LOC_ID == "0")
                    {
                        URL = "Master/AddLocation";
                    }
                    else
                    {
                        URL = "Master/AddLocation";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("LocationMaster");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> Location_GetByID(string ID)
        {
            using (client)
            {
                M_LocationModel _UNIT = new M_LocationModel
                {
                    LOC_ID = ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "Master/Business_Unit_GetById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Location);
            }
        }

        public async Task<IActionResult> Location_Delete(string ID)
        {
            try
            {
                using (client)
                {
                    M_LocationModel _UNIT = new M_LocationModel
                    {
                        LOC_ID = ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "Master/Business_Unit_Delete", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.STATUS);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion
        #region [BUILDING_MASTER]
        public async Task<IActionResult> BuildingMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "Master/GetBuildingMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Building);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBuilding(BUILDING_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.BUIL_ID == "0")
                    {
                        URL = "Master/AddBuilding";
                    }
                    else
                    {
                        URL = "Master/AddBuilding";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("BuildingMaster");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> Building_GetByID(string ID)
        {
            using (client)
            {
                BUILDING_MASTER _UNIT = new BUILDING_MASTER
                {
                    BUIL_ID = ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "Master/Business_Unit_GetById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Building);
            }
        }

        public async Task<IActionResult> Building_Delete(string ID)
        {
            try
            {
                using (client)
                {
                    BUILDING_MASTER _UNIT = new BUILDING_MASTER
                    {
                        BUIL_ID = ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "Master/Business_Unit_Delete", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.STATUS);
                }
            }
            catch (Exception ex)
            {
                //return Json(ex);
                ErrorLogs.ErrorLog errorLog = new ErrorLogs.ErrorLog();
                //errorLog.ErrorLogs(ex, "Building_Delete");
                //errorLog.ErrorLogs(ex.Message + "Building_Delete ==> " + ex.InnerException, ex.Message + "Building_Delete");//ex.Message + "Building_Delete ==> " + 
                throw;
            }
        }
        #endregion
        #region [SECTOR_TYPE_MASTER]
        public async Task<IActionResult> SectorType()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "Master/GetSectorTypeDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Sect_Type);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSectorTypeMaster(SECTORTYPE_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.SEC_TYPE_ID == "0")
                    {
                        URL = "Master/AddSectorTypeDetails";
                    }
                    else
                    {
                        URL = "Master/AddSectorTypeDetails";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("SectorType");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> SectorType_GetByID(string ID)
        {
            using (client)
            {
                M_LocationModel _UNIT = new M_LocationModel
                {
                    LOC_ID = ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_GetById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_SecLab);
            }
        }

        public async Task<IActionResult> SectorType_Delete(string ID)
        {
            try
            {
                using (client)
                {
                    M_LocationModel _UNIT = new M_LocationModel
                    {
                        LOC_ID = ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_Delete", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.STATUS);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion
        #region [SECTOR_MASTER]
        public async Task<IActionResult> Sector()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "Master/GetSectorDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Sector);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSectorMaster([FromBody] SECTOR_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.SEC_ID == "0")
                    {
                        URL = "Master/AddSectorDetails";
                    }
                    else
                    {
                        URL = "Master/AddSectorDetails";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                    return Json(deserialized);
                }
                return RedirectToAction("Sector");
            }
            else
            {
                return NoContent();
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddSectorMaster(M_LocationModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (client)
        //        {
        //            string URL = "";
        //            if (model.LOC_ID == "0")
        //            {
        //                URL = "Master/AddLocation";
        //            }
        //            else
        //            {
        //                URL = "Master/AddLocation";
        //            }
        //            HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
        //            string customerJsonString = await response.Content.ReadAsStringAsync();
        //            RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
        //            TempData["msg"] = deserialized!.MESSAGE;
        //        }
        //        return RedirectToAction("AddLocationMaster");
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}

        public async Task<IActionResult> Sector_GetByID(string ID)
        {
            using (client)
            {
                SECTOR_MASTER _UNIT = new SECTOR_MASTER
                {
                    SEC_ID = ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_GetById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Sector);
            }
        }

        public async Task<IActionResult> Sector_Delete(string ID)
        {
            try
            {
                using (client)
                {
                    SECTOR_MASTER _UNIT = new SECTOR_MASTER
                    {
                        SEC_ID = ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_Delete", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.STATUS);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion
        #region [DEPARTMENT_MASTER]
        public async Task<IActionResult> DepartmentMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "Master/GetDepartmentMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Depart);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDepartmentMaster(DEPARTMENT_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.DEP_ID == "0")
                    {
                        URL = "Master/AddDepartment";
                    }
                    else
                    {
                        URL = "Master/AddDepartment";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("DepartmentMaster");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> Department_GetByID(string ID)
        {
            using (client)
            {
                DEPARTMENT_MASTER _UNIT = new DEPARTMENT_MASTER
                {
                    DEP_ID = ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "Master/GetDepartemntById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Depart);
            }
        }

        public async Task<IActionResult> Department_Delete(string ID)
        {
            try
            {
                using (client)
                {
                    M_LocationModel _UNIT = new M_LocationModel
                    {
                        LOC_ID = ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_Delete", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.STATUS);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion
        #region [SECTION_LAB_MASTER]
        public async Task<IActionResult> SectionLabMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "Master/GetSectionLabMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_SecLab);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSectionLab(M_LocationModel model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.LOC_ID == "0")
                    {
                        URL = "Master/AddSectionLab";
                    }
                    else
                    {
                        URL = "Master/AddSectionLab";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("SectionLabMaster");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> SectionLab_GetByID(string ID)
        {
            using (client)
            {
                M_LocationModel _UNIT = new M_LocationModel
                {
                    LOC_ID = ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_GetById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_SecLab);
            }
        }

        public async Task<IActionResult> SectionLab_Delete(string ID)
        {
            try
            {
                using (client)
                {
                    M_LocationModel _UNIT = new M_LocationModel
                    {
                        LOC_ID = ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_Delete", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.STATUS);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion
        #region [DESIGNATION_MASTER]
        public async Task<IActionResult> Designation()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "Master/GetDesignationMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Design);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDesignationMaster(M_LocationModel model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.LOC_ID == "0")
                    {
                        URL = "Master/AddLocation";
                    }
                    else
                    {
                        URL = "Master/AddLocation";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("AddLocationMaster");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> Designation_GetByID(string ID)
        {
            using (client)
            {
                M_LocationModel _UNIT = new M_LocationModel
                {
                    LOC_ID = ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_GetById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Design);
            }
        }

        public async Task<IActionResult> Designation_Delete(string ID)
        {
            try
            {
                using (client)
                {
                    M_LocationModel _UNIT = new M_LocationModel
                    {
                        LOC_ID = ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_Delete", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.STATUS);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion
        #region [EMERGENCY_TYPE_MASTER]
        public async Task<IActionResult> EmergencyTypeMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "Master/GetEmergTypeMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_ET);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmergencyType(M_LocationModel model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.LOC_ID == "0")
                    {
                        URL = "Master/AddLocation";
                    }
                    else
                    {
                        URL = "Master/AddLocation";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("AddLocationMaster");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> EmergencyType_GetByID(string ID)
        {
            using (client)
            {
                M_LocationModel _UNIT = new M_LocationModel
                {
                    LOC_ID = ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_GetById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Design);
            }
        }

        public async Task<IActionResult> EmergencyType_Delete(string ID)
        {
            try
            {
                using (client)
                {
                    M_LocationModel _UNIT = new M_LocationModel
                    {
                        LOC_ID = ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "BusinessUnitMaster/Business_Unit_Delete", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.STATUS);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion
        #region [MASTERS_DROPDOWN]
        public async Task<JsonResult> GetNationalityDetails()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetNationalityDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.Get_All_National);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> _GetLocationMasterSelect()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetLocationMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.Get_All_Location);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> _GetBuildingMasterSelect()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetBuildingMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.Get_All_Building);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> _GetDepartmentMasterSelect()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetDepartmentMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.Get_All_Depart);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> _GetDesignationMasterSelect()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetDesignationMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.Get_All_Design);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> _GetSectionMasterSelect()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetSectionLabMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.Get_All_SecLab);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> _GetSectorMasterSelect()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetSectorDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.Get_All_Sector);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> _GetSectorTypeMasterSelect()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("Master/GetSectorTypeDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_MASTERS_LIST deserialized = JsonConvert.DeserializeObject<GET_MASTERS_LIST>(customerJsonString)!;
                    return Json(deserialized!.Get_All_Sect_Type);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> _GetEmployeeNameList(string Desi_Id) // Category (Employee || QCC_Employee)
        {
            try
            {
                using (client)
                {
                    M_Employee_Master_Filter _UNIT = new M_Employee_Master_Filter
                    {
                        Desi_Id = Desi_Id
                    };
                    //var loginclass = _loginClass;
                    HttpResponseMessage response = client.PostAsync("Emergency/GetEmployeeByBuilding", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    M_Employee_Master_Filter deserialized = JsonConvert.DeserializeObject<M_Employee_Master_Filter>(customerJsonString)!;
                    return Json(deserialized!.Get_All_Emp);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetEmergencyTeamDrop ==> " + ex.InnerException);
                throw;
            }
        }
        #endregion
    }
}