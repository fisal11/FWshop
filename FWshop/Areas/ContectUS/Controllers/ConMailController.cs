using FWshop.Areas.ContectUS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

namespace FWshop.Areas.ContectUS.Controllers
{
    [Area("ContectUS")]
    [Authorize]
    public class ConMailController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(ConMail conMail)
        {
            try {

                SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("Email", "Password");
                smtp.Send("Email", "Email resever",conMail.Title,conMail.Message);

                TempData["Mess"] = "Mail Sent Successfully";
                return RedirectToAction("Index");   
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
