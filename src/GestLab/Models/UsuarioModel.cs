using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GestLab.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A senha deve ser informada")]
        public string? Senha { get; set; }
        [Required(ErrorMessage = "O nome deve ser informado")]
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "O tipo de usuario deve ser informado")]
        public string? Tipo { get; set; }
    }
}
