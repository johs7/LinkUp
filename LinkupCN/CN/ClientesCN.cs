using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkupDAO.DAO;
using LinkupEDM.AppModel;

namespace LinkupCN.CN
{
    public class ClientesCN
    {
        private ClientesDAO op = new ClientesDAO();

        public List<Clientes> Listar()
        {
            return op.Listar();
        }
        public int Agregar(Clientes obj,out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje = "El Nombre del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje = "Los apellidos del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                mensaje = "La Direccion del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Cedula) || string.IsNullOrWhiteSpace(obj.Cedula))
            {
                mensaje = "La Cedula del cliente es obligatoria";
            }
            if (obj.Telefono==0)
            {
                mensaje = "El telefono del cliente es obligatorio";
            }
            return op.Agregar(obj, out mensaje);
        }
    }
}
