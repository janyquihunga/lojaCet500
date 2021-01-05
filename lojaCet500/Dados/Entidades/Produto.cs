using System;
using System.ComponentModel.DataAnnotations;

namespace lojaCet500.Dados.Entidades
{
    public class Produto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Preco { get; set; }

        [Display(Name = "image")]
        public string UrlDaIamgem { get; set; }

        [Display(Name = "Última compra")]
        public DateTime UltimaCompra { get; set; }

        [Display(Name = "Última venda")]
        public DateTime UltimaVenda { get; set; }

        [Display(Name = "Disponível")]
        public bool Disponivel { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }


    }
}
