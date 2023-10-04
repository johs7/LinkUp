using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkupDAO.DAO;
using LinkupEDM.AppModel;

namespace LinkupCN.CN
{
    public class MonedaCN
    {
        
        private MonedaDAO op = new MonedaDAO();
        
        public List<Moneda> Listar()
        {
            
            return op.Listar();
        }

        public int Agregar(Moneda obj, out string mensaje)
        {

            mensaje = string.Empty;
            

            if (obj.TipoMoneda == null || string.IsNullOrWhiteSpace(obj.TipoMoneda))
            {
                mensaje = "Debe escribir el nombre de la Moneda";
            }
            if (obj.BancoId == 0)
            {
                mensaje = "Debe escribir el id del Banco";
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
        public bool Editar(Moneda obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.TipoMoneda == null || string.IsNullOrWhiteSpace(obj.TipoMoneda))
            {
                mensaje = "Debe escribir el nombre del Moneda";
            }
            if (obj.BancoId == 0)
            {
                mensaje = "Debe escribir el id del Banco";
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
        public bool Eliminar(int id, out string Mensaje)
        {
            var Moneda = new Moneda { Id_Moneda = id };
            return op.Eliminar(id, out Mensaje);
        }
    }
}
