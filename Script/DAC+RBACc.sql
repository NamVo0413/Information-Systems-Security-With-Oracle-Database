---DAC + RBAC POLICY
DROP ROLE HR_MNG;
DROP ROLE FIN_MNG;
DROP ROLE SPEC_MNG;
DROP ROLE RECEPTION;
DROP ROLE FINANCE;
DROP ROLE DOCTOR;
DROP ROLE SELLER;
DROP ROLE ACCOUNTANT;
---------------tao role
CREATE ROLE HR_MNG;
CREATE ROLE FIN_MNG;
CREATE ROLE SPEC_MNG;
CREATE ROLE RECEPTION;
CREATE ROLE FINANCE;
CREATE ROLE DOCTOR;
CREATE ROLE SELLER;
CREATE ROLE ACCOUNTANT;
--------------------------Gan quyen theo table
ALTER SESSION SET "_ORACLE_SCRIPT"=true;
GRANT CONNECT,RESOURCE TO HR_MNG,FIN_MNG, SPEC_MNG, RECEPTION,FINANCE,DOCTOR,SELLER,ACCOUNTANT;
GRANT Create session TO HR_MNG,FIN_MNG, SPEC_MNG, RECEPTION,FINANCE,DOCTOR,SELLER,ACCOUNTANT;
Grant select any table to HR_MNG
---BENH NHAN
GRANT SELECT ON BENHNHAN TO DOCTOR;
GRANT ALL ON BENHNHAN TO RECEPTION;
---CHAM CONG
GRANT SELECT ON CHAMCONG TO HR_MNG, FIN_MNG, SPEC_MNG, 
RECEPTION, FINANCE,DOCTOR, SELLER;
GRANT ALL ON CHAMCONG TO ACCOUNTANT;
---CHI TIET DON THUOC
GRANT SELECT ON CHITIETDONTHUOC TO SPEC_MNG,SELLER;
GRANT ALL ON CHITIETDONTHUOC TO DOCTOR;
---DICH VU
GRANT SELECT ON DICHVU TO RECEPTION, FINANCE, DOCTOR;
GRANT ALL ON DICHVU TO FIN_MNG;
---HOA DON DICH VU
GRANT SELECT ON HOADON_DICHVU TO FIN_MNG;
GRANT ALL ON HOADON_DICHVU TO FINANCE;
---HOA DON THUOC
GRANT SELECT ON HOADON_THUOC TO FIN_MNG;
GRANT ALL ON HOADON_THUOC TO SELLER;
---LICH TRUC
GRANT SELECT ON LICHTRUC TO DOCTOR;
GRANT ALL ON LICHTRUC TO HR_MNG;
---NHAN VIEN
GRANT SELECT ON HOSPITAL_ADMIN.NHANVIEN TO PUBLIC;
GRANT SELECT ON NHANVIEN TO FIN_MNG, SPEC_MNG, 
RECEPTION, FINANCE, DOCTOR, SELLER;
GRANT SELECT ON NHANVIEN TO ACCOUNTANT;
GRANT ALL ON hr.NHANVIEN TO HR_MNG;
---PHIEU KHAM BENH
GRANT SELECT ON PHIEUKHAMBENH TO SPEC_MNG, DOCTOR;
GRANT ALL ON PHIEUKHAMBENH TO RECEPTION;
---PHIEU XET NGHIEM
GRANT SELECT ON PHIEUXETNGHIEM TO SPEC_MNG, RECEPTION;
GRANT ALL ON PHIEUXETNGHIEM TO DOCTOR;
---PHONG
GRANT SELECT ON PHONG TO RECEPTION, HR_MNG;
---THUOC
GRANT SELECT ON THUOC TO DOCTOR, SELLER;
GRANT ALL ON THUOC TO FIN_MNG;

------------------------------------- User

DROP USER NV000001;
DROP USER NV000003;
DROP USER NV000004;
DROP USER NV000005;
DROP USER NV000009;
DROP USER NV000011;
DROP USER NV000014;
DROP USER NV000017;

create user NV000001 identified by trang98;
GRANT HR_MNG TO NV000001;
create user NV000003 identified by abc123456789;
GRANT FIN_MNG TO NV000003;
create user NV000004 identified by nhiyenvu1991;
GRANT SPEC_MNG TO NV000004;
create user NV000005 identified by minhpham254;
GRANT DOCTOR TO NV000005;
create user NV000009 identified by krystal119;
GRANT RECEPTION TO NV000009;
create user NV000011 identified by baoduy_00;
GRANT ACCOUNTANT TO NV000011;
create user NV000014 identified by hlongktruc;
GRANT FINANCE TO NV000014;
create user NV000017 identified by vankhanh_445;
GRANT SELLER TO NV000017;
GRANT ALL ON hr.NHANVIEN to NV000001




