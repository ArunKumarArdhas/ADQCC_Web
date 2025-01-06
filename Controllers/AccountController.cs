using Microsoft.AspNetCore.Mvc;
using ADQCC_New.Models;
using static ADQCC_New.Models.EmergencyModel;
using Newtonsoft.Json;
using ADQCC_New.ErrorLogs;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.Primitives;
using ADQCC_New.Common;
using static ADQCC_New.Common.CommonClass;

namespace ADQCC_New.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient client;
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("API");
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        public ActionResult LoginAccount()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return View();
            //    //var loginclass = (GET_USER_DETAILS)Session["objloginClass"];
            //    //if (loginclass.DESI_NAME == "Employee")
            //    //{
            //    //    return RedirectToAction("TrainingEmployeeDashboard", "TrainingManagement", new { LanguageAbbrevation = loginclass.LANG_ID});
            //    //}
            //    //else
            //    //{
            //    //    return RedirectToAction("AdminDashboard", "Dashboard", new { LanguageAbbrevation = loginclass.LANG_ID});
            //    //}
            //}
            //else
            //{
            return View();
            //}

            // NotificaionService.GetNotification();
        }
        [HttpPost]
        [Route("Account/LoginOTPAsync")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginOTPAsync(LOGIN _login)
        {
            try
            {

                using (var response = client.PostAsJsonAsync("Account/SEND_OTP", _login).Result)
                {
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    RETURN_MESSAGE deserialized = JsonConvert.DeserializeObject<RETURN_MESSAGE>(customerJsonString)!;
                    return Json(deserialized);
                }
            }

            catch (Exception ex)
            {
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "LoginAsync ==> " + ex.InnerException);
                //throw;
                var Repo = "LoginOTPAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return NoContent();
            }
        }

        [HttpPost]
        [Route("Account/LoginAsync")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(LOGIN _login)
        {
            try
            {
                using (var response = client.PostAsJsonAsync("Account/LOGIN", _login).Result)
                {
                    string customerJsonString = await response.Content.ReadAsStringAsync();
                    GET_USER_DETAILS_RETURN deserialized = JsonConvert.DeserializeObject<GET_USER_DETAILS_RETURN>(customerJsonString)!;
                    if (deserialized.STATUS_CODE == "200")
                    {
                        var str = Encrypt(JsonConvert.SerializeObject(deserialized.USER_DETAILS));
                        SetLocSession("LoginAccount", str);
                        SetLocSession("JWT", deserialized.USER_DETAILS!.JWT_Token!);
                        //var deserialized = (GET_USER_DETAILS_RETURN)JsonConvert.DeserializeObject(customerJsonString, typeof(GET_USER_DETAILS_RETURN));
                        var retuJson = (LOGIN_RETURN_MESSAGE)JsonConvert.DeserializeObject(customerJsonString, typeof(LOGIN_RETURN_MESSAGE));
                        retuJson.DESI_NAME = deserialized.USER_DETAILS.DESI_NAME;
                        if (deserialized.STATUS == true)
                        {
                            if (deserialized.USER_DETAILS.DESI_NAME == "ADMIN")
                            {
                                deserialized.USER_DETAILS.LANG_ID = "bo";
                                retuJson.LANG_ID = "bo";
                            }
                            else
                            {
                                deserialized.USER_DETAILS.LANG_ID = _login.LANG_ID;
                                retuJson.LANG_ID = _login.LANG_ID;
                            }
                            // HttpContext.Session.SetString["testClass"] = "SARAVANAKUMAR TEST SESSION";

                            HttpContext.Session.SetString("LIn", _login.UserName.Trim());

                            GET_USER_DETAILS objloginClass = _LoginClass(deserialized);
                            string serializedObj = JsonConvert.SerializeObject(objloginClass);
                            HttpContext.Session.SetString("objloginClass", serializedObj);


                            //var token = client.GetAsync("Token/GetToken" + "?username=" + deserialized.USER_DETAILS.EMP_USERNAME).Result;
                            //string tokenString = await token.Content.ReadAsStringAsync();
                            //var T_deserialized = (GET_TOKEN)JsonConvert.DeserializeObject(tokenString, typeof(GET_TOKEN));
                            ////HttpContext.Session["Token"] = T_deserialized.ACCESS_TOKEN;


                            //HttpContext.Session.SetString("Token", T_deserialized.ACCESS_TOKEN);
                            //HttpContext.Session.SetString("LIn", _login.UserName.Trim());

                            string guid = Guid.NewGuid().ToString();
                            HttpContext.Session.SetString("AuthToken", guid);

                            Response.Cookies.Append("AuthToken", guid, new CookieOptions
                            {
                                Expires = DateTimeOffset.UtcNow.AddHours(1), // Set expiration time (1 hour in this example)
                                HttpOnly = true,  // Makes the cookie accessible only to the server
                                Secure = true,    // Ensures the cookie is sent over HTTPS only
                                SameSite = SameSiteMode.Strict // Protects against cross-site request forgery (CSRF) attacks
                            });
                        }

                    }
                    else
                    {
                        TempData["Res"] = "Fail";
                        return View("Login");
                    }
                    return Json(deserialized);
                }
                //return Json("200");
            }


            catch (Exception ex)
            {
                 
                //Common.CommonMethods common = new Common.CommonMethods();
                //common.ErrorLog(ex.Message + "LoginAsync ==> " + ex.InnerException);
                throw;
            }
        }
        private void SetLocSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
        }

        public GET_USER_DETAILS _LoginClass(GET_USER_DETAILS_RETURN _USERDETAILS)
        {
            GET_USER_DETAILS objloginClass = new GET_USER_DETAILS
            {
                EMP_ID = _USERDETAILS.USER_DETAILS.EMP_ID,
                DISPLAY_NAME = _USERDETAILS.USER_DETAILS.DISPLAY_NAME,
                DISPLAY_NAME_AR = _USERDETAILS.USER_DETAILS.DISPLAY_NAME_AR,
                EMP_USERNAME = _USERDETAILS.USER_DETAILS.EMP_USERNAME,
                EMP_PASSWORD = _USERDETAILS.USER_DETAILS.EMP_PASSWORD,
                LANG_ID = _USERDETAILS.USER_DETAILS.LANG_ID,
                DESI_NAME = _USERDETAILS.USER_DETAILS.DESI_NAME,
                DESI_NAME_AR = _USERDETAILS.USER_DETAILS.DESI_NAME_AR,
                GENDER = _USERDETAILS.USER_DETAILS.GENDER,
                EXPIRED_DATE = _USERDETAILS.USER_DETAILS.EXPIRED_DATE,
                EMP_ENCRYPT_ID = _USERDETAILS.USER_DETAILS.EMP_ENCRYPT_ID,
            };
            return objloginClass;
        }

    }
}
