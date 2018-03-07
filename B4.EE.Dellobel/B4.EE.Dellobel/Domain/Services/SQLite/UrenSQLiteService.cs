using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.SQLite
{
    public class UrenSQLiteService : SQLiteServiceBase, IUrenService
    {
        public async Task DeleteUren(int werkId)
        {
            await Task.Run(() =>
            {
                try
                {
                    connection.Delete<WerkUren>(werkId);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task<IEnumerable<WerkUren>> GetAllUren()
        {
            return await Task.Run<IEnumerable<WerkUren>>(() =>
            {
                try
                {

                    var werkUren = connection.GetAllWithChildren<WerkUren>().ToList();
                    return werkUren;


                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task<WerkUren> GetUrenById(int id)
        {
            return await Task.Run<WerkUren>(() =>
            {
                try
                {
                    WerkUren werkUren = connection.Table<WerkUren>().Where(u => u.WerkId == id).FirstOrDefault();
                    return werkUren;

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            });
        }

        public async Task SaveUren(WerkUren werk)
        {
            await Task.Run(() =>
            {
                try
                {
                    connection.InsertOrReplace(werk);

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
