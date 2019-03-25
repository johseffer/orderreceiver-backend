--1 Darth Vader
--2 Obi-Wan Kenobi
--3 Luke Skywalker
--4 Imperador Palpatine
--5 Han Solo
insert into Customers values (NEWID(), 'Darth Vader');
insert into Customers values (NEWID(), 'Obi-Wan Kenobi');
insert into Customers values (NEWID(), 'Luke Skywalker');
insert into Customers values (NEWID(), 'Imperador Palpatine');
insert into Customers values (NEWID(), 'Han Solo');

--1 Millenium Falcon 550.000,00
--2 X-Wing 60.000,00 2
--3 Super Star Destroyer 4.570.000,00
--4 TIE Fighter 75.000,00 2
--5 Lightsaber 6.000,00 5
--6 DLT-19 Heavy Blaster Rifle 5.800,00
--7 DL-44 Heavy Blaster Pistol 1.500,00 10

insert into Products values (NEWID(), 550000,1,'Millenium Falcon');
insert into Products values (NEWID(), 60000,2,'X-Wing');
insert into Products values (NEWID(), 4570000,1,'Super Star Destroyer');
insert into Products values (NEWID(), 75000,2,'TIE Fighter');
insert into Products values (NEWID(), 6000,5,'Lightsaber');
insert into Products values (NEWID(), 5800,1,'DLT-19 Heavy Blaster Rifle');
insert into Products values (NEWID(), 1.500,10,'DL-44 Heavy Blaster Pistol');

delete from OrderItems;
delete from Products;
delete from Customers;
delete from Orders;