using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DAO
{
    public class StudentDAO
    {
        private static StudentDAO instance;
        private static readonly object instancelock = new object();
        private StudentDAO() { }
        public static StudentDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new StudentDAO();
                    }
                    return instance;
                }
            }
        }

        public Student Login(string email, string password)
        {
            using (var db = new CapstoneProjectCheckContext())
            {
                return db.Students.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
            }
        }
    }
}
