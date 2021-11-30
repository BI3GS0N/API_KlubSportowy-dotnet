using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Interfaces;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Services
{
    public class ZawodnicyRepository : IZawodnicyRepository
    {
        private readonly KlubSportowyContext context;

        public ZawodnicyRepository(KlubSportowyContext _context)
        {
            context = _context;
        }

        public Zawodnicy Delete(int ZawodnikId)
        {
            Zawodnicy zawodnik = context.Zawodnicies.Find(ZawodnikId);
            if (zawodnik != null) {
                context.Zawodnicies.Remove(zawodnik);
                context.SaveChanges();
            }
            return zawodnik;
        }

        public Zawodnicy Get(int ZawodnikId)
        {
            return context.Zawodnicies.Find(ZawodnikId);
        }

        public IEnumerable<Zawodnicy> GetAll()
        {
            return context.Zawodnicies;
        }

        public Zawodnicy Post(Zawodnicy newZawodnik)
        {
            context.Zawodnicies.Add(newZawodnik);
            context.SaveChanges();
            return newZawodnik;
        }

        public Zawodnicy Put(Zawodnicy updatedZawodnik)
        {
            var zawodnik = context.Zawodnicies.Attach(updatedZawodnik);
            zawodnik.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedZawodnik;
        }
    }
}
