CREATE PROCEDURE AddEvent
@authorId INT,
@title NVARCHAR(50),
@description NVARCHAR(350) NULL,
@dateOfEvent DATETIME NULL
AS
BEGIN
INSERT INTO Notice.Event(AuthorId, Title, Description, DateOfEvent)
VALUES (@authorId, @title, @description, @dateOfEvent);

SELECT Id FROM Notice.Event WHERE AuthorId = @authorId AND Title = @title
AND (Description IS NULL OR Description = @description) AND (DateOfEvent = @dateOfEvent OR DateOfEvent IS NULL);
END
GO

exec AddEvent 2, 'Olympic of History 3rd stage', null, null;
GO

CREATE PROCEDURE GetAllEvents
AS
SELECT * FROM Notice.Event;
GO

exec GetAllEvents

CREATE PROCEDURE GetAllPupils
AS
SELECT Pupil.Id, CONCAT(LastName, ' ',
		Substring(FirstName, 1, 1), '. ',
		Substring(Patronymic, 1, 1), '.') AS FullName, Email, ClassName
 FROM Notice.Pupil, Notice.Class WHERE ClassId = Class.Id;
GO

CREATE PROCEDURE GetAllTeachers
AS
SELECT Id, CONCAT(LastName, ' ',
		Substring(FirstName, 1, 1), '. ',
		Substring(Patronymic, 1, 1), '.') AS FullName, Email
FROM Notice.SchoolWorker WHERE TypeOfUser LIKE 'T';
GO

CREATE PROCEDURE GetAllAdmins
AS
SELECT Id, CONCAT(LastName, ' ',
		Substring(FirstName, 1, 1), '. ',
		Substring(Patronymic, 1, 1), '.') AS FullName, Email
FROM Notice.SchoolWorker WHERE TypeOfUser LIKE 'A';
GO

CREATE PROCEDURE AddNotificationForPupil
@eventId INT,
@pupilId INT
AS
INSERT INTO Notice.NotifyingPupil(EventId, RecipientPupilId, TypeOfUser)
VALUES(@eventId, @pupilId, 'P');
GO

CREATE PROCEDURE AddNotificationForSchoolWorker
@eventId INT,
@schoolWorkerId INT,
@role NVARCHAR(1)
AS
INSERT INTO Notice.NotifyingSchoolWorker(EventId, RecipientTeacherId, TypeOfUser)
VALUES(@eventId, @schoolWorkerId, @role);
GO


exec AddNotificationForSchoolWorker 10, 14, 'T'
 

CREATE PROCEDURE GetPupilsOfEventById
@eventId INT
AS
SELECT Pupil.Id, CONCAT(LastName, ' ',
		Substring(FirstName, 1, 1), '. ',
		Substring(Patronymic, 1, 1), '.') AS FullName,
		ClassName
FROM Notice.Pupil, Notice.Class, Notice.NotifyingPupil
WHERE Pupil.ClassId = Class.Id AND 
Pupil.Id = NotifyingPupil.RecipientPupilId AND
NotifyingPupil.EventId = @eventId;
GO

CREATE PROCEDURE GetTeachersOfEventById
@eventId INT
AS
SELECT SchoolWorker.Id, CONCAT(LastName, ' ',
		Substring(FirstName, 1, 1), '. ',
		Substring(Patronymic, 1, 1), '.') AS FullName
FROM Notice.SchoolWorker, Notice.NotifyingSchoolWorker
WHERE SchoolWorker.Id = NotifyingSchoolWorker.RecipientTeacherId AND
NotifyingSchoolWorker.EventId = @eventId;
GO

CREATE PROCEDURE GetEventById
@eventId INT
AS
SELECT * FROM Notice.Event WHERE Id = @eventId;
GO

select * from Notice.SchoolWorker

GO
CREATE PROCEDURE GetPupilEmailById
@id INT
AS
SELECT Email FROM Notice.Pupil WHERE Pupil.Id = @id;
GO

exec GetPupilEmailById 14;
GO


CREATE PROCEDURE GetTecherEmailById
@id INT
AS
SELECT Email FROM Notice.SchoolWorker WHERE Id = @id;
GO

CREATE PROCEDURE GetNotifications
@schoolWorkerId INT
AS
SELECT title, Event.Id from Notice.Event, Notice.NotifyingSchoolWorker
WHERE Event.Id = NotifyingSchoolWorker.EventId AND 
NotifyingSchoolWorker.RecipientTeacherId = @schoolWorkerId
GO