using System.ComponentModel.DataAnnotations;

namespace CRUDUsuariosStoredProcedure.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Sobrenome!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite o Email!"),
        EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Cargo!")]
        public string Cargo { get; set; }
    }
}
