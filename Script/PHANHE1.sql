-----###########################################################################
--Xem thong tin ve nguoi dung
-----###########################################################################
create or replace PROCEDURE proc_Users(c1 out SYS_REFCURSOR) 
AUTHID CURRENT_USER AS 
BEGIN
    open c1 for
    SELECT * from dba_users;
    --return c1;
    --dbms_sql.return_result(c1);
END;

--EXECUTE proc_Users(c1);
-----###########################################################################
------------------Xem thong tin ve quyen cua nguoi dung
-----###########################################################################
create or replace PROCEDURE proc_Privileges (c2 out sys_refcursor)
AUTHID CURRENT_USER AS 
BEGIN
    open c2 for
    SELECT * from DBA_SYS_PRIVS;
    --dbms_sql.return_result(c2);
END;
--SELECT * from DBA_SYS_PRIVS;
--EXECUTE proc_Privileges;
-----###########################################################################
----- Tao user: da ton tai thi thong bao
-----###########################################################################
create or replace PROCEDURE proc_CreateUser 
(n_username in varchar2,
n_password in varchar2)
AUTHID CURRENT_USER AS   
	user_name NVARCHAR2(20)  	:= n_username;
	pwd NVARCHAR2(20) 		:= n_password;
   	l_count       INTEGER	:= 0;	
    lv_stmt   VARCHAR2 (1000);
BEGIN
   	SELECT COUNT (1)
     	INTO l_count
     	FROM dba_users
   	WHERE username = UPPER ( user_name );

   	IF l_count != 0
   	THEN
    raise_application_error(-20010,'Tai khoan da ton tai!');      	
   	END IF;
        lv_stmt := 'CREATE USER ' || user_name || ' IDENTIFIED BY ' || pwd || ' DEFAULT TABLESPACE SYSTEM';
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt ); 
END;
-----###########################################################################
----- Tao role: da ton tai thi thong bao
-----###########################################################################
create or replace PROCEDURE proc_CreateRole 
(n_role in varchar2)
AUTHID CURRENT_USER AS   
	l_role NVARCHAR2(20)  	:= n_role;
   	l_count       INTEGER	:= 0;	
    lv_stmt   VARCHAR2 (1000);
BEGIN
   	SELECT COUNT (1)
     	INTO l_count
     	FROM dba_roles
   	WHERE dba_roles.ROLE = UPPER (l_role );

   	IF l_count != 0
   	THEN
    raise_application_error(-20010,'Role da ton tai!');      	
   	END IF;
        lv_stmt := 'CREATE ROLE ' || l_role ;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt ); 
END;
--select * from dba_roles;
--create role bear;

--execute proc_CreateRole ('animal');

-----###########################################################################
----- Xoa user: neu k ton tai thi thong bao
-----###########################################################################
create or replace PROCEDURE proc_DropUser 
(n_username in varchar2)
AUTHID CURRENT_USER AS   
	user_name NVARCHAR2(20)  	:= n_username;
   	l_count       INTEGER	:= 0;	
    lv_stmt   VARCHAR2 (1000);
BEGIN
   	SELECT COUNT (1)
     	INTO l_count
     	FROM dba_users
   	WHERE username = UPPER ( user_name );

   	IF l_count != 0
   	THEN
        lv_stmt := 'DROP USER ' || user_name ;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt );

   	ELSE
    raise_application_error(-20010,'Tai khoan khong ton tai!'); 
    END IF;     
END;

-----###########################################################################
----- Xoa role: neu k ton tai thi thong bao
-----###########################################################################
create or replace PROCEDURE proc_DropRole 
(n_role in varchar2)
AUTHID CURRENT_USER AS   
	l_role NVARCHAR2(20)  	:= n_role;
   	l_count       INTEGER	:= 0;	
    lv_stmt   VARCHAR2 (1000);
BEGIN
   	SELECT COUNT (1)
     	INTO l_count
     	FROM dba_roles
   	WHERE dba_roles.ROLE = UPPER (l_role );

   	IF l_count != 0
   	THEN
        lv_stmt := 'DROP ROLE ' || l_role ;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt );
         	
   	ELSE
    raise_application_error(-20010,'Role khong ton tai!'); 
    END IF;     
END;
--EXECUTE proc_DropRole('animal');
-----###########################################################################
------------------Cap quyen cho nguoi dung hoac role
-----###########################################################################
create or replace PROCEDURE proc_GrantRoleForUser 
(n_role in varchar2,
n_user in varchar2)
AUTHID CURRENT_USER AS   
	l_role NVARCHAR2(20)  	:= n_role;
	l_user NVARCHAR2(20) 		:= n_user;
   	l_count       INTEGER	:= 0;	
    lv_stmt   VARCHAR2 (1000);
BEGIN
    lv_stmt := 'GRANT ' || l_role || ' TO ' || l_user;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt ); 
END;
--execute  proc_GrantRoleForUser('bear','icebear');
--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = 'ICEBEAR';
---------------------------------------------------------------
create or replace PROCEDURE proc_GrantForUser 
(n_pri in varchar2,
n_obj in varchar2,
n_user in varchar2,
n_flag in CHAR)
AUTHID CURRENT_USER AS   
	l_pri NVARCHAR2(20)  	:= n_pri;
	l_obj NVARCHAR2(50) 		:= n_obj;
    l_user NVARCHAR2(20) 		:= n_user;
    l_flag CHAR(2)        :=n_flag;
    lv_stmt   VARCHAR2 (1000);
BEGIN
    if l_flag='N' then
    lv_stmt := 'GRANT ' || l_pri || ' ON ' || l_obj || ' TO '||l_user;
    else
    lv_stmt := 'GRANT ' || l_pri || ' ON ' || l_obj || ' TO '||l_user || ' WITH GRANT OPTION';
    end if;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt ); 
END;
--execute  proc_GrantForUser('SELECT','NHANVAT','ICEBEAR','y');
--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = 'ICEBEAR';
---------------------------------------------------------------
create or replace PROCEDURE proc_GrantForRole 
(n_pri in varchar2,
n_obj in varchar2,
n_user in varchar2)
AUTHID CURRENT_USER AS   
	l_pri NVARCHAR2(20)  	:= n_pri;
	l_obj NVARCHAR2(50) 		:= n_obj;
    l_user NVARCHAR2(20) 		:= n_user;
    lv_stmt   VARCHAR2 (1000);
BEGIN
    lv_stmt := 'GRANT ' || l_pri || ' ON ' || l_obj || ' TO '||l_user;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt ); 
END;

-----###########################################################################
------------------Thu hoi quyen nguoi dung hoac role
-----###########################################################################
create or replace PROCEDURE proc_RevokeFromUser 
(n_pri in varchar2,
n_obj in varchar2,
n_user in varchar2,
n_flag in CHAR)
AUTHID CURRENT_USER AS   
	l_pri NVARCHAR2(20)  	:= n_pri;
	l_obj NVARCHAR2(50) 		:= n_obj;
    l_user NVARCHAR2(20) 		:= n_user;
    lv_stmt   VARCHAR2 (1000);
BEGIN
    lv_stmt := 'REVOKE ' || l_pri || ' ON ' || l_obj || ' FROM '||l_user;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt ); 
END;

create or replace PROCEDURE proc_RevokeAll
(n_revoke in varchar2)
AUTHID CURRENT_USER AS   
	l_revoke NVARCHAR2(20)  	:= n_revoke;
   	l_count       INTEGER	:= 0;	
    lv_stmt   VARCHAR2 (1000);
BEGIN
   lv_stmt := 'REVOKE ALL ON NHANVIEN FROM ' || l_revoke;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt );
END;
--------------------------------------------------------------------------------
create or replace PROCEDURE proc_RevokeRoleFromUser
(n_role in varchar2,
n_user in varchar2)
AUTHID CURRENT_USER AS   
	l_role NVARCHAR2(20)  	:= n_role;
	l_user NVARCHAR2(20) 		:= n_user;
   	l_count       INTEGER	:= 0;	
    lv_stmt   VARCHAR2 (1000);
BEGIN
   lv_stmt := 'REVOKE ' || n_role || ' FROM ' || n_user;
	DBMS_OUTPUT.put_line(lv_stmt);
	EXECUTE IMMEDIATE ( lv_stmt );
END;


-----###########################################################################
------------------Xem thong tin ve quyen cua nguoi dung - role
-----###########################################################################
create or replace PROCEDURE proc_CheckPrivileges 
(n_check in varchar2,
c2 out sys_refcursor)
AUTHID CURRENT_USER AS
    l_check NVARCHAR2(20) :=n_check;
BEGIN
    open c2 for
    SELECT * from DBA_TAB_PRIVS  where GRANTEE= l_check;
    --dbms_sql.return_result(c2);
END;
--SELECT * from DBA_TAB_PRIVS where GRANTEE='ADMIN' ;
--EXECUTE proc_Privileges();
--grant bear to panda;
----------------------------------------------------------
create or replace PROCEDURE proc_CheckUserRole 
(n_check in varchar2,
c2 out sys_refcursor)
AUTHID CURRENT_USER AS
    l_check NVARCHAR2(20) :=n_check;
BEGIN
    open c2 for
    SELECT * from DBA_ROLE_PRIVS  where GRANTEE= l_check;
    --dbms_sql.return_result(c2);
END;
--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = 'ICEBEAR';
------------------------------------------------------------
create or replace PROCEDURE proc_CheckRole 
(n_check in varchar2,
c2 out sys_refcursor)
AUTHID CURRENT_USER AS
    l_check NVARCHAR2(20) :=n_check;
BEGIN
    open c2 for
    SELECT * from role_TAB_privs  where role= l_check;
    --dbms_sql.return_result(c2);
END;
--SELECT * FROM DBA_TAB_PRIVS;
