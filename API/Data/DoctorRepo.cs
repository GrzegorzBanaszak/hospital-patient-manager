using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly AppDbContext _context;

        public DoctorRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Doctor entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _context.AddAsync(entity);
        }

        public void Delete(Doctor entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Remove(entity);
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetById(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}