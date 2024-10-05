create database Library_Management_System;

use Library_Management_System;

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(100) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Enroll NVARCHAR(100) NOT NULL,
    Contact NVARCHAR(15),
    Email NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    DOB DATE NOT NULL,
    Gender VARCHAR(100) NOT NULL,
    UserType INT NOT NULL
);


CREATE TABLE Librarian (
    LibrarianSL INT PRIMARY KEY IDENTITY(1,1),
    Id INT NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (Id) REFERENCES Users(Id)
);

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

CREATE TABLE [dbo].[IRBook](
	[BID] [int] IDENTITY(1,1) NOT NULL,
	[Stu_enroll] [varchar](100) NOT NULL,
	[Stu_name] [varchar](100) NOT NULL,
	[PhoneNo] [NVARCHAR] (100) NOT NULL,
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
	[PhoneNo] [NVARCHAR](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Book] [varchar] (1000) NOT NULL,
	[Price] [int] default(0),
	
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
));




SELECT U.*, L.Salary FROM Users U INNER JOIN Librarian L ON U.Id = L.Id WHERE U.UserType = 2;

SELECT U.*, L.Salary FROM Users U INNER JOIN Librarian L ON U.Id = L.Id WHERE U.UserType = 2 AND U.Id=5;
