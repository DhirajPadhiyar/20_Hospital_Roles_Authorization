using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _20_Hospital_Roles_Authorization.Controllers
{
    [Authorize(Roles ="Receptionist")]
    public class ReceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
