using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuariosRepositorio _usuarioRepositorio;


        public LoginController(IUsuariosRepositorio usuarioRepositorio  )
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

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
                    UsuariosModel usuarios = _usuarioRepositorio.BuscarLogin(loginModel.Login);
                    if (usuarios != null)
                    {
                        if (usuarios.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home"); //Index da ControllerHome
                        }
                        TempData["MensagemErro"] = $"Senha inválida. Por favor, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
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
