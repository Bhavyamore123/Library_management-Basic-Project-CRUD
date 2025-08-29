using _1_Library_Model.Models;
using _2_Library_Interface.Interfaces;
using Library_Management.Authorize_user_authentication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Library_Management.Controllers
{
    [Authorize_User_]
    public class Library_Book_Controller : Controller
    {

        Library_Book_Interface ILibrary;
        public Library_Book_Controller(Library_Book_Interface library)
        {
            ILibrary = library;
        }
      
        
        public ActionResult LibraryBookView()
        {
            string email = Session["Session_Email_ID"]?.ToString();

            if (email == null)
            {
                // user not logged in
                return RedirectToAction("LoginView", "Login_");
            }
           
            Library_Book_Model model = new Library_Book_Model();
            return View(model);
        }
        public ActionResult GetLibraryBookView() 
        {
            DataTable dt = ILibrary.GetLibraryData();
            var LibraryList = new List<Library_Book_Model>();
            for(int i = 0; i< dt.Rows.Count; i++)
            {
                Library_Book_Model model = new Library_Book_Model()
                {
                    BookId = Convert.ToInt32(dt.Rows[i]["BookId"]),
                    Title = dt.Rows[i]["Title"].ToString(),
                    Author = dt.Rows[i]["Author"].ToString(),
                    ISBN = dt.Rows[i]["ISBN"].ToString(),
                    Category = dt.Rows[i]["Category"].ToString(),
                };
                LibraryList.Add(model);
            }
            return View(LibraryList);
        }

        public ActionResult SaveorUpdate(Library_Book_Model model)
        {
            if (!ModelState.IsValid) 
            {
                return View("LibraryBookView", model); 
            }
            else
            { 
                int responce = ILibrary.PostData(model);
            }
           
            return RedirectToAction("LibraryBookView");
        }
        public ActionResult LibraryBookViewEdit(int ID)
        {
            DataTable dt = ILibrary.LibraryBookViewEdit(ID);
            Library_Book_Model model = new Library_Book_Model()
            {
                BookId = Convert.ToInt32(dt.Rows[0]["BookId"]),
                Title = dt.Rows[0]["Title"].ToString(),
                Author = dt.Rows[0]["Author"].ToString(),
                ISBN = dt.Rows[0]["ISBN"].ToString(),
                Category = dt.Rows[0]["Category"].ToString(),
            };
            return View("LibraryBookView",model);

        }
        public ActionResult LibraryBookDelete(int ID)
        {
            ILibrary.LibraryBookViewDelete(ID);
            return RedirectToAction("GetLibraryBookView");
        }
    }
}