using BuySellApi.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuySellApi.Data
{
    public class AdvertisementRepository : IAdvertisement
    {
        private readonly ApplicationDbContext _db;

        public AdvertisementRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<Advertisement>> FindAll()
        {
            return await _db.Advertisements.ToListAsync();
        }

        public async Task<Advertisement> Find(int id)
        {
            return await _db.Advertisements.FindAsync(id);
        }

        public void Edit(Advertisement advertisement)
        {
            _db.Advertisements.Update(advertisement);
        }

        public void Create(Advertisement advertisement)
        {
            _db.Advertisements.Add(advertisement);
        }

        public void Delete(Advertisement advertisement)
        {
            _db.Advertisements.Remove(advertisement);
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }
    }
}
