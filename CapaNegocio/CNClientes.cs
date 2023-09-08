using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RemesasDAO;
using RemesasEDM;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNClientes
    {
        private CDClientes objCapaDato = new CDClientes();
        public List<Clientes> Listar()
        {
            return objCapaDato.Listar();
        }

    }
}
