using MC.BusinessAccess.Interface;
using MC.Entities;
using MC.Web.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MC.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        private readonly IAdminUserBusinessAccess _userService;


        public LoginController()
        {

        }
        public LoginController(IAdminUserBusinessAccess userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }

        #region HTTP POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public ActionResult Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userService.GetUserByEmail(model.Username);
                    // ModelState.AddModelError("UserName", user.Email);
                    if (user != null)
                    {
                        if (user.Password.Equals(model.Password))
                        {

                            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel
                            {
                                UserId = user.UserId,
                                UserName = user.UserName,
                                FirstName = "",
                                LastName = "",
                                roles = new string[] { "Admin" }
                            };
                            Session["UserId"] = user.UserId;
                            Session["UserRoleId"] = user.UserRoleId;
                            string userData = JsonConvert.SerializeObject(serializeModel);
                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);

                            string encTicket = FormsAuthentication.Encrypt(authTicket);
                            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                            Response.Cookies.Add(faCookie);

                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        }
                    }
                    ModelState.AddModelError("Password", "Incorrect username and/or password");
                    return View("Index", model);
                }
                else
                {
                    return View("Index", model);
                }

            }
            catch (Exception ex)
            {
                //ExceptionLogger.LogError("Exception Message: " + ex.Message, string.IsNullOrEmpty(Convert.ToString(Session["UserId"])) ? null : Convert.ToString(Session["UserId"]));
                return RedirectToAction("Index", "Error");
            }

        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login", null);
        }

        #endregion

    }
}