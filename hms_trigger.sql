use hms;
  /*on ipd , changes to rooms*/
ALTER TRIGGER beds2 
ON dbo.IPD
AFTER INSERT 
AS UPDATE Rooms SET Vacant_beds=Vacant_beds-1 WHERE Rid=(SELECT i.Room_No FROM inserted AS i);

DELETE FROM Doctors where D_ID=10;



ALTER TRIGGER beds_update
ON dbo.IPD
AFTER UPDATE
AS
BEGIN
DECLARE @Pid integer ,@Rido integer ,@Ridn integer
SET @Pid=(SELECT i.PId FROM inserted i)
SET @Ridn=(SELECT i.Room_No FROM inserted i)
SET @Rido=(SELECT d.Room_No FROM deleted d)
IF (@Rido>0)
BEGIN
/*INSERT INTO test(test.Pid,test.Rid,test.ridn) Values(@Pid,@Rido,@Ridn); asach test sathi*/
/*inserted stores new value deleted stores old value for update command*/
UPDATE Rooms SET Vacant_beds=Vacant_beds+1 WHERE Rid=@Rido;
UPDATE Rooms SET Vacant_beds=Vacant_beds-1 WHERE Rid=@Ridn;
END
ELSE
UPDATE Rooms SET Vacant_beds=Vacant_beds-1 WHERE Rid=@Ridn;
END


ALTER TRIGGER room_update
ON dbo.Rooms
AFTER UPDATE
AS
BEGIN
DECLARE @Rid integer ,@newno integer ,@oldno integer,@diff integer
SET @Rid=(SELECT i.RId FROM inserted i)
SET @newno=(SELECT i.No_of_beds FROM inserted i)
SET @oldno=(SELECT d.No_of_beds FROM deleted d)
SET @diff=@newno-@oldno
IF (@diff<>0)
BEGIN
/*INSERT INTO test(test.Pid,test.Rid,test.ridn) Values(@Pid,@Rido,@Ridn); asach test sathi*/
/*inserted stores new value deleted stores old value for update command*/
UPDATE Rooms SET Vacant_beds=Vacant_beds+@diff WHERE Rid=@Rid;
END
END




ALTER TABLE test
ADD ridn integer;

CREATE TABLE test (Pid integer primary key,Rid integer);
SELECT * FROM IPD;
SELECT * FROM test;
Truncate table test;

UPDATE IPD SET Room_No=204 WHERE PId=178;

 SELECT * From Rooms;
 UPDATE Rooms SET No_of_beds=8 WHERE Rid=204;






  /*on patients ,changes to ipd,opd*/
ALTER TRIGGER ipd_patients
ON dbo.Patients
AFTER INSERT
AS 
BEGIN
DECLARE @Dept char(1)
SET @Dept=(SELECT i.Department FROM inserted i)
IF (@Dept='I')
BEGIN
INSERT INTO IPD(IPD.PId,IPD.Doctor_ID,IPD.Admission_Date) 
VALUES((SELECT i.Case_ID FROM inserted i),(SELECT i.Doctor_ID FROM inserted i),GETDATE());
END
ELSE IF (@Dept='O')
BEGIN
INSERT INTO OPD(OPD.PId,OPD.Doctor_ID) 
VALUES((SELECT i.Case_ID FROM inserted i),(SELECT i.Doctor_ID FROM inserted i));
END
end

CREATE TRIGGER 



SELECT * FROM OPD;
SELECT * FROM Patients;
SELECT * FROM Patients FULL OUTER JOIN OPD ON Patients.Case_ID=OPD.PId ;
SELECT * FROM Rooms;
DELETE FROM IPD WHERE PId=127;
INSERT INTO IPD VALUES(127,002,12000,'2023-04-01','2023-04-02',204);

INSERT INTO Patients(PName,Age,Phone,Doctor_ID,Department,Case_ID,gender) VALUES
('Mubin Raju',21,2223331111,2,'I',127,'M');

SELECT * FROM OPD;




CREATE TRIGGER deletebeds 
ON dbo.IPD
AFTER DELETE 
AS UPDATE Rooms SET Vacant_beds=Vacant_beds+1 WHERE Rid=(SELECT d.Room_No FROM deleted AS d);



/*
create proc patient_Insert 
@student_rollNo int,
@student_name varchar(100),
@student_address varchar(100),
@Parent_name varchar(100),
@parent_phoneNo int,
@flag varchar(20),
@class int,
@AmdDate datetime,
@leaving_Yr int
as
begin
insert into Student (student_rollNo, student_name, student_address, Parent_name, parent_phoneNo, flag, class, AmdDate, leaving_Yr)
values (@student_rollNo, @student_name, @student_address, @Parent_name, @parent_phoneNo, @flag, @class, @AmdDate, @leaving_Yr)
end

 

create proc StudentView
as 
begin
select * from Student
end

CREATE table customer(id integer primary key,CName varchar(20));
Insert into customer values(13,'Astha');
Select * from Patients;
*/

/* PROCEDURES*/

CREATE PROC Doctorview
AS 
BEGIN
SELECT * FROM Doctors
END

ALTER PROC Patientsview
AS 
BEGIN
SELECT * FROM Patients
END

Select * from Rooms ;
