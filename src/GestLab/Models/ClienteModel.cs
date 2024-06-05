using System.ComponentModel.DataAnnotations.Schema;

namespace GestLab.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public string Cnpj { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Email { get; set; }
        public string Telefone { get; set; } = "";
        public string CEP { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Logradouro { get; set; } = "";
        public virtual UsuarioModel Usuario { get; set; }
    }
}
