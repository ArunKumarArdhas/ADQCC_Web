using ADQCC_New.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using static ADQCC_New.Models.EmergencyModel;
using System.Net.Http.Headers;
using System.Text;
using System.Reflection;
using Newtonsoft.Json.Linq;
using ADQCC_New.Models.Masters;
using Grpc.Core;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ADQCC_New.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string ApiUrl;
        private GET_USER_DETAILS? _loginClass;
        private string _Token;
        private readonly IWebHostEnvironment _env;

        public IncidentController(IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
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
        }

        #region [INCIDENT DETAILS]

        public IActionResult IncidentDetails(string LanguageAbbrevation, string pathName)
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

        public IActionResult EHSAlertEmployee(string LanguageAbbrevation, string pathName)
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

        public IActionResult CorrectiveActionInvest(string LanguageAbbrevation, string pathName)
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

        List<UPLOAD_PHOTO_LIST> ObjPhotodata = new List<UPLOAD_PHOTO_LIST>();
        List<UPLOAD_DOCUMENT> ObjDocUpload = new List<UPLOAD_DOCUMENT>();
        List<UPLOAD_INC_VIDEO_LIST> ObjVideodata = new List<UPLOAD_INC_VIDEO_LIST>();

        #region [UPLOAD IMAGE]
        [HttpPost]
        public JsonResult UploadEmgTeamDocumentFiles()
        {
            try
            {
                return HandleFileUpload(
                    "~/EmgTeamDoc/",
                    new[] { ".pdf" },
                    5000000,
                    (safeFileName, fileExt, filePath) =>
                    {
                        ObjDocUpload.Add(new UPLOAD_DOCUMENT
                        {
                            EMR_FILE_NAME = safeFileName,
                            EMR_FILE_PATH = Path.Combine("EmgTeamDoc", safeFileName),
                            EMR_FILE_TYPE = fileExt,
                            EMR_FILE_STATUS = "1"
                        });
                        HttpContext.Session.SetString("ObjDocUpload", JsonConvert.SerializeObject(ObjDocUpload));
                    }
                );
            }
            catch (Exception ex)
            {
                // Log the error as needed
                throw;
            }
        }

        [HttpPost]
        public JsonResult UploadVideos()
        {
            try
            {
                return HandleFileUpload(
                    "~/IncidentVideoStorage/",
                    new[] { ".mp4", ".flv", ".avi" },
                    5000000,
                    (safeFileName, fileExt, filePath) =>
                    {
                        ObjVideodata.Add(new UPLOAD_INC_VIDEO_LIST
                        {
                            INC_VIDEO_NAME = safeFileName,
                            INC_VIDEO_PATH = Path.Combine("IncidentVideoStorage", safeFileName),
                            INC_VIDEO_FILE_TYPE = fileExt,
                            INC_VIDEO_STATUS = "1"
                        });
                        HttpContext.Session.SetString("ObjDocUpload", JsonConvert.SerializeObject(ObjDocUpload));
                    }
                );
            }
            catch (Exception ex)
            {
                // Log the error as needed
                throw;
            }
        }

        private JsonResult HandleFileUpload(string storagePath, string[] allowedExtensions, int maxFileSize, Action<string, string, string> onFileSave)
        {
            try
            {
                // Ensure the directory exists
                string basePath = Path.Combine(Directory.GetCurrentDirectory(), storagePath.TrimStart('~').Replace("/", "\\"));
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                // Check if files are present in the request
                if (Request.Form.Files.Count > 0)
                {
                    var files = Request.Form.Files;
                    foreach (var postedFile in files)
                    {
                        string fileName = postedFile.FileName;
                        string fileExt = Path.GetExtension(fileName).ToLower();

                        // Validate file extension
                        if (!allowedExtensions.Contains(fileExt))
                        {
                            return Json(new { Message = "Invalid File Format" });
                        }

                        // Validate file size
                        if (postedFile.Length > maxFileSize)
                        {
                            return Json(new { Message = $"File size exceeds the limit of {maxFileSize / 1000000} MB" });
                        }

                        // Generate a safe file name
                        string safeFileName = GetSafeFileName(basePath, Path.GetFileNameWithoutExtension(fileName) + fileExt);
                        string filePath = Path.Combine(basePath, safeFileName);

                        // Save the file
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                        }

                        // Execute the callback with the file metadata
                        onFileSave(safeFileName, fileExt, filePath);
                    }

                    return Json(new { Message = "File(s) Uploaded Successfully" });
                }
                else
                {
                    return Json(new { Message = "No Files Found" });
                }
            }
            catch (Exception ex)
            {
                // Log the error
                throw;
            }
        }
        #endregion

        public void AssignIncId(string id)
        {
            // Ensure the id is not null or empty
            if (!string.IsNullOrEmpty(id))
            {
                // Set the INC_ID value in session (using SetString for a string value)
                HttpContext.Session.SetString("INC_ID", id);
            }
            else
            {
                // Optionally log an error or set a default value
                HttpContext.Session.SetString("INC_ID", "default-id");  // Or handle the case appropriately
            }
        }

        public async Task<JsonResult> _SelectGetIncidentCategory()
        {
            try
            {
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                // Setting authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                // Performing the HTTP GET request
                var response = await client.GetAsync($"{ApiUrl}Incident/GetIncidentCategory");
                response.EnsureSuccessStatusCode(); // Ensures the request was successful

                // Reading and deserializing the response
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<List<GET_INCIDENT_CATEGORY_DETAILS>>(inccatJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                // Log exception or handle error as needed
                // Example: _logger.//LogError(ex, "Error occurred in _SelectGetIncidentCategory.");
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> _GetIncidentList()
        {
            try
            {
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                // Setting authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                // Constructing the query parameters
                var url = $"{ApiUrl}Incident/GetIncident?EMP_LOGIN_ID={_loginClass.EMP_ID}&DESI_NAME={_loginClass.DESI_NAME}";

                // Performing the HTTP GET request
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Ensures the request was successful

                string incidentJsonString = await response.Content.ReadAsStringAsync();
                JObject parsedResponse = JObject.Parse(incidentJsonString);
                var getAll = parsedResponse["Get_All"].ToObject<List<GET_INCIDENT_DETAILS>>();

                return PartialView(getAll);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate response
                // Example: _logger.//LogError(ex, "Error occurred in _GetIncidentList.");
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> _DeleteIncidentCategory(string INCCATID)
        {
            try
            {
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                // Setting authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                // Constructing the request URL with query parameters
                var url = $"{ApiUrl}Incident/DeleteIncidentCategory?INCCATID={INCCATID}";

                // Performing the HTTP DELETE request
                var response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode(); // Ensures the request was successful

                // Reading and deserializing the response
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IncidentCategoryModel>(inccatJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate response
                // Example: _logger.//LogError(ex, "Error occurred in _DeleteIncidentCategory.");
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> _EditIncidentCategory(string INCCATID)
        {
            try
            {
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                // Setting authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                // Constructing the request URL with query parameters
                var url = $"{ApiUrl}Incident/EditIncidentCategory?INCCATID={INCCATID}";

                // Performing the HTTP GET request
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Ensures the request was successful

                // Reading and deserializing the response
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IncidentCategoryModel>(inccatJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate response
                // Example: _logger.//LogError(ex, "Error occurred in _EditIncidentCategory.");
                return Json(new { success = false, message = ex.Message });
            }
        }

        #region [INCIDENT NOTIFICATION HELP DOCUMENTS]
        public IActionResult IncidentNotificationHelpDoc()
        {
            return View();
        }
        #endregion

        public async Task<JsonResult> AddIncidentCategory(IncidentCategoryModel _AddIncCatmodel)
        {
            try
            {
                // Check if the category is new or updating an existing one
                if (_AddIncCatmodel.INC_CAT_ID == 0)
                {
                    // Adding a new incident category
                    return await AddNewIncidentCategory(_AddIncCatmodel);
                }
                else
                {
                    // Updating an existing incident category
                    return await UpdateIncidentCategory(_AddIncCatmodel);
                }
            }
            catch (Exception ex)
            {
                // Log and handle the exception as needed
                // You can log the error or return a failure response
                throw new Exception("An error occurred while adding/updating the incident category.", ex);
            }
        }

        private async Task<JsonResult> AddNewIncidentCategory(IncidentCategoryModel _AddIncCatmodel)
        {
            try
            {
                using (var client = new HttpClient()) // Assuming IHttpClientFactory is injected
                {
                    var loginclass = _loginClass;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{_Token}:{loginclass.EMP_USERNAME}");

                    var response = await client.PostAsJsonAsync(ApiUrl + "Incident/AddIncidentCategory", _AddIncCatmodel);

                    response.EnsureSuccessStatusCode(); // Ensure 2xx status code

                    string inccatJsonString = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonConvert.DeserializeObject<IncidentCategoryModel>(inccatJsonString);

                    return Json(deserialized);
                }
            }
            catch (Exception ex)
            {
                // Log error and rethrow
                throw new Exception("Error adding incident category", ex);
            }
        }

        private async Task<JsonResult> UpdateIncidentCategory(IncidentCategoryModel _AddIncCatmodel)
        {
            try
            {
                using (var client = new HttpClient()) // Assuming IHttpClientFactory is injected
                {
                    var loginclass = _loginClass;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{_Token}:{loginclass.EMP_USERNAME}");

                    var response = await client.PutAsJsonAsync(ApiUrl + "Incident/UpdateIncidentCategory", _AddIncCatmodel);

                    response.EnsureSuccessStatusCode(); // Ensure 2xx status code

                    string inccatJsonString = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonConvert.DeserializeObject<IncidentCategoryModel>(inccatJsonString);

                    return Json(deserialized);
                }
            }
            catch (Exception ex)
            {
                // Log error and rethrow
                throw new Exception("Error updating incident category", ex);
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddIncident(IncidentModel _INCIDENT_DETAILS)
        {
            try
            {
                if (string.IsNullOrEmpty(_INCIDENT_DETAILS.INC_ID) || _INCIDENT_DETAILS.INC_ID == "0")
                {
                    var serializedModel = JsonConvert.SerializeObject(_INCIDENT_DETAILS);
                    //var response = await client.PostAsJsonAsync($"{ApiUrl}Incident/AddIncident", new StringContent(serializedModel, Encoding.UTF8, "application/json"));

                    var response = await client.PostAsJsonAsync($"{ApiUrl}Incident/AddIncident", _INCIDENT_DETAILS);
                    var incidentJsonString = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(incidentJsonString);

                    // Handle Photo Upload
                    await HandleMediaUploadAsync(client, deserialized.STATUS_CODE, "AddPhotoUpload", "ObjPhotodata");

                    // Handle Video Upload
                    await HandleMediaUploadAsync(client, deserialized.STATUS_CODE, "AddVideoUpload", "ObjVideodata");

                    return Json(deserialized);
                }
                else
                {
                    var response = await client.PutAsJsonAsync($"{ApiUrl}Incident/UpdateIncident", _INCIDENT_DETAILS);
                    var incidentJsonString = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonConvert.DeserializeObject<IncidentModel>(incidentJsonString);
                    return Json(deserialized);
                }
            }
            catch (Exception ex)
            {
                // Log error with more details if needed
                //LogError(ex, "AddIncident");
                throw;
            }
        }

        private async Task HandleMediaUploadAsync(HttpClient client, string incidentId, string action, string sessionKey)
        {
            // Retrieve the session data as a string
            var sessionData = HttpContext.Session.GetString(sessionKey);

            if (!string.IsNullOrEmpty(sessionData))
            {
                IEnumerable<object> mediaList = null;
                var PHOTOmediaList = JsonConvert.DeserializeObject<IEnumerable<UPLOAD_PHOTO_LIST>>(sessionData);
                var VIDEOmediaList = JsonConvert.DeserializeObject<IEnumerable<UPLOAD_INC_VIDEO_LIST>>(sessionData);

                if (PHOTOmediaList != null)
                {
                    mediaList = PHOTOmediaList;
                }
                else if (VIDEOmediaList != null)
                {
                    mediaList = VIDEOmediaList;
                }

                if (mediaList != null)
                {
                    // Set the INC_ID for each item
                    foreach (var item in mediaList)
                    {
                        if (item is UPLOAD_PHOTO_LIST photoItem)
                        {
                            photoItem.INC_ID = incidentId;
                        }
                        else if (item is UPLOAD_INC_VIDEO_LIST videoItem)
                        {
                            videoItem.INC_ID = incidentId;
                        }
                    }

                    // Perform the media upload
                    var mediaResponse = await client.PostAsJsonAsync($"{ApiUrl}Incident/{action}", mediaList);
                    var mediaJsonString = await mediaResponse.Content.ReadAsStringAsync();
                    var mediaDeserialized = JsonConvert.DeserializeObject<IncidentModel>(mediaJsonString);

                    // Optional: Handle or log any errors
                }
            }
        }

        public async Task<JsonResult> DeleteIncident(string INCID)
        {
            try
            {
                var response = await client.DeleteAsync($"{ApiUrl}Incident/DeleteIncident?INCID={INCID}");
                var incidentJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(incidentJsonString);
                return Json(deserialized);
            }
            catch (Exception ex)
            {
                //LogError(ex, "DeleteIncident");
                throw;
            }
        }

        public async Task<JsonResult> EditIncident(string INCID)
        {
            try
            {
                var response = await client.GetAsync($"{ApiUrl}Incident/GetIncidentEdit?INCID={INCID}");
                var incidentJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IncidentModel>(incidentJsonString);
                return Json(deserialized);
            }
            catch (Exception ex)
            {
                //LogError(ex, "EditIncident");
                throw;
            }
        }

        public async Task<JsonResult> GetReporterBy()
        {
            var loginClass = _loginClass;
            var token = _Token;
            if (string.IsNullOrEmpty(token))
            {
                return Json(new { error = "Token is missing" });
            }

            using (var client = new HttpClient()) // Consider reusing HttpClient for performance if needed
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer", $"{token}:{loginClass.EMP_USERNAME}");

                try
                {
                    HttpResponseMessage response = await client.GetAsync(ApiUrl + "Incident/GetReporterBy");
                    response.EnsureSuccessStatusCode();
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAllToken = parsedResponse["Get_All"];
                    if (getAllToken == null)
                    {
                        return Json(new List<GET_EMPLOYEE_DETAILS_REPORTABLE>());
                    }
                    var deserialized = JsonConvert.DeserializeObject<List<GET_EMPLOYEE_DETAILS_REPORTABLE>>(getAllToken.ToString());
                    return Json(deserialized);
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it or return a specific error message)
                    return Json(new { error = ex.Message });
                }
            }
        }

        public async Task<ActionResult> _ViewIncident(string INC_ID)
        {
            try
            {
                using (var client = new HttpClient()) // Creating a new HttpClient instance for each request
                {
                    IncidentModel incidentModel = new IncidentModel();
                    incidentModel.INC_ID = INC_ID;
                    var loginClass = _loginClass;
                    var token = _Token;

                    if (string.IsNullOrEmpty(token))
                    {
                        return Json(new { error = "Token is missing" });
                    }
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Bearer", $"{token}:{loginClass.EMP_USERNAME}");
                    HttpResponseMessage response = await client.GetAsync(ApiUrl + "Incident/GetIncidentView" + "?INCID=" + incidentModel.INC_ID);

                    response.EnsureSuccessStatusCode();
                    string incidentJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(incidentJsonString);
                    var getAllToken = parsedResponse["Get_All"];
                    var viewIncidentDetailsList = new VIEW_INCIDENT_DETAILS_LIST
                    {
                        VIEW_INCIDENT_DETAILS = getAllToken?["VIEW_INCIDENT_DETAILS"]?.ToObject<List<VIEW_INCIDENT_DETAILS>>(),
                        INCIDENT_TYPE_DETAILS = getAllToken?["INCIDENT_TYPE_DETAILS"]?.ToObject<List<ADQ_INCIDENT_TYPE_DETAILS>>(),
                        UPLOAD_PHOTO_LIST = getAllToken?["UPLOAD_PHOTO_LIST"]?.ToObject<List<UPLOAD_PHOTO_LIST>>(),
                        UPLOAD_INC_VIDEO_LIST = getAllToken?["UPLOAD_INC_VIDEO_LIST"]?.ToObject<List<UPLOAD_INC_VIDEO_LIST>>(),
                        STATUS = parsedResponse["STATUS"]?.ToObject<bool>() ?? false,
                        MESSAGE = parsedResponse["MESSAGE"]?.ToString()
                    };

                    AssignIncId(incidentModel.INC_ID);
                    return Json(viewIncidentDetailsList);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and log it if necessary
                return Json(new { error = ex.Message });
            }
        }

        public async Task<JsonResult> _UpdateIncidentStatus(UPDATE_INCIDENT_STATUS _UPDATE_INCIDENT_STATUS)
        {
            try
            {
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                // Setting authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                // Performing the HTTP PUT request
                var response = await client.PutAsJsonAsync($"{ApiUrl}Incident/UpdateIncidentStatus", _UPDATE_INCIDENT_STATUS);
                response.EnsureSuccessStatusCode(); // Ensures the request was successful

                // Reading and deserializing the response
                string incidentJsonString = await response.Content.ReadAsStringAsync();
                RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(incidentJsonString);
                return Json(deserialized);
            }
            catch (Exception ex)
            {
                // Log exception or handle error as needed
                // Example: _logger.//LogError(ex, "Error occurred in _UpdateIncidentStatus.");
                return Json(new { success = false, message = ex.Message });
            }
        }
        public IActionResult CategorybaseInvestigation()
        {
            try
            {
                string LanguageAbbrevation = _loginClass.LANG_ID;
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
        #endregion

        #region [INCIDENT INVESTIGATION]
        public IActionResult IncidentInvestigation(string LanguageAbbrevation, string pathName)
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

        public async Task<ActionResult> _GetIncidentInvestigationList(string STATUS_ID)
        {
            try
            {
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                // Setting authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                // Constructing the query parameters
                var url = $"{ApiUrl}Incident/GetInvestigationList" + "?STATUS_ID=" + STATUS_ID + "&EMP_LOGIN_ID=" + _loginClass.EMP_ID + "&DESI_NAME=" + _loginClass.DESI_NAME;

                // Performing the HTTP GET request
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Ensures the request was successful

                // Reading and deserializing the response
                string incidentJsonString = await response.Content.ReadAsStringAsync();
                JObject parsedResponse = JObject.Parse(incidentJsonString);
                var getAll = parsedResponse["Get_All"].ToObject<List<GET_INCIDENT_DETAILS>>();

                return PartialView(getAll);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate response
                // Example: _logger.//LogError(ex, "Error occurred in _GetIncidentList.");
                return Json(new { success = false, message = ex.Message });
            }
        }
        #endregion

        #region [EHS Alert]
        public async Task<ActionResult> _GetEHSAlertEmployee()
        {
            try
            {
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                // Setting authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );
                var response = await client.GetAsync($"{ApiUrl}Incident/GetEHSAlertIncident");
                response.EnsureSuccessStatusCode();
                string incidentJsonString = await response.Content.ReadAsStringAsync();
                JObject parsedResponse = JObject.Parse(incidentJsonString);
                var getAll = parsedResponse["Get_All"].ToObject<List<GET_INCIDENT_DETAILS>>();

                return PartialView(getAll);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate response
                // Example: _logger.//LogError(ex, "Error occurred in _GetIncidentList.");
                return Json(new { success = false, message = ex.Message });
            }
        }
        #endregion

        #region [CorrectiveAction]
        public async Task<ActionResult> _GetCorrectiveInvestList()
        {
            try
            {
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                // Setting authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );
                var url = $"{ApiUrl}Incident/GetCorrectiveInvestList" + "?LOGIN_ID=" + _loginClass.EMP_ID + "&DESIG_NAME=" + _loginClass.DESI_NAME;
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string incidentJsonString = await response.Content.ReadAsStringAsync();
                JObject parsedResponse = JObject.Parse(incidentJsonString);
                var getAll = parsedResponse["Get_All"].ToObject<List<GET_INVE_CORRECTIVE_ACTION>>();

                return PartialView(getAll);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate response
                // Example: _logger.//LogError(ex, "Error occurred in _GetIncidentList.");
                return Json(new { success = false, message = ex.Message });
            }
        }
        #endregion

        #region [InvestigationForm]
        public async Task<ActionResult> _GET_INVE_NATUREOFINJURY_LIST()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetEMRNIIDetails").Result;
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_NATURE_INJURY_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ActionResult> _GET_INVE_MECHANISMOFINJURY_LIST()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetEMRMIIDetails").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_MECH_INJURY_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> _GET_INVE_SOURCEOFINJURY_LIST()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetEMRAIIDetails").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_AGENCY_INJURY_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> _GET_INVE_BODYLOCATION_LIST()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetemrBODYLOCCATdetails").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_BODY_LOC_CAT_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> _GET_INVE_IM_CASUE_LIST()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetEMRICActDetails").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_IC_ACT_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> _GET_INVE_IM_UC_LIST()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetEMRICUCDetails").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_IC_UC_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> _GET_INVE_ROOT_PF_LIST()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetEMRRCPFDetails").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_RC_PF_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> _GET_INVE_ROOT_SF_LIST()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetEMRRCSFDetails").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_RC_SF_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> _GET_COST_ANALYSIS()
        {
            try
            {
                using (client)
                {
                    var response = client.GetAsync(ApiUrl + "Incident/GetemrINCDTCAdetails").Result;
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    JObject parsedResponse = JObject.Parse(customerJsonString);
                    var getAll = parsedResponse["Get_All"].ToObject<List<GET_EMR_INCDT_CA_DETAILS>>();
                    return PartialView(getAll);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> _ViewIncidentCategory(string INCID)
        {
            try
            {
                IncidentModel incidentModel = new IncidentModel();
                incidentModel.INC_ID = INCID;
                var loginClass = _loginClass;
                var token = _Token;

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );
                var response = await client.GetAsync($"{ApiUrl}Incident/GetIncidentView" + "?INCID=" + INCID);
                response.EnsureSuccessStatusCode();
                string incidentJsonString = await response.Content.ReadAsStringAsync();
                JObject parsedResponse = JObject.Parse(incidentJsonString);
                var getAllToken = parsedResponse["Get_All"];
                var viewIncidentDetailsList = new VIEW_INCIDENT_DETAILS_LIST
                {
                    VIEW_INCIDENT_DETAILS = getAllToken?["VIEW_INCIDENT_DETAILS"]?.ToObject<List<VIEW_INCIDENT_DETAILS>>(),
                    INCIDENT_TYPE_DETAILS = getAllToken?["INCIDENT_TYPE_DETAILS"]?.ToObject<List<ADQ_INCIDENT_TYPE_DETAILS>>(),
                    UPLOAD_PHOTO_LIST = getAllToken?["UPLOAD_PHOTO_LIST"]?.ToObject<List<UPLOAD_PHOTO_LIST>>(),
                    UPLOAD_INC_VIDEO_LIST = getAllToken?["UPLOAD_INC_VIDEO_LIST"]?.ToObject<List<UPLOAD_INC_VIDEO_LIST>>(),
                    STATUS = parsedResponse["STATUS"]?.ToObject<bool>() ?? false,
                    MESSAGE = parsedResponse["MESSAGE"]?.ToString()
                };

                AssignIncId(incidentModel.INC_ID);
                return Json(viewIncidentDetailsList);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> _GetEmployeeList(string EMP_ID, string EMP_NAME, string EMP_DESI)
        {
            try
            {
                List<GET_EMPLOYEE_DETAILS> employeeDetails = new List<GET_EMPLOYEE_DETAILS>();
                var loginClass = _loginClass;
                if (loginClass == null || string.IsNullOrEmpty(_Token))
                {
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");
                }

                string token = _Token;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}:{loginClass.EMP_USERNAME}");
                var response = await client.GetAsync($"{ApiUrl}EmployeeDetails/GetEmployeeDetails?EMP_ID={EMP_ID}&EMP_NAME={EMP_NAME}&EMP_DESI={EMP_DESI}");
                response.EnsureSuccessStatusCode();
                string incidentJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<List<GET_EMPLOYEE_DETAILS>>(incidentJsonString.ToString());
                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> INSERT_INVESTICATION([FromBody] INVESTCATION_DETAILS _INVESTCATION_DETAILS)
        {
            try
            {
                using (client)
                {
                    var response = await client.PutAsJsonAsync($"{ApiUrl}Incident/ADD_INVESTIGATION", _INVESTCATION_DETAILS);
                    response.EnsureSuccessStatusCode();

                    string incidentJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(incidentJsonString);

                    List<SITE_INSPECTION_PHOTO_LIST> objPhotodataSession;

                    var sessionData = HttpContext?.Session.GetString("SitePhotodata");

                    if (!string.IsNullOrEmpty(sessionData))
                    {
                        try
                        {
                            objPhotodataSession = JsonConvert.DeserializeObject<List<SITE_INSPECTION_PHOTO_LIST>>(sessionData) ?? new List<SITE_INSPECTION_PHOTO_LIST>();
                        }
                        catch (JsonException)
                        {
                            objPhotodataSession = new List<SITE_INSPECTION_PHOTO_LIST>();
                        }
                    }
                    else
                    {
                        objPhotodataSession = new List<SITE_INSPECTION_PHOTO_LIST>();
                    }

                    if (HttpContext?.Session.GetString("SitePhotodata") != null)
                    {
                        var ObjPhotodatasession = JsonConvert.DeserializeObject<List<SITE_INSPECTION_PHOTO_LIST>>(sessionData) ?? new List<SITE_INSPECTION_PHOTO_LIST>();

                        foreach (var item in ObjPhotodatasession)
                        {
                            item.INC_ID = _INVESTCATION_DETAILS.INCIDENT_ROOT_CAUSE[0].INC_ID;
                        }
                        var Photoresponse = await client.PutAsJsonAsync($"{ApiUrl}Incident/AddSitePhotoUpload", ObjPhotodatasession);
                        var PhotoincidentJsonString = await Photoresponse.Content.ReadAsStringAsync();
                        var Photodeserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(PhotoincidentJsonString);

                    }
                    return Json(deserialized);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        List<SITE_INSPECTION_PHOTO_LIST> SitePhotodata = new List<SITE_INSPECTION_PHOTO_LIST>();

        [HttpPost]
        public IActionResult UploadFiles(List<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count == 0)
                {
                    return Json("No Records Found");
                }

                string path = Path.Combine(_env.WebRootPath, "IncidentImageStorage");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var sitePhotoData = new List<SITE_INSPECTION_PHOTO_LIST>();
                foreach (var file in files)
                {
                    string sourceName = file.FileName;
                    var temp = sourceName.Split('.');
                    int length = temp.Length;

                    if (length <= 2)
                    {
                        string newFilename = new Regex(@"\.(?!(\w{3,4}$))").Replace(sourceName, "");
                        string fileExt = Path.GetExtension(newFilename);

                        if (fileExt == ".png" || fileExt == ".jpeg" || fileExt == ".jpg")
                        {
                            if (file.Length > 3000000) // 3 MB limit
                            {
                                return Json("File Length too Exceeded");
                            }
                        }
                        else
                        {
                            return Json("Invalid File Format");
                        }

                        string safeFileName = newFilename.Substring(0, 1) + Guid.NewGuid().ToString().Substring(0, 13) + fileExt;
                        safeFileName = GetSafeFileName(path, safeFileName);
                        string fullPath = Path.Combine(path, safeFileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        sitePhotoData.Add(new SITE_INSPECTION_PHOTO_LIST
                        {
                            INC_PHOTO_NAME = safeFileName,
                            INC_PHOTO_PATH = $"{Request.Scheme}://{Request.Host}/IncidentImageStorage/{safeFileName}",
                            INC_PHOTO_FILE_TYPE = fileExt,
                            INC_PHOTO_STATUS = "1"
                        });
                    }
                    else
                    {
                        return Json("File name mismatched");
                    }
                }

                // Store the sitePhotoData in TempData or another appropriate storage mechanism
                TempData["SitePhotodata"] = sitePhotoData;

                return Json("Photo Uploaded Successfully");
            }
            catch (Exception ex)
            {
                // Log the error
                Console.Error.WriteLine($"Error in UploadFiles: {ex.Message}");
                throw;
            }
        }

        private string GetSafeFileName(string path, string fileName)
        {
            string safeFileName = fileName;
            int counter = 1;

            while (System.IO.File.Exists(Path.Combine(path, safeFileName)))
            {
                safeFileName = Path.GetFileNameWithoutExtension(fileName) + $"({counter})" + Path.GetExtension(fileName);
                counter++;
            }

            return safeFileName;
        }

        public string FileToData(string fileData)
        {
            try
            {
                string attachmentName = "";
                if (string.IsNullOrEmpty(fileData))
                    throw new ArgumentException("File data cannot be null or empty");

                // Strip the prefix if it contains `data:`
                if (fileData.Contains("data:"))
                {
                    fileData = fileData.Replace("data:", "");
                }

                string ext = "";
                if (fileData.Contains("image/jpeg"))
                {
                    ext = ".jpeg";
                }
                else if (fileData.Contains("image/jpg"))
                {
                    ext = ".jpg";
                }
                else if (fileData.Contains("image/png"))
                {
                    ext = ".png";
                }
                else if (fileData.Contains("application/pdf"))
                {
                    ext = ".pdf";
                }
                else
                {
                    ext = ".xlsx";
                }

                // Generate unique filename
                Guid fileName = Guid.NewGuid();

                // Split the Base64 string
                var lst = Regex.Split(fileData, "base64,");
                if (lst.Length < 2)
                    throw new ArgumentException("Invalid Base64 string format.");

                byte[] byteLength = Convert.FromBase64String(lst[1]);
                int fileSize = byteLength.Length;

                // Check for file size (5MB limit)
                if (fileSize > 5000000)
                {
                    attachmentName = "100"; // File size exceeded
                }
                else
                {
                    // Path configuration for the directory
                    var imageStoragePath = Path.Combine(_env.WebRootPath, "IncidentImageStorage");
                    if (!Directory.Exists(imageStoragePath))
                    {
                        Directory.CreateDirectory(imageStoragePath);
                    }

                    // Full path to save the file
                    var fullFilePath = Path.Combine(imageStoragePath, fileName + ext);

                    // Save file to disk
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        stream.Write(byteLength, 0, byteLength.Length);
                    }

                    // Create URL to access the file
                    string incidentImageUrl = $"{Request.Scheme}://{Request.Host}/IncidentImageStorage/";
                    attachmentName = incidentImageUrl + fileName + ext;
                }

                return attachmentName;
            }
            catch (Exception ex)
            {
                // Log exception (can replace with a proper logging mechanism)
                Console.Error.WriteLine($"Error in FileToData: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region [VIEW_INVESTIGATION_DETAILS]
        public async Task<JsonResult> LOAD_INVE_REVIEW_AND_APPROVALS_LIST(string INCID)
        {
            try
            {
                //INCID = "9"
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_INVE_REVIEW_AND_APPROVALS?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<GET_EMR_REVIEW_AND_APPROVALS>(inccatJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> LOAD_INVE_EHS_ALERT_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GetAlertList?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<GET_INVE_EHS_ALERT>(inccatJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> GET_INCIDENT_TYPE_DETAILS(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GetIncidentView?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<VIEW_INCIDENT_DETAILS_LIST>(inccatJsonString);

                return Json(deserialized.INCIDENT_TYPE_DETAILS);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_IM_CASUE_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_IM_CASUSE_ACT?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_IC_ACT_DETAILS>>(inccatJsonString);
                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_IM_UC_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_IM_UC_LIST?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_IC_UC_DETAILS>>(inccatJsonString);
                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_ROOT_PF_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_ROOT_PF_LIST?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_RC_PF_DETAILS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_ROOT_SF_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_ROOT_SF_LIST?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_RC_SF_DETAILS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_IM_METHOD_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_IM_METHOD?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_VIEW_INVE_IM_METHOD>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_IM_ENVI_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_IM_ENVI?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_VIEW_INVE_IM_ENVIRONMENT>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_IM_MATERIAL_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_IM_MATERIAL?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_VIEW_INVE_IM_MATERIAL>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_NATUREOFINJURY_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_NATUREOFINJURY_LIST?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_NATURE_INJURY_DETAILS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_MECHANISMOFINJURY_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_MECHANISMOFINJURY_LIST?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_MECH_INJURY_DETAILS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_SOURCEOFINJURY_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_SOURCEOFINJURY_LIST?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_AGENCY_INJURY_DETAILS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> LOAD_INVE_BODYLOCATION_LIST(string INCID)
        {
            try
            {
                //INCID = "9"
                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_INVE_BODYLOCATION_LIST?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<GET_EMR_BODY_LOC_DETAILS>(inccatJsonString);

                return Json(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_COST_ANALYSIS(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_COST_ANALYSIS?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_INCDT_COST_ANALYSIS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_ACTION_TAKEN(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_ACTION_TAKEN?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<ACTION_TAKEN_IMMEDIATELY>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INCIDENT_ROOT_CAUSE(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_INCIDENT_ROOT_CAUSE?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<INCIDENT_ROOT_CAUSE>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_CORRECTIVE_ACTION(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_CORRECTIVE_ACTION?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<CORRECTIVE_ACTION>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INJURED_PERSON_DETAILS(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_INJURED_PERSON_DETAILS?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<INJURED_PERSONAL_DETAILS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_MEDICAL_REPORT(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_MEDICAL_REPORT?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<MEDICAL_REPORT>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> VIEW_INVE_SEQUENCE_EVENT_LIST(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_INVE_SEQUENCE_EVENT_LIST?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_SEQUENCE_EVENT>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> GET_VIEW_INVE_INTERVIEW_DETAILS(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_INVE_INTERVIEW_DETAILS?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_INTERVIEW_DETAILS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> GET_VIEW_INVE_DOCUMENT_DETAILS(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_INVE_DOCUMENT_DETAILS?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_DOCUMENT_DETAILS>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<ActionResult> GET_VIEW_INVE_NEW_SITE_INSPECTION(string INCID)
        {
            try
            {
                //INCID = "9"

                if (string.IsNullOrEmpty(_Token) || _loginClass == null)
                    throw new UnauthorizedAccessException("Token or LoginClass is missing.");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    $"{_Token}:{_loginClass.EMP_USERNAME}"
                );

                var url = $"{ApiUrl}Incident/GET_VIEW_INVE_NEW_SITE_INSPECTION?INCCATID={INCID}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string inccatJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<GET_EMR_NEW_SITE_INSPECTION>>(inccatJsonString);

                return PartialView(deserialized);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        #endregion
    }
}
