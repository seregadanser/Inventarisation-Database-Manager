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
delete warehouse2.Useful
delete dbo.Persons

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
--( 'admin', 'vova', 'markus','admin', '1912-10-25' ,'password',0),
( 'hradminn', 'valera', 'borisov','hradmin', '1962-10-25' ,'123456',0)

insert into warehouse2.Useful values
( 1, 'f', null)
go

create role Worker
grant select, insert, delete on warehouse2.Useful to Worker
grant select on warehouse2.Products to Worker
grant select on warehouse2.InventoryProduct to Worker
grant update on dbo.Persons to Worker

create role HRAdmin
grant select, insert, update, delete on dbo.Persons to HRAdmin 
grant select on warehouse2.Useful to HRAdmin
GRANT ALTER ANY ROLE TO HRAdmin;



create role Warehouseman
grant select, delete on warehouse2.Useful to Warehouseman
grant select on warehouse2.InventoryProduct to Warehouseman
grant select on warehouse2.Place to Warehouseman
grant select on warehouse2.PlaceofObject to Warehouseman
grant select on dbo.Persons to Warehouseman

create role WarehouseAdmin
grant select, insert, delete on warehouse2.Products to WarehouseAdmin
grant select, insert, delete on warehouse2.InventoryProduct to WarehouseAdmin
grant select, insert, delete on warehouse2.PlaceofObject to WarehouseAdmin
grant select, insert, delete on warehouse2.Place to WarehouseAdmin	
grant select on warehouse2.Useful to WarehouseAdmin
grant update on warehouse2.Place to WarehouseAdmin

create role NotLogin
grant select on  dbo.Persons to  NotLogin

create login notautorise with password = '111111'
create user notautorise for login notautorise
alter role NotLogin add member notautorise

select * from warehouse2.Products
select * from warehouse2.InventoryProduct
select * from warehouse2.Place
select * from warehouse2.PlaceofObject
select * from dbo.Persons
select * from warehouse2.Useful

update warehouse2.Products
set warehouse2.Products.value = 1

go
CREATE TRIGGER add_login_and_role
ON dbo.Persons
AFTER INSERT
AS
BEGIN
  DECLARE @login_name NVARCHAR(100);
  DECLARE @password NVARCHAR(100);
  DECLARE @role_name NVARCHAR(100);
  
  -- Get the login name, password, and role name from the inserted row
  SELECT @login_name = inserted.[Login], @password = inserted.[password], @role_name = inserted.Position
  FROM inserted;
  
DECLARE @sql NVARCHAR(MAX) = N'CREATE LOGIN ' + QUOTENAME(@login_name) + N' WITH PASSWORD = ' + QUOTENAME(@password, '''') + N';';
EXEC sp_executesql @sql;
DECLARE @sql1 NVARCHAR(MAX) = N'create user ' + QUOTENAME(@login_name) + N' for login ' + QUOTENAME(@login_name);
EXEC sp_executesql @sql1;
DECLARE @sql2 NVARCHAR(MAX) = case @role_name
when 'hradmin' then
   N'ALTER ROLE HRAdmin ADD MEMBER ' +  QUOTENAME(@login_name)
when 'admin' then
	N'ALTER ROLE WarehouseAdmin ADD MEMBER ' +  QUOTENAME(@login_name)
when 'worker' then
	N'ALTER ROLE Worker ADD MEMBER ' +  QUOTENAME(@login_name)
when 'warehouseman' then
	N'ALTER ROLE Warehouseman ADD MEMBER ' +  QUOTENAME(@login_name)
end
EXEC sp_executesql @sql2;
END;
go

CREATE TRIGGER delete_login_and_role
ON dbo.Persons
AFTER DELETE
AS
BEGIN
  DECLARE @login_name NVARCHAR(100);
  DECLARE @role_name NVARCHAR(100);
  
  -- Get the login name and role name from the deleted row
  SELECT @login_name = deleted.Login, @role_name = deleted.Position
  FROM deleted;

    
DECLARE @sql2 NVARCHAR(MAX) = case @role_name
when 'hradmin' then
   N'ALTER ROLE HRAdmin drop MEMBER ' +  QUOTENAME(@login_name)
when 'admin' then
	N'ALTER ROLE WarehouseAdmin drop MEMBER ' +  QUOTENAME(@login_name)
when 'worker' then
	N'ALTER ROLE Worker drop MEMBER ' +  QUOTENAME(@login_name)
when 'warehouseman' then
	N'ALTER ROLE Warehouseman drop MEMBER ' +  QUOTENAME(@login_name)
end
 EXEC sp_executesql @sql2;
 DECLARE @sql1 NVARCHAR(MAX) = N'drop user ' + QUOTENAME(@login_name);
EXEC sp_executesql @sql1;
  DECLARE @sql NVARCHAR(MAX) = N'drop LOGIN ' + QUOTENAME(@login_name);
EXEC sp_executesql @sql;

END;
go
drop TRIGGER add_login_and_role
drop TRIGGER delete_login_and_role
--Сотрудник
select warehouse2.InventoryProduct.inventory_number, [name], dateCome, dateProduction
from warehouse2.InventoryProduct join warehouse2.Products on warehouse2.Products.Id = warehouse2.InventoryProduct.product_Id 
where warehouse2.InventoryProduct.inventory_number not in (select warehouse2.Useful.InventoryId from warehouse2.Useful)

--Главная сущность Inventory ее Id выводится, при этом сотрудник может только добавлять и удалять Useful по Id инвентарному 
--Id сотрудника будет устанавливаться при входе. Просматривает он составную таблицу из Inventory, Product

select * from (select warehouse2.InventoryProduct.inventory_number as IvN, [name], dateCome, dateProduction
from warehouse2.InventoryProduct join warehouse2.Products on
warehouse2.Products.Id = warehouse2.InventoryProduct.product_Id ) as K join warehouse2.Useful on
warehouse2.Useful.InventoryId = K.IvN where PersonId like 'f'


--кладовщик
select  PE.[Name], PE.SecondName, PE.[Login], I.inventory_number, K.number_stay, K.number_layer, U.DateOfStart
from warehouse2.Useful as U 
join dbo.Persons as PE on PE.[Login] like U.PersonId 
join 
	(select PO.InventoryId, P.number_stay, P.number_layer from warehouse2.PlaceofObject as PO 
	 join warehouse2.Place as P on PO.PlaceId = P.Id) 
as K on K.InventoryId = U.InventoryId 
join warehouse2.InventoryProduct as I on I.inventory_number = U.InventoryId


--Useful главная таблица ее Id выводится. Кладовщик может только удалять из Useful по Id при этом просматривает он 
--Составную сущность из Useful, Person, Inventory, Place

--Админ склада

