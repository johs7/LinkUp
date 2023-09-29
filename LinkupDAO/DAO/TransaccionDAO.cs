using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinkupEDM.AppModel;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LinkupDAO.DAO
{
    public class TransaccionDAO
    {
        Model1Container db = new Model1Container();
        public int Agregar( Envio trans, out string mensaje)
        {
            try
            {
                db.Envio.Add(trans);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    mensaje = " agregado exitosamente";
                }
                else
                {
                    mensaje = "No se pudo agregar el cliente";
                }
                return result;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al agregar: {ex.Message}";
                return 0;
            }
        }

        public List<Envio> Listar()
        {
            return (db.Envio.ToList());

        }

        public bool Eliminar(string id, out string mensaje)
        {
            try
            {
                Envio trans = db.Envio.FirstOrDefault(c => c.Id_Envio == id);

                if (trans != null)
                {
                    db.Envio.Remove(trans);
                    int result = db.SaveChanges();
                    if (result > 0)
                    {
                        mensaje = "eliminado exitosamente";
                        return true;
                    }
                    else
                    {
                        mensaje = "No se pudo eliminar";
                        return false;
                    }
                }
                else
                {
                    mensaje = " no encontrado";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al eliminar el cliente: {ex.Message}";
                return false;
            }
        }

        public bool Modificar(Envio trans, out string mensaje)
        {
            try
            {
                db.Entry(trans).State = EntityState.Modified;
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

        public string IdEnvio()
        {
            Random random = new Random();
            var id = "Env" + random.Next(0, 1000).ToString();
            var verificar = db.Envio.DefaultIfEmpty(null).FirstOrDefault(e => e.Id_Envio == id);
            if (verificar == null)
                return id;
            else
                return "Env" + random.Next(0, 1000).ToString();
        }

        public string ClientReceiver(int id)
        {
            var receiver = db.Clientes.DefaultIfEmpty(null).FirstOrDefault(c => c.Id == id);
            return receiver != null ? receiver.Nombres+" "+receiver.Apellidos : null;
        }
    }
}
