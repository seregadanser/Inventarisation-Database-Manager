create database warehouse
go


--create schema warehouse2
--go


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
inventory_number int primary key, 
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
InventoryId int REFERENCES  warehouse2.InventoryProduct (inventory_number)
)
go

create table dbo.Persons
(
[Login] varchar(50) primary key,
[Name] varchar(50), 
SecondName varchar(50),
Position varchar(50),
DateOfBirthday date,
[password] varchar(50) unique,
number_of_come int
)

create table warehouse2.Useful
(
InventoryId int REFERENCES  warehouse2.InventoryProduct (inventory_number) primary key,
PersonId varchar(50) REFERENCES  dbo.Persons ([Login]),
DateOfStart date
)
go
--drop table warehouse2.InventoryProduct
--drop table warehouse2.Products
--drop table warehouse2.Place
--drop table warehouse2.PlaceofObject
--drop table warehouse2.Useful
--drop table dbo.Persons

delete warehouse2.Products
delete warehouse2.InventoryProduct
delete warehouse2.PlaceofObject
delete warehouse2.Place

insert into warehouse2.Products values
(1, 'microscop', 2, null, null),
(2, 'LUPA', 1, null, null)


insert into warehouse2.InventoryProduct values
( 1, 1),
( 3, 1),
( 23, 2)

insert into warehouse2.Place values
(1, 1, 1, 50),
(2, 2, 3, 50),
(3, 2, 4, 50),
(4, 2, 5, 50),
(5, 2, 6, 50)

insert into warehouse2.PlaceofObject values
(1,2,2),
(2,2,1),  
(3,3,1),
(4,4,3),
(5,5,3)



insert into dbo.Persons values
( 'admin', 'vova', 'markus','admin', '1912-10-25' ,'password',0),
( 'hradmin', 'valera', 'borisov','hradmin', '1962-10-25' ,'123456',0)

insert into warehouse2.Useful values
( 1, 'f', null)
go

create role worker
create role HRAdmin
create role Warehouseman
create role WerehouseAdmin
create role NotLogin

grant select on dbo.Persons to NotLogin, Warehouseman, HRAdmin
grant select, insert, update, delete on dbo.Persons to HRAdmin

grant select, delete on  warehouse2.Useful to Warehouseman
grant select, delete, insert on  warehouse2.Useful to worker
grant select on warehouse2.InventoryProduct to worker, Warehouseman
grant select on warehouse2.Products to worker
grant select on warehouse2.PlaceofObject to Warehouseman
grant select on warehouse2.Place to Warehouseman


select * from warehouse2.Products
select * from warehouse2.InventoryProduct
select * from warehouse2.Place
select * from warehouse2.PlaceofObject
select * from dbo.Persons
select * from warehouse2.Useful

update warehouse2.Products
set warehouse2.Products.value = 1


--���������
select warehouse2.InventoryProduct.inventory_number, [name], dateCome, dateProduction
from warehouse2.InventoryProduct join warehouse2.Products on warehouse2.Products.Id = warehouse2.InventoryProduct.product_Id 
where warehouse2.InventoryProduct.inventory_number not in (select warehouse2.Useful.InventoryId from warehouse2.Useful)

--������� �������� Inventory �� Id ���������, ��� ���� ��������� ����� ������ ��������� � ������� Useful �� Id ������������ 
--Id ���������� ����� ��������������� ��� �����. ������������� �� ��������� ������� �� Inventory, Product

select * from (select warehouse2.InventoryProduct.inventory_number as IvN, [name], dateCome, dateProduction
from warehouse2.InventoryProduct join warehouse2.Products on
warehouse2.Products.Id = warehouse2.InventoryProduct.product_Id ) as K join warehouse2.Useful on
warehouse2.Useful.InventoryId = K.IvN where PersonId like 'f'


--���������
select  PE.[Name], PE.SecondName, PE.[Login], I.inventory_number, K.number_stay, K.number_layer, U.DateOfStart
from warehouse2.Useful as U 
join dbo.Persons as PE on PE.[Login] like U.PersonId 
join 
	(select PO.InventoryId, P.number_stay, P.number_layer from warehouse2.PlaceofObject as PO 
	 join warehouse2.Place as P on PO.PlaceId = P.Id) 
as K on K.InventoryId = U.InventoryId 
join warehouse2.InventoryProduct as I on I.inventory_number = U.InventoryId


--Useful ������� ������� �� Id ���������. ��������� ����� ������ ������� �� Useful �� Id ��� ���� ������������� �� 
--��������� �������� �� Useful, Person, Inventory, Place

--����� ������

