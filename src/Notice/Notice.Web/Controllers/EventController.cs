using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notice.DAL.Entities;
using Notice.DAL.Interfaces;
using Notice.DAL.Repositories;
using Notice.Web.ViewModels;

namespace Notice.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IBaseRepository baseRepository;

        private const int ID = 17;

        public EventController(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Func<SqlDataReader, Event> func = reader => new Event(reader);

            List<Event> events = baseRepository.GettingData("GetAllEvents", func).OrderByDescending(x => x.DateOfEvent).ToList();



            Dictionary<string, object> paramNamesAndValues = new Dictionary<string, object>()
            {
                ["@schoolWorkerId"] = ID
            };

            List<Notification> notifications = baseRepository.GettingData("GetNotifications", reader => new Notification(reader), paramNamesAndValues);

            return View(new ListEventViewModel() { Events = events, notifications = notifications });
        }

        [HttpGet]
        public IActionResult AddEvent()
        {
            Func<SqlDataReader, Pupil> funcCreatePupil = reader => new Pupil(reader);
            Func<SqlDataReader, Teacher> funcCreateTeacher = reader => new Teacher(reader);

            List<Pupil> pupils = baseRepository.GettingData("GetAllPupils", funcCreatePupil).OrderBy(x => x.ClassName).ToList();
            List<Teacher> teachers = baseRepository.GettingData("GetAllTeachers", funcCreateTeacher).OrderBy(x => x.FullName).ToList();

            ViewBag.Pupils = new PupilTeacherListsViewModel() { PupilParticipants = pupils, TeacherParticipants = teachers };

            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(EventFullInfoViewModel eventFullInfo)
        {
            object d = eventFullInfo.Event.DateOfEvent;
            if(d.Equals(new DateTime(1, 1, 1)))
            {
                d = DBNull.Value;
            }
            object desc = eventFullInfo.Event.Description;
            if (string.IsNullOrEmpty(eventFullInfo.Event.Description))
            {
                desc = DBNull.Value;
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                ["@authorId"] = ID,
                ["@title"] = eventFullInfo.Event.Title,
                ["@description"] =  desc,
                ["@dateOfEvent"] = d
            };

            int eventId = baseRepository.GettingData("AddEvent", reader => reader.GetInt32(0), parameters).First();

            Dictionary<string, object> par = new Dictionary<string, object>()
            {
                ["@schoolWorkerId"] = ID,
                ["@eventId"] = 10,
                ["@role"] = "T"
            };

            baseRepository.GettingData("AddNotificationForSchoolWorker", reader => reader.GetInt32(0), par);


            Func<SqlDataReader, string> funcCreatePupil = reader => reader.GetString(0);

            Dictionary<string, object> paramNamesAndValues = new Dictionary<string, object>()
            {
                ["@id"] = ID
            };

            string email = baseRepository.GettingData("GetTecherEmailById", funcCreatePupil, paramNamesAndValues).First();

            SendEmail(email, eventFullInfo.Event.Title);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddEventTo(int id)
        {
            Func<SqlDataReader, string> funcCreatePupil = reader => reader.GetString(0);
            // Func<SqlDataReader, Teacher> funcCreateTeacher = reader => new Teacher(reader);

            Dictionary<string, object> paramNamesAndValues = new Dictionary<string, object>()
            {
                ["@id"] = 14
            };

            string email = baseRepository.GettingData("GetTecherEmailById", funcCreatePupil, paramNamesAndValues).First();

            SendEmail(email, "Christmas Party");

            //List<Teacher> teachers = baseRepository.GettingData("GetAllTeachers", funcCreateTeacher).OrderBy(x => x.FullName).ToList();
            return RedirectToAction("Index");

            return View(new EventFullInfoViewModel()
            {
              //  PupilParticipans = pupils,
                //TeacherParticipants = teachers
            });
        }

        public IActionResult EditEvent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile(int eventId)
        {
            Func<SqlDataReader, Event> func = reader => new Event(reader);
            Func<SqlDataReader, Pupil> funcCreatePupil = reader => new Pupil(reader);
            Func<SqlDataReader, Teacher> funcCreateTeacher = reader => new Teacher(reader);

            Dictionary<string, object> paramNamesAndValues = new Dictionary<string, object>()
            {
                ["@eventId"] = eventId
            };

            Event schoolEvent = baseRepository.GettingData("GetEventById", func, paramNamesAndValues).First();
            List<Pupil> pupils = baseRepository.GettingData("GetPupilsOfEventById", funcCreatePupil, paramNamesAndValues).OrderBy(x => x.ClassName).ToList();
            List<Teacher> teachers = baseRepository.GettingData("GetTeachersOfEventById", funcCreateTeacher, paramNamesAndValues).OrderBy(x => x.FullName).ToList();


            return View(new EventFullInfoViewModel()
            {
                Event = schoolEvent,
                PupilParticipans = pupils,
                TeacherParticipants = teachers
            });
        }

        private void SendEmail(string toEmail, string eventTitle)
        {
            MailAddress from = new MailAddress("msjonny14@gmail.com", "Notice");
            MailAddress to = new MailAddress(toEmail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "New notification in Notice!";
            m.Body = "<h2>Hello!</h2>" +
                "<br>" +
                "<h3>New event '" + eventTitle + "' was added</h3>" +
                "<h5>Go to Notice to check all details!</h5>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("msjonny14@gmail.com", "jonny2012");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(m);
            }
            catch
            {
                //MessageBox.Show("Письмо не было отправлено", "Упс...", MessageBoxButtons.OK);
                return;
            }

            m.Dispose();
            smtp.Dispose();
            smtp = null;
        }
    }
}