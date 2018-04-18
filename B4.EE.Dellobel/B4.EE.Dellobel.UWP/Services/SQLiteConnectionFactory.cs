using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using Windows.Storage;
using System.IO;
using SQLite.Net.Platform.WinRT;
using SQLite.Net.Interop;
using B4.EE.DellobelI.Domain.Services.Abstract;

[assembly: Dependency(typeof(B4.EE.DellobelI.UWP.Services.SQLiteConnectionFactory))]

namespace B4.EE.DellobelI.UWP.Services
{
    internal class SQLiteConnectionFactory : ISQLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseFileName)
        {
            string path = ApplicationData.Current.LocalFolder.Path;
            path = Path.Combine(path, databaseFileName);

            return new SQLiteConnection(
                new SQLitePlatformWinRT(),
                path,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
                storeDateTimeAsTicks: false
            );
        }
    }
}

