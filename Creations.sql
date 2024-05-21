Create database RamyaEmployeeDirectoryDB;

create table employee(
 [Id] varchar(30) primary key not null,
 [FirstName] varchar(30) not null,
 [LastName] varchar(30) not null,
 [Email] varchar(30) not null,
 [MobileNumber] bigint,
 [DateOfBirth] varchar(30),
 [DateOfJoin] varchar(30),
 [Location] varchar(30),
 [JobTitle] varchar(30),
 [Department] varchar(30),
 [Manager] varchar(30),
 [Project] varchar(30)
);


create table [Roles](
 [Name] varchar(30) not null,
 [Location] varchar(30),
 [Department] varchar(30) not null,
 [Description] varchar(30) 
);
