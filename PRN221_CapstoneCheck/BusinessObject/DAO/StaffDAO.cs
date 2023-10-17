using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;
        private static readonly object instancelock = new object();
        private StaffDAO() { }
        public static StaffDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new StaffDAO();
                    }
                    return instance;
                }
            }
        }

        public staff Login(string email, string password)
        {
            using (var db = new CapstoneProjectCheckContext())
            {
                return db.staff.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
            }
        }
    }
}
