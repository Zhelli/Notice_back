CREATE PROCEDURE GetAllClasses
AS
SELECT * FROM Notice.Class;

EXEC GetAllClasses;
GO

CREATE PROCEDURE AddLesson
@classId		INT,
@teacherId		INT,
@subject		NVARCHAR(50),
@dayOfWeek		NVARCHAR(50),
@numberOfLesson INT,
@classroom		NVARCHAR(20)
AS
INSERT INTO Notice.Lesson(ClassId, TeacherId, Subject, DayOfWeek, NumberOfLesson, Classroom)
VALUES (@classId, @teacherId, @subject, @dayOfWeek, @numberOfLesson, @classroom);
GO

CREATE PROCEDURE AddClass
@className NVARCHAR(50),
@teacherId INT
AS
INSERT INTO Notice.Class(ClassName, TeacherId)
VALUES (@className, @teacherId);
GO

exec AddClass '5-F', null

CREATE PROCEDURE GetClassId
@className NVARCHAR(50)
AS
SELECT Id FROM Notice.Class WHERE ClassName = @className;
GO

CREATE PROCEDURE GetAllLessons
AS
SELECT ClassName, Lesson.ClassId, Lesson.TeacherId, SchoolWorker.LastName, 
SchoolWorker.FirstName, SchoolWorker.Patronymic, Subject, 
DayOfWeek, NumberOfLesson, Classroom 
FROM Notice.Class, Notice.Lesson, Notice.SchoolWorker
WHERE Notice.Class.Id = Notice.Lesson.ClassId AND 
Notice.Class.TeacherId = Notice.SchoolWorker.Id;
GO

CREATE PROCEDURE GetAllLessonsByClassName
@className NVARCHAR(50)
AS
SELECT ClassName, Lesson.ClassId, Lesson.TeacherId, SchoolWorker.LastName, 
SchoolWorker.FirstName, SchoolWorker.Patronymic, Subject, 
DayOfWeek, NumberOfLesson, Classroom 
FROM Notice.Class, Notice.Lesson, Notice.SchoolWorker
WHERE Notice.Class.Id = Notice.Lesson.ClassId AND 
Notice.Class.TeacherId = Notice.SchoolWorker.Id AND
Notice.Class.ClassName LIKE '%'+ @className +'%';
GO

select * from Notice.SchoolWorker 