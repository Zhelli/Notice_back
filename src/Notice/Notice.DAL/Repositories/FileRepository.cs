using Microsoft.Extensions.Options;
using Notice.DAL.Entities;
using Notice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notice.DAL.Repositories
{
    public class FileRepository : BaseRepository, IFileRepository
    {
        public FileRepository(IOptions<DbConnection> options) : base(options) { }

        public void ImportSchedule(List<Lesson> lessons)
        {
            Random r = new Random();

            foreach (var lesson in lessons)
            {
                Dictionary<string, object> paramValue = new Dictionary<string, object>()
                {
                    ["@className"] = lesson.ClassName
                };

                Dictionary<string, object> paramsValues = new Dictionary<string, object>()
                {
                    ["@className"] = lesson.ClassName,
                    ["@teacherId"] = DBNull.Value
                };

                List<int> ids = GettingData("GetClassId", reader => reader.GetInt32(0), paramValue);

                int id = 0;
                if (ids.Count() == 0)
                {
                    GettingData("AddClass", reader => reader.GetString(0), paramsValues);
                    id = GettingData("GetClassId", reader => reader.GetInt32(0), paramValue).First();
                }
                else
                {
                    id = ids.First();
                }
                int teacherId = r.Next(3, 12);
                paramValue = new Dictionary<string, object>()
                {
                    ["@classId"] = id,
                    ["@teacherId"] = teacherId,
                    ["@subject"] = lesson.Subject,
                    ["@dayOfWeek"] = lesson.DayOfWeek,
                    ["@numberOfLesson"] = lesson.NumberOfLesson,
                    ["@classroom"] = lesson.Classroom
                };

                GettingData("AddLesson", reader => reader.GetString(0), paramValue);
            }
        }
    }
}