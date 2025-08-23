using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuariosRepositorio
    {
        List<UsuariosModel> BuscarTodos();
        UsuariosModel BuscarID(int id);
        UsuariosModel Adicionar(UsuariosModel usuarios);
        UsuariosModel Atualizar(UsuariosModel usuarios);
        bool Apagar(int id);
    }
}
