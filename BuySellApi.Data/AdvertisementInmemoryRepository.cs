using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuySellApi.Core;

namespace BuySellApi.Data
{
    public class AdvertisementInmemoryRepository : IAdvertisement
    {
        private readonly List<Advertisement> _advertisements;

        public AdvertisementInmemoryRepository()
        {
            _advertisements = new List<Advertisement>()
            {
                new Advertisement() { Id = 1, Title="Sample Ad-1", Description="Description for Sample Ad-1",CreatedOn=DateTime.Now,IsActive=true },
                new Advertisement() { Id = 2, Title="Sample Ad-2", Description="Description for Sample Ad-2",CreatedOn=DateTime.Now,IsActive=true },
                new Advertisement() { Id = 3, Title="Sample Ad-3", Description="Description for Sample Ad-3",CreatedOn=DateTime.Now,IsActive=true },
                new Advertisement() { Id = 4, Title="Sample Ad-4", Description="Description for Sample Ad-4",CreatedOn=DateTime.Now,IsActive=true }
            };
        }


        public Task Commit()
        {
            throw new NotImplementedException();
        }

        public void Create(Advertisement advertisement)
        {
            advertisement.Id = _advertisements.Count + 1;
            _advertisements.Add(advertisement);
        }

        public void Delete(Advertisement advertisement)
        {
            var existing = _advertisements.First(a => a.Id == advertisement.Id);
            _advertisements.Remove(existing);
        }

        public void Edit(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }

        public async Task<Advertisement> Find(int id)
        {
            return await Task.Run(() => _advertisements.Where(a => a.Id == id).FirstOrDefault());
        }

        public async Task<IEnumerable<Advertisement>> FindAll()
        {
            return await Task.Run(() => _advertisements);
        }
    }
}
