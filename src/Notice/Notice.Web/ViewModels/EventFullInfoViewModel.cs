using Notice.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notice.Web.ViewModels
{
    public class EventFullInfoViewModel
    {
        public Event Event { get; set; } = new Event();

        public List<Pupil> PupilParticipans { get; set; }

        public List<Teacher> TeacherParticipants { get; set; }
    }
}
