using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Interfaces;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Services
{
    public class KontraktyRepository : IKontraktyRepository
    {
        private readonly KlubSportowyContext context;

        public KontraktyRepository(KlubSportowyContext _context)
        {
            context = _context;
        }

        public Kontrakty Delete(int KontraktyId)
        {
            Kontrakty kontrakty = context.Kontrakties.Find(KontraktyId);
            if (kontrakty != null)
            {
                context.Kontrakties.Remove(kontrakty);
                context.SaveChanges();
            }
            return kontrakty;
        }

        public Kontrakty Get(int KontraktyId)
        {
            return context.Kontrakties.Find(KontraktyId);
        }

        public IEnumerable<Kontrakty> GetAll()
        {
            return context.Kontrakties;
        }

        public Kontrakty Post(Kontrakty newKontrakty)
        {
            context.Kontrakties.Add(newKontrakty);
            context.SaveChanges();
            return newKontrakty;
        }

        public Kontrakty Put(Kontrakty updatedKontrakty)
        {
            var kontrakty = context.Kontrakties.Attach(updatedKontrakty);
            kontrakty.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedKontrakty;
        }
    }
}
