using DomainModel.Domain.Enum;
using DomainModel.Domain.Eventos;
using DomainModel.Domain.ValueObjects;
using DomainModel.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Domain.Entities
{
    public class Pedido : Entity, IAggregateRoot
    {
        public DateTime Data { get; private set; }

        public Endereco Endereco { get; private set; }

        public StatusPedido StatusPedido { get; private set; }

        public string Descricao { get; private set; }

        public bool Rascunho { get; private set; }


        private readonly List<PedidoItem> _pedidoItem;

        public IReadOnlyCollection<PedidoItem> PedidoItem => _pedidoItem;

        protected Pedido() 
        {
            _pedidoItem = new List<PedidoItem>();
            Rascunho = false;
        }

        public Pedido(Endereco endereco, int tipoCartao, string numeroCartao, string numeroSegurancaCartao,
            string nomeImpressoCartao, DateTime dataExpiracaoCartao) : this()
        {
            Data = DateTime.Now;
            Endereco = endereco;
            StatusPedido = StatusPedido.Submetido;

            AdicionarPedidoIniciadoDomainEvent(tipoCartao, numeroCartao, numeroSegurancaCartao, nomeImpressoCartao, dataExpiracaoCartao);
        }

        public static Pedido NovoRascunho()
        {
            return new Pedido
            {
                Rascunho = true
            };
        }

        public void AdicionarPedidoItem(int produtoId, string nomeProduto, decimal precoUnitario, decimal desconto, int quantidade = 1)
        {
            var existePedidoPorProduto = _pedidoItem
                .Where(o => o.ProdutoId == produtoId)
                .SingleOrDefault();

            if (existePedidoPorProduto != null)
            {
                //if previous line exist modify it with higher discount  and units..

                if (desconto > existePedidoPorProduto.ObterDesconto())
                {
                    existePedidoPorProduto.GravarNovoDesconto(desconto);
                }

                existePedidoPorProduto.AdicionarQuantidade(quantidade);
            }
            else
            {
                //add validated new order item

                var pedidoItem = new PedidoItem(produtoId, nomeProduto, precoUnitario, desconto, quantidade);
                _pedidoItem.Add(pedidoItem);
            }
        }

        public void DefinirStatusAguardandoValidacao()
        {
            if (StatusPedido == StatusPedido.Submetido)
            {
                AddDomainEvent(new PedidoAlteradoParaAguardandoValidacaoDomainEvent(Id, _pedidoItem));
                StatusPedido = StatusPedido.AguardandoValidacao;
            }
        }

        public void DefinirStatusEstoqueConfirmado()
        {
            if (StatusPedido == StatusPedido.AguardandoValidacao)
            {
                AddDomainEvent(new PedidoAlteradoParaEstoqueConfirmadoDomainEvent(Id));

                StatusPedido = StatusPedido.EstoqueConfirmado;
                Descricao = "Todos os itens foram confirmados com estoque disponível.";
            }
        }

        public void DefinirStatusPago()
        {
            if (StatusPedido == StatusPedido.EstoqueConfirmado)
            {
                AddDomainEvent(new PedidoAlteradoParaPagoDomainEvent(Id, PedidoItem));

                StatusPedido = StatusPedido.Pago;
                Descricao = "O pagamento foi realizado em uma conta bancária simulada";
            }
        }

        public void DefinirStatusEnviado()
        {
            if (StatusPedido != StatusPedido.Enviado)
            {
                StatusAlteradoException(StatusPedido.Enviado);
            }

            StatusPedido = StatusPedido.Enviado;
            Descricao = "O pedido foi enviado.";

            AddDomainEvent(new PedidoEnviadoDomainEvent(this));
        }

        public void DefinirStatusCancelado()
        {
            if (StatusPedido == StatusPedido.Pago ||
                StatusPedido == StatusPedido.Enviado)
            {
                StatusAlteradoException(StatusPedido.Cancelado);
            }

            StatusPedido = StatusPedido.Cancelado;
            Descricao = $"O pedido foi cancelado.";

            AddDomainEvent(new PedidoCanceladoDomainEvent(this));
        }

        public void DefinirStatusCanceladoQuandoEstoqueRejeitado(IEnumerable<int> orderStockRejectedItems)
        {
            if (StatusPedido == StatusPedido.AguardandoValidacao)
            {
                StatusPedido = StatusPedido.Cancelado;

                var produtosRejeitadosEmEstoque = PedidoItem
                    .Where(c => orderStockRejectedItems.Contains(c.ProdutoId))
                    .Select(c => c.ObterNomeProduto());

                var itemsStockRejectedDescription = string.Join(", ", produtosRejeitadosEmEstoque);
                Descricao = $"Os itens do produto não têm estoque: ({itemsStockRejectedDescription}).";
            }
        }

        private void AdicionarPedidoIniciadoDomainEvent(int cardTypeId, string cardNumber,
                string cardSecurityNumber, string cardHolderName, DateTime cardExpiration)
        {
            var pedidoIniciadoDomainEvent = new PedidoIniciadoDomainEvent(this, cardTypeId,
                                                                        cardNumber, cardSecurityNumber,
                                                                        cardHolderName, cardExpiration);

            this.AddDomainEvent(pedidoIniciadoDomainEvent);
        }

        private void StatusAlteradoException(StatusPedido orderStatusToChange)
        {
            throw new DomainException($"Não é possível alterar o status do pedido de {StatusPedido.ToString()} para {orderStatusToChange}.");
        }

        public decimal ObterTotal()
        {
            return _pedidoItem.Sum(o => o.ObterQuantidade() * o.ObterPrecoUnitario());
        }
    }
}
