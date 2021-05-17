using EstudosFluentValidation.Models.Enums;
using System;
using System.Collections.Generic;

namespace EstudosFluentValidation.Models
{
    public class Venda
    {
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public TipoVenda Tipo { get; set; }
        public List<ItemVenda> Itens { get; set; }
    }
}
