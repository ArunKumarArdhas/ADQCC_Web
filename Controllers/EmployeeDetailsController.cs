//using ADQCC_New.Authentication;
//using ADQCC_New.Data;
using ADQCC_New.Models;
using ADQCC_New.Common;
//using Azure.Core;
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
//using System.Web.Mvc;
//using System.Web.Services.Description;
using System.Xml.Linq;
//using static Azure.Core.HttpHeader;
using static ADQCC_New.Models.EmergencyModel;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace ADQCC_New.Controllers
{
    public class EmployeeDetailsController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string VACCINE_DOCUMENTFILEURL;
        public string ApiUrl;
        private readonly IWebHostEnvironment _env;
        // Declare a private property to hold the deserialized object
        private GET_USER_DETAILS? _loginClass;
        private string _Token;

        // Constructor with Dependency Injection
        //[ValidateAntiForgeryToken]
        public EmployeeDetailsController(IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _configuration = configuration;
            client = httpClientFactory.CreateClient("API");
            _env = env;

            // Initialize the HttpContext using IHttpContextAccessor _Token
            var str = httpContextAccessor.HttpContext!.Session.GetString("objloginClass");
            _Token = httpContextAccessor.HttpContext!.Session.GetString("AuthToken");
            if (str != null)
            {
                _loginClass = JsonConvert.DeserializeObject<GET_USER_DETAILS>(str);
            }
            ApiUrl = configuration["ConnectionStrings:DefaultConnection"];
            VACCINE_DOCUMENTFILEURL = configuration["VACCINE:value"];
        }

        //[Authorize]
        //[AuthLog("ADMIN")]
        public IActionResult Index(string LanguageAbbrevation, string pathName)
        {
            try
            {
                if (!string.IsNullOrEmpty(LanguageAbbrevation))
                {
                    // Set the current thread's culture for the request
                    CultureInfo culture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }

                if (!string.IsNullOrEmpty(pathName))
                {
                    // Create a cookie with the specified pathName and LanguageAbbrevation
                    CookieOptions options = new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(7), // Set an expiration date for the cookie
                        HttpOnly = true, // Makes the cookie inaccessible to client-side scripts
                        Secure = true    // Ensures the cookie is sent over HTTPS
                    };

                    HttpContext.Response.Cookies.Append(pathName, LanguageAbbrevation, options);
                }

                return View();
            }
            catch (Exception ex)
            {
                // Log the exception (if you have a logging mechanism)
                // Optionally rethrow the exception or handle it accordingly
                throw;
            }
        }

        public async Task<IActionResult> _GetEmployeeList(string EMP_ID, string EMP_NAME, string EMP_DESI)
        {
            try
            {
                // Dependency injection is used for the HttpClient instance
                List<GET_EMPLOYEE_DETAILS> employeeDetails = new List<GET_EMPLOYEE_DETAILS>();
                var loginClass = _loginClass; // Helper extension method for session
                if (loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Unauthorized(); // Return an appropriate status if session is invalid
                }

                string token = _Token;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}:{loginClass.EMP_USERNAME}");

                string url = $"{ApiUrl}EmployeeDetails/GetEmployeeDetails?EMP_ID={EMP_ID}&EMP_NAME={EMP_NAME}&EMP_DESI={EMP_DESI}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, "Error fetching employee details.");
                }

                string customerJsonString = await response.Content.ReadAsStringAsync();
                List<GET_EMPLOYEE_DETAILS> deserialized = JsonConvert.DeserializeObject<List<GET_EMPLOYEE_DETAILS>>(customerJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                // Log the exception with better context
                //var common = new Common.CommonMethods();
                //common.ErrorLog($"{ex.Message} _GetEmployeeList ==> {ex.InnerException}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        #region [Emergency Team]
        List<UPLOAD_DOCUMENT> ObjDocUpload = new List<UPLOAD_DOCUMENT>();
        public IActionResult UploadEmgTeamDocumentFiles()
        {
            try
            {
                string URL = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/";
                if (Request.Form.Files.Count > 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/EmgTeamDoc/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var files = Request.Form.Files;
                    foreach (var postedFile in files)
                    {
                        string sourceName = postedFile.FileName;
                        string fileExt = Path.GetExtension(sourceName);
                        if (fileExt != ".pdf")
                        {
                            return Json(new { Message = "Invalid File Format" });
                        }

                        string safeFileName = sourceName.Substring(0, 1) + Guid.NewGuid().ToString().Substring(0, 13) + fileExt;
                        safeFileName = GetSafeFileName(path, safeFileName);
                        string filePath = Path.Combine(path, safeFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                        }

                        UPLOAD_DOCUMENT objData = new UPLOAD_DOCUMENT
                        {
                            EMR_FILE_NAME = safeFileName,
                            EMR_FILE_PATH = Path.Combine("EmgTeamDoc", safeFileName),
                            EMR_FILE_TYPE = fileExt,
                            EMR_FILE_STATUS = "1"
                        };
                        ObjDocUpload.Add(objData);
                    }

                    HttpContext.Session.SetString("ObjDocUpload", JsonSerializer.Serialize(ObjDocUpload));
                    return Json(new { Message = "Document Uploaded Successfully" });
                }
                else
                {
                    return Json(new { Message = "No Records Found" });
                }
            }
            catch (Exception ex)
            {
                //var common = new Common.CommonMethods();
                //common.ErrorLog($"{ex.Message} UploadEmgTeamDocumentFiles ==> {ex.InnerException}");
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

        #endregion

        #region [Employee Details ADD]

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddEmployeeDetails([FromBody] ADD_EMPLOYEE_DETAILS model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Save data to the database or handle the logic here
        //        // Example: _context.EmployeeDetails.Add(model);
        //        // _context.SaveChanges();

        //        // Redirect to another view or return success message
        //        return RedirectToAction("EmployeeDetailsAdded");
        //    }

        //    // If validation fails, return the view with validation messages
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployeeDetails(ADD_EMPLOYEE_DETAILS _EMPLOYEE_DETAILS)
        {
            try
            {
                if (string.IsNullOrEmpty(_EMPLOYEE_DETAILS.EMP_ID) || _EMPLOYEE_DETAILS.EMP_ID == "0")
                {
                    _EMPLOYEE_DETAILS.EMP_ENCRYPT_ID = "7CYwZ8SGzwtoGDfiERHD6Q==";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                    // Make POST request
                    var response = await client.PostAsJsonAsync($"{ApiUrl}EmployeeDetails/AddEmployeeDetails", _EMPLOYEE_DETAILS);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var deserialized = JsonConvert.DeserializeObject<ADD_EMPLOYEE_DETAILS>(responseContent);
                        return Json(deserialized);
                    }
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
                }
                else
                {
                    // Retrieve session data
                    //var loginClass = JsonConvert.DeserializeObject<GET_USER_DETAILS>(HttpContext.Session.GetString("objloginClass"));
                    //var token = HttpContext.Session.GetString("Token");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                    // Make PUT request
                    var response = await client.PutAsJsonAsync($"{ApiUrl}EmployeeDetails/UpdateEmployeeDetails", _EMPLOYEE_DETAILS);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var deserialized = JsonConvert.DeserializeObject<ADD_EMPLOYEE_DETAILS>(responseContent);
                        return Json(deserialized);
                    }
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                // Return appropriate error response
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        public async Task<JsonResult> GetSelectEmergencyTypeMaster()
        {
            try
            {
                var response = await client.GetAsync($"{ApiUrl}Masters/GetEmergTypeMaster");

                if (!response.IsSuccessStatusCode)
                {
                    
                    return Json(new { error = "Failed to fetch emergency type master data." });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var emergencyTypeMaster = JsonSerializer.Deserialize<IEnumerable<GET_EMR_TYPE_MASTER>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Json(emergencyTypeMaster);
            }
            catch (Exception ex)
            {
                return Json(new { error = "An error occurred while processing the request." });
            }
        }

        public async Task<JsonResult> GetEmployeeFilter()
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetEmployeeFilter");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to fetch employee filter data." });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var employeeDetails = JsonSerializer.Deserialize<IEnumerable<GET_EMPLOYEE_DETAILS>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Json(employeeDetails);
            }
            catch (Exception)
            {
                return Json(new { error = "An error occurred while processing the request." });
            }
        }

        public async Task<JsonResult> _GetEmployee_EHSList()
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetEmployee_EHSList");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to fetch the EHS list." });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var deserialized = JsonSerializer.Deserialize<IEnumerable<EMPLOYEE_MANAGER_LIST>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Json(deserialized);
            }
            catch (Exception)
            {
                return Json(new { error = "An error occurred while processing the request." });
            }
        }

        public async Task<JsonResult> _GetEmployee_SECTION_HEAD_List()
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetEmployee_SECTION_HEAD_List");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to fetch the SECTION HEAD list." });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var deserialized = JsonSerializer.Deserialize<IEnumerable<EMPLOYEE_MANAGER_LIST>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Json(deserialized);
            }
            catch (Exception)
            {
                return Json(new { error = "An error occurred while processing the request." });
            }
        }

        public async Task<JsonResult> _GetEmployee_HSSE_List()
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetEmployee_HSSE_List");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to fetch the HSSE list." });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var deserialized = JsonSerializer.Deserialize<IEnumerable<EMPLOYEE_MANAGER_LIST>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Json(deserialized);
            }
            catch (Exception)
            {
                return Json(new { error = "An error occurred while processing the request." });
            }
        }

        public async Task<JsonResult> _GetEmp_Dir_BySector(string SECTOR_ID, string BUILDING_ID)
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetEmp_Dir_BySector?SECTOR_ID={SECTOR_ID}&BUILDING_ID={BUILDING_ID}");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to fetch data from the API." });
                }

                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        public async Task<ActionResult> _GetPreviewList()
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetPreviewDetails");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to fetch preview details from the API." });
                }

                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<EMPLOYEE_PREVIEW>>(customerJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        public async Task<ActionResult> _GetHealthVitalsDetails(string EMP_ID)
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetHealthVitalsDetails?EMP_ID={EMP_ID}");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to fetch health vitals details from the API." });
                }

                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<HEALTH_VITAL_LIST>>(customerJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        public async Task<JsonResult> UpdateActiveDeactiveStatus(string EMP_ID, string STATUS, string PASSWORD, string USERNAME)
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetActiveDeactiveStatus?EMP_ID={EMP_ID}&STATUS={STATUS}&PASSWORD={PASSWORD}&USERNAME={USERNAME}");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to update the active/deactive status." });
                }

                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        public async Task<JsonResult> _DeleteEmployeeList(string EMP_ID)
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.DeleteAsync($"{ApiUrl}EmployeeDetails/DeleteEmployeeDetails?EMP_ID={EMP_ID}");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to delete employee." });
                }

                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString);
                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }

        public async Task<JsonResult> _EditEmployeeList(string EMP_ID)
        {
            try
            {
                if (_loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    return Json(new { error = "Invalid session or token." });
                }

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", $"{_Token}:{_loginClass.EMP_USERNAME}");

                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetEmployeeEditDetails?EMP_ID={EMP_ID}");

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { error = "Failed to retrieve employee details." });
                }

                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<ADD_EMPLOYEE_DETAILS>(customerJsonString);
                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }


        #endregion


        #region [UPLOAD_VACCINE_FILES]
        public string UPLOAD_DOC_FILES(string FileData)
        {
            try
            {
                string AttachmentName = "";
                if (FileData.Contains("data:"))
                {
                    FileData = FileData.Replace("data:", "");
                }

                string ext = "";

                if (FileData.Contains("application/pdf"))
                {
                    ext = ".pdf";
                }
                else
                {
                    ext = ".doc";
                }
                Guid FileName = Guid.NewGuid();
                var lst = Regex.Split(FileData, "base64,");
                byte[] byteLenth = Convert.FromBase64String(lst[1]);
                string byteImage = Convert.ToString(lst[0]);
                var bitValidate = byteLenth.Length;
                if (byteImage == "image/jpeg;" || byteImage == "image/jpg;" || byteImage == "image/png;" || byteImage == "image/tiff; ")
                {
                    AttachmentName = "200";
                }
                else
                {
                    if (bitValidate > 5000000)
                    {
                        AttachmentName = "100";
                    }
                    else
                    {
                        if (lst.Count() > 1)
                        {
                            FileData = lst[1];

                            var vaccineFilePath = Path.Combine(_env.WebRootPath, "VaccineFile");

                            // Check if the directory exists, if not, create it
                            if (!Directory.Exists(vaccineFilePath))
                            {
                                Directory.CreateDirectory(vaccineFilePath);
                            }

                            // Construct the full file path
                            var fullFilePath = Path.Combine(vaccineFilePath, FileName + ext);

                            // Create the file and write data to it
                            using (FileStream stream = new FileStream(fullFilePath, FileMode.Create))
                            {
                                byte[] byteArray = Convert.FromBase64String(FileData);
                                stream.Write(byteArray, 0, byteArray.Length);
                            }

                            // Construct the attachment URL
                            AttachmentName = Path.Combine(VACCINE_DOCUMENTFILEURL, "VaccineFile", FileName + ext).Replace("\\", "/");


                        }
                    }
                }


                return AttachmentName;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

    }
}
