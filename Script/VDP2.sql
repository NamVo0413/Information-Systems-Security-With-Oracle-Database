Create or replace function vpd_schedule_function(p_schema varchar2, 
p_obj varchar2)
Return varchar2
As 
cnt NUMBER(3); 
user VARCHAR2(100);
Begin 
select count (*) into cnt FROM SESSION_ROLES where ROLE='DOCTOR';
if ( 1=cnt) then
return '''' || sys_context('userenv','session_user') || ''' = LT_MABS';
else
return '1=1';
end if;
End;

begin
dbms_rls.add_policy (object_schema => 'hr',
object_name => 'NHANVIEN',
policy_name => 'VDP_INFO',
function_schema => 'hr',
policy_function => 'vpd_schedule_function',
statement_types => 'select',
update_check => TRUE );
end;
/
--select * from session_roles;