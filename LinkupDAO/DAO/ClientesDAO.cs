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

        public bool Eliminar(int id, out string mensaje)
        {
            try
            {
                Clientes cliente = db.Clientes.FirstOrDefault(c => c.Id == id);

                if (cliente != null)
                {
                    db.Clientes.Remove(cliente);
                    int result = db.SaveChanges();
                    if (result > 0)
                    {
                        mensaje = "Cliente eliminado exitosamente";
                        return true;
                    }
                    else
                    {
                        mensaje = "No se pudo eliminar el cliente";
                        return false;
                    }
                }
                else
                {
                    mensaje = "Cliente no encontrado";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al eliminar el cliente: {ex.Message}";
                return false;
            }
        }



        public bool Modificar(Clientes cli, out string mensaje)
        {
            try
            {
                db.Entry(cli).State = EntityState.Modified;
                int result = db.SaveChanges();
                if (result > 0)
                {
                    mensaje = "Cliente modificado exitosamente";
                    return true;
                }
                else
                {
                    mensaje = "No se pudo modificar el cliente";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al modificar el cliente: {ex.Message}";
                return false;
            }
        }

    }
}
