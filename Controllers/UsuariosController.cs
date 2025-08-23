using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IUsuariosRepositorio _usuarioRepositorio;

        public UsuariosController(IUsuariosRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuariosModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuariosModel usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuarios);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuarios);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ocorreu um erro ao cadastrar um usuário detalhe do erro: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
