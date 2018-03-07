using B4.EE.DellobelI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.Abstract
{
    public interface IVoertuigenService
    {
        Task<IEnumerable<Voertuigen>> GetAll();
        Task<Voertuigen> GetVoertuigenLijst(int voertuigenId);
        Task DeleteVoertuigenLijst(int voertuigenId);
        Task SaveVoertuigenLijst(Voertuigen voertuigen);
    }
}
