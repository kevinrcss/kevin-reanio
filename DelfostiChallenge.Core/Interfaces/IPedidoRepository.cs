using DelfostiChallenge.Core.Entities;

namespace DelfostiChallenge.Core.Interfaces
{
    public interface IPedidoRepository
    {
        Task<PedidoEntity> CreateAsync(PedidoEntity entity);
        Task<bool> UpdateAsync(PedidoEntity entity);
        Task<PedidoEntity> GetByIdAsync(int id);
    }
}
