use MSSQL_Test;

Drop TABLE Employees;

CREATE TABLE Employees(
	empID integer PRIMARY KEY Identity(101, 1),
	empFirstName varchar(30) NOT NULL,
	empLastName varchar(30) NOT NULL,
	empAge integer NOT NULL
)

--DBCC CHECKIDENT ('[Employees]', RESEED, 106);

Select * from Employees;

insert into dbo.Employees values( 'Janet', 'Stevens', 50);
insert into dbo.Employees values( 'Jim', 'Bob', 43);
insert into dbo.Employees values( 'Will', 'Johnson', 27);
insert into dbo.Employees values( 'Margaret', 'Adams', 33);
insert into dbo.Employees values( 'Johann', 'Lee', 22);