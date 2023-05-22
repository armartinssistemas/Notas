using Microsoft.AspNetCore.Mvc;

namespace EF_MVC_Notas2.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
