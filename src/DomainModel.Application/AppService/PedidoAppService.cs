using AutoMapper;
using DomainModel.Application.Interface;
using DomainModel.Application.ViewModel;
using DomainModel.Domain.Entities;
using DomainModel.Domain.Interface;
using DomainModel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Application.AppService
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IMapper _mapper;
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoAppService(IMapper mapper,
            IPedidoService pedidoService,
            IPedidoRepository pedidoRepository)
        {
            _mapper = mapper;
            _pedidoService = pedidoService;
            _pedidoRepository = pedidoRepository;
        }

        public void CriarPedido(CriarPedidoViewModel viewModel)
        {
            var endereco = new Endereco(viewModel.Rua, viewModel.Cidade, viewModel.Estado, viewModel.Pais, viewModel.CEP);
            var entity = new Pedido(endereco, viewModel.TipoCartao, viewModel.NumeroCartao, viewModel.NumeroSegurancaCartao,
                viewModel.NomeImpressoCartao, viewModel.DataExpiracaoCartao);

            entity.DefinirStatusEnviado();

            entity.AdicionarPedidoItem(0, viewModel.Produto, viewModel.PrecoUnitario, viewModel.Desconto, viewModel.Quantidade);

            _pedidoRepository.Add(entity);
        }

        /// <summary>
        /// Criar Pedido passando pelo Serviço de Dominio
        /// </summary>
        /// <param name="criarPedidoViewModel"></param>
        public void CriarPedidoServiceDomain(CriarPedidoViewModel viewModel)
        {
            var endereco = new Endereco(viewModel.Rua, viewModel.Cidade, viewModel.Estado, viewModel.Pais, viewModel.CEP);
            var entity = new Pedido(endereco, viewModel.TipoCartao, viewModel.NumeroCartao, viewModel.NumeroSegurancaCartao, 
                viewModel.NomeImpressoCartao, viewModel.DataExpiracaoCartao);

            entity.DefinirStatusEnviado();

            entity.AdicionarPedidoItem(0, viewModel.Produto, viewModel.PrecoUnitario, viewModel.Desconto, viewModel.Quantidade);

            _pedidoService.CriarPedido(entity);
        }
    }
}
