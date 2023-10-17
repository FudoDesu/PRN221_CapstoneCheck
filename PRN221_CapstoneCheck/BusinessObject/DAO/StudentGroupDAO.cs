using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DAO
{
    public class StudentGroupDAO
    {
        private static StudentGroupDAO instance;
        private static readonly object instancelock = new object();
        private StudentGroupDAO() { }
        public static StudentGroupDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new StudentGroupDAO();
                    }
                    return instance;
                }
            }
        }

        public void CreateGroup (int studentId)
        {
            StudentGroup studentGroup = new StudentGroup()
            {
            };
            using var db = new CapstoneProjectCheckContext()
            {
                
            };
        }
    }
}
