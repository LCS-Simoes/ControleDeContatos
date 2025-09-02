using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress(ErrorMessage ="O E-mail é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "Número informado é inválido")]
        public string Celular { get; set; }
        public int? UsuarioID { get; set; }
        public UsuariosModel Usuario { get; set; }  


        /*
         * Colocando o [Required] tudo o que estiver abaixo será obritatório informado
         * [EmailAdress] válida se o e-mail é válido ou não
         * [Phone] Também válida se o celulaar é válido ou não
         */
       
    }
}
