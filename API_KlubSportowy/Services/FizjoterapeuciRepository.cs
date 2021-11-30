using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Interfaces;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Services
{
    public class FizjoterapeuciRepository : IFizjoterapeuciRepository
    {

        private readonly KlubSportowyContext context;

        public FizjoterapeuciRepository(KlubSportowyContext _context) 
        {
            context = _context;
        }

        public Fizjoterapeuci Delete(int FizjoterapeuciId)
        {
            Fizjoterapeuci fizjoterapeuci = context.Fizjoterapeucis.Find(FizjoterapeuciId);
            if (fizjoterapeuci != null) 
            {
                context.Fizjoterapeucis.Remove(fizjoterapeuci);
                context.SaveChanges();
            }
            return fizjoterapeuci;
        }

        public Fizjoterapeuci Get(int FizjoterapeuciId)
        {
            return context.Fizjoterapeucis.Find(FizjoterapeuciId);
        }

        public IEnumerable<Fizjoterapeuci> GetAll()
        {
            return context.Fizjoterapeucis;
        }

        public Fizjoterapeuci Post(Fizjoterapeuci newFizjoterapeuci)
        {
            context.Fizjoterapeucis.Add(newFizjoterapeuci);
            context.SaveChanges();
            return newFizjoterapeuci;
        }

        public Fizjoterapeuci Put(Fizjoterapeuci updatedFizjoterapeuci)
        {
            var fizjoterapeuta = context.Fizjoterapeucis.Attach(updatedFizjoterapeuci);
            fizjoterapeuta.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedFizjoterapeuci;
        }
    }
}
