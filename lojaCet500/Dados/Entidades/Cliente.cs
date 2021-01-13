using System.ComponentModel.DataAnnotations;

namespace lojaCet500.Dados.Entidades
{
    public class Cliente
    {

        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]

        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Display(Name = "Idade")]
        public decimal Idade { get; set; }

        [Display(Name = "NIF")]
        public decimal NIF { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

    }
}
