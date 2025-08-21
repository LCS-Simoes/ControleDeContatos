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

        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        //Métodos POST
        [HttpPost] //Assinando como post
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index"); //Retornando para a page Index
        }

    }
}
