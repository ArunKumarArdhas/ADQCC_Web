using ADQCC_New.Models;using Microsoft.AspNetCore.Mvc;using Newtonsoft.Json;using static ADQCC_New.Models.EmergencyModel;using System.Globalization;using System.Net.Http.Headers;using Microsoft.AspNetCore.Authorization;using System.Text;using ADQCC_New.Models.Masters;using ADQCC_New.ErrorLogs;using static ADQCC_New.Models.RiskManagement.RiskManagementModel;namespace ADQCC_New.Controllers{    [AllowAnonymous]    [TypeFilter(typeof(SessionExpireActionFilter))]
    //[TypeFilter(typeof(ExpFilter))]
    public class RiskManagementController : Controller    {        private readonly HttpClient client = new HttpClient();        private readonly IConfiguration configuration;        private string conn;
        private object _loginClass;

        public RiskManagementController(IHttpClientFactory httpClientFactory, IConfiguration configuration)        {            client = httpClientFactory.CreateClient("API");            this.configuration = configuration;
            //conn = configuration.GetConnectionString("DefaultConnection");
        }

        #region[dropdown]
        public async Task<JsonResult> _GetHazardMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("RiskManagement/GETRMHAZARDMASREPO").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_HAZRDMASTER deserialized = JsonConvert.DeserializeObject<GET_HAZRDMASTER>(customerJsonString)!;
                    return Json(deserialized!.Get_All);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        #endregion
        #region [HAZARD_MASTER]                                                                        public async Task<IActionResult> HazardMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "RiskManagement/GETRMHAZARDMASREPO").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_HAZRDMASTER deserialized = JsonConvert.DeserializeObject<GET_HAZRDMASTER>(customerJsonString)!;
                    return View(deserialized!.Get_All);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHazard(ADD_RM_HAZARD_MASTER _RMHAZARDMASTER)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (_RMHAZARDMASTER.HAZARD_MAS_ID == "0")
                    {
                        URL = "RiskManagement/ADDRMHAZARDMASREPO";
                    }
                    else
                    {
                        URL = "RiskManagement/ADDRMHAZARDMASREPO";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(_RMHAZARDMASTER), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("HazardMaster");
            }
            else
            {
                return NoContent();
            }
        }

        public async Task<IActionResult> Hazard_GetByID(string ID)
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

        public async Task<IActionResult> Hazard_Delete(string ID)
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



        #region[RISK AND OTHER RISK]
        public IActionResult RMRISKOTHERRISK()
        {
            return View();
        }
        public async Task<ActionResult> GETRMRISKOTHERRISK()
        {
            try
            {

                HttpResponseMessage response = client.GetAsync("RiskManagement/GETHAZARDSELECTREPO").Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();

                GET_RISKSOTHERRISKS deserialized = JsonConvert.DeserializeObject<GET_RISKSOTHERRISKS>(customerJsonString)!;
                return Json(deserialized!.Get_All);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ActionResult> GETRISKDROPDOWN()
        {
            try
            {
                using (client)
                {
                    var loginclass = _loginClass;
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", parameter: Session["Token"].ToString() + ":" + loginclass.EMP_USERNAME);
                    var response = client.GetAsync(Url + "RiskManagement/GETRMRISKCATMAS").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_RM_RISK_CAT_MASTER>>(customerJsonString);
                    return Json(deserialized);
                }
            }
            catch (Exception ex)
            {
                // Common.CommonMethods common = new Common.CommonMethods();
                // common.ErrorLog(ex.Message + "EDITRMHAZARDMASTER ==> " + ex.InnerException);
                throw;
            }

        }
        public async Task<JsonResult> ADDRMRISKOTHERRISK([FromBody] ADD_RM_RISKS_OTHER_RISKS _RMRISKOTHERRISK)
        {
            try
            {
                var Url = "";
                if (_RMRISKOTHERRISK.RISKS_OTHER_RISKS_ID == "0" || _RMRISKOTHERRISK.RISKS_OTHER_RISKS_ID == null)
                {
                    Url = "RiskManagement/ADDRMRISKOTHERRISKREPO";
                }
                else
                {
                    Url = "/RiskManagement/GETBYIDRISKREPO";
                }

                HttpResponseMessage response = client.PostAsync(Url, new StringContent(JsonConvert.SerializeObject(_RMRISKOTHERRISK), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                return Json(deserialized);
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "ADDRMHAZARDMASTER ==> " + ex.InnerException);
                throw;
            }
        }




        #endregion



        #region[dropdown]
        public async Task<JsonResult> _GetPersonMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("RiskManagement/GETRMPERSONSGROUPSREPO").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_PERSONSGROUPS deserialized = JsonConvert.DeserializeObject<GET_PERSONSGROUPS>(customerJsonString)!;
                    return Json(deserialized!.Get_All);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }


        #endregion
        #region [PERSON_GROUPS]        public async Task<IActionResult> PersonMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "RiskManagement/GETRMPERSONSGROUPSREPO").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_PERSONSGROUPS deserialized = JsonConvert.DeserializeObject<GET_PERSONSGROUPS>(customerJsonString)!;
                    return View(deserialized!.Get_All);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPerson(ADD_RM_PERSONS_GROUPS model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.PERSON_GROUP_ID == "0")
                    {
                        URL = "RiskManagement/ADDRMPERSONSGROUPSREPO";
                    }
                    else
                    {
                        URL = "RiskManagement/ADDRMPERSONSGROUPSREPO";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("PersonMaster");
            }
            else
            {
                return NoContent();
            }
        }




        #endregion


        #region[dropdown]
        public async Task<JsonResult> _GetDetailsMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("RiskManagement/GETDECREPO").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_DETAILS deserialized = JsonConvert.DeserializeObject<GET_DETAILS>(customerJsonString)!;
                    return Json(deserialized!.Get_All);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }




        #endregion
        #region [Details of any Existing Controls]        public async Task<IActionResult> DetailsMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "RiskManagement/GETDECREPO").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_DETAILS deserialized = JsonConvert.DeserializeObject<GET_DETAILS>(customerJsonString)!;
                    return View(deserialized!.Get_All);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDetails(ADD_RM_DETAILS_EXIST_CONT _ADDDEC)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (_ADDDEC.DETAILS_EXIST_CONT_ID == "0")
                    {
                        URL = "RiskManagement/ADDDEC";
                    }
                    else
                    {
                        URL = "RiskManagement/ADDDEC";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(_ADDDEC), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("DetailsMaster");
            }
            else
            {
                return NoContent();
            }
        }
        #endregion


        #region[dropdown]
        public async Task<JsonResult> _GetAdditionalMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("RiskManagement/GETADDTCONTMEASREPO").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_ADDITIONAL deserialized = JsonConvert.DeserializeObject<GET_ADDITIONAL>(customerJsonString)!;
                    return Json(deserialized!.Get_All);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetLocationMasterSelect ==> " + ex.InnerException);
                throw;
            }
        }
        #endregion
        #region[Additional Control Measures]
        public async Task<IActionResult> AdditionalMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync(conn + "RiskManagement/GETADDTCONTMEASREPO").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_ADDITIONAL deserialized = JsonConvert.DeserializeObject<GET_ADDITIONAL>(customerJsonString)!;
                    return View(deserialized!.Get_All);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdditional(ADD_RM_ADD_CONT_MEAS _ADDCONTMEAS)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (_ADDCONTMEAS.ADD_CONT_MEAS_ID == "0")
                    {
                        URL = "RiskManagement/ADDCONTMEASREPO";
                    }
                    else
                    {
                        URL = "RiskManagement/ADDCONTMEASREPO";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(_ADDCONTMEAS), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("AdditionalMaster");
            }
            else
            {
                return NoContent();
            }
        }
        #endregion
    }
}