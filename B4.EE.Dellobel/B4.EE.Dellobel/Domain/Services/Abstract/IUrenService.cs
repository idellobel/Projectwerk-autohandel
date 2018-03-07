using B4.EE.DellobelI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.Abstract
{
    public interface IUrenService
    {
        Task<IEnumerable<WerkUren>> GetAllUren();
        Task<WerkUren> GetUrenById(int id);
        Task SaveUren(WerkUren werk);
        Task DeleteUren(int werkId);
    }
}
