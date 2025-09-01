using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuariosRepositorio
    {
        UsuariosModel buscarInformacoes(string login, string email);
        UsuariosModel BuscarLogin(string login);
        List<UsuariosModel> BuscarTodos();
        UsuariosModel BuscarID(int id);
        UsuariosModel Adicionar(UsuariosModel usuarios);
        UsuariosModel Atualizar(UsuariosModel usuarios);
        UsuariosModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Apagar(int id);
    }
}
