using ADQCC_New.Models;
using ADQCC_New.Common;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using static ADQCC_New.Models.EmergencyModel;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;
using ADQCC_New.Models.Masters;

namespace ADQCC_New.Controllers
{
    //[SessionExpire]
    //[Authorize]
    public class EmergencyController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;

        public string ApiUrl => "https://localhost:44328/api/";

        // Declare a private property to hold the deserialized object
        private GET_USER_DETAILS? _loginClass;
        private string _Token;

        // Constructor with Dependency Injection
        public EmergencyController(IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _configuration = configuration;
            client = httpClientFactory.CreateClient("API");

            // Initialize the HttpContext using IHttpContextAccessor _Token
            var str = httpContextAccessor.HttpContext!.Session.GetString("objloginClass");
            _Token = httpContextAccessor.HttpContext!.Session.GetString("AuthToken");
            if (str != null)
            {
                _loginClass = JsonConvert.DeserializeObject<GET_USER_DETAILS>(str);
            }
        }

        #region [Emergency Team Activate]
        public ActionResult EmergencyTeamActivate(string LanguageAbbrevation, string pathName)
        {
            try
            {
                if (LanguageAbbrevation != null)
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
                }
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7),  // Optional: Set expiration
                    HttpOnly = true,                    // Optional: For security, to make cookie accessible only via HTTP (not JavaScript)
                    Secure = true,                      // Optional: Set to true if you're using HTTPS
                    SameSite = SameSiteMode.Lax         // Optional: Adjust SameSite setting (Lax, Strict, None)
                };

                //Response.Cookies.Append(pathName, LanguageAbbrevation, cookieOptions);

                return View();
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "EmergencyTeamActivate ==> " + ex.InnerException);
                throw;
            }
        }

        public async Task<ActionResult> _GetEmrTeamActivate()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var loginClass = _loginClass;
                    if (string.IsNullOrEmpty(_Token))
                        throw new UnauthorizedAccessException("Token is missing.");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        scheme: "Bearer",
                        parameter: $"{_Token}:{loginClass.EMP_USERNAME}");

                    HttpResponseMessage response = await client.GetAsync(ApiUrl + "Emergency/GetEmrTeamActivate");
                    response.EnsureSuccessStatusCode(); // Throw if the status code is not 2xx

                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMERGENCY_TYPE_MASTER_SELECT>>(customerJsonString);

                    return PartialView(deserialized);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetEmrTeamActivate ==> " + (ex.InnerException?.Message ?? "No Inner Exception"));
                throw;
            }
        }
        #endregion

        #region [Additional from other Controller]

        public async Task<JsonResult> _GetEmergencyTeamDrop()
        {
            try
            {
                using (client)
                {
                    var loginclass = _loginClass;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", parameter: _Token + ":" + loginclass.EMP_USERNAME);
                    HttpResponseMessage response = client.GetAsync(ApiUrl + "Emergency/GetEmergencyTypeTeamList").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    IEnumerable<GET_EMERGENCY_TYPE_TEAM> deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMERGENCY_TYPE_TEAM>>(customerJsonString);
                    return Json(deserialized);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetEmergencyTeamDrop ==> " + ex.InnerException);
                throw;
            }
        }
        public async Task<JsonResult> GetEmployeeByBuilding(string LOC_ID, string BUILD_ID, string EMR_Type)
        {
            try
            {
                using (client)
                {
                    M_Employee_Master_Filter _UNIT = new M_Employee_Master_Filter
                    {
                        Loc_id = LOC_ID,
                        Build_id = BUILD_ID,
                        EMR_Type = EMR_Type
                    };
                    var loginclass = _loginClass;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", parameter: _Token + ":" + loginclass.EMP_USERNAME);
                    //HttpResponseMessage response = client.GetAsync(ApiUrl + "Emergency/GetEmployeeByBuilding", _UNIT).Result;
                    HttpResponseMessage response = client.PostAsync(ApiUrl + "Emergency/GetEmployeeByBuilding", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    M_Employee_Master_Filter deserialized = JsonConvert.DeserializeObject<M_Employee_Master_Filter>(customerJsonString);
                    return Json(deserialized.Get_All_Emp);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "_GetEmergencyTeamDrop ==> " + ex.InnerException);
                throw;
            }
        }
        //public async Task<JsonResult> GetEmployeeByBuilding(string LOC_ID, string BUILD_ID, string EMR_Type)
        //{
        //    using (client)
        //    {
        //        M_Employee_Master_Filter _UNIT = new M_Employee_Master_Filter
        //        {
        //            Loc_id = LOC_ID,
        //            Build_id = BUILD_ID,
        //            EMR_Type = EMR_Type
        //        };
        //        var response = client.PostAsync("Emergency/GetEmployeeByBuilding", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
        //        var customerJsonString = await response.Content.ReadAsStringAsync();
        //        var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMPLOYEE_DETAILS>>(customerJsonString);
        //        //return Json(deserialized);
        //        return Json(deserialized);
        //    }
        //}
        //public async Task<IActionResult> GetEmployeeByBuilding()
        //{
        //    using (client)
        //    {
        //        M_Employee_Master_Filter _UNIT = new M_Employee_Master_Filter
        //        {
        //            //Loc_id = LOC_ID,
        //            //Build_id = BUILD_ID,
        //            //EMR_Type = EMR_Type
        //        };
        //        var response = client.PostAsync("Emergency/GetEmployeeByBuilding", new StringContent(JsonConvert.SerializeObject(_UNIT), Encoding.UTF8, "application/json")).Result;
        //        var customerJsonString = await response.Content.ReadAsStringAsync();
        //        var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMPLOYEE_DETAILS>>(customerJsonString);
        //        //return Json(deserialized);
        //        return Json(deserialized);
        //    }
        //}

        public async Task<JsonResult> GetSelectEmployeeLoad()
        {
            //Common.CommonMethods common = new Common.CommonMethods();
            try
            {
                using (var client = new HttpClient())
                {
                    List<GET_EMPLOYEE_DETAILS> encryptedEmployeeDetails = new List<GET_EMPLOYEE_DETAILS>();
                    var loginClass = _loginClass;

                    if (string.IsNullOrEmpty(_Token))
                        throw new UnauthorizedAccessException("Token is missing.");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        scheme: "Bearer",
                        parameter: $"{_Token}:{loginClass.EMP_USERNAME}");

                    HttpResponseMessage response = await client.GetAsync(ApiUrl + "Emergency/GetSelectEmployeeLoad");
                    response.EnsureSuccessStatusCode();

                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMPLOYEE_DETAILS>>(customerJsonString);

                    foreach (var item in deserialized)
                    {
                        encryptedEmployeeDetails.Add(new GET_EMPLOYEE_DETAILS
                        {
                            EMPLOYEE_ID = item.EMPLOYEE_ID,
                            EMPLOYEE_NAME = item.EMPLOYEE_NAME,
                            EMP_NAME_AR = item.EMP_NAME_AR
                        });
                    }

                    return Json(encryptedEmployeeDetails);
                }
            }
            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + " GetSelectEmployeeLoad ==> " + (ex.InnerException?.Message ?? "No Inner Exception"));
                throw;
            }
        }

        #endregion

        #region [Emergency Team]

        //[AuthLog("ADMIN")]
        public IActionResult EmergencyTeam(string LanguageAbbrevation, string pathName)
        {
            try
            {
                if (!string.IsNullOrEmpty(LanguageAbbrevation))
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
                }

                // Setting cookies in ASP.NET Core
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict // Customize based on requirement
                };
                //Response.Cookies.Append(pathName, LanguageAbbrevation, cookieOptions);

                return View();
            }
            catch (Exception ex)
            {
                //var common = new Common.CommonMethods();
                //common.ErrorLog($"{ex.Message} EmergencyTeam ==> {ex.InnerException}");
                throw;
            }
        }

        public string GetSafeFileName(string directory, string name)
        {
            string fullPath = Path.Combine(directory, name);
            int count = 0;
            while (System.IO.File.Exists(fullPath))
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(name);
                string extension = Path.GetExtension(name);
                fullPath = Path.Combine(directory, $"{fileNameWithoutExt}_{++count}{extension}");
            }
            return Path.GetFileName(fullPath);
        }

        [HttpPost]
        public IActionResult UploadDocumentFiles()
        {
            try
            {
                string URL = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/";
                if (Request.Form.Files.Count > 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/IncidentImageStorage/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var files = Request.Form.Files;
                    List<UPLOAD_PHOTO_LIST> ObjPhotodata = new List<UPLOAD_PHOTO_LIST>();

                    foreach (var postedFile in files)
                    {
                        string sourceName = postedFile.FileName;
                        string fileExt = Path.GetExtension(sourceName);

                        // Validate file format
                        if (!(fileExt == ".png" || fileExt == ".jpeg" || fileExt == ".jpg"))
                        {
                            return Json(new { Message = "Invalid File Format" });
                        }

                        // Validate file size
                        if (postedFile.Length > 3000000) // 3 MB
                        {
                            return Json(new { Message = "File Length too Excited" });
                        }

                        // Generate a safe file name
                        string safeFileName = sourceName.Substring(0, 1) + Guid.NewGuid().ToString().Substring(0, 13) + fileExt;
                        safeFileName = GetSafeFileName(path, safeFileName);
                        string filePath = Path.Combine(path, safeFileName);

                        // Save the file
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                        }

                        // Add file metadata to list
                        UPLOAD_PHOTO_LIST objData = new UPLOAD_PHOTO_LIST
                        {
                            INC_PHOTO_NAME = safeFileName,
                            INC_PHOTO_PATH = Path.Combine("IncidentImageStorage", safeFileName),
                            INC_PHOTO_FILE_TYPE = fileExt,
                            INC_PHOTO_STATUS = "1"
                        };
                        ObjPhotodata.Add(objData);
                    }

                    // Store the list in session as a JSON string
                    HttpContext.Session.SetString("ObjPhotodata", JsonSerializer.Serialize(ObjPhotodata));

                    return Json(new { Message = "Photo Uploaded Successfully" });
                }
                else
                {
                    return Json(new { Message = "No Records Found" });
                }
            }
            catch (Exception ex)
            {
                //var common = new Common.CommonMethods();
                //common.ErrorLog($"{ex.Message} UploadDocumentFiles ==> {ex.InnerException}");
                throw;
            }
        }
        #endregion
    }
}