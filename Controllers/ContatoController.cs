using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _contatoRepositorio;

       public ContatoController(IContatoRepositorio contatoRepositorio) {

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
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarID(id);
            return View(contato);
        }


        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        //Métodos POST
        [HttpPost] //Assinando como post
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index"); //Retornando para a page Index
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

    }
}
