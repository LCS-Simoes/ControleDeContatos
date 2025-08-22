using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {

            _contatoRepositorio = contatoRepositorio;
        }

        //Métodos Gets
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarRegistros();
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
