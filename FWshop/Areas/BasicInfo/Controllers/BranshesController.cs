using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FWshop.Areas.BasicInfo.Controllers
{

    [Area("BasicInfo")]
    [Authorize]
    public class BranshesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
