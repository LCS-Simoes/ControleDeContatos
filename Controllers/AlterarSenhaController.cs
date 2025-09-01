using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuariosRepositorio usuariosRepositorio, ISessao sessao)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuariosModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    
                    _usuariosRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso";
                    return View("Index", alterarSenhaModel);
                }
                TempData["MensagemErro"] = "Ocorreu um erro na alteração da senha do usuário";
                return View("Index", alterarSenhaModel);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ops, ocorreu o seguinte erro: " + ex.Message;
                return View("Index", alterarSenhaModel);
            }
            
        }
    }
}
