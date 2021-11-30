using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace API_KlubSportowy.Models
{
    public partial class Kontuzje
    {
        public int IdKontuzja { get; set; }
        public string Opis { get; set; }
        public DateTime DataDoznania { get; set; }
        public DateTime? DataWyleczenia { get; set; }
        public int? ZawodnikId { get; set; }
        public int? FizjoterapeutaId { get; set; }

        [JsonIgnore]
        public virtual Fizjoterapeuci Fizjoterapeuta { get; set; }
        [JsonIgnore]
        public virtual Zawodnicy Zawodnik { get; set; }
    }
}
