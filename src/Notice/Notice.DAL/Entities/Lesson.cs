using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Entities
{
    public class Lesson
    {
        public string ClassName;

        public int ClassId;

        public int TeacherId;

        public string FullTeacherName;

        public string Subject;

        public string DayOfWeek;

        public int NumberOfLesson;

        public string Classroom;

        public Lesson() { }

        public Lesson(SqlDataReader reader)
        {
            ClassName = reader.GetString(0);
            ClassId = reader.GetInt32(1);
            TeacherId = reader.GetInt32(2); ;
            FullTeacherName = $"{reader.GetString(3)} {reader.GetString(4)[0]}.{reader.GetString(5)[0]}.";
            Subject = reader.GetString(6);
            DayOfWeek = reader.GetString(7);
            NumberOfLesson = reader.GetInt32(8); ;
            Classroom = reader.GetString(9);
        }
    }
}