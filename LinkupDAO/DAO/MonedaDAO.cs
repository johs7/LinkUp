using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinkupEDM.AppModel;
using System.Threading.Tasks;
using System.Data.Entity;


namespace LinkupDAO.DAO
{
   public class MonedaDAO
    {
        Model1Container db = new Model1Container();
        public int Agregar(Moneda mon, out string mensaje)
        {
            try
            {
                db.Moneda.Add(mon);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    mensaje = "agregado exitosamente";
                }
                else
                {
                    mensaje = "No se pudo agregar la moneda";
                }
                return result;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al agregar: {ex.Message}";
                return 0;
            }
        }

        public List<Moneda> Listar()
        {
            return (db.Moneda.ToList());

        }

        public bool Eliminar(int id, out string mensaje)
        {
            try
            {
                Moneda mon = db.Moneda.FirstOrDefault(c => c.Id_Moneda == id);

                if (mon != null)
                {
                    db.Moneda.Remove(mon);
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
                    mensaje = "Moneda no encontrada";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al eliminar: {ex.Message}";
                return false;
            }
        }

        public bool Modificar(Moneda mon, out string mensaje)
        {
            try
            {
                db.Entry(mon).State = EntityState.Modified;
                int result = db.SaveChanges();
                if (result > 0)
                {
                    mensaje = "Moneda modificada exitosamente";
                    return true;
                }
                else
                {
                    mensaje = "No se pudo modificar la Moneda";
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
