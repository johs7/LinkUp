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
    }
}
