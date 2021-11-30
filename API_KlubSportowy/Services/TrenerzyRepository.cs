using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Interfaces;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Services
{
    public class TrenerzyRepository : ITrenerzyRepository
    {
        private readonly KlubSportowyContext context;

        public TrenerzyRepository(KlubSportowyContext _context)
        {
            context = _context;
        }

        public Trenerzy Delete(int TrenerId)
        {
            Trenerzy trener = context.Trenerzies.Find(TrenerId);
            if (trener != null) 
            {
                context.Trenerzies.Remove(trener);
                context.SaveChanges();
            }
            return trener;
        }

        public Trenerzy Get(int TrenerId)
        {
            return context.Trenerzies.Find(TrenerId);
        }

        public IEnumerable<Trenerzy> GetAll()
        {
            return context.Trenerzies;
        }

        public Trenerzy Post(Trenerzy newTrener)
        {
            context.Trenerzies.Add(newTrener);
            context.SaveChanges();
            return newTrener;
        }

        public Trenerzy Put(Trenerzy updatedTrener)
        {
            var trener = context.Trenerzies.Attach(updatedTrener);
            trener.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedTrener;
        }
    }
}
