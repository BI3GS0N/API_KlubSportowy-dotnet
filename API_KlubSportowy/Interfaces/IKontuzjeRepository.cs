using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Interfaces
{
    public interface IKontuzjeRepository
    {
        Kontuzje Get(int KontuzjaId);
        IEnumerable<Kontuzje> GetAll();
        Kontuzje Post(Kontuzje newKontuzja);
        Kontuzje Put(Kontuzje updatedKontuzja);
        Kontuzje Delete(int KontuzjaId);
    }
}
