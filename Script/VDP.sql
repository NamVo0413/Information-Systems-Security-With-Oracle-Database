Create or replace function vpd_info_function(p_schema varchar2, 
p_obj varchar2)
return varchar2
As 
cnt NUMBER(3); 
user VARCHAR2(100);
Begin 
select count (*) into cnt FROM SESSION_ROLES where ROLE='DOCTOR' 
OR ROLE='FINANCE' OR ROLE ='RECEPTION' OR ROLE = 'SELLER';
if (1 = cnt) then

--user := SYS_CONTEXT('userenv','SESSION_USER'); 
--return 'NV_MANV = ' || user;
return '''' || sys_context('userenv','session_user') || ''' = NV_MANV';

else
return '1=1';
end if;
End;
begin
dbms_rls.add_policy (object_schema => 'hr',
object_name => 'NHANVIEN',
policy_name => 'VDP_INFO',
function_schema => 'hr',
policy_function => 'vpd_info_function',
statement_types => 'select',
update_check => TRUE );
end;
/
commit;
BEGIN
DBMS_RLS.DROP_POLICY (
object_schema => 'HR',
object_name => 'NHANVIEN',
policy_name =>'VDP_INFO');
END;
--select * from session_roles;