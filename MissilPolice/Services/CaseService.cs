using Microsoft.EntityFrameworkCore;
using MissilPolice.Data;
using MissilPolice.Models;

namespace MissilPolice.Services
{
    public class CaseService
    {
        private readonly AppDbContext _context;

        public CaseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fir>> GetRecentCasesAsync()
        {
            try
            {
                return await _context.Firs
                    .Include(f => f.AccusedList)
                    .OrderByDescending(f => f.FIRID)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cases: {ex.Message}");
                return new List<Fir>();
            }
        }
    }
}
