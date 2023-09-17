using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkupDAO.DAO;
using LinkupEDM.AppModel;

namespace LinkupCN.CN
{
    public class BancoCN
    {
        private BancoDAO op = new BancoDAO();
        public List<Banco> Listar()
        {
            return op.Listar();
        }

        public int Agregar(Banco obj, out string mensaje)
        {

            mensaje = string.Empty;

         
            if (obj.NombreBanco == null || string.IsNullOrWhiteSpace(obj.NombreBanco))
            {
                mensaje = "Debe escribir el nombre del banco";
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
        public bool Editar(Banco obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.NombreBanco == null || string.IsNullOrWhiteSpace(obj.NombreBanco))
            {
                mensaje = "Debe escribir el nombre del banco";
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
            var banco = new Banco { Id_Banco = id };
            return op.Eliminar(id, out Mensaje);
        }
    }
}
