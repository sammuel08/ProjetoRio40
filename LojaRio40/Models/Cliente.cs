using System.ComponentModel.DataAnnotations;

namespace LojaRio40.Models
{
    public class Cliente
    {
        [Display(Name = "CPF do Cliente")]
        public string ? CPF { get; set; }
        [Display(Name = "Nome do Cliente")]
        public string ? Nome { get; set; }
        [Display(Name = "Endereço do Cliente")]
        public string ? Endereco { get; set; }
    }
}
