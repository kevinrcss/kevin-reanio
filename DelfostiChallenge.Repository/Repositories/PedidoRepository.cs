using DelfostiChallenge.Core.Entities;
using DelfostiChallenge.Core.Interfaces;
using DelfostiChallenge.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DelfostiChallenge.Repository.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;

        #region Constructor
        public PedidoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

        public async Task<PedidoEntity> CreateAsync(PedidoEntity entity)
        {
            using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _appDbContext.Add(entity);
                    await _appDbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return await Task.FromResult(entity);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                finally { transaction.Dispose(); }
            }
        }

        public async Task<bool> UpdateAsync(PedidoEntity entity)
        {
            using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _appDbContext.Update(entity);
                    bool result = await _appDbContext.SaveChangesAsync() > 0;
                    await transaction.CommitAsync();
                    return result;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<PedidoEntity> GetByIdAsync(int id)
        {
            return await _appDbContext.Pedidos
                .Include(p => p.PedidoDetalles)
                .ThenInclude(d => d.Producto)
                .Include(p => p.Vendedor)
                .Include(p => p.Repartidor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
