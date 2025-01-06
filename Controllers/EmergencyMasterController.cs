using System.Text;
using ADQCC_New.Models;
using ADQCC_New.Models.Emergency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using ADQCC_New.Models.Masters;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ADQCC_New.Controllers
{
    public class EmergencyMasterController : Controller
    {

        private readonly HttpClient client = new HttpClient();
        private readonly IConfiguration configuration;
        private string conn;
        public EmergencyMasterController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            client = httpClientFactory.CreateClient("API");
            this.configuration = configuration;
        }

        #region[Immediatecause UnSafeAct]
        public async Task<IActionResult> UnSafeActMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetUnSafeActMaster").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_UnSafeAct);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUnSafeAct(M_EmergencyModel model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.CAUSE_ID == "0")
                    {
                        URL = "EmergencyMaster/AddUnSafeAct";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddUnSafeAct";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("UnSafeActMaster");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UnSafeAct_GetById(string CAUSE_ID)
        {
            using (client)
            {
                M_EmergencyModel _UNIT = new M_EmergencyModel
                {
                    CAUSE_ID = CAUSE_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetUnSafeById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_UnSafeAct);
            }
        }

        public async Task<IActionResult> UnSafeAct_Delete(string CAUSE_ID)
        {
            try
            {
                using (client)
                {
                    M_EmergencyModel _UNIT = new M_EmergencyModel
                    {
                        CAUSE_ID = CAUSE_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteUnSafeAct", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    //M_EmergencyModel deserialized = JsonConvert.DeserializeObject<M_EmergencyModel>(customerJsonString)!;
                    //return Json(deserialized!.STATUS_CODE);
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);
                    //TempData["msg"] = deserialized!.MESSAGE;
                    //return RedirectToAction("UnSafeActMaster");
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        #endregion

        #region[Immediatecause UnSafeCondition]
        [HttpGet]
        public async Task<IActionResult> UnSafeConditionMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetAllUnSafeCond").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Condition);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUnSafeCond(UNSAFECONDITION_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.IM_UNSAFE_ID == "0")
                    {
                        URL = "EmergencyMaster/AddUnSafeCond";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddUnSafeCond";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("UnSafeConditionMaster");
            }
            else
            {
                return NoContent();
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> UnSafeCond_GetById(string IM_UNSAFE_ID)
        {
            using (client)
            {
                UNSAFECONDITION_MASTER _UNIT = new UNSAFECONDITION_MASTER
                {
                    IM_UNSAFE_ID = IM_UNSAFE_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Condition);
            }
        }


        public async Task<IActionResult> UnSafeCond_Delete(string IM_UNSAFE_ID)
        {
            try
            {
                using (client)
                {
                    UNSAFECONDITION_MASTER _UNIT = new UNSAFECONDITION_MASTER
                    {
                        IM_UNSAFE_ID = IM_UNSAFE_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteUnSafeCond", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);
                  
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        #endregion

        #region[RootCause (Personal Factor)]
        [HttpGet]
        public async Task<IActionResult> RootCausePersonalMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetRootPersonal").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Personal);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRootPersonal(ROOT_CAUSE_PERSONAL_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.ROOT_CAUSE_ID == null)
                    {
                        model.ROOT_CAUSE_ID = "0"; // need to check
                        URL = "EmergencyMaster/AddRootPersonal";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddRootPersonal";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("RootCausePersonalMaster");
            }
            else
            {
                return NoContent();
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Personal_GetById(string ROOT_CAUSE_ID)
        {
            using (client)
            {
                ROOT_CAUSE_PERSONAL_MASTER _UNIT = new ROOT_CAUSE_PERSONAL_MASTER
                {
                    ROOT_CAUSE_ID = ROOT_CAUSE_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetPersonalById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Personal);
            }
        }

        public async Task<IActionResult> Personal_Delete(string ROOT_CAUSE_ID)
        {
            try
            {
                using (client)
                {
                    ROOT_CAUSE_PERSONAL_MASTER _UNIT = new ROOT_CAUSE_PERSONAL_MASTER
                    {
                        ROOT_CAUSE_ID = ROOT_CAUSE_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeletePersonal", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        #endregion

        #region[RootCause (System Factor)]
        [HttpGet]
        public async Task<IActionResult> RootCauseSystemMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetRootSystem").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_System);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRootSystem(ROOT_CAUSE_SYSTEM_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.RC_SF_ID == null)
                    {
                        model.RC_SF_ID = "0";
                        URL = "EmergencyMaster/AddRootSystem";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddRootSystem";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("RootCauseSystemMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> System_GetById(string RC_SF_ID)
        {
            using (client)
            {
                ROOT_CAUSE_SYSTEM_MASTER _UNIT = new ROOT_CAUSE_SYSTEM_MASTER
                {
                    RC_SF_ID = RC_SF_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetSystemById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_System);
            }
        }

        public async Task<IActionResult> System_Delete(string RC_SF_ID)
        {
            try
            {
                using (client)
                {
                    ROOT_CAUSE_SYSTEM_MASTER _UNIT = new ROOT_CAUSE_SYSTEM_MASTER
                    {
                        RC_SF_ID = RC_SF_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteSystem", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        #endregion

        #region[RootCause (Method)]
        [HttpGet]
        public async Task<IActionResult> RootCauseMethodMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetRootMethod").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Method);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRootMethod(ROOT_CAUSE_METHOD_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.RC_METHOD_ID == null)
                    {
                        model.RC_METHOD_ID = "0";
                        URL = "EmergencyMaster/AddRootMethod";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddRootMethod";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("RootCauseMethodMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Method_GetById(string RC_METHOD_ID)
        {
            using (client)
            {
                ROOT_CAUSE_METHOD_MASTER _UNIT = new ROOT_CAUSE_METHOD_MASTER
                {
                    RC_METHOD_ID = RC_METHOD_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetMethodById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Method);
            }
        }

        public async Task<IActionResult> Method_Delete(string RC_METHOD_ID)
        {
            try
            {
                using (client)
                {
                    ROOT_CAUSE_METHOD_MASTER _UNIT = new ROOT_CAUSE_METHOD_MASTER
                    {
                        RC_METHOD_ID = RC_METHOD_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteMethod", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        #endregion

        #region[RootCause (Environment)]
        [HttpGet]
        public async Task<IActionResult> EnvironmentMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetEMRRCEnvironment").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Environment);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEEMRRCEnvironment(ROOT_CAUSE_ENVIRONMENT_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.RC_ENVIRONMENT_ID == null)
                    {
                        model.RC_ENVIRONMENT_ID = "0";
                        URL = "EmergencyMaster/AddEEMRRCEnvironment";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddEEMRRCEnvironment";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("EnvironmentMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Environment_GetById(string RC_ENVIRONMENT_ID)
        {
            using (client)
            {
                ROOT_CAUSE_ENVIRONMENT_MASTER _UNIT = new ROOT_CAUSE_ENVIRONMENT_MASTER
                {
                    RC_ENVIRONMENT_ID = RC_ENVIRONMENT_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetCauseById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Environment);
            }
        }


        public async Task<IActionResult> Environment_Delete(string RC_ENVIRONMENT_ID)
        {
            try
            {
                using (client)
                {
                    ROOT_CAUSE_ENVIRONMENT_MASTER _UNIT = new ROOT_CAUSE_ENVIRONMENT_MASTER
                    {
                        RC_ENVIRONMENT_ID = RC_ENVIRONMENT_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteEnvironment", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        #endregion

        #region[RootCause (Material)]
        [HttpGet]
        public async Task<IActionResult> MaterialMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetEMRRCMaterial").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Material);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEEMRRCMaterial(ROOT_CAUSE_MATERIAL_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.RC_MATERIAL_ID == "0")
                    {
                        URL = "EmergencyMaster/AddEEMRRCMaterial";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddEEMRRCMaterial";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("MaterialMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Material_GetById(string RC_MATERIAL_ID)
        {
            using (client)
            {
                ROOT_CAUSE_MATERIAL_MASTER _UNIT = new ROOT_CAUSE_MATERIAL_MASTER
                {
                    RC_MATERIAL_ID = RC_MATERIAL_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetCauseMaterialById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Material);
            }
        }

        public async Task<IActionResult> Material_Delete(string RC_MATERIAL_ID)
        {
            try
            {
                using (client)
                {
                    ROOT_CAUSE_MATERIAL_MASTER _UNIT = new ROOT_CAUSE_MATERIAL_MASTER
                    {
                        RC_MATERIAL_ID = RC_MATERIAL_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteMaterial", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        #endregion

        #region [Nature of Injury / Illness]
        [HttpGet]
        public async Task<IActionResult> NatureMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetEMRNIIDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Nature);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEMRNII(NATURE_INJURY_DETAILS model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.NATURE_INJURY_ID == null)
                    {
                        model.NATURE_INJURY_ID = "0";
                        URL = "EmergencyMaster/AddEMRNII";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddEMRNII";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("NatureMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Nature_GetById(string NATURE_INJURY_ID)
        {
            using (client)
            {
                NATURE_INJURY_DETAILS _UNIT = new NATURE_INJURY_DETAILS
                {
                    NATURE_INJURY_ID = NATURE_INJURY_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetNatureById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Nature);
            }
        }

        public async Task<IActionResult> Nature_Delete(string NATURE_INJURY_ID)
        {
            try
            {
                using (client)
                {
                    NATURE_INJURY_DETAILS _UNIT = new NATURE_INJURY_DETAILS
                    {
                        NATURE_INJURY_ID = NATURE_INJURY_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteNature", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        #endregion

        #region [Mechanism of Injury / Illness]
        [HttpGet]
        public async Task<IActionResult> MechanismMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetEMRMIIDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Mechanism);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEMRMII(MECH_INJURY_DETAILS model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.MECH_INJURY_ID == null)
                    {
                        model.MECH_INJURY_ID = "0";
                        URL = "EmergencyMaster/AddEMRMII";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddEMRMII";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("MechanismMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Mechanism_GetById(string MECH_INJURY_ID)
        {
            using (client)
            {
                MECH_INJURY_DETAILS _UNIT = new MECH_INJURY_DETAILS
                {
                    MECH_INJURY_ID = MECH_INJURY_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetInjuryById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Mechanism);
            }
        }

        public async Task<IActionResult> Mech_Delete(string MECH_INJURY_ID)
        {
            try
            {
                using (client)
                {
                    MECH_INJURY_DETAILS _UNIT = new MECH_INJURY_DETAILS
                    {
                        MECH_INJURY_ID = MECH_INJURY_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteMechanism", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion

        #region [Agency / Source of Injury / Illness]
        [HttpGet]
        public async Task<IActionResult> AgencyMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetEMRAIIDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Agency);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEMRAII(AGENCY_INJURY_DETAILS model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.AGENCY_INJURY_ID == null)
                    {
                        model.AGENCY_INJURY_ID = "0";
                        URL = "EmergencyMaster/AddEMRAII";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddEMRAII";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("AgencyMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Agency_GetById(string AGENCY_INJURY_ID)
        {
            using (client)
            {
                AGENCY_INJURY_DETAILS _UNIT = new AGENCY_INJURY_DETAILS
                {
                    AGENCY_INJURY_ID = AGENCY_INJURY_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetAgencyInjuryById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Agency);
            }
        }

        public async Task<IActionResult> Agency_Delete(string AGENCY_INJURY_ID)
        {
            try
            {
                using (client)
                {
                    AGENCY_INJURY_DETAILS _UNIT = new AGENCY_INJURY_DETAILS
                    {
                        AGENCY_INJURY_ID = AGENCY_INJURY_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteAgency", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion

        #region[Incident Cause Analysis]
        [HttpGet]
        public async Task<IActionResult> IncidentMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetemrINCDTCAdetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Incident);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddemrINCDTCA(INCIDENT_DETAILS model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.INCDT_CAS_ID == null)
                    {
                        model.INCDT_CAS_ID = "0";
                        URL = "EmergencyMaster/AddemrINCDTCA";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddemrINCDTCA";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("IncidentMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Incident_GetById(string INCDT_CAS_ID)
        {
            using (client)
            {
                INCIDENT_DETAILS _UNIT = new INCIDENT_DETAILS
                {
                    INCDT_CAS_ID = INCDT_CAS_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetIncidentCauseById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Incident);
            }
        }

        public async Task<IActionResult> IncidentCause_Delete(string INCDT_CAS_ID)
        {
            try
            {
                using (client)
                {
                    INCIDENT_DETAILS _UNIT = new INCIDENT_DETAILS
                    {
                        INCDT_CAS_ID = INCDT_CAS_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteIncidentCause", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion

        #region [Incident Category]
        [HttpGet]
        public async Task<IActionResult> IncidentCategoryMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetIncidentCategory").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_IncidentDet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIncidentCategory(INCIDENT_CATEGORY_DETAILS model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.INC_CAT_ID == null)
                    {
                        model.INC_CAT_ID = "0";
                        URL = "EmergencyMaster/AddIncidentCategory";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddIncidentCategory";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("IncidentCategoryMaster");
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost]
        public async Task<IActionResult> IncidentCategory_GetById(string INC_CAT_ID)
        {
            using (client)
            {
                INCIDENT_CATEGORY_DETAILS _UNIT = new INCIDENT_CATEGORY_DETAILS
                {
                    INC_CAT_ID = INC_CAT_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetIncidentById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_IncidentDet);
            }
        }


        public async Task<IActionResult> IncidentCategory_Delete(string INC_CAT_ID)
        {
            try
            {
                using (client)
                {
                    INCIDENT_CATEGORY_DETAILS _UNIT = new INCIDENT_CATEGORY_DETAILS
                    {
                        INC_CAT_ID = INC_CAT_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteIncidentCategory", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion

        #region [DISASTER_TYPE]
        [HttpGet]
        public async Task<IActionResult> DisasterMaster()
        {
            try
            {
                using (client)
                {
                    HttpResponseMessage response = client.GetAsync("EmergencyMaster/GetDiasterType").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                    return View(deserialized!.Get_All_Disaster);
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDiasterType(DISASTER_TYPE_MASTER model)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    string URL = "";
                    if (model.DISASTER_ID == null)
                    {
                        model.DISASTER_ID = "0";
                        URL = "EmergencyMaster/AddDiasterType";
                    }
                    else
                    {
                        URL = "EmergencyMaster/AddDiasterType";
                    }
                    HttpResponseMessage response = client.PostAsync(conn + URL, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;

                    TempData["msg"] = deserialized!.MESSAGE;
                }
                return RedirectToAction("DisasterMaster");
            }
            else
            {
                return NoContent();
            }

        }
        //[HttpPost]
        //public async Task<IActionResult> Edit_Observation_Reporting([FromBody] M_Observation_Corrective_Action _UNIT)
        //{
        //    using (client)
        //    {
        //        Login_ LoginClass = GetLoginDetails();
        //        //M_Observation_Corrective_Action _UNIT = new()
        //        //{
        //        //    Inc_Obser_Report_Id = Convert.ToString(Inc_Obser_Report_Id)
        //        //};

        //        HttpResponseMessage response = client.PostAsync("Incident_Observation_Report/Inc_Observation_Report_GetByID", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
        //        string customerJsonString = await response.Content.ReadAsStringAsync();
        //        GET_OBSERVATION_REPORT deserialized = JsonConvert.DeserializeObject<GET_OBSERVATION_REPORT>(customerJsonString)!;
        //        return Json(deserialized!.Get_Observation_Report);
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> Disaster_GetById(string DISASTER_ID)
        {
            using (client)
            {
                DISASTER_TYPE_MASTER _UNIT = new DISASTER_TYPE_MASTER
                {
                    DISASTER_ID = DISASTER_ID
                };
                HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/GetDiasterTypeById", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                string customerJsonString = await response.Content.ReadAsStringAsync();
                GET_EMERGENCY_LIST deserialized = JsonConvert.DeserializeObject<GET_EMERGENCY_LIST>(customerJsonString)!;
                return Json(deserialized!.Get_ById_Disaster);
            }
        }

        public async Task<IActionResult> Disaster_Delete(string DISASTER_ID)
        {
            try
            {
                using (client)
                {
                    DISASTER_TYPE_MASTER _UNIT = new DISASTER_TYPE_MASTER
                    {
                        DISASTER_ID = DISASTER_ID
                    };
                    HttpResponseMessage response = client.PostAsync(conn + "EmergencyMaster/DeleteDisasterType", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);

                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion
    }
}



  