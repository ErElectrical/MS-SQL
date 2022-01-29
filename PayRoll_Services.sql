create database Payroll_Services;

use Payroll_Services;
go;

create table Employee_Pay(
	Emp_Id int not null identity primary Key,
	Startdate date not null,
	Emp_PhoneNumber varchar(15) not null unique,
	Emp_Address varchar(300) not null default 'Office',
	Dept_Name varchar(20) not null,
	state_belong varchar(20) not null,
	Country varchar(20) not null,
	BasicPay int not null,
	Deducations int not null,
	TaxPay int not null,
	IncomeTax int not null,
	NetPay int not null,
	gender varchar(10) not null,
	Emp_Name varchar(30) not null default 'Anonymos'
);

select * from Employee_Pay;


insert into Employee_Pay
(Startdate,Emp_PhoneNumber,Emp_Address,Dept_Name,state_belong,Country,BasicPay,Deducations,TaxPay,IncomeTax,NetPay,gender,Emp_Name)
values
('2021-08-29','245262425','Mumbai juhu','Hr','Maharstra','India',18900,120,110,1000,18000,'male','Mphan'),
('2019-11-30','467532','jhajjar','sale','tamilnadu','India',20000,1200,110,1000,19000,'Female','somiya'),
('2017-09-23','4676322',' juhu','Engg','Maharstra','India',25890,180,190,1200,24000,'male','john'),
('2021-11-20','3567753','canught Palce','Engg','Delhi','India',16200,120,110,800,16000,'Female','chinki');

select Startdate,Emp_PhoneNumber,Emp_Address,Dept_Name,state_belong,Country,BasicPay,Deducations,TaxPay,IncomeTax,NetPay,gender,Emp_Name
from Employee_Pay;

create proc SPhelpInserting
(

	@EmployeeName varchar(30),
	@Phonenumber varchar(15),
	@Startdate date,
	@Emp_Address varchar(15),
	@Dept_Name varchar(15),
	@state_belong varchar(20),
	@Country varchar(20),
	@BasicPay int,
	@Deducations int,
	@TaxPay int,
	@IncomeTax int,
	@NetPay int,
	@gender varchar(10)
	
)
as 
begin 
insert into Employee_Pay values(@Startdate,@PhoneNumber,@Emp_Address,@Dept_Name,@state_belong,@Country,@BasicPay,@Deducations,@TaxPay,@IncomeTax,@NetPay,@gender,@EmployeeName)
end
go

select * from Employee_Pay;











