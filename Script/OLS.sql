--- connect as sysdba 
conn as sysdba;
---unlock lbacsys
ALTER USER LBACSYS IDENTIFIED BY oracle123 ACCOUNT UNLOCK;
--- log vao dtb hosspital
conn sys/Oracle123@//192.168.1.8:1521/hospital as sysdba;

SELECT VALUE FROM V$OPTION WHERE PARAMETER = 'Oracle Label Security';
--- enable
EXEC LBACSYS.CONFIGURE_OLS;
EXEC LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS;
-- resstart (optional)
shutdown IMMEDIATE;
startup;
---check (1 trong 2)
SELECT status FROM dba_ols_status WHERE name = 'OLS_CONFIGURE_STATUS';
SELECT VALUE FROM v$option WHERE parameter = 'Oracle Label Security';

-- LOGIN VAO LBACSYS
conn lbacsys/oracle123@//192.168.1.8:1521/hospital;
------- TAO POLICY
EXEC SA_SYSDBA.DROP_POLICY('OLS_INFO_POLICY',TRUE);
BEGIN
sa_sysdba.create_policy
(policy_name => 'OLS_INFO_POLICY', 
column_name => 'INFO_LABELS',
default_options => 'NO_CONTROL' );
END;
/
------- TAO LEVEL
BEGIN
   SA_COMPONENTS.CREATE_LEVEL (
      policy_name => 'OLS_INFO_POLICY',
      level_num   => 50,
      short_name  => 'D',
      long_name   => 'DEFAULT');
END;
/
------- TAO CONPARTMENT
BEGIN
  SA_COMPONENTS.CREATE_COMPARTMENT (
   policy_name     => 'OLS_INFO_POLICY',
   comp_num       => 100,
   short_name      => 'N',
   long_name       => 'INACTIVE');
END;
/
------- TAO GROUP
BEGIN
  SA_COMPONENTS.CREATE_GROUP (
   policy_name     => 'OLS_INFO_POLICY',
   group_num       => 1000,
   short_name      => 'HR',
   long_name       => 'ALL_HUMAN_RESOURCE',
   parent_name     => NULL);

  SA_COMPONENTS.CREATE_GROUP (
   policy_name     => 'OLS_INFO_POLICY',
   group_num       => 1100,
   short_name      => 'FIN',
   long_name       => 'FINANCE_MANAGER',
   parent_name     => 'HR');

  SA_COMPONENTS.CREATE_GROUP (
   policy_name     => 'OLS_INFO_POLICY',
   group_num       => 1110,
   short_name      => 'EMP',
   long_name       => 'FINANCE_EMPLOYEE',
   parent_name     => 'FIN');

  SA_COMPONENTS.CREATE_GROUP (
   policy_name     => 'OLS_INFO_POLICY',
   group_num       => 1200,
   short_name      => 'SPEC',
   long_name       => 'SPECIALITY_MANAGER',
   parent_name     => 'HR');
   SA_COMPONENTS.CREATE_GROUP (
   policy_name     => 'OLS_INFO_POLICY',
   group_num       => 1210,
   short_name      => 'DOC',
   long_name       => 'DOCTOR',
   parent_name     => 'SPEC');

  SA_COMPONENTS.CREATE_GROUP (
   policy_name     => 'OLS_INFO_POLICY',
   group_num       => 1300,
   short_name      => 'REC',
   long_name       => 'RECEPTION',
   parent_name     => 'HR');
END;
/
------- TAO LABEL THU CONG
BEGIN
sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 1,
label_value => 'D',
data_label => true);

sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 1000,
label_value => 'D::HR',
data_label => true);

sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 1100,
label_value => 'D::FIN',
data_label => true);

sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 1200,
label_value => 'D::SPEC',
data_label => true);

sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 1110,
label_value => 'D::EMP',
data_label => true);

sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 1210,
label_value => 'D::DOC',
data_label => true);

sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 1300,
label_value => 'D::REC',
data_label => true);

sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 5000,
label_value => 'D:N',
data_label => true);
--begin
sa_label_admin.create_label
(policy_name => 'OLS_INFO_POLICY',
label_tag => 7000,
label_value => 'D:N:HR',
data_label => true);A
END;
/

-- disable policy
EXEC sa_sysdba.disable_policy(policy_name=>'OLS_INFO_POLICY');

------- APPLY POLICY NO_CONTROL
BEGIN
  SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
    policy_name    => 'OLS_INFO_POLICY',
    schema_name    => 'HOSPITAL_ADMIN', 
    table_name     => 'NHANVIEN');
END;
/


------- UPDATE LABEL TREN BANG DU LIEU
UPDATE NHANVIEN
SET INFO_LABELS = TO_DATA_LABEL('OLS_INFO_POLICY','D:N') WHERE NV_ACTIVE='N';

UPDATE NHANVIEN
SET INFO_LABELS = TO_DATA_LABEL('OLS_INFO_POLICY','D::HR') 
WHERE NV_ACTIVE!='N' AND (NV_CHUCVU='QL NHAN SU' OR NV_CHUCVU='KE TOAN') ;

UPDATE NHANVIEN
SET INFO_LABELS = TO_DATA_LABEL('OLS_INFO_POLICY','D::FIN') 
WHERE NV_ACTIVE!='N' AND NV_CHUCVU='QL TAI VU' ;

UPDATE NHANVIEN
SET INFO_LABELS = TO_DATA_LABEL('OLS_INFO_POLICY','D::SPEC') 
WHERE NV_ACTIVE!='N' AND NV_CHUCVU='QL CHUYEN MON' ;

UPDATE NHANVIEN
SET INFO_LABELS = TO_DATA_LABEL('OLS_INFO_POLICY','D::EMP') 
WHERE NV_ACTIVE!='N' AND (NV_CHUCVU='NV TAI VU' OR NV_CHUCVU= 'NV BAN THUOC');

UPDATE NHANVIEN
SET INFO_LABELS = TO_DATA_LABEL('OLS_INFO_POLICY','D::DOC') 
WHERE NV_ACTIVE!='N' AND NV_CHUCVU='BAC SI' ;

UPDATE NHANVIEN
SET INFO_LABELS = TO_DATA_LABEL('OLS_INFO_POLICY','D::REC') 
WHERE NV_ACTIVE!='N' AND NV_CHUCVU='TIEP TAN' ;

-------nhap --> bo
BEGIN
  SA_POLICY_ADMIN.REMOVE_TABLE_POLICY(
    policy_name => 'OLS_INFO_POLICY',
    schema_name => 'HOSPITAL_ADMIN',
    table_name   => 'NHANVIEN',
    drop_column  => TRUE);
END;
/
BEGIN
  SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
    policy_name => 'OLS_INFO_POLICY',
    schema_name => 'HOSPITAL_ADMIN',
    table_name  => 'NHANVIEN',
    table_options => 'READ_CONTROL, WRITE_CONTROL'
    --,label_function => 'admin.get_emp_label(:new.rol,:new.status)',
    );
END;
/ 
-----------------------------------

--- LABEL USER
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'HOSPITAL_ADMIN',
max_read_label => 'D::HR'
);
end;
/
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'NV000001',
max_read_label => 'D::HR'
);
end;
/
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'NV000003',
max_read_label => 'D::FIN'
);
end;
/
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'NV000004',
max_read_label => 'D::SPEC'
);
end;
/
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'NV000005',
max_read_label => 'D::DOC'
);
end;
/
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'NV000009',
max_read_label => 'D::REC'
);
end;
/
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'NV0000011',
max_read_label => 'D::HR'
);
end;
/
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'NV000014',
max_read_label => 'D::EMP'
);
end;
/
begin
SA_USER_ADMIN.SET_USER_LABELS
( policy_name => 'OLS_INFO_POLICY',
user_name => 'NV000017',
max_read_label => 'D::EMP'
);
end;
/
EXEC sa_sysdba.enable_policy(policy_name=>'OLS_INFO_POLICY');



