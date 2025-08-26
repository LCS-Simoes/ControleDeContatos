using ControleDeContatos.Models;

namespace ControleDeContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuariosModel usuario);
        void RemoverSessaoUsuario();
        UsuariosModel BuscarSessaoUsuario();
        
    }
}
