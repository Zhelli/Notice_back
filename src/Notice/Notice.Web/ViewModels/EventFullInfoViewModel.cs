using Notice.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notice.Web.ViewModels
{
    public class EventFullInfoViewModel
    {
        public Event Event;

        public List<Pupil> PupilParticipans;

        public List<Teacher> TeacherParticipants;
    }
}
