using DomainModel.DomainCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain.Entities
{
    public class PedidoItem : Entity
    {
        public string Produto { get; private set; }

        public decimal PrecoUnitario { get; private set; }

        public decimal Desconto { get; private set; }

        public int Quantidade { get; private set; }

        public int ProdutoId { get; private set; }

        protected PedidoItem() {}

        public PedidoItem(int produtoId, string produto, decimal precoUnitario, decimal desconto, int quantidade = 1)
        {
            var validation = new Validation.PedidoItemValidation();
            var result = validation.Validate(this);

            if (!result.IsValid)
            {
                string erros = string.Empty;
                foreach (var item in result.Errors) erros += item.Message + ". ";
                throw new DomainException(erros);
            }

            Produto = produto;
            PrecoUnitario = precoUnitario;
            Desconto = desconto;
            Quantidade = quantidade;
            ProdutoId = produtoId;
        }

        public decimal ObterDesconto()
        {
            return Desconto;
        }

        public int ObterQuantidade()
        {
            return Quantidade;
        }

        public decimal ObterPrecoUnitario()
        {
            return PrecoUnitario;
        }

        public string ObterNomeProduto() => Produto;

        public void GravarNovoDesconto(decimal desconto)
        {
            if (desconto < 0)
            {
                throw new DomainException("Desconto inválido");
            }

            Desconto = desconto;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            if (quantidade < 0)
            {
                throw new DomainException("Quantidade inválida");
            }

            Quantidade += quantidade;
        }
    }
}
