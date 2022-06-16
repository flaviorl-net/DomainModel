using DomainModel.Domain.Entities;
using DomainModel.Domain.Interface;
using DomainModel.DomainCore;
using DomainModel.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DomainModelContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public PedidoRepository(DomainModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Pedido Add(Pedido pedido)
        {
            return _context.Pedido.Add(pedido).Entity;
        }

        public async Task<Pedido> GetAsync(int pedidoId)
        {
            var order = await _context
                            .Pedido
                            .Include(x => x.Endereco)
                            .FirstOrDefaultAsync(o => o.Id == pedidoId);
            if (order == null)
            {
                order = _context
                            .Pedido
                            .Local
                            .FirstOrDefault(o => o.Id == pedidoId);
            }
            if (order != null)
            {
                await _context.Entry(order)
                    .Collection(i => i.PedidoItem).LoadAsync();

                //await _context.Entry(order)
                //    .Reference(i => i.StatusPedido).LoadAsync();
            }

            return order;
        }

        public void Update(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
        }
    }
}
