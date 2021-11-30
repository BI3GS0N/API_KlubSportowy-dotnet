using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace API_KlubSportowy.Models
{
    public partial class Trenerzy
    {
        public Trenerzy()
        {
            Zespolies = new HashSet<Zespoly>();
        }

        public int IdTrener { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Plec { get; set; }
        public string Narodowosc { get; set; }
        public int? KontraktId { get; set; }

        [JsonIgnore]
        public virtual Kontrakty Kontrakt { get; set; }
        [JsonIgnore]
        public virtual ICollection<Zespoly> Zespolies { get; set; }
    }
}
