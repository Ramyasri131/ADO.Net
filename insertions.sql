insert into Employee([Id],[FirstName],[LastName],[Email],[MobileNumber],[DateOfBirth],[DateOfJoin],[Location],[JobTitle],[Department],[Manager],[Project])
values
('TZ0001','Ramya','Sanaboina','ramya@tezo.com',9876543210,'01/12/2002','01/12/2020','Hyderabad','Lead','PE','Sandeep','GeoBlue'),
('TZ0002','Kavya','Gutthula','kavya@tezo.com',9876543210,'02/11/2002','01/12/2020','Banglore','Solution Architect','PE','Sandeep','GeoBlue'),
('TZ0003','Sravya','Saripella','sravya@tezo.com',9876543210,'13/02/2002','01/12/2020','Hyderabad','Lead','Testing','Shashank','GeoBlue');

insert into Roles([Name],[Location],[Department],[Description])
values
('Lead developer','Hyderabad','PE','test'),
('Solution Architect','Hyderabad','PE','test'),
('Lead tester','Hyderabad','QA','test');

select *from Employee;
select *from roles;