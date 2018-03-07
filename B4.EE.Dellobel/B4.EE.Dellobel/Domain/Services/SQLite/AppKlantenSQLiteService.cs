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
    public class AppKlantenSQLiteService : SQLiteServiceBase, IKlantenService
    {
        public async Task DeleteKlant(Guid id)
        {
            await Task.Run(() =>
             {
                 try
                 {
                     connection.Delete<Klant>(id);
                 }
                 catch (Exception ex)
                 {
                     Debug.WriteLine(ex.Message);
                     throw;
                 }

             });
        }

        public async Task<IEnumerable<Klant>> GetAllKlanten()
        {
            return await Task.Run <IEnumerable<Klant>> (() =>
                  {
                try
                {

                    var klanten = connection.GetAllWithChildren<Klant>().ToList();
                    return klanten;
                    

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task<IEnumerable<Klant>> GetAllKlantenOrdered()
        {
            return await Task.Run<IEnumerable<Klant>>(() =>
            {
                try
                {

                    var orderedKlanten = connection.GetAllWithChildren<Klant>().OrderBy(k => k.Naam.Substring(0, 1)).ToList();
                    return orderedKlanten;


                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task<Klant> GetKlantById(Guid id)
        {
            return await Task.Run<Klant>(() =>
            {
                try
                {
                    Klant klant = connection.Table<Klant>().Where(k => k.Id == id).FirstOrDefault();
                    return klant;

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task SaveKlant(Klant klant)
        {
            await Task.Run(() =>
            {
                try
                {
                    connection.InsertOrReplace(klant);

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
