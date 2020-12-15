using Notice.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notice.Web.ViewModels
{
    public class PupilTeacherListsViewModel
    {
        public List<Pupil> PupilParticipants;

        public List<Teacher> TeacherParticipants;
    }
}
