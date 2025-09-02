using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        /* 
        readonly é somente para leitura, variaveis privadas só da classe
        pode utilizar _ de inicio
        
         */


        private readonly BancoContext _bancoContext;


        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel BuscarID(int id)
        {
            return _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
        }


        public List<ContatoModel> BuscarRegistros(int usuarioID)
        {
            return _bancoContext.Contato.Where(x => x.UsuarioID == usuarioID).ToList(); 
        }


        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }


        public bool Apagar(int id)
        {
            ContatoModel contatoDB = BuscarID(id);
            if (contatoDB == null)
            {
                throw new Exception("Ocorreu um erro ao deletar o contato");
            }
            _bancoContext.Contato.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarID(contato.Id);
            if(contatoDB == null)
            {
                throw new Exception("Ocorreu um erro ao atualizar");
            }

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contato.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }
    }
}
