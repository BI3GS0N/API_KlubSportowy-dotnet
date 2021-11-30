using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Models;

namespace API_KlubSportowy.Interfaces
{
    public interface IZespolyRepository
    {
        Zespoly Get(int ZespolId);
        IEnumerable<Zespoly> GetAll();
        Zespoly Post(Zespoly newZespol);
        Zespoly Put(Zespoly updatedZespol);
        Zespoly Delete(int ZespolId);
    }
}
