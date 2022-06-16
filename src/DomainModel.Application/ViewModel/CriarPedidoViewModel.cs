using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Application.ViewModel
{
    public class CriarPedidoViewModel
    {
        public string Produto { get; set; }

        public decimal PrecoUnitario { get; set; }

        public decimal Desconto { get; set; }

        public int Quantidade { get; set; }

        public string Rua { get; set; }
        
        public string Cidade { get; set; }
        
        public string Estado { get; set; }
        
        public string Pais { get; set; }
        
        public string CEP { get; set; }

        public int TipoCartao { get; set; }

        public string NumeroCartao { get; set; }

        public string NumeroSegurancaCartao { get; set; }

        public string NomeImpressoCartao { get; set; }

        public DateTime DataExpiracaoCartao { get; set; }

    }
}
