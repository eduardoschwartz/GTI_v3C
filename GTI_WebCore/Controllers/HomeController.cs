using GTI_WebCore.Interfaces;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GTI_WebCore.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }

       public ActionResult Certidao() {
            return View();
        }

    }
}