using BusinessObject.DAO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class StaffRepository : IStaffRepository
    {
        public staff Login(string email, string password) => StaffDAO.Instance.Login(email, password);
    }
}
