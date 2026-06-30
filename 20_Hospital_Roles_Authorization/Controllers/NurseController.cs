using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _20_Hospital_Roles_Authorization.Controllers
{
    [Authorize(Roles ="Nurse")]
    public class NurseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
