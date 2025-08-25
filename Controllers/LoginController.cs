using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index","Home"); //Index da ControllerHome
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ops não conseguimos realizar o login, detalhe erro:" + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
} 
