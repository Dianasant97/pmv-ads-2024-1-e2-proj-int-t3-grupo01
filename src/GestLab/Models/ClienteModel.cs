namespace GestLab.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Cnpj { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string CEP { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Logradouro { get; set; } = "";
    }
}
