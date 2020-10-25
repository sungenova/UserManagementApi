create database UserManagementDB
go
use UserManagementDB
go
create table Users
(   
   IIN varchar(50) primary key,
   FirstName nvarchar(50) not null,
   LastName nvarchar(50) not null,
   BirthDate date not null
)