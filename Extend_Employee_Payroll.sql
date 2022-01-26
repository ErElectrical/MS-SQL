create database Employee_Company;

-- to do work with a paticular database we have to shift into that for that we do

use Employee_Company;
go

--SQL Server allows the user to list all databases stored in the database engine by using the following command:
-- it will display the all databases we have available 

select name from master.sys.databases order by name;

-- we are going to delete not required databases.
--SQL Server enables users to remove the database from the server instance by using the below syntax:

--DROP DATABASE [IF EXIST] database_name    

-- if we have to delete multiple database with a single line command than define databse_name seprearted by comma
-- [if exist] clause is optional but if database name is not available it will through an error .

drop database if exists Payroll_Services


-- Uc2 create employee_Payroll table

create table Payroll_Employee(
	id int identity primary key,
	name varchar(30) not null,
	salary int not null,
	startdate date not null

);

select * from Payroll_Employee

-- How to delete a table if not required 
--We can use the following syntax to remove a table in SQL Server:

--DROP TABLE [IF EXISTS] [database_name.][schema_name.]table_name;  

-- if exists is optional but if sql server do not find that specified table name than it will through an error.
-- not neccessary to proivde database name it will delete the table in which we are currently working 
-- to delete multiple table define them comma seprated.

/*
When we remove a table in SQL Server
, it also erases all of the table's data, triggers, constraints, and permissions.
 This query does not allow deletion of the views, user-defined functions, and stored procedures
  explicitly referencing the dropped table.
   Hence, we should use the DROP VIEW and DROP PROCEDURE statements if we want to remove these objects explicitly.

We must remember the following points before deleting a table:

The DROP TABLE query will delete the table, including its physical disc files. 
Therefore, we must keep a backup if we need to recover it in the future.

If a foreign key constraint references the table, this query does not drop a table.
 If we want to do this, we will first remove the referencing foreign key constraint or the table.
  Also, we first list the referencing table in an event when the reference table and the primary key 
  table are both being deleted in the same DROP TABLE statement.

This statement does not remove the data stored in the file system when the table has a varbinary (max) column with the FILESTREAM
*/






-- Uc3 Insert data into Payroll_Employee table 


-- add single data into table 
insert into Payroll_Employee
(name,salary,startdate)
values
('Mohit',1254,'2022-01-26')

-- add multiple data into table 
insert into Payroll_Employee
(name,salary,startdate)
values
('Kudven',1638,'2012-05-29'),
('chinnu',2573,'2019-09-30'),
('chintu',8392,'2010-12-12');


-- Uc4 ability to retrive data from the table 

-- * will included all columns
select * from Payroll_Employee;

-- we can also Provide Particular records

select name from Payroll_Employee;

-- Uc5 Ability to retrive data based on conditions 


-- retrive data based on name 
select salary,startdate from Payroll_Employee
where name = 'Mohit';

-- retrive data between a range of date.

select name,salary from Payroll_Employee
where startdate between CAST('2012-05-29' as date) and GETDATE();

--cast is a function which will do conversion for us
--Example
--Convert a value to an int datatype:
--SELECT CAST(25.65 AS int);
--The CAST() function converts a value (of any type) into a specified datatype.

--The CONVERT() function converts a value (of any type) into a specified datatype.
--syntax
--CONVERT(data_type(length), expression, style)

--Example
--Convert an expression to int:
--SELECT CONVERT(int, 25.65);

-- difference between cast and convert is that 
--The CAST function is used to convert a data type without a specific format.
--The CONVERT function does converting and formatting data types at the same time.

--The GETDATE() function returns the current database system date and time, in a 'YYYY-MM-DD hh:mm:ss.mmm' format.

-- Uc6 Add Gender to all employees 

-- to add new column in a existing table we use Alter table statement

--ALTER command in SQL Server is used to make modifications in an existing table.
-- These alterations can be adding a column, deleting a column, changing the size, modifying the data type,
-- adding or removing indexes, and adding or deleting constraints in a table definition.
-- It also allows us to rename and rebuild partitions and disable and enable constraints and triggers.

--syntax
--ALTER TABLE table_name     
 --   ADD column_name1 column_definition,  
 --   ADD column_name2 column_definition;  

 alter table Payroll_Employee
 add gender varchar(6) ;

 select * from Payroll_Employee;

 -- to do update in an existing table we have update command .
 --UPDATE statement in SQL Server is a DML statement used to update or modify the already existing records into a table or view. 
 --The UPDATE query is always recommended to use with the SET and WHERE clause.

 --Syntax
--The following syntax illustrates the UPDATE statement in SQL Server:

--UPDATE [database_name].[ schema_name].table_name       
--SET column1 = new_value1,     
 --       column2 = new_value2, ...      
--[WHERE Clause]    

update [Employee_Company].[dbo].[Payroll_Employee]
set gender ='male'
where name='Mohit' or name='Kudven' or name='chinnu';

select * from [Payroll_Employee];

update [Employee_Company].[dbo].[Payroll_Employee]
set gender='Female'
where name ='chintu';

--Uc7 ability to find sum,average,min,max, number of male and female employee 

-- sum

select sum(salary) 
from Payroll_Employee
where gender='male';

select sum(salary)
from Payroll_Employee
where gender='Female';

--average

select AVG(salary)
from Payroll_Employee
where gender='male';

select avg(salary)
from Payroll_Employee
where gender='Female';

--min

select min(salary)
from Payroll_Employee
where gender='male';

-- max

select MAX(salary)
from Payroll_Employee
where gender='male';

--count

select COUNT(gender)
from Payroll_Employee
where gender='male';

select COUNT(gender)
from Payroll_Employee
where gender='Female';

-- Uc8 add employee_Phone,address,Department

alter table [Payroll_Employee]
add Employee_Phonenumber bigint not null default 91;

alter table [Payroll_Employee]
add Employee_Address varchar(1000) not null default 'office';

alter table [Payroll_Employee]
add Employee_Department varchar(100) not null default 'staff';

select * from Payroll_Employee;

-- Uc9 extend Payroll_Employee Basic pay,tax pay,deducation,Income tax,net pay

alter table [Payroll_Employee]
add Basic_Pay int ,  tax_Pay int,  Deducations int,  Income_Tax int , Net_Pay int;

-- Insert data into updated columns

insert into [Payroll_Employee]
(name,salary,startdate,gender,Employee_Phonenumber,Employee_Address,Employee_Department,Basic_Pay,tax_Pay,Deducations,Income_Tax,Net_Pay)
values
('Terisa',189902,'2018-02-27','Female',353673522,'Mumbai juhu','Sales',12822,200,573,190,120983),
('Terisa',189902,'2018-02-27','Female',353673522,'Mumbai juhu','Marketing',12822,200,573,190,120983);


