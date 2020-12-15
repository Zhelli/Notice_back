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

        public EventController(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Func<SqlDataReader, Event> func = reader => new Event(reader);

            List<Event> events = baseRepository.GettingData("GetAllEvents", func).OrderByDescending(x => x.DateOfEvent).ToList();


            return View(new ListEventViewModel() { Events = events });
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

            SendEmail(email);

            //List<Teacher> teachers = baseRepository.GettingData("GetAllTeachers", funcCreateTeacher).OrderBy(x => x.FullName).ToList();
            return RedirectToAction("AddEvent");

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

        private void SendEmail(string toEmail)
        {
            MailAddress from = new MailAddress("msjonny14@gmail.com", "Notice");
            MailAddress to = new MailAddress(toEmail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "New notification";
            m.Body = "<h2>Hello!</h2>" +
                "<br>" +
                "<h4>New event was added</h4>" +
                "<h6>Go to Notice to check all details!</h6>";
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

            //MessageBox.Show("Письмо отправлено!", "Готово!", MessageBoxButtons.OK);

            //textBox1.Clear();

            m.Dispose();
            smtp.Dispose();
            smtp = null;
        }
    }
}