using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CajaDataAccess
    {
        public static int create(Caja caja)
        {
            OrdenEntities contexto = new OrdenEntities();

            contexto.Caja.Add(caja);

            contexto.SaveChanges();

            if(caja.id_caja > 0)
            {
                return caja.id_caja;
            }

            return -1;

        }

        public static void update(Caja caja)
        {
            OrdenEntities contexto = new OrdenEntities();

            Caja cajaExistente = contexto.Caja.Where(x => x.id_caja == caja.id_caja).FirstOrDefault();

            cajaExistente = caja;

            contexto.Entry<Caja>(cajaExistente).State = System.Data.Entity.EntityState.Modified;
                        
            contexto.SaveChanges();
        }

        public static void delete(Caja caja)
        {
            OrdenEntities contexto = new OrdenEntities();

            Caja cajaExistente = contexto.Caja.Where(x => x.id_caja == caja.id_caja).FirstOrDefault();
            
            contexto.Entry<Caja>(cajaExistente).State = System.Data.Entity.EntityState.Deleted;

            contexto.SaveChanges();
        }

        public static Caja getById(int id_caja)
        {
            OrdenEntities contexto = new OrdenEntities();

            return contexto.Caja.Where(x => x.id_caja == id_caja).FirstOrDefault();
        }

        public static List<Caja> getByNombre(string nombre)
        {
            OrdenEntities contexto = new OrdenEntities();

            return contexto.Caja.Where(x => x.nombre.Contains(nombre)).ToList();
        }

        public static List<Caja> getAll()
        {
            OrdenEntities contexto = new OrdenEntities();

            return contexto.Caja.ToList();
        }

        public static void agregarObjeto(Caja caja, List<Objeto> objetos)
        {
            OrdenEntities contexto = new OrdenEntities();

            List<Objeto> objetosActuales = caja.Objeto.ToList();

            objetosActuales.AddRange(objetos);
        }




        //public static List<Objeto> getObjetosByIdCaja(int id_caja)
        //{
        //    OrdenEntities contexto = new OrdenEntities();

        //    return contexto.Objeto.Where(x => x.id_caja == id_caja).ToList();
        //}
    }
}
