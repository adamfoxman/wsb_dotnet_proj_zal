using Microsoft.EntityFrameworkCore;
using proj_zal.Models;

namespace proj_zal.Data
{
    public class AlbumService : IGenericService<Album>
    {
        private readonly ApplicationDbContext _context;

        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Album?> AddAsync(Album? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.Albums.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Album?> DeleteAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var album = await _context.Albums.FindAsync(id);

            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }

            return album;
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<Album?> GetAsync(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _context.Albums.FindAsync(id);
        }

        public async Task<Album?> UpdateAsync(Album? entity)
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