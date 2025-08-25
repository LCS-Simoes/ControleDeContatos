using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuariosRepositorio
    {
        UsuariosModel BuscarLogin(string login);
        List<UsuariosModel> BuscarTodos();
        UsuariosModel BuscarID(int id);
        UsuariosModel Adicionar(UsuariosModel usuarios);
        UsuariosModel Atualizar(UsuariosModel usuarios);
        bool Apagar(int id);
    }
}
