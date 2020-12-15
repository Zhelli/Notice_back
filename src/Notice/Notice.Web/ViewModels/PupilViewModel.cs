using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notice.Web.ViewModels
{
    public class PupilViewModel
    {
        public int Id;

        public string Email;

        public PupilViewModel() { }

        public PupilViewModel(int id)
        {
            Id = id;
        }

        public PupilViewModel(int id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
