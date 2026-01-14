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

        public async Task<List<Fir>> GetAllCasesAsync()
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
        public async Task<bool> AddCaseAsync(Fir newCase)
        {
            try
            {
                _context.Firs.Add(newCase);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding case: {ex.Message}");
                return false;
            }
        }
    }
}
