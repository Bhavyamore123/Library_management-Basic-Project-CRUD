using _1_Library_Model.Models;
using _2_Library_Interface.Interfaces;
using Library_Management.Authorize_user_authentication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management.Controllers
{
    
    public class Login_Controller : Controller
    {
       
        public string Session_Email_ID = null;
        public string Session_Password = null;
        public string Session_UserName = null;
       

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginView()
        {
            return View();
        }

        Login_Interface ILogin;
        public Login_Controller(Login_Interface init)
        {
            ILogin = init;
        }
        public ActionResult CheckAuthentication(Login_Model model)
        {


            if (string.IsNullOrEmpty(model.Login_Email))
            {
                TempData["ErrorMessage"] = "Please enter your email address.";
                return RedirectToAction("LoginView");
            }

            if (string.IsNullOrEmpty(model.Login_Password))
            {
                TempData["ErrorMessage"] = "Please enter your password.";
                return RedirectToAction("LoginView");
            }

            DataTable dt = ILogin.GetLoginData(model);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Login_Email_ID = dt.Rows[0]["Login_Email"].ToString();
                    string Login_Password = dt.Rows[0]["Login_Password"].ToString();
                    string Login_Username = dt.Rows[0]["Login_Username"].ToString();

                    // ✅ Verify password from DB with entered password
                    if (Login_Email_ID == model.Login_Email && Login_Password == model.Login_Password)
                    {
                        Session.Add("Session_Email_ID", Login_Email_ID);
                        Session.Add("Session_Password", Login_Password);
                        Session.Add("Session_UserName", Login_Username);

                        return RedirectToAction("LibraryBookView", "Library_Book_");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Incorrect password.";
                        return RedirectToAction("LoginView");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Incorrect email or password.";
                    return RedirectToAction("LoginView");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
                return RedirectToAction("LoginView");
            }


        }
        public ActionResult Logout()
        {
            // Clear everything stored in session
            Session.Clear();
            Session.Abandon();

            // Optional: Clear authentication cookie if you’re using FormsAuth
            // FormsAuthentication.SignOut();

            // Redirect back to login page
            return RedirectToAction("LoginView", "Login_");
        }
    }
}