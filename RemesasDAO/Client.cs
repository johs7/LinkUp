using RemesasEDM;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel;

namespace RemesasDAO
{
   public class Client
    {
        LinkupEntities1 db= new LinkupEntities1();
        public bool Agregar(Clientes cli)
        {
            db.Clientes.Add(cli);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Eliminar(Clientes cli)
        {
            Clientes clientes = db.Clientes.Remove(cli);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Modificar(Clientes cli)
        {
            db.Entry(cli).State = EntityState.Modified;
            return (db.SaveChanges() > 0 ? true : false);
        }

       
    }
}
