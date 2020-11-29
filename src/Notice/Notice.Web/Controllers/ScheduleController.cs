﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notice.DAL.Entities;
using Notice.DAL.Interfaces;
using Notice.Web.ViewModels;

namespace Notice.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IBaseRepository baseRepository;

        private readonly IFileRepository fileRepository;

        public ScheduleController(IBaseRepository baseRepository, IFileRepository fileRepository)
        {
            this.baseRepository = baseRepository;
            this.fileRepository = fileRepository;
        }

        public IActionResult AddSchedule()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            Func<SqlDataReader, Lesson> func = reader => new Lesson(reader);
            
            List<Lesson> lessons = baseRepository.GettingData("GetAllLessons", func);
            lessons = lessons.OrderBy(l => l.ClassName).ThenBy(l => l.NumberOfLesson).ToList();

            return View(new LessonsViewModel() { lessons = lessons });
        }

        [HttpGet]
        public IActionResult GetLessonsByClassName(string className)
        {
            Func<SqlDataReader, Lesson> func = reader => new Lesson(reader);
            Dictionary<string, object> paramValue = new Dictionary<string, object>()
            {
                ["@className"] = className
            };

            List<Lesson> lessons = baseRepository.GettingData("GetAllLessonsByClassName", func, paramValue);

            return View(new LessonsViewModel() { lessons = lessons });
        }

        [HttpPost]
        public IActionResult ImportFromExceFile(IFormFile fileExcel)
        {
            List<Lesson> lessons = new List<Lesson>();

            Dictionary<int, string> daysOfWeek = new Dictionary<int, string>()
            {
                [2] = "Mon",
                [4] = "Tue",
                [6] = "Wed",
                [8] = "Thu",
                [10] = "Fri"
            };

            using (XLWorkbook workBook = new XLWorkbook(fileExcel.OpenReadStream(), XLEventTracking.Disabled))
            {
                foreach (var worksheet in workBook.Worksheets)
                {
                    var rows = worksheet.RowsUsed();
                    int k = 0;

                    for (int i = 2; i < rows.Count(); i++)
                    {
                        try
                        {
                            int numberOfLesson = Convert.ToInt32(rows.ElementAt(i).Cell(1).Value.ToString());
                            string className = rows.ElementAt(k).Cell(1).Value.ToString();

                            for (int j = 2; j <= 10; j += 2)
                            {
                                Lesson lesson = new Lesson();
                                lesson.ClassName = className;
                                lesson.NumberOfLesson = numberOfLesson;
                                lesson.Subject = rows.ElementAt(i).Cell(j).Value.ToString();
                                lesson.Classroom = rows.ElementAt(i).Cell(j + 1).Value.ToString();
                                lesson.DayOfWeek = daysOfWeek[2];

                                if (lesson.Subject != "")
                                {
                                    lessons.Add(lesson);
                                }
                            }
                        }
                        catch { }

                        if (i % 11 == 0)
                        {
                            k += 12;
                            i += 2;
                        }
                    }
                }
            }

            fileRepository.ImportSchedule(lessons);

            return View(new LessonsViewModel() { lessons = lessons });
        }
    }
}