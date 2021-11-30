using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace API_KlubSportowy.Models
{
    public partial class Zespoly
    {
        public Zespoly()
        {
            Zawodnicies = new HashSet<Zawodnicy>();
        }

        public int IdZespol { get; set; }
        public string Nazwa { get; set; }
        public int? TrenerId { get; set; }

        [JsonIgnore]
        public virtual Trenerzy Trener { get; set; }
        [JsonIgnore]
        public virtual ICollection<Zawodnicy> Zawodnicies { get; set; }
    }
}
