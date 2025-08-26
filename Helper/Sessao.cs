using ControleDeContatos.Models;
using Newtonsoft.Json;


namespace ControleDeContatos.Helper
{
    public class Sessao : ISessao
    {

        private readonly IHttpContextAccessor _contextAccessor;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _contextAccessor = httpContext;
        }

        void ISessao.CriarSessaoUsuario(UsuariosModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado" , valor);
        }

        UsuariosModel ISessao.BuscarSessaoUsuario()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuariosModel>(sessaoUsuario);
        }

        void ISessao.RemoverSessaoUsuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

        /*
         *  Pacote utilizado para o Json: Newtonsoft.Json
         * 
         */
    }
}
