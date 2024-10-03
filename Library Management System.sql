create database Library_Management_System;

use Library_Management_System;


CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[Publication] [varchar](50) NOT NULL,
	[ISBN] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
));

CREATE TABLE [dbo].[Librarian](
	[LibrarianSL] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Contact] [varchar](100) NOT NULL,
	[Date_of_birth] [varchar](100) NOT NULL,
	[Gender] [varchar](100) NOT NULL,
	[Salary] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LibrarianSL] ASC
));

CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[enroll] [varchar](100) NOT NULL,
	[Contact] [bigint] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[address] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
));

CREATE TABLE [dbo].[IRBook](
	[BID] [int] IDENTITY(1,1) NOT NULL,
	[Stu_enroll] [varchar](100) NOT NULL,
	[Stu_name] [varchar](100) NOT NULL,
	[PhoneNo] [bigint] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Book_name] [varchar](100) NOT NULL,
	[Book_issue_date] [varchar](100) NOT NULL,
	[Book_return_date] [varchar](100) NULL,
	[Fine] [int] default(0),

PRIMARY KEY CLUSTERED 
(
	[BID] ASC
));


CREATE TABLE [dbo].[Accounts](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Stu_Name] [varchar](50) NOT NULL,
	[PhoneNo] [int] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Book] [varchar] (1000) NOT NULL,
	[Price] [int] default(0),
	
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
));



INSERT INTO [dbo].[Student]
           ([Name]
           ,[enroll]
           ,[Contact]
           ,[email]
           ,[address])
     VALUES
           ('Sara'        -- Name (varchar)
           ,'en-005'     -- Enrollment (varchar)
           ,857875       -- Contact (bigint)
           ,'sara@gmail.com' -- Email (varchar)
           ,'Barishall');  -- Address (varchar)

		   INSERT INTO [dbo].[Librarian]
           ([UserID]
           ,[Password]
           ,[Email]
           ,[Contact]
           ,[Date_of_birth]
           ,[Gender]
           ,[Salary])
     VALUES
           ('user4'           -- UserID (varchar)
           ,'2121'         -- Password (varchar)
           ,'user4@example.com' -- Email (varchar)
           ,'676545'       -- Contact (varchar)
           ,'2001-10-10'       -- Date of Birth (date or varchar)
           ,'Male'             -- Gender (varchar)
           ,10000);            -- Salary (bigint)


		   INSERT INTO [dbo].[Book]
           ([Name]
           ,[Author]
           ,[Publication]
           ,[ISBN]
           ,[Quantity]
           ,[Price])
     VALUES
           ('Database System Concepts'       -- Name (varchar)
           ,'Abraham Silberschatz'     -- Author (varchar)
           ,'McGraw-Hill' -- Publication (varchar)
           ,'103'      -- ISBN (varchar)
           ,40                -- Quantity (int)
           ,1500);             -- Price (int)
		   



		   ALTER TABLE [dbo].[Student]
           ADD [Password] bigint;


		   ALTER TABLE Student
           ALTER COLUMN Password varchar(100);


		    ALTER TABLE Student
           ADD DateOfBirth DATE;