using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace SampleProject.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        //public partial class sivaEntities : DbContext
        tblRegistration _tbleobj = new tblRegistration();
        Regestation _regobj = new Regestation();
        List<int> loginff = new List<int>();
        List<tblRegistration> _obj = new List<tblRegistration>();
        /// <summary>  
        ///   
        /// insert and update user data 
        /// </summary>  
        /// <returns></returns>s  
        public ActionResult Register_userdata(tblRegistration _userdata)
        {
            _regobj.Registration_Insert(_userdata.Id,_userdata.Fullname,_userdata.Email,_userdata.PhoneNo,_userdata.Username,_userdata.Password,_userdata.Gender);
            _regobj.SaveChanges();
            return View();
        }
        public ActionResult checkuserlogin(tblRegistration _credantials) {
            /*  List<tblRegistration> i=*/
        //_regobj.checklogin(_credantials.Username,_credantials.Password);
            
            return Json(_regobj.checklogin(_credantials.Username, _credantials.Password), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult unique_Email(string Email)
        {
            //_obj = DbContext.tblRegistrations.Where(s => s.Email == email).ToList();
            //return Json(tblemaildetails, JsonRequestBehavior.AllowGet);
                  //_regobj.CheckuniqueEmail(Email);
            return Json(_regobj.CheckuniqueEmail(Email), JsonRequestBehavior.AllowGet);
        }
        public ActionResult unique_Email(long PhoneNo)
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

    }
}