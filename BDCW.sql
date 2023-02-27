create database warehouse
go

--use warehouse
--go

--create schema warehouse1
--go

--create table warehouse1.Products 
--(
--Id int primary key, 
--[Name] varchar(30), 
--[value] int
--)
--go

--create table warehouse1.InventoryProduct
--(
--Id int primary key, 
--inventory_number int unique,
--product_Id int REFERENCES  warehouse1.Products (Id)
--)
--go

create schema warehouse2
go


create table warehouse2.Products 
(
Id int primary key, 
[Name] varchar(30), 
[value] int,
 dateCome date,
 dateProduction date
)
go

create table warehouse2.InventoryProduct
(
Id int primary key, 
inventory_number int unique,
product_Id int REFERENCES  warehouse2.Products (Id)
)
go

create table warehouse2.Place
(
Id int primary key, 
number_stay int,
number_layer int, 
size int
)
go

create table warehouse2.PlaceofObject
(
Id int primary key, 
PlaceId int REFERENCES  warehouse2.Place (Id),
InventoryId int REFERENCES  warehouse2.InventoryProduct (Id)
)
go

create table dbo.Persons
(
Id int primary key,
[Name] varchar(50), 
SecondName varchar(50),
Position varchar(50),
DateOfBirthday date,
[Login] varchar(50)
)

create table warehouse2.Useful
(
Id int primary key,
InventoryId int REFERENCES  warehouse2.InventoryProduct (Id) unique,
PersonId int REFERENCES  dbo.Persons (Id),
DateOfStart date
)

--drop table warehouse2.InventoryProduct
--drop table warehouse2.Products
--drop table warehouse2.Place
--drop table warehouse2.PlaceofObject
--drop table warehouse2.Useful
--drop table dbo.Persons


insert into warehouse2.Products values
(1, 'microscop', 2),
(2, 'LUPA', 1)

insert into warehouse2.InventoryProduct values
(1, 1, 1),
(2, 3, 1),
(3, 23, 2)

insert into dbo.Persons values
(1, 'a', 'b', 'm', '1912-10-25' ,'va'),
(2, 'f', 'g', 'b', '1962-10-25' ,'jt'),
(3, 'a', 'g', 'b', '1956-10-25' ,'jt')


--drop table warehouse2.InventoryProduct
--drop table warehouse1.InventoryProduct
--drop table warehouse1.Products 
--drop table warehouse2.Products 
--drop schema warehouse1
--drop schema warehouse2

select * from warehouse1.Products