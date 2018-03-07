using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace B4.EE.DellobelI.Domain.Models
{
    public enum VoertuigenStatus
    {
        Aanbod, Gekocht, Verkocht, Vraag
    }
    public class Voertuigen
    {
        [PrimaryKey]
        public int Id { get; set; }

        public VoertuigenStatus VoertuigenStatus { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All )]
        public List<Auto> Autoos { get; set; }

    }
}
