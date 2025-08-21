using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    //Métodos para o contato
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarRegistros();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
