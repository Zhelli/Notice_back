INSERT INTO Notice.SchoolWorker(Login, Password, LastName, FirstName, Patronymic, 
Email, PhoneNumber, DateOfBirth, TypeOfUser) 
VALUES('admin', 'qwe123!1', 'Petrenko', 'Anastasia', 'Viktorovna',
'petrenko_av@gmail.com', '+380983452690', 1980-05-23, 'A'), --1
('login', '234asd2/', 'Dmitrienko', 'Ann', 'Vasilievna',
'dmitr.an56@ukr.net', '+380954938027', 1972-07-12, 'A'),--2
('logon', '456asd2/', 'Chernyshov', 'Maksim', 'Nykolaevich',
'mr.chernishov@ukr.net', '+380934538427', 1968-05-19, 'T'),--3
('logint', 'asdfgh2/', 'Skorohodova', 'Tatty', 'Aleksandrovna',
'ann.skoroxod@gmail.com', '+380954956034', 1982-11-13, 'T'),--4
('logine', '234a.rt2/', 'Grygoryevna', 'Anny', 'Petrovna',
'gri.maria79@gmail.com', '+380954937823', 1979-08-15, 'T'),--5
('loginw', '289asd2/', 'Vynogradova', 'Zoya', 'Dmytrievna',
'vinograd123z@gmail.com', '+380634938043', 1975-10-30, 'T'),--6
('loginb', '212asd2/', 'Tsvetochnaya', 'Mira', 'Yurievna',
'flower.olesya@ukr.net', '+380967834522', 1992-06-17, 'T'),--7
('loginm', '267asd2/', 'Pirogova', 'Ekaterina', 'Romanovna',
'katepirogooo@gmail.com', '+380934943712', 1984-12-15, 'T'),--8
('loginl', '894asd2/', 'Yankovskaya', 'Valentina', 'Mykhailovna',
'yank.ava88@gmail.com', '+380684908756', 1988-02-18, 'T'),--9
('logink', '454asd2/', 'Arbuzova', 'Alex', 'Ivanovna',
'watermelonalex@gmail.com', '+380634930677', 1985-07-25, 'T'),--10
('loginj', '234asd2/', 'Derevko', 'Irina', 'Mykovaivna',
'de.iritree15@ukr.net', '+380983248098', 1980-02-09, 'T');--11
GO

INSERT INTO Notice.Class(ClassName, TeacherId) VALUES
('7-�', 2),--1
('8-�', 4),--2
('9-�', 5),--3
('9-�', 7),--4
('10-�', 10),--5
('11-�', 3),--6
('11-�', 8),--7
('6-�', 9);--8
GO

INSERT INTO Notice.Lesson(ClassId, TeacherId, Subject, DayOfWeek,
NumberOfLesson, Classroom)
VALUES
(1, 1, '���������� ����', '��', 2, '12'),--1
(1, 1, '���������� ����', '��', 1, '12'),--2
(1, 1, '���������� ����', '��', 4, '12'),--3
(1, 2, '�������', '��', 1, '12'),--4
(1, 2, '�������', '��', 3, '15'),--5
(1, 2, '�������', '��', 2, '20'),--6
(8, 2, '�������', '��', 2, '12'),--7
(8, 2, '�������', '��', 2, '15'),--8
(8, 2, '�������', '��', 1, '20'),--9

(2, 2, '�������', '��', 3, '12'),--10
(2, 2, '�������', '��', 4, '12'),--11
(2, 2, '�������', '��', 4, '2'),--12

(3, 3, '�������', '��', 1, '2'),--13
(3, 3, '�������', '��', 2, '2'),--14
(3, 3, '�������', '��', 3, '10'),--15
(3, 3, '�������', '��', 4, '2'),--16

(4, 3, '�������', '��', 3, '2'),--17
(4, 3, '�������', '��', 1, '10'),--18
(4, 3, '�������', '��', 2, '10'),--19
(4, 3, '�������', '��', 3, '12'),--20

(5, 4, '�������', '��', 1, '24'),--21
(5, 4, '�������', '��', 1, '24'),--22
(5, 4, '�������', '��', 3, '24'),--23
(6, 4, '�������', '��', 4, '24'),--24
(6, 4, '�������', '��', 3, '24'),--25
(6, 4, '�������', '��', 4, '24'),--26

(7, 4, '�������', '��', 3, '24'),--27
(7, 4, '�������', '��', 4, '24'),--28
(7, 4, '�������', '��', 1, '24'),--29

(1, 2, '���������', '��', 2, '12'),--30
(1, 2, '���������', '��', 3, '12'),--31
(1, 2, '���������', '��', 4, '12'),--32

(8, 2, '���������', '��', 1, '12'),--33
(8, 2, '���������', '��', 1, '12'),--34
(8, 2, '���������', '��', 2, '12'),--35

(2, 2, '���������', '��', 1, '15'),--36
(2, 2, '���������', '��', 4, '15'),--37
(2, 2, '���������', '��', 3, '20'),--38

(3, 3, '���������', '��', 2, '12'),--39
(3, 3, '���������', '��', 3, '12'),--40
(3, 3, '���������', '��', 1, '12'),--41
(3, 3, '���������', '��', 1, '12'),--42

(4, 3, '���������', '��', 4, '12'),--43
(4, 3, '���������', '��', 5, '12'),--44
(4, 3, '���������', '��', 4, '2'),--45
(4, 3, '���������', '��', 2, '12'),--46

(5, 4, '���������', '��', 1, '24'),--47
(5, 4, '���������', '��', 1, '24'),--48
(5, 4, '���������', '��', 2, '24'),--49

(6, 4, '���������', '��', 2, '24'),--50
(6, 4, '���������', '��', 2, '24'),--51
(6, 4, '���������', '��', 3, '24'),--52

(7, 4, '���������', '��', 3, '24'),--53
(7, 4, '���������', '��', 4, '24'),--54
(7, 4, '���������', '��', 2, '24'),--55

(1, 5, '���������', '��', 3, '14'),--56
(1, 5, '���������', '��', 3, '14'),--57

(2, 5, '���������', '��', 4, '14'),--58
(2, 5, '���������', '��', 2, '14'),--59

(3, 5, '���������', '��', 1, '14'),--60
(3, 5, '���������', '��', 4, '14'),--61

(4, 5, '���������', '��', 2, '14'),--62
(4, 5, '���������', '��', 1, '14'),--63

(5, 5, '���������', '��', 5, '14'),--64
(5, 5, '���������', '��', 5, '14'),--65

(6, 5, '���������', '��', 3, '14'),--66
(6, 5, '���������', '��', 4, '14'),--67

(7, 5, '���������', '��', 4, '14'),--68
(7, 5, '���������', '��', 2, '14'),--69

(8, 5, '���������', '��', 1, '14'),--70
(8, 5, '���������', '��', 3, '14'),--71

(1, 6, '�����������', '��', 5, '12'),--72
(2, 6, '�����������', '��', 5, '12'),--73
(3, 6, '�����������', '��', 5, '12'),--74

(4, 6, '�����������', '��', 6, '15'),--75
(5, 6, '�����������', '��', 6, '15'),--76
(6, 6, '�����������', '��', 6, '20'),--77

(7, 3, '�����������', '��', 7, '12'),--78
(8, 3, '�����������', '��', 6, '12');--79
GO

INSERT INTO Notice.Pupil(Login, Password, LastName, FirstName, Patronymic, 
ClassId, Email, PhoneNumber, DateOfBirth, TypeOfUser) 
VALUES
('pupil3214', 'zxcv1234!', 'Scherbak', 'Nikita', 'Victorovich',
1, 'nikita1289@gmail.com', NULL, 2006-08-13, 'P'), --1
('pupil6708', '234kljhy.', 'Diakonenko', 'Anna', 'Aleksandrovna',
1, NULL, NULL, 2006-07-12, 'P'),--2
('pupil8967', '456asrf_', 'Horelov', 'Evhenii', 'Nikolaevich',
2, NULL, NULL, 2005-05-19, 'P'),--3
('pupil0978', 'akldre34_', 'Ziomenko', 'Marina', 'Aleksandrovna',
3, 'zio_marinko@gmail.com', NULL, 2005-11-13, 'P'),--4
('pupil3409', '234a.rr3', 'Andreyeva', 'Olga', 'Petrovna',
3, 'ol.andre79@gmail.com', '+380950087823', 2005-08-15, 'P'),--5
('pupil7214', '289alk.23', 'Vavilov', 'Arthur', 'Mihailovich',
3, 'vaaaartur@gmail.com', '+380632068043', 2005-10-30, 'P'),--6
('pupil6709', '212.45ko', 'Herasimova', 'Anastasiya', 'Yurievna',
4, NULL, NULL, 2005-06-17, 'P'),--7
('pupil2387', '267a_uhj', 'Svetlov', 'Valerii', 'Romanovich',
5,'katepirogooo@gmail.com', '+380932923712', 2004-12-15, 'P'),--8
('pupil9834', '894as_lf8', 'Yurchenko', 'Dariya', 'Mihailovna',
6, NULL, '+380684336756', 2004-02-18, 'P'),--9
('pupil6756', '454ako.p', 'Barinova', 'Alla', 'Ivanovna',
7, 'mbaralla34@gmail.com', NULL, 2003-07-25, 'P'),--10
('pupil7842', '234ahu*9', 'Drobiazko', 'Margarita', 'Nikolaivna',
8,'de.ritee15@gmail.com', '+380983568098', 2009-02-09, 'P'),--11
('pupil8812', '23vg7h_9', 'Kulich', 'Agata', 'Albertovna',
8,NULL, '+380983248098', 2009-12-29, 'P'),--12
('pupil7912', '2_4ahtr9', 'Gromova', 'Tatiana', 'Andreevna',
8, NULL, NULL, 2009-05-08, 'P'),--13
('pupil0556', '4_hmahu9', 'Burov', 'Vladimir', 'Nikolaevich',
8,NULL, '+380663248098', 2009-06-05, 'P'),--14
('pupil5637', '2.ghju9', 'Zukov', 'Evhenii', 'Aleksandrovich',
8,'evxyznii@gmail.com', NULL, 2009-04-08, 'P');--15
GO

INSERT INTO Notice.Event(AuthorId, Title, Description, DateOfEvent)
VALUES
(1, 'Mathematics Olympiad',
'III (regional) stage of the Olympiad in mathematics, the venue is KhNU of V.N. Karazin',
2020-12-18), --1
(1, 'Tournament of Young Biologists',
'II (district) stage of the XVII tournament of young biologists, the venue is School No. 108',
2020-12-21), --2
(2, 'Halloween Flashmob',
'On Monday we are waiting for everyone on the ground floor at the 3rd and 4th breaks We will hold contests and choose the most creative festive outfit! ',
2020-11-02), --3
(3, 'Excursion to Poltava',
'I invite everyone to a one-day excursion to Poltava. We will visit the Poltava Museum of Local Lore, the famous Museum-Estate of I. Kotlyarevsky, learn to make the traditional Poltava dumplings and then will taste them. Please decide whether or not you are going until 30.10 ',
NULL), --4
(4, 'Drawing competition for the Day of Remembrance of the Victims of the Holodomor of 1932-1933',
'Everyone can participate. Bring your work to the classroom of school self-government until 25.11 ',
NULL), --5
(1, 'Olympiad in English', 'City Olympiad in English, the venue is KhNU of V.N. Karazin',
2020-11-28), --6
(1, 'Tournament of Young Geographers',
'II (district) stage of the XVII tournament of young Geographers, the venue is School No. 126',
2020-11-27), --7
(1, 'Meeting with representatives of the team of the Kharkiv mayor',
'The meeting will take place in the assembly hall from 12:00 to 14:00. There is an opportunity to ask questions of interest. Everyone should be present. If you are not there, please notify in advance. ',
2020-11-04); --8
GO

INSERT INTO Notice.NotifyingSchoolWorker(EventId, RecipientTeacherId, TypeOfUser)
VALUES
(8, 2, 'T'), --1
(8, 3, 'T'), --2
(8, 4, 'T'), --3
(8, 5, 'T'), --4
(8, 6, 'T'), --5
(8, 7, 'T'), --6
(8, 8, 'T'), --7
(8, 9, 'T'), --8
(8, 10, 'T'), --9
(8, 11, 'T'); --10
GO

INSERT INTO Notice.NotifyingPupil(EventId, RecipientPupilId, TypeOfUser)
VALUES
(4, 12, 'P'), --1
(4, 13, 'P'), --2
(4, 14, 'P'), --3
(4, 15, 'P'), --4
(1, 4, 'P'), --5
(1, 6, 'P'), --6
(1, 8, 'P'), --7
(1, 10, 'P'), --8
(2, 5, 'P'), --9
(2, 6, 'P'), --10
(2, 7, 'P'), --11
(2, 9, 'P'), --12
(2, 10, 'P'), --13
(3, 1, 'P'), --14
(3, 2, 'P'), --15
(3, 3, 'P'), --16
(3, 4, 'P'), --17
(3, 5, 'P'), --18
(3, 6, 'P'), --19
(3, 7, 'P'), --20
(3, 8, 'P'), --21
(3, 9, 'P'), --22
(3, 10, 'P'), --23
(3, 11, 'P'), --24
(3, 12, 'P'), --25
(3, 13, 'P'), --26
(3, 14, 'P'), --27
(3, 15, 'P'), --28
(5, 1, 'P'), --29
(5, 2, 'P'), --30
(5, 3, 'P'), --31
(5, 4, 'P'), --32
(5, 5, 'P'), --33
(5, 6, 'P'), --34
(5, 7, 'P'), --35
(5, 8, 'P'), --36
(5, 9, 'P'), --37
(5, 10, 'P'), --38
(5, 11, 'P'), --39
(5, 12, 'P'), --40
(5, 13, 'P'), --41
(5, 14, 'P'), --42
(5, 15, 'P'), --43
(6, 7, 'P'), --44
(6, 8, 'P'), --45
(7, 4, 'P'), --46
(7, 5, 'P'), --47
(7, 7, 'P'), --48
(7, 8, 'P'), --49
(7, 10, 'P'); --50
GO