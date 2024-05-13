using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GestLab.Models
{
    public class ProdutoViewModel
    {
        public IEnumerable<SelectListItem> Cores { get; set; }
        public IEnumerable<SelectListItem> Tipos { get; set; }
        public string Cor { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        [Range(1, 40)]
        public int Quantidade { get; set; }
    }
}
