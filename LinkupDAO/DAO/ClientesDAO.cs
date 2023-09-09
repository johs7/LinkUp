using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkupEDM.AppModel;
using System.Data.Entity;

namespace LinkupDAO.DAO
{
    public class ClientesDAO
    {
        Model1Container db = new Model1Container();
        public int Agregar(Clientes cli, out string mensaje)
        {
            try
            {
                db.Clientes.Add(cli);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    mensaje = "Cliente agregado exitosamente";
                }
                else
                {
                    mensaje = "No se pudo agregar el cliente";
                }
                return result;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al agregar el cliente: {ex.Message}";
                return 0;
            }
        }

        public List<Clientes> Listar()
        {
            return (db.Clientes.ToList());

        }

        public bool Eliminar(Clientes cli)
        {
            Clientes c = db.Clientes.Remove(cli);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Modificar(Clientes cli)
        {
            db.Entry(cli).State = EntityState.Modified;
            return (db.SaveChanges() > 0 ? true : false);
        }
    }
}
