namespace GestLab.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Cor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public bool Utilizado { get; set; }
        public string Tipo { get; set; } //Lente-Armação
    }
}
