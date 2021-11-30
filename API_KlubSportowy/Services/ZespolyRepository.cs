using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Interfaces;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Services
{
    public class ZespolyRepository : IZespolyRepository
    {
        private readonly KlubSportowyContext context;

        public ZespolyRepository(KlubSportowyContext _context)
        {
            context = _context;
        }

        public Zespoly Delete(int ZespolId)
        {
            Zespoly zespol = context.Zespolies.Find(ZespolId);
            if (zespol != null)
            {
                context.Zespolies.Remove(zespol);
                context.SaveChanges();
            }
            return zespol;
        }

        public Zespoly Get(int ZespolId)
        {
            return context.Zespolies.Find(ZespolId);
        }

        public IEnumerable<Zespoly> GetAll()
        {
            return context.Zespolies;
        }

        public Zespoly Post(Zespoly newZespol)
        {
            context.Zespolies.Add(newZespol);
            context.SaveChanges();
            return newZespol;
        }

        public Zespoly Put(Zespoly updatedZespol)
        {
            var zespoly = context.Zespolies.Attach(updatedZespol);
            zespoly.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedZespol;
        }
    }
}
