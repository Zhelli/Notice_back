using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notice.Web.ViewModels
{
    public class TeacherViewModel
    {
        public int Id;

        public string Email;

        public TeacherViewModel() { }

        public TeacherViewModel(int id)
        {
            Id = id;
        }

        public TeacherViewModel(int id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
