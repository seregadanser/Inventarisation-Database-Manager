create database warehouse
go


--create schema warehouse2
--go


--create table warehouse2.Products 
--(
--Id int primary key, 
--[Name] varchar(30), 
--[value] int,
-- dateCome date,
-- dateProduction date
--)
--go

--create table warehouse2.InventoryProduct
--(
--Id int primary key, 
--inventory_number int unique,
--product_Id int REFERENCES  warehouse2.Products (Id)
--)
--go

--create table warehouse2.Place
--(
--Id int primary key, 
--number_stay int,
--number_layer int, 
--size int
--)
--go

--create table warehouse2.PlaceofObject
--(
--Id int primary key, 
--PlaceId int REFERENCES  warehouse2.Place (Id),
--InventoryId int REFERENCES  warehouse2.InventoryProduct (Id)
--)
--go

--create table dbo.Persons
--(
--Id int primary key,
--[Name] varchar(50), 
--SecondName varchar(50),
--Position varchar(50),
--DateOfBirthday date,
--[Login] varchar(50) unique
--)

--create table warehouse2.Useful
--(
--Id int primary key,
--InventoryId int REFERENCES  warehouse2.InventoryProduct (Id) unique,
--PersonId int REFERENCES  dbo.Persons (Id),
--DateOfStart date
--)
--go
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

insert into warehouse2.PlaceofObject values
(1,1,3),
(2,2,1),
(3,3,1),
(4,4,2),
(5,5,2)

insert into warehouse2.Useful values
(1, 1, 2, null)

insert into dbo.Persons values
(1, 'a', 'b', 'm', '1912-10-25' ,'va'),
(2, 'f', 'g', 'b', '1962-10-25' ,'jt'),
(3, 'a', 'g', 'b', '1956-10-25' ,'ji')
go

--Сотрудник
select warehouse2.InventoryProduct.Id,
warehouse2.InventoryProduct.inventory_number, [name], dateCome, dateProduction
from warehouse2.InventoryProduct join warehouse2.Products on warehouse2.Products.Id = warehouse2.InventoryProduct.product_Id 
where warehouse2.InventoryProduct.Id not in (select warehouse2.Useful.InventoryId from warehouse2.Useful)

--Главная сущность Inventory ее Id выводится, при этом сотрудник может только добавлять и удалять Useful по Id инвентарному 
--Id сотрудника будет устанавливаться при входе. Просматривает он составную таблицу из Inventory, Product

select * from (select warehouse2.InventoryProduct.Id,
warehouse2.InventoryProduct.inventory_number, [name], dateCome, dateProduction
from warehouse2.InventoryProduct join warehouse2.Products on
warehouse2.Products.Id = warehouse2.InventoryProduct.product_Id ) as K join warehouse2.Useful on
warehouse2.Useful.InventoryId = K.Id where PersonId = 2


--кладовщик
select U.Id, PE.[Name], PE.SecondName, PE.[Login], I.inventory_number, K.number_stay, K.number_layer, U.DateOfStart
from warehouse2.Useful as U 
join dbo.Persons as PE on PE.Id = U.PersonId 
join 
	(select PO.InventoryId, P.number_stay, P.number_layer from warehouse2.PlaceofObject as PO 
	 join warehouse2.Place as P on PO.PlaceId = P.Id) 
as K on K.InventoryId = U.InventoryId 
join warehouse2.InventoryProduct as I on I.Id = U.InventoryId


--Useful главная таблица ее Id выводится. Кладовщик может только удалять из Useful по Id при этом просматривает он 
--Составную сущность из Useful, Person, Inventory, Place

--Админ склада

