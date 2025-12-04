using System.ComponentModel.DataAnnotations;

namespace LojaRio40.Models
{
    public class Produto
    {
        [Display(Name = "Código do Produto")]
        public int Prodid { get; set; }
        [Display(Name = "Nome do Produto")]
        public string? Prodnome { get; set; }
        [Display(Name = "Descrição do Produto")]
        public string? Proddescr { get; set; }
    }
}
