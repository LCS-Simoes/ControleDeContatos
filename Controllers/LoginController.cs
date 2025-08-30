using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuariosRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;


        public LoginController(IUsuariosRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            /* Se o usuário tiver logado,  redicionar para a tela inicia */
            if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Redefinir()
        {
            return View();
        }

        public IActionResult Deslogar()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index","Login");

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
                            _sessao.CriarSessaoUsuario(usuarios);
                            return RedirectToAction("Index", "Home"); //Index da ControllerHome
                        }
                        TempData["MensagemErro"] = $"Senha inválida. Por favor, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente. ";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ops não conseguimos realizar o login, detalhe erro:" + ex.Message;
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult EnviarRedefinicao(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuariosModel usuarios = _usuarioRepositorio.buscarInformacoes(redefinirSenhaModel.Login, redefinirSenhaModel.Email);
                    if (usuarios != null)
                    {
                        string novaSenha = usuarios.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuarios.Email, "Sistema de contatos: Redefinir senha.", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuarios);
                            TempData["MensagemSucesso"] = "Enviamos uma nova senha em seu e-mail cadastrado.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o e-mail. Por favor, tente novamente.";
                        }
                            return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = $"Login e/ou E-mail inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ops não conseguimos redefinir sua senha, tente novamente, detalhe erro:" + ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
} 
