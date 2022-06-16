using DomainModel.Domain.Entities;
using DomainModel.DomainCore;
using System.Threading.Tasks;

namespace DomainModel.Domain.Interface
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Pedido Add(Pedido pedido);

        void Update(Pedido pedido);

        Task<Pedido> GetAsync(int pedidoId);
    }
}