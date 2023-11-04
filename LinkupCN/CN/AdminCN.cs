using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkupDAO.DAO;
using LinkupEDM.AppModel;

namespace LinkupCN.CN
{
    public class AdminCN
    {
        public AdminDAO op = new AdminDAO();
        public List<Admin> Listar()
        {
            return op.Listar();
        }
    }
}
