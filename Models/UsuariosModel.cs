using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuariosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do usuário")]
        public string Nome  { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do usuário")]
        [EmailAddress(ErrorMessage = "O E-mail é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Selecione o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? AlteracaoUser { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.Criptografar();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.Criptografar();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0,8);
            Senha = novaSenha.Criptografar();
            return novaSenha;
        }


        /* Colocando ? após o DateTime, ele passar a não ser um item obrigatório
         * da criação de um Usuario
         */
    }
}
