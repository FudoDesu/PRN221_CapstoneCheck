using BusinessObject.DAO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class MentorRepository : IMentorRepository
    {
        public Mentor Login(string email, string password) => MentorDAO.Instance.Login(email, password);
    }
}
