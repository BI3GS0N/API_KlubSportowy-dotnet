using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Interfaces
{
    public interface IZawodnicyRepository
    {
        Zawodnicy Get(int ZawodnikId);
        IEnumerable<Zawodnicy> GetAll();
        Zawodnicy Post(Zawodnicy newZawodnik);
        Zawodnicy Put(Zawodnicy updatedZawodnik);
        Zawodnicy Delete(int ZawodnikId);
    }
}
