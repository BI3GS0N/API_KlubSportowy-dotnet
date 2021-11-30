using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace API_KlubSportowy.Models
{
    public partial class Kontrakty
    {
        public Kontrakty()
        {
            Fizjoterapeucis = new HashSet<Fizjoterapeuci>();
            Trenerzies = new HashSet<Trenerzy>();
            Zawodnicies = new HashSet<Zawodnicy>();
        }

        public int IdKontrakt { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public decimal? Pensja { get; set; }

        [JsonIgnore]
        public virtual ICollection<Fizjoterapeuci> Fizjoterapeucis { get; set; }
        [JsonIgnore]
        public virtual ICollection<Trenerzy> Trenerzies { get; set; }
        [JsonIgnore]
        public virtual ICollection<Zawodnicy> Zawodnicies { get; set; }
    }
}
