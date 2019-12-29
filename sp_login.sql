CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_Users`(IN firstname longtext, IN lastname longtext, IN rolename longtext, IN departmentname longtext)
BEGIN
select concat(u.firstname=firstname, " " ,u.lastname=lastname) as Name, r.rolename=rolename as Role, d.departmentname=departmentname as Department
from 
users u 
join 
roles r 
on 
u.RoleId = r.Id join 
departments d 
on
u.DepartmentId = d.Id;
END