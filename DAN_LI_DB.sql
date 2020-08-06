CREATE DATABASE DAN_LI
 IF DB_ID('DAN_LI') IS NULL
CREATE DATABASE DAN_LI;
GO
USE DAN_LI;
--we provided drop tables
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblDoctors')
drop table tblDoctors;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblPatients')
drop table tblPatients ;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblSickLeave')
drop table tblSickLeave ;


CREATE TABLE tblDoctors(
 DoctorID int IDENTITY(1,1) Primary key not null, --Primary key
 DoctorName  nvarchar (50) not null,
 DoctorSurname  nvarchar (50) not null,
 JMBG nvarchar(13) not null unique check (JMBG not like '%[^0-9]%') , --jmbg validation
 AccountNumber nvarchar (50) not null unique,
 Username nvarchar (50) not null unique,
 Pasword nvarchar (50) not null,
 

 )

 CREATE TABLE tblSickLeave(
 SickLeaveID int IDENTITY(1,1) Primary key not null, --Primary key
 OpenDate date,
 Reason  nvarchar (50) not null,
 Company  nvarchar (50) not null,
 Urgency bit,
 )

CREATE TABLE tblPatients(
 PatientID int IDENTITY(1,1) Primary key not null, --Primary key
 FullName  nvarchar (50) not null,
 JMBG nvarchar(13) not null unique check (JMBG not like '%[^0-9]%') , --jmbg validation
 MedicalRecord nvarchar (50) not null unique,
 Username nvarchar (50) not null unique,
 Pasword nvarchar (50) not null,
 DoctorID int,
 SickLeaveID int,
 
)

ALTER TABLE tblPatients
ADD FOREIGN KEY (DoctorID) REFERENCES tblDoctors(DoctorID);

ALTER TABLE tblPatients
ADD FOREIGN KEY (SickLeaveID) REFERENCES tblSickLeave(SickLeaveID);
