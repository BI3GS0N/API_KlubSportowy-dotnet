using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Interfaces;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Services
{
    public class KontuzjeRepository : IKontuzjeRepository
    {
        private readonly KlubSportowyContext context;

        public KontuzjeRepository(KlubSportowyContext _context)
        {
            context = _context;
        }

        public Kontuzje Delete(int KontuzjaId)
        {

            Kontuzje kontuzja = context.Kontuzjes.Find(KontuzjaId);
            if (kontuzja != null)
            {
                context.Kontuzjes.Remove(kontuzja);
                context.SaveChanges();
            }
            return kontuzja;
        }

        public Kontuzje Get(int KontuzjaId)
        {
            return context.Kontuzjes.Find(KontuzjaId);
        }

        public IEnumerable<Kontuzje> GetAll()
        {
            return context.Kontuzjes;
        }

        public Kontuzje Post(Kontuzje newKontuzja)
        {
            context.Kontuzjes.Add(newKontuzja);
            context.SaveChanges();
            return newKontuzja;
        }

        public Kontuzje Put(Kontuzje updatedKontuzja)
        {
            var kontuzja = context.Kontuzjes.Attach(updatedKontuzja);
            kontuzja.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedKontuzja;
        }
    }
}
