using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinkupEDM.AppModel;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LinkupDAO.DAO
{
    public class BancoDAO
    {
        Model1Container db = new Model1Container();
        public int Agregar(Banco bcn, out string mensaje)
        {
            try
            {
                db.Banco.Add(bcn);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    mensaje = "agregado exitosamente";
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

        public List<Banco> Listar()
        {
            return (db.Banco.ToList());

        }

        public bool Eliminar(int id, out string mensaje)
        {
            try
            {
                Banco bcn = db.Banco.FirstOrDefault(c => c.Id_Banco == id);

                if (bcn != null)
                {
                    db.Banco.Remove(bcn);
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
                    mensaje = "Cliente no encontrado";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al eliminar: {ex.Message}";
                return false;
            }
        }

        public bool Modificar(Banco bcn, out string mensaje)
        {
            try
            {
                db.Entry(bcn).State = EntityState.Modified;
                int result = db.SaveChanges();
                if (result > 0)
                {
                    mensaje = "Banco modificado exitosamente";
                    return true;
                }
                else
                {
                    mensaje = "No se pudo modificar el Banco";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al modificar e: {ex.Message}";
                return false;
            }
        }
    }
}
