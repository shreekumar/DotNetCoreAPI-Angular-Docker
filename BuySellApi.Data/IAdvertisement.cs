using BuySellApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuySellApi.Data
{
    public interface IAdvertisement
    {
        Task<IEnumerable<Advertisement>> FindAll();

        Task<Advertisement> Find(int id);

        void Create(Advertisement advertisement);

        void Edit(Advertisement advertisement);

        void Delete(Advertisement advertisement);

        Task Commit();
    }
}
