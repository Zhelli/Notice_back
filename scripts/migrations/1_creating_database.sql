PRINT N'Creating Notice...';
GO
CREATE SCHEMA [Notice];
GO

PRINT N'Creating Notice.SchoolWorker...';
GO
CREATE TABLE [Notice].[SchoolWorker] (
    [Id]			INT				  IDENTITY(1, 1) PRIMARY KEY,
    [Login]			NVARCHAR (50)     UNIQUE NOT NULL,
	[Password]		NVARCHAR (50)	  NOT NULL,
    [LastName]		NVARCHAR (50)     NOT NULL,
	[FirstName]		NVARCHAR (50)     NOT NULL,
	[Patronymic]	NVARCHAR (50)     NULL,
	[Email]			NVARCHAR (50)     NULL,
	[PhoneNumber]	NVARCHAR (50)     NULL,
	[DateOfBirth]	DATETIME		  NULL,
	[TypeOfUser]	NVARCHAR (1)      NOT NULL
	CONSTRAINT Check_SchoolWorker_TypeOfUser CHECK (TypeOfUser IN('T', 'A'))
);
GO

PRINT N'Creating Notice.Class...';
GO
CREATE TABLE [Notice].[Class] (
    [Id]			 INT			IDENTITY(1, 1) PRIMARY KEY,
	[ClassName]		 NVARCHAR (50)	UNIQUE NOT NULL,
    [TeacherId]		 INT			NULL
	CONSTRAINT FK_Class_To_Teacher  FOREIGN KEY (TeacherId) REFERENCES Notice.SchoolWorker(Id)
	ON UPDATE CASCADE ON DELETE SET NULL
);
GO

PRINT N'Creating Notice.Pupil...';
GO
CREATE TABLE [Notice].[Pupil] (
    [Id]			INT				  IDENTITY(1, 1) PRIMARY KEY,
    [Login]			NVARCHAR (50)     UNIQUE NOT NULL,
	[Password]		NVARCHAR (50)	  NOT NULL,
    [LastName]		NVARCHAR (50)     NOT NULL,
	[FirstName]		NVARCHAR (50)     NOT NULL,
	[Patronymic]	NVARCHAR (50)     NULL,
	[ClassId]		INT				  NULL,
	[Email]			NVARCHAR (50)     NULL,
	[PhoneNumber]	NVARCHAR (50)     NULL,
	[DateOfBirth]	DATETIME		  NULL,
	[TypeOfUser]	NVARCHAR (1)      DEFAULT('P') NOT NULL,
	CONSTRAINT FK_Pupil_To_Class FOREIGN KEY (ClassId) REFERENCES Notice.Class(Id)
	ON UPDATE CASCADE ON DELETE SET NULL
);
GO

PRINT N'Creating Notice.Lesson...';
GO
CREATE TABLE [Notice].[Lesson] (
    [ClassId]		 INT			NOT NULL,
    [TeacherId]		 INT			NOT NULL,
	[Subject]		 NVARCHAR (50)	NOT NULL,
	[DayOfWeek]		 NVARCHAR (50)	NOT NULL,
	[NumberOfLesson] INT			NOT NULL,
	[Classroom]		 NVARCHAR (20)	NOT NULL
	CONSTRAINT PK_Lesson PRIMARY KEY (ClassId, TeacherId, Subject, DayOfWeek, NumberOfLesson),
	CONSTRAINT FK_Lesson_To_Class FOREIGN KEY (ClassId) REFERENCES Notice.Class(Id),
	CONSTRAINT FK_Lesson_To_Teacher FOREIGN KEY (TeacherId) REFERENCES Notice.SchoolWorker(Id)
);
GO

PRINT N'Creating Notice.Event...';
GO
CREATE TABLE [Notice].[Event] (
    [Id]				INT				IDENTITY(1, 1) PRIMARY KEY,
    [AuthorId]			INT				NOT NULL,
	[Title]			    NVARCHAR (150)	NOT NULL,
	[Description]		NVARCHAR (350)	NULL,
	[DateOfEvent]		DATETIME		NULL
	CONSTRAINT FK_Event_To_SchoolWorker FOREIGN KEY (AuthorId) REFERENCES Notice.SchoolWorker(Id)
	ON UPDATE CASCADE ON DELETE CASCADE
);
GO

PRINT N'Creating Notice.Notifying...';
GO
CREATE TABLE [Notice].[Notifying] (
    [EventId]			INT				NOT NULL,
	[RecipientId]		INT				NOT NULL,
	[TypeOfUser]		NVARCHAR (1)    NOT NULL,
	[Status]			INT				DEFAULT (1) NOT NULL
	CONSTRAINT PK_Notifying PRIMARY KEY (EventId, RecipientId, TypeOfUser),
	CONSTRAINT FK_Notifying_To_Event FOREIGN KEY (EventId) REFERENCES Notice.Event(Id)
	ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_Notifying_To_Pupil FOREIGN KEY (RecipientId) REFERENCES Notice.Pupil(Id),
	CONSTRAINT FK_Notifying_To_SchoolWorker FOREIGN KEY (RecipientId) REFERENCES Notice.SchoolWorker(Id),
	CONSTRAINT Check_Notifying_TypeOfUser CHECK (TypeOfUser IN('P', 'T', 'A')),
	CONSTRAINT Check_Notifying_Status CHECK (TypeOfUser IN(0, 1))  -- 1 - unread, 0 - read
);
GO
