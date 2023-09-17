using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkupDAO.DAO;
using LinkupEDM.AppModel;

namespace LinkupCN.CN
{
    public class TransaccionCN
    {
        private TransaccionDAO op = new TransaccionDAO();
        public List<Envio> Listar()
        {
            return op.Listar();
        }

        public int Agregar(Envio obj, out string mensaje)
        {

            mensaje = string.Empty;
            if (obj.Monto == 0)
            {
                mensaje = "Ingrese el monto a digitar";
            }
            if (obj.FechaEnvio == null || obj.FechaEnvio == DateTime.MinValue)
            {
                mensaje = "Ingrese la fecha de la transaccion";
            }

            if (string.IsNullOrEmpty(obj.CodigoRemitente) || string.IsNullOrWhiteSpace(obj.CodigoRemitente))
            {
                mensaje = "Ingrese el codigo del remitente";

            }
            if (obj.ClientesId == 0)
            {
                mensaje = "Ingrese  el id del cliente";
            }
            if (string.IsNullOrEmpty(mensaje))
            {
                return op.Agregar(obj, out mensaje);
            }
            else
            {
                return 0;
            }

        }
        public bool Editar(Envio obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Monto == 0)
            {
                mensaje = "Ingrese el monto a digitar";
            }
            if (obj.FechaEnvio == null || obj.FechaEnvio == DateTime.MinValue)
            {
                mensaje = "Ingrese la fecha de la transaccion";
            }

            if (string.IsNullOrEmpty(obj.CodigoRemitente) || string.IsNullOrWhiteSpace(obj.CodigoRemitente))
            {
                mensaje = "Ingrese el codigo del remitente";

            }
            if (obj.ClientesId == 0)
            {
                mensaje = "Ingrese  el id del cliente";
            }
            if (string.IsNullOrEmpty(mensaje))
            {
                return op.Modificar(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(string id, out string Mensaje)
        {
            var envio = new Envio  { Id_Envio = id };
            return op.Eliminar(id, out Mensaje);
        }
    }
}
