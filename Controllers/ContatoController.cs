using ControleDeContatos.Filters;
using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaUsuarioLogado]
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepositorio contatoRepositorio, ISessao sessao)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessao = sessao;
        }

        //Métodos Gets
        public IActionResult Index()
        {
            UsuariosModel usuarioLogado = _sessao.BuscarSessaoUsuario();
            List<ContatoModel> contatos = _contatoRepositorio.BuscarRegistros(usuarioLogado.Id);
            return View(contatos);
        }


        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarID(id);
            return View(contato);
        }

        //Métodos 
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarID(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro na exclusão do contato";
                    
                }

                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = "Ops, ocorreu um erro:" + error.Message;
                return RedirectToAction("Index");
            }
            
        }

        //Métodos POST
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuariosModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                    contato.UsuarioID = usuarioLogado.Id;
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = "Ocorreu um erro no exclusão, erro:" + error.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    UsuariosModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                    contato.UsuarioID = usuarioLogado.Id;
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na edição, erro:" + error.Message;
                return RedirectToAction("Index");
            }
        }
    }
}


/* Observação
 * return View() -> Vai sempre retornar para a view do método 
 * ex: Alterar() ele vai retornar pra alterar, mesmo que não exista
 * assim dando erro
 * Resolver: return View("Nome da View", objeto)
 */
