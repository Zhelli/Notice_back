using Notice.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notice.DAL.Interfaces
{
    public interface IFileRepository : IBaseRepository
    {
        public void ImportSchedule(List<Lesson> lessons);
    }
}
