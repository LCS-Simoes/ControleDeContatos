using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuariosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuariosModel BuscarID(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuariosModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuariosModel Adicionar(UsuariosModel usuarios)
        {
            usuarios.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuarios);
            _bancoContext.SaveChanges();
            return usuarios;
        }

        public bool Apagar(int id)
        {

            UsuariosModel usuariosDB = BuscarID(id);
            if (usuariosDB == null)
            {
                throw new Exception("Ocorreu um erro ao deletar o usuário");
            }
            _bancoContext.Usuarios.Remove(usuariosDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuariosModel Atualizar(UsuariosModel usuarios)
        {
            UsuariosModel usuariosDB = BuscarID(usuarios.Id);
            if (usuariosDB == null)
            {
                throw new Exception("Ocorreu um erro ao atualizar o usuário");
            }
            
            usuariosDB.Nome = usuarios.Nome;
            usuariosDB.Email = usuarios.Email;
            usuariosDB.Login = usuarios.Login;
            usuariosDB.Perfil = usuarios.Perfil;
            usuariosDB.AlteracaoUser = DateTime.Now;

            _bancoContext.Usuarios.Update(usuariosDB);
            _bancoContext.SaveChanges();

            return usuariosDB;
        }
    }
}
