using System;
using B4.EE.DellobelI.Domain.Services.Abstract;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly:Dependency(typeof(B4.EE.DellobelI.Droid.Services.SQLiteConnectionFactory))]

namespace B4.EE.DellobelI.Droid.Services
{
    internal class SQLiteConnectionFactory : ISQLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseFileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, databaseFileName);
            return new SQLiteConnection(
                new SQLitePlatformAndroid(), 
                path, 
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite, 
                storeDateTimeAsTicks: false); } }
}