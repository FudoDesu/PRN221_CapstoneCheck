using BusinessObject.DAO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    internal class StudentRepository : IStudentRepository
    {
        public Student Login(string email, string password) => StudentDAO.Instance.Login(email, password);
    }
}
