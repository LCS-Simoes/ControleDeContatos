using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class AlterarSenhaModel
    {
        [Required(ErrorMessage = "Digite uma nova Senha")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confrime  a nova Senha")]
        [Compare("NovaSenha", ErrorMessage = "Senha é divergente da senha digitada!")] //Serve para comparar atributos
        public string ConfirmarNovaSenha { get; set; }
        public int Id {  get; set; }
    }
}
