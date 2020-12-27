using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notice.Web.ViewModels
{
    public class EventViewModel
    {
        public int AuthorId = 1;

        public string Title;

        public string Description;

        public DateTime DateOfEvent;

        public int Id;

        public EventViewModel(string title, string description, DateTime date)
        {
            Title = title;
            Description = description;
            DateOfEvent = date;
        }
    }
}
