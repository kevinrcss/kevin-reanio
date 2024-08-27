using DelfostiChallenge.Core.Entities;
using DelfostiChallenge.Core.Interfaces;
using DelfostiChallenge.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelfostiChallenge.Repository.Repositories
{
    public class SecuenciaRepository : ISecuenciaRepository
    {
        private readonly AppDbContext _context;

        #region Constructor
        public SecuenciaRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<int> GetNextSequenceValueAsync(string sequenceName)
        {
            var sequence = await _context.Secuencias
                .FirstOrDefaultAsync(s => s.Nombre == sequenceName);

            if (sequence == null)
            {
                sequence = new SecuenciaEntity { Nombre = sequenceName, UltimoValor = 0 };
                _context.Secuencias.Add(sequence);
            }

            sequence.UltimoValor++;
            await _context.SaveChangesAsync();

            return sequence.UltimoValor;
        }

    }
}
