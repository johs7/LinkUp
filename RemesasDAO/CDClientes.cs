using RemesasEDM;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace RemesasDAO
{
   public class CDClientes
    {
        LinkupEntities db= new LinkupEntities();
        public bool Agregar(Clientes cli)
        {
            db.Clientes.Add(cli);
            return (db.SaveChanges() > 0 ? true : false);
        }
        public List<Clientes> Listar()
        {
            return (db.Clientes.ToList());

        }

        public bool Eliminar(Clientes cli)
        {
            Clientes c= db.Clientes.Remove(cli);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Modificar(Clientes cli)
        {
            db.Entry(cli).State = EntityState.Modified;
            return (db.SaveChanges() > 0 ? true : false);
        }
       
       
    }
}
