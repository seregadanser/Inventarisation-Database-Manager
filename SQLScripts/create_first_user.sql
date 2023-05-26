use warehouse
go 

insert into dbo.Persons values
( 'admin', 'vova', 'markus','admin', '1912-10-25' ,'password',0),
( 'hradminn', 'valera', 'borisov','hradmin', '1962-10-25' ,'123456',0)
go

use master
go

alter server role securityadmin add member hradminn
alter server role sysadmin add member hradminn


select * from dbo.Persons
delete dbo.Persons where dbo.Persons.[Login] = 'admin'

drop trigger  add_login_and_role
drop trigger delete_login_and_role