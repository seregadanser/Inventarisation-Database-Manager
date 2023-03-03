create database warehouse
go


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
[Login] varchar(50) unique
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
(1, 'microscop', 2, null, null),
(2, 'LUPA', 1, null, null)


insert into warehouse2.InventoryProduct values
(1, 1, 1),
(2, 3, 1),
(3, 23, 2)

insert into warehouse2.Place values
(1, 1, 1, 50),
(2, 2, 3, 50),
(3, 2, 4, 50),
(4, 2, 5, 50),
(5, 2, 6, 50)



insert into dbo.Persons values
(1, 'a', 'b', 'm', '1912-10-25' ,'va'),
(2, 'f', 'g', 'b', '1962-10-25' ,'jt'),
(3, 'a', 'g', 'b', '1956-10-25' ,'ji')
go


select * from warehouse2.InventoryProduct join warehouse2.Products on warehouse2.Products.Id = warehouse2.InventoryProduct.product_Id