using System;

namespace Autohandel.Domain.Entities
{
    public class Klant
    {
        public long KlantId { get; set; }
        public DateTime Klantdatum { get; set; }
        public string KlantNaam { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long PersoonId { get; set; }
        public Persoon Persoon { get; set; }

    }
}