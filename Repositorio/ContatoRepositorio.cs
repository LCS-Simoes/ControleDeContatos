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

        public List<ContatoModel> BuscarRegistros()
        {
            return _bancoContext.Contato.ToList(); //Listando tudo do banco de dados
        }


        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
