using B4.EE.DellobelI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.Abstract
{
    public interface IKlantenService
    {
        Task<IEnumerable<Klant>> GetAllKlanten();
        Task<IEnumerable<Klant>> GetAllKlantenOrdered();
        Task<Klant> GetKlantById(Guid id);
        Task SaveKlant(Klant klant);
        Task DeleteKlant(Guid id);
    }
    
}
