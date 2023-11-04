using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkupEDM.AppModel;
using System.Data.Entity;

namespace LinkupDAO.DAO
{
    public class AdminDAO
    {
        Model1Container db = new Model1Container();
       
        public List<Admin> Listar()
        {
            return (db.Admin.ToList());
        }

    
     
        public bool AdmnistradorYaExiste(string usuario, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                // Verificar si existe un cliente con la misma cédula o correo
                return db.Admin.Any(c => c.Usuario == usuario);
            }
            catch (Exception ex)
            {
                mensaje = $"Error al verificar si el cliente existe: {ex.Message}";
                return false;
            }
        }

        public Admin GetAdmin(string usuario)
        {
            return db.Admin.DefaultIfEmpty(null).FirstOrDefault(c => c.Usuario == usuario);
        }
    }
}
