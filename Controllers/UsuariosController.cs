using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    [PaginaUsuarioLogado]
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

        public IActionResult Editar(int id)
        {
            UsuariosModel usuarios = _usuarioRepositorio.BuscarID(id);
            return View(usuarios);
        }

        //Métodos
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuariosModel usuarios = _usuarioRepositorio.BuscarID(id);
            return View(usuarios); 
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário excluído com sucesso"; 
                }else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro na exclusão do usuário";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ops, ocorreu o seguinte erro: " + ex.Message;
                return RedirectToAction("Index");   
            }
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

        [HttpPost]
        public IActionResult Editar(UsuariosSemSenhaModel usuariosSemSenha)
        {
            try
            {
                UsuariosModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuariosModel()
                    {
                        Id = usuariosSemSenha.Id,
                        Nome = usuariosSemSenha.Nome,
                        Email = usuariosSemSenha.Email,
                        Login = usuariosSemSenha.Login,
                        Perfil = usuariosSemSenha.Perfil
                    };

                    usuario =_usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSuccesso"] = "Usuário foi editado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);

            }catch(Exception ex)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na edição, erro:" + ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
