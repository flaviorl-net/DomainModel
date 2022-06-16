using DomainModel.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Application.ViewModel
{
    public class PedidoViewModel
    {
        public string Produto { get; set; }

        public decimal PrecoUnitario { get; set; }

        public decimal Desconto { get; set; }

        public int Quantidade { get; set; }

        public StatusPedido StatusPedido { get; set; }

        public string Descricao { get; set; }
    }
}
