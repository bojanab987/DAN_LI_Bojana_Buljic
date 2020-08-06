IF DB_ID('MedicalCareCenter') IS NULL
    create database MedicalCareCenter;
GO	
use MedicalCareCenter
--Deleting tables and views, if they exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblSickLeave')
	drop table tblSickLeave;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblDoctor')
	drop table tblDoctor;
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblPatient')
	drop table tblPatient;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblUser')
	drop table tblUser;
IF EXISTS(select * FROM sys.views where name = 'vwSickLeave')
	drop view vwSickLeave;
IF EXISTS(select * FROM sys.views where name = 'vwDoctor')
	drop view vwDoctor;
	IF EXISTS(select * FROM sys.views where name = 'vwPatient')
	drop view vwPatient;
IF EXISTS(select * FROM sys.views where name = 'vwUser')
	drop view vwUser;
GO

create table tblUser(
UserId int identity(1,1) PRIMARY KEY,
Name varchar(50) NOT NULL,
Surname varchar(50) NOT NULL,
JMBG varchar(13) NOT NULL CHECK(LEN(JMBG)=13 AND ISNUMERIC(JMBG)=1),
Username varchar(40) UNIQUE NOT NULL,
Password varchar(255) NOT NULL
);

create table tblDoctor(
DoctorId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
BankAccountNo varchar(18) UNIQUE NOT NULL,
);

create table tblPatient(
PatientId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
HealthInsuranceCardNo varchar(11) UNIQUE NOT NULL,
DoctorId int FOREIGN KEY REFERENCES tblDoctor(DoctorId),
);

create table tblSickLeave(
RequestId int identity(1,1) PRIMARY KEY,
RequestSendDate date NOT NULL,
SLReason varchar(250) NOT NULL,
Company varchar(100) NOT NULL,
CaseOfEmergency varchar(2) NOT NULL,
PatientId int FOREIGN KEY REFERENCES tblPatient(PatientId) NOT NULL
);

--Creating a views
GO
create view vwUser as
select *
from tblUser;
GO

create view vwDoctor as
select d.*, u.Name, u.Surname, u.JMBG, u.Username, u.Password
from tblDoctor d
INNER JOIN tblUser u
ON d.UserId = u.UserId;
GO

create view vwPatient as
select p.*, u.Name, u.Surname, u.JMBG, u.Username, u.Password
from tblPatient p
INNER JOIN tblUser u
ON p.UserId = u.UserId;
GO

create view vwSickLeave as
select p.*, s.CaseOfEmergency, s.Company, s.RequestSendDate, s.SLReason, u.Name, u.Surname
from tblSickLeave s
INNER JOIN tblPatient p
ON p.PatientId = s.PatientId
INNER JOIN tblUser u
ON u.UserId=p.UserId;