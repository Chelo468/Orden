using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ObjetoDataAccess
    {
        public int create(Objeto objeto)
        {
            OrdenEntities contexto = new OrdenEntities();

            contexto.Objeto.Add(objeto);

            contexto.SaveChanges();

            if (objeto.id_objeto > 0)
            {
                return objeto.id_objeto;
            }

            return -1;

        }

        public void update(Objeto objeto)
        {
            OrdenEntities contexto = new OrdenEntities();

            Objeto objetoExistente = contexto.Objeto.Where(x => x.id_objeto == objeto.id_objeto).FirstOrDefault();

            objetoExistente = objeto;

            contexto.Entry<Objeto>(objetoExistente).State = System.Data.Entity.EntityState.Modified;

            contexto.SaveChanges();
        }

        public void delete(Objeto objeto)
        {
            OrdenEntities contexto = new OrdenEntities();

            Objeto objetoExistente = contexto.Objeto.Where(x => x.id_objeto == objeto.id_objeto).FirstOrDefault();

            contexto.Entry<Objeto>(objeto).State = System.Data.Entity.EntityState.Deleted;

            contexto.SaveChanges();
        }

        public Objeto getById(int id_objeto)
        {
            OrdenEntities contexto = new OrdenEntities();

            return contexto.Objeto.Where(x => x.id_objeto == id_objeto).FirstOrDefault();
        }

        public List<Objeto> getByCaja(Caja caja)
        {
            OrdenEntities contexto = new OrdenEntities();

            return contexto.Objeto.Where(x => x.id_caja == caja.id_caja).ToList();
        }

        public static List<Objeto> getAll()
        {
            OrdenEntities contexto = new OrdenEntities();

            return contexto.Objeto.ToList();
        }

        public List<Objeto> getByNombre(string nombre)
        {
            OrdenEntities contexto = new OrdenEntities();

            return contexto.Objeto.Where(x => x.nombre.Contains(nombre)).ToList();
        }
    }
}
