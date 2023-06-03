
use warehouse
go


CREATE TRIGGER add_login_and_role
ON dbo.Persons
AFTER INSERT
AS
BEGIN
  DECLARE @login_name NVARCHAR(100);
  DECLARE @password NVARCHAR(100);
  DECLARE @role_name NVARCHAR(100);
  
  
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