using Microsoft.EntityFrameworkCore;
using proj_zal.Models;

namespace proj_zal.Data
{
    public class ArtistService : IGenericService<Artist>
    {
        private readonly ApplicationDbContext _context;

        public ArtistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Artist?> AddAsync(Artist? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.Artists.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Artist?> DeleteAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var artist = await _context.Artists.FindAsync(id);

            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
            }

            return artist;
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist?> GetAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _context.Artists.FindAsync(id);
        }

        public async Task<Artist?> UpdateAsync(Artist? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}