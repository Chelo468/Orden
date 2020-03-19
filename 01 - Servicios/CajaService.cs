using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Servicios
{
    public class CajaService
    {
        public int create(Caja caja)
        {
            return CajaDataAccess.create(caja);
        }

        public List<Caja> getAll()
        {
            return CajaDataAccess.getAll();
        }

        public Caja getById(int id_caja)
        {
            return CajaDataAccess.getById(id_caja);
        }
    }
}
