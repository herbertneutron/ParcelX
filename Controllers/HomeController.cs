using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using ParcelX.Models;
using System.IO;

namespace ParcelX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private string   Feedback = "Response('{0}','{1}','{2}');";

        private readonly ParcelXContext parcelxcontext;

        const string SessionUser = "";

        private static string GenerateWalletID()
        {
            Random generator = new Random();
            String r = generator.Next(0, 100000000).ToString("D7");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateWalletID();
            }
            return r;
        }


        public HomeController(ILogger<HomeController> logger, ParcelXContext context)
        {
            _logger = logger;

            parcelxcontext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WebApp()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult PartnerLogin()
        {
            return View();
        }
        public IActionResult VerifyMobile()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Partner()
        {
            return View();
        }
        
        public IActionResult RegisterPartner()
        {
            return View();
        }


        public IActionResult App()
        {

            //if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionUser)))
            //{
            //    HttpContext.Session.Clear();
            
            //    return View("~/Pages/Login.cshtml");
            //}

           return View(); 
        }
        
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }



        [HttpPost]
        public IActionResult RegisterCus(UserData data)
        {
            var Member = new ParcelXCusModel();

            bool CheckEmail      = parcelxcontext.Px_Customers.Where(c => c.User_Email == data.Email).Any();
            bool CheckUserMobile = parcelxcontext.Px_Customers.Where(c => c.Phone_Number == data.Mobile_Number).Any();

            if ((CheckEmail != true) & (CheckUserMobile != true))
            {


                Member.FirstName        = data.FirstName;
                Member.LastName         = data.LastName;
                Member.Phone_Number     = data.Mobile_Number;
                Member.User_Email       = data.Email;
                Member.Password         = data.Password;
                Member.Enabled          = "NO";
                Member.CreatedOn_Date   = DateTime.Now;
                Member.UpdatedOn_Date   = DateTime.Now;

                parcelxcontext.Add(Member);
                parcelxcontext.SaveChanges();

                //ViewBag.ErrorMessage = string.Format(  Feedback, "Congratulation!", "Your account has been created", "success");
                return View("~/Pages/Shared/VerifyMobile.cshtml") ;
            }
            else if (CheckEmail)
            {
                ViewBag.ErrorMessage = string.Format(  Feedback, "", "This email already exists", "");

                return View("~/Pages/Shared/Register.cshtml");
            }
            else if (CheckUserMobile)
            {
                ViewBag.ErrorMessage = string.Format(  Feedback, "", "The mobile number provided is already linked to an existing account.", "");

                return View("~/Pages/Shared/Register.cshtml");
            }


            return View("~/Pages/Shared/Login.cshtml");
        }


        [HttpPost]
        public IActionResult CheckExistCus([FromBody]UserData data)
        {

            var DbResponse = "";


            var Member = new ParcelXCusModel();
            List<CheckExistResponse> ExistsResponse = new List<CheckExistResponse>();

            bool CheckEmail = parcelxcontext.Px_Customers.Where(c => c.User_Email == data.Email).Any();
            bool CheckUserMobile = parcelxcontext.Px_Customers.Where(c => c.Phone_Number == data.Mobile_Number).Any();

            if (CheckEmail)
            {
                DbResponse = "EE";
            }
            else if (CheckUserMobile)
            {
                DbResponse = "ME";
            }

            return Json(new { success = true, ExistsResponse = DbResponse });
        }


        [HttpPost]
        public IActionResult LoginCus(UserData data)
        {
            //HttpContext.Session.SetString(SessionUser, " "); ;

            var Member = new ParcelXCusModel();

            var entry = parcelxcontext.Px_Customers.Where(c => c.User_Email.Equals(data.Email) && c.Password.Equals(data.Password)).FirstOrDefault();


            if (entry != null)
            {
                //var User = entry.FirstName + " " + entry.LastName;

                //HttpContext.Session.SetString(SessionUser, User);

                //ViewBag.User = HttpContext.Session.GetString(SessionUser);

                return View("~/Pages/Shared/Profile.cshtml", entry);
            }
            else
            {
                ViewBag.ErrorMessage = string.Format(Feedback, "", "invalid data provided", "");

            }


            return View("~/Pages/Shared/Login.cshtml");
        }


        [HttpPost]
        public IActionResult RegisterPar(UserData data)
        {
            var Member = new ParcelXParModel();

            bool CheckEmail = parcelxcontext.Px_Partners.Where(c => c.Business_Email == data.Email).Any();
            bool CheckUserMobile = parcelxcontext.Px_Partners.Where(c => c.Phone_Number == data.Mobile_Number).Any();

            if ((CheckEmail != true) & (CheckUserMobile != true))
            {

                Member.Business_Name = data.BusinessName;
                Member.Phone_Number = data.PartnerMobile;
                Member.Business_Email = data.PartnerEmail;
                Member.Password = data.PartnerPassword;
                Member.Partner_Status = "PENDING";
                Member.Created_Date = DateTime.Now;
                Member.Last_Updated_On = DateTime.Now;
                Member.Last_Updated_By = "SYSTEM";

                parcelxcontext.Add(Member);
                parcelxcontext.SaveChanges();

                //ViewBag.ErrorMessage = string.Format(  Feedback, "Congratulation!", "Your account has been created", "success");
                return View("~/Pages/Shared/PartnerLogin.cshtml");
            }
            else if (CheckEmail)
            {
                ViewBag.ErrorMessage = string.Format(Feedback, "", "This email already exists", "");

                return View("~/Pages/Shared/RegisterPartner.cshtml");
            }
            else if (CheckUserMobile)
            {
                ViewBag.ErrorMessage = string.Format(Feedback, "", "The mobile number provided is already linked to an existing account.", "");

                return View("~/Pages/Shared/RegisterPartner.cshtml");
            }


            return View("~/Pages/Shared/RegisterPartner.cshtml");
        }


        [HttpPost]
        public IActionResult CheckExistPar([FromBody] UserData data)
        {

            var DbResponse = "";


            var Member = new ParcelXParModel();
            List<CheckExistResponse> ExistsResponse = new List<CheckExistResponse>();

            bool CheckEmail = parcelxcontext.Px_Partners.Where(c => c.Business_Email == data.Email).Any();
            bool CheckUserMobile = parcelxcontext.Px_Partners.Where(c => c.Phone_Number == data.Mobile_Number).Any();

            if (CheckEmail)
            {
                DbResponse = "EE";
            }
            else if (CheckUserMobile)
            {
                DbResponse = "ME";
            }

            return Json(new { success = true, ExistsResponse = DbResponse });
        }


        [HttpPost]
        public IActionResult LoginPar(UserData data)
        {
            //HttpContext.Session.SetString(SessionUser, " "); ;

            var Member = new ParcelXParModel();

            var entry = parcelxcontext.Px_Partners.Where(c => c.Business_Email.Equals(data.Email) && c.Password.Equals(data.Password)).FirstOrDefault();


            if (entry != null)
            {
                //var User = entry.FirstName + " " + entry.LastName;

                //HttpContext.Session.SetString(SessionUser, User);

                //ViewBag.User = HttpContext.Session.GetString(SessionUser);

                return View("~/Pages/Shared/Partner.cshtml", entry);
            }
            else
            {
                ViewBag.ErrorMessage = string.Format(Feedback, "", "invalid data provided", "");

            }


            return View("~/Pages/Shared/PartnerLogin.cshtml");
        }

        [HttpPost]
        public IActionResult UpdateBDReg(UserData data)
        {
            if(data.HasBike != null) { data.HasBike = "Motor Cycle"; } else { data.HasBike = " "; }
            if (data.HasSmallvan != null) { data.HasSmallvan = "Small Van"; } else { data.HasSmallvan = " "; }
            if (data.HasBigvan != null) { data.HasBigvan = "Big Van"; } else { data.HasBigvan = " "; }

            var Vehicle = $"{data.HasBike},{data.HasSmallvan},{data.HasBigvan}";
            var Member  = new ParcelXParModel();

            var entry = parcelxcontext.Px_Partners.Where(c => c.Business_Name == data.BusinessName).FirstOrDefault();

            if (entry != null)
            {

                entry.Business_Address = data.Business_Address;
                entry.Operating_Area   = data.Operating_Area;
                entry.Storage_Abilty   = data.Storage_Abilty;
                entry.International    = data.International;
                entry.Interstate       = data.Interstate;
                entry.Express_Delivery = data.Express_Delivery;
                entry.Sameday_Delivery = data.Sameday_Delivery;
                if (entry.Partner_Status == "DOCUMENT AND ACCOUNT UPDATED") { entry.Partner_Status = "ACTIVE"; }
                else { entry.Partner_Status = "BUSINESS DATA UPDATED"; }
                entry.Vehicle_Type     = Vehicle;
                entry.Last_Updated_On  = DateTime.Now;
                entry.Last_Updated_By  = data.BusinessName;

                parcelxcontext.SaveChanges();

                //ViewBag.ErrorMessage = string.Format(  Feedback, "Congratulation!", "Your account has been created", "success");
                return View("~/Pages/Shared/Partner.cshtml",entry);
            }
            

            return View("~/Pages/Shared/Partner.cshtml", data);
        }

        [HttpPost]
        public IActionResult UpdateDSReg(UserData data)
        {

            var Member = new ParcelXParModel();

            var entry = parcelxcontext.Px_Partners.Where(c => c.Business_Name == data.BusinessName).FirstOrDefault();

            if (entry != null)
            {

                entry.Business_Type = data.Business_Type;
                entry.Address_Doc = data.Address_Doc;
                entry.CAC_Doc = data.CAC_Doc;
                entry.Memorandom_Doc = data.Memorandom_Doc;
                entry.ID_Doc = data.ID_Doc;
                entry.Settlement_Account = $"{data.Bank},{data.Account_Type},{data.AccountNumber}";
                if(entry.Partner_Status == "BUSINESS DATA UPDATED") { entry.Partner_Status = "ACTIVE"; }
                else { entry.Partner_Status = "DOCUMENT AND ACCOUNT UPDATED"; }
                entry.Last_Updated_On = DateTime.Now;
                entry.Last_Updated_By = data.BusinessName;

                parcelxcontext.SaveChanges();

                //ViewBag.ErrorMessage = string.Format(  Feedback, "Congratulation!", "Your account has been created", "success");
                return View("~/Pages/Shared/Partner.cshtml", entry);
            }


            return View("~/Pages/Shared/Partner.cshtml", data);
        }

        public static string ConvertToBase64(string path)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
