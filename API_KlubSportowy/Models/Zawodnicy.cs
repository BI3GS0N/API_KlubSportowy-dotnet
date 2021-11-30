using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace API_KlubSportowy.Models
{
    public partial class Zawodnicy
    {
        public Zawodnicy()
        {
            Kontuzjes = new HashSet<Kontuzje>();
        }

        public int IdZawodnik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Plec { get; set; }
        public string Narodowosc { get; set; }
        public int? ZespolId { get; set; }
        public int? KontraktId { get; set; }

        [JsonIgnore]
        public virtual Kontrakty Kontrakt { get; set; }
        [JsonIgnore]
        public virtual Zespoly Zespol { get; set; }
        [JsonIgnore]
        public virtual ICollection<Kontuzje> Kontuzjes { get; set; }
    }
}
