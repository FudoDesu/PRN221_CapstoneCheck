using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DAO
{
    public class MentorDAO
    {
        private static MentorDAO instance;
        private static readonly object instancelock = new object();
        private MentorDAO() { }
        public static MentorDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new MentorDAO();
                    }
                    return instance;
                }
            }
        }

        public Mentor Login (string email, string password)
        {
            using (var db = new CapstoneProjectCheckContext())
            {
                return db.Mentors.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
            }
        }
    }
}
