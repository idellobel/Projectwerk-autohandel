using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.SQLite
{
    public class VoertuigenSQLiteService : SQLiteServiceBase, IVoertuigenService
    {
        public async Task DeleteVoertuigenLijst(int voertuigenId)
        {
            await Task.Run(() =>
            {
                try
                {
                    connection.Delete<Voertuigen>(voertuigenId);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task<IEnumerable<Voertuigen>> GetAll()
        {
            return await Task.Run<IEnumerable<Voertuigen>>(() =>
            {
                try
                {

                    var voertuigenLijst = connection.GetAllWithChildren<Voertuigen>().ToList();
                    return voertuigenLijst;


                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task<Voertuigen> GetVoertuigenLijst(int voertuigenId)
        {
            return await Task.Run<Voertuigen>(() =>
            {
                try
                {
                    Voertuigen voertuigenLijst = connection.Table<Voertuigen>().Where(v=> v.Id == voertuigenId).FirstOrDefault();
                    if (voertuigenLijst != null)
                        connection.GetChildren<Voertuigen>(voertuigenLijst, true);
                    return voertuigenLijst;

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task SaveVoertuigenLijst(Voertuigen voertuigen)
        {
            await Task.Run(() =>
            {
                try
                {
                    connection.InsertOrReplaceWithChildren(voertuigen);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }
    }
}
