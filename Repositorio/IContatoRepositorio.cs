using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    //Métodos para o contato
    public interface IContatoRepositorio
    {

        ContatoModel BuscarID(int id);
        List<ContatoModel> BuscarRegistros();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
