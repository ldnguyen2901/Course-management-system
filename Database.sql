use master;
go
if exists(select * from sys.databases where name='CsdlPortal')
drop database CsdlPortal;
go
create database CsdlPortal;
go
use CsdlPortal;
go

--INSERT INTO SINHVIEN VALUES
--(1, N'User1', 1),
--(2, N'User2', 0);

create table BangThamSo(
	Stt		int not null identity (1,1),
	MoTa	nvarchar(50) not null,
	GiaTri	sql_variant not null
);

create table NVPDT(
	MaNV	int NOT NULL IDENTITY(1,1),
	TenNV	nvarchar(30) NOT NULL, 
	GioiTinh nvarchar(3) NOT NULL,
	email	nvarchar(50) NOT NULL,
	Matkhau	nvarchar(50) NOT NULL,
	constraint NVPDT_PK primary key (MaNV),
);

create table CTDAOTAO (
	MaCTDT	int NOT NULL IDENTITY(1,1),
	TenCTDT nvarchar(20) NOT NULL,
	Nganh	nvarchar(30) NOT NULL,
	constraint CTDATAO_PK primary key (MaCTDT),
); 


create table GIANGVIEN (
	MaGV		int NOT NULL IDENTITY(0,1),
	HoTen		nvarchar(50) NOT NULL,
	GioiTinh	nvarchar(4)	 NOT NULL,
	HocVi		nvarchar(20) NOT NULL,
	Email		nvarchar(30) NOT NULL,
	constraint GIANGVIEN_PK primary key (MaGV)
); 

create table KHOA (
	MaSoKhoa	int not null identity(1,1),
	MaKhoa		nvarchar(10) NOT NULL,
	TenKhoa		nvarchar(20) NOT NULL,
	constraint KHOA_PK primary key (MaSoKhoa),
);

create table HOCPHAN (
	MSHP		int not null identity(1,1),
	MaHP		nvarchar(10) NOT NULL,
	TenHP		nvarchar(50) NOT NULL,
	SoTinChi	int			 NOT NULL,
	MaSoKhoa	int			 NOT NULL,
	TuyenQuyet	int,
	constraint HOCPHAN_PK		primary key (MSHP),
	constraint HOCPHAN_KHOA_FK	foreign key (MaSoKhoa) references KHOA (MaSoKhoa),
	constraint HOCPHAN_TUYENQUYET_FK foreign key (TuyenQuyet) references HOCPHAN (MSHP)
);
create table LOPHOCPHAN (
	MaLHP	int NOT NULL IDENTITY(1,1),
	TenLop	nvarchar(10)	NOT NULL,
	SiSo	int				NOT NULL,
	LT_TH	nvarchar(10)	NOT NULL,
	Thu		nvarchar(3)		NOT NULL,
	TietBD	int				NOT NULL,
	TietKT	int				NOT NULL,
	Phong	nvarchar(5)		NOT NULL,
	DiaDiem nvarchar(20)	NOT NULL,
	KhoaHoc int				not null,
	Huy		nvarchar(3),
	constraint MaLHP_PK	primary key (MaLHP),
);
create table LOP (
	MaLop	int NOT NULL IDENTITY(1,1),
	TenLop	nvarchar(20) NOT NULL,
	MaSoKhoa	int NOT NULL,
	SiSo		int	NOT NULL,	
	constraint LOP_PK			primary key (MaLop),
	constraint LOP_KHOA_FK		foreign key (MaSoKhoa)	references KHOA (MaSoKhoa)
);

create table SINHVIEN (
	Id			int not null identity(1,1),
	MSSV		nvarchar(10) NOT NULL,
	HoTen		nvarchar(50) NOT NULL,
	GioiTinh	nvarchar(3)	NOT NULL,
	NgaySinh	date		NOT NULL,
	MatKhau		nvarchar(20) NOT NULL,
	KhoaHoc		int	not null,
	MaCTDT		int NOT NULL,
	MaLop		int NOT NULL,
	constraint SINHVIEN_PK		primary key (Id),
	constraint SINHVIEN_CTDT_FK foreign key (MaCTDT)	references CTDAOTAO (MaCTDT),
	constraint SINHVIEN_LOP_FK	foreign key (MaLop)		references LOP (MaLop)
);

create table DANGKY (
	MaLHP			int NOT NULL,
	Id				int NOT NULL,
	ThoiGianBD		date		NOT NULL,
	constraint DANGKY_PK			primary key (MaLHP, Id),
	constraint DANGKY_SINHVIEN_FK	foreign key (Id)		references SINHVIEN (Id),
	constraint DANGKY_LOPHOCPHAN_FK foreign key (MaLHP)		references LOPHOCPHAN (MaLHP),
);

create table MOLOP (
	MaLHP	int NOT NULL,
	MaGV	int NOT NULL,
	MSHP	int NOT NULL,
	MaNV	int NOT NULL,
	HocKy	int NOT NULL,
	Nam		int NOT NULL,
	constraint MOLOP_PK				primary key (MaLHP, MSHP, HocKy, Nam, MaNV),
	constraint MOLOP_NV_FK			foreign key (MaNV)	references NVPDT (MaNV),
	constraint MOLOP_LOPHOCPHAN_FK	foreign key (MaLHP) references LOPHOCPHAN (MaLHP),
	constraint MOLOP_HOCPHAN_FK		foreign key (MSHP)	references HOCPHAN (MSHP),
	constraint MOLOP_GIANGVIEN_FK	foreign key (MaGV)	references GIANGVIEN (MaGV),
);

--insert into CTDAOTAO values (TenCTDT, Nganh)
insert into CTDAOTAO values (N'Cử Nhân',N'Toán học')

--insert into NVPDT values (TenNV, GioiTinh, email, Matkhau)
insert into NVPDT values (N'Xuân Hoàng', N'Nữ', 'nxkhoang@hcmus.edu.vn', 'nxhoang123')
insert into NVPDT values (N'Nguyen', N'Nam', 'n@gmail.com', '111')

--insert into NVPDT values (MaKhoa, TenKhoa)
insert into KHOA values ('MTH',N'Toán-Tin')

--insert into GIANGVIEN values (HoTen, GioiTinh, HocVi, Email)
insert into GIANGVIEN values ('NoName','Null','Null','Null')
insert into GIANGVIEN values (N'Trần Anh Tuấn A',N'Nam',N'Tiến Sĩ','trananhtuana@gmail.com')
insert into GIANGVIEN values (N'Nguyễn Hiền Lương',N'Nam',N'Tiến Sĩ','nguyenhienluong@gmail.com')
insert into GIANGVIEN values (N'Võ Đức Cẩm Hải',N'Nam',N'Tiến Sĩ','voduccamhai@gmail.com')
insert into GIANGVIEN values (N'Hà Văn Thảo',N'Nam',N'Tiến Sĩ','havanthao@gmail.com')
insert into GIANGVIEN values (N'Phạm Thi Vương',N'Nam',N'Tiến Sĩ','phamthivuong@gmail.com')
insert into GIANGVIEN values (N'Ngô Minh Mẫn ',N'Nam',N'Tiến Sĩ','ngominhman@gmail.com')
insert into GIANGVIEN values (N'Huỳnh Thế Đăng',N'Nam',N'Tiến Sĩ','huynhthedang@gmail.com')
insert into GIANGVIEN values (N'Nguyễn Thanh Bình',N'Nam',N'Tiến Sĩ','nguyenthanhbinh@gmail.com')
insert into GIANGVIEN values (N'Kha Tuấn Minh',N'Nam',N'Tiến Sĩ','khatuanminh@gmail.com')

--insert into LOP values (TenLop, MaSoKhoa, SiSo)
insert into LOP  values ('19TTH1',1,70)
insert into LOP  values ('19TTH2',1,100)
insert into LOP  values ('19TTH3',1,60)
insert into LOP  values ('20TTH1',1,50)
insert into LOP  values ('20TTH2',1,90)

--insert into HOCPHAN values (MaHP, TenHP, SoTinChi, MaSoKhoa, TuyenQuyet)
insert into HOCPHAN values ('MTH10310',N'Lập Trình.Net', 4 ,1, NULL)
insert into HOCPHAN values ('MTH10333',N'Thiết kế Web', 3 ,1, null)
insert into HOCPHAN values ('MTH10315',N'Phân tích và thiết kế hệ thống thông tin', 4 ,1,null)
insert into HOCPHAN values ('MTH10335',N'Thiết kế Mạng', 4 ,1, null)
insert into HOCPHAN values ('MTH10316',N'Lập trình Java', 3 ,1, null)
insert into HOCPHAN values ('MTH10308',N'Phát triển phần mềm hướng đối tượng', 4 ,1, null)
insert into HOCPHAN values ('MTH10341',N'Chuyên đề.NET', 4 ,1, null)
insert into HOCPHAN values ('MTH10317',N'Phân tích & xử lý ảnh', 4 ,1, null)
insert into HOCPHAN values ('MTH10322',N'Nhận dạng mẫu ', 4 ,1, null)
insert into HOCPHAN values ('MTH10354',N'Máy học nâng cao', 4 ,1, null)
insert into HOCPHAN values ('MTH10318',N'Nhập môn trí tuệ nhân tạo', 4 ,1, null)
insert into HOCPHAN values ('MTH10406',N'Toán rời rạc', 4 ,1, null)

--insert into SINHVIEN values (MSSV, HoTen, GioiTinh, NgaySinh, MatKhau, KhoaHoc, MaCTDT, MaLop)
insert into SINHVIEN values ('19110442',N'Nguyễn Bá Thắng',N'Nam','2001-04-20','thang123',2019,1,1)
insert into SINHVIEN values ('19110231',N'Trịnh Thanh Bình',N'Nữ','2001-11-10','binh321',2019,1,1)
insert into SINHVIEN values ('19110023',N'Trần Đức Bo',N'Nữ','2001-03-02','bo445',2019,1,2)
insert into SINHVIEN values ('19110452',N'Trần Thị Thơm',N'Nữ','2001-10-11','thom444',2019,1,2)
insert into SINHVIEN values ('19110111',N'Trần Thới Tuấn',N'Nam','2001-07-24','tuanzz11',2019,1,1)
insert into SINHVIEN values ('19110002',N'Lê Thị Ánh',N'Nữ','2001-4-29','anhrr11',2019,1,3)
insert into SINHVIEN values ('19110420',N'Lê Văn Thanh',N'Nam','2001-05-13','thanhpro123',2019,1,1)
insert into SINHVIEN values ('19110150',N'Trần Thanh Tâm',N'Nam','2001-01-16','tam1123',2019,1,2)
insert into SINHVIEN values ('20110520',N'Trần Anh Dũng',N'Nam','2001-12-14','dungvl11',2020,1,3)
insert into SINHVIEN values ('20110005',N'Lê Thị Kim',N'Nữ','2001-06-22','anh000',2020,1,3)
insert into SINHVIEN values ('20110008',N'Lê Ánh',N'Nữ','2001-06-18','anh589',2020,1,4)
insert into SINHVIEN values ('20110222',N'Lê Thanh Tín',N'Nam','2001-08-26','tin444',2020,1,4)

--insert into LOPHOCPHAN values (TenLop, SiSo, LT_TH, Thu, TietKT, Phong, DiaDiem, Huy)
insert into LOPHOCPHAN values ('20TTH',100,'LT',7,1,3,'E402','NVC',2020,null)
insert into LOPHOCPHAN values ('20TTH',100,'LT',7,4,6,'H2.1','NVC',2020,null)
insert into LOPHOCPHAN values ('20TTH',50,'LT',4,7,9,'F208','LT',2020,null)
insert into LOPHOCPHAN values ('20TTH',50,'LT','CN',6,8,'E405','NVC',2020,null)
insert into LOPHOCPHAN values ('20TTH',50,'TH',2,9,10,'P máy','NVC',2020,null)
insert into LOPHOCPHAN values ('19TTH',50,'LT',3,5,6,'B44','NVC',2019,null)
insert into LOPHOCPHAN values ('20TTH',50,'LT',7,9,11,'F303','NVC',2020,null)
insert into LOPHOCPHAN values ('20TTH',100,'LT',6,7,9,'F301','NVC',2020,null)
insert into LOPHOCPHAN values ('20TTH',100,'LT',6,8,9,'HT B','LT',2020,null)
insert into LOPHOCPHAN values ('19TTH',50,'LT',4,1,4,'E402','NVC',2019,null)
insert into LOPHOCPHAN values ('20THH',50,'LT',5,2,3,'E405','NVC',2020,null)
insert into LOPHOCPHAN values ('20TTH',100,'LT',4,1,3,'E401','NVC',2020,null)

--insert into MOLOP values (MaLHP, MaGV, MSHP, MaNV, HocKy, Nam)
insert into MOLOP values (1,1,1,1,1,2022)
insert into MOLOP values (2,1,2,1,2,2022)
insert into MOLOP values (3,2,3,1,2,2022)
insert into MOLOP values (4,3,4,1,2,2022)
insert into MOLOP values (5,4,5,1,2,2022)
insert into MOLOP values (6,5,6,1,2,2022)
insert into MOLOP values (7,1,7,1,2,2022)
insert into MOLOP values (8,1,8,1,2,2022)
insert into MOLOP values (9,6,9,1,2,2022)
insert into MOLOP values (10,7,10,1,2,2022)
insert into MOLOP values (11,8,11,1,2,2022)
insert into MOLOP values (12,9,12,1,2,2022)

--insert into DANGKY values (MaLHP, Id, ThoiGianBD)
insert into DANGKY values (1,1,'2022-09-06')
insert into DANGKY values (2,2,'2022-09-06')
insert into DANGKY values (3,3,'2022-09-06')
insert into DANGKY values (4,4,'2022-09-06')
insert into DANGKY values (5,5,'2022-09-06')
insert into DANGKY values (6,6,'2022-09-06')
insert into DANGKY values (7,7,'2022-09-06')
insert into DANGKY values (8,8,'2022-09-06')
insert into DANGKY values (9,9,'2022-09-06')
insert into DANGKY values (1,10,'2022-09-06')
insert into DANGKY values (2,11,'2022-09-06')
insert into DANGKY values (4,2,'2022-09-06')
insert into DANGKY values (6,7,'2022-09-06')
insert into DANGKY values (9,5,'2022-09-06')
insert into DANGKY values (2,4,'2022-09-06')
insert into DANGKY values (8,3,'2022-09-06')
insert into DANGKY values (7,4,'2022-09-06')
insert into DANGKY values (5,12,'2022-09-06')
insert into DANGKY values (3,5,'2022-09-06')
insert into DANGKY values (10,12,'2022-09-06')
insert into DANGKY values (4,5,'2022-09-06')
insert into DANGKY values (2,9,'2022-09-06')

insert into HOCPHAN values ('MTH10309',N'Quản trị hệ thống mạng', 4 ,1, null)
insert into LOPHOCPHAN values ('19TTH',50,'LT',3,7,9,'F303','NVC',2019,null)
insert into MOLOP values (13,0,13,1,1,2022)

CREATE PROCEDURE [dbo].[sp.NVPDT_Login_Check]
	@UserName NVARCHAR (20),
	@Password NVARCHAR (30),
	@res BIT OUTPUT 
AS
BEGIN
	DECLARE @count INT

	SELECT @count = count(*) FROM NVPDT WHERE @UserName = email AND @Password = Matkhau

	IF @count > 0 
		SET @res = 1
	ELSE 
		SET @res = 0
END

CREATE PROCEDURE [dbo].[sp.SV_Login_Check]
	@UserName NVARCHAR (20),
	@Password NVARCHAR (30),
	@res BIT OUTPUT 
AS
BEGIN
	DECLARE @count INT

	SELECT @count = count(*) FROM SINHVIEN WHERE @UserName = MSSV AND @Password = MatKhau

	IF @count > 0 
		SET @res = 1
	ELSE 
		SET @res = 0
END

select * from CTDAOTAO;
select * from NVPDT;
select * from GIANGVIEN;
select * from LOP;

select * from KHOA;
select * from HOCPHAN;
SELECT * FROM SINHVIEN;
select * from MOLOP;
select * from LOPHOCPHAN;
select * from DANGKY;


SELECT  HP.MSHP,HP.TenHP,HP.SoTinChi,
		LHP.TenLop,LHP.SiSo,LHP.LT_TH,LHP.TietBD,LHP.TietKT,LHP.Phong,LHP.DiaDiem
FROM MOLOP AS M
INNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP 
INNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP
GROUP BY HP.MSHP,HP.TenHP,HP.SoTinChi,
		LHP.TenLop,LHP.SiSo,LHP.LT_TH,LHP.TietBD,LHP.TietKT,LHP.Phong,LHP.DiaDiem


SELECT  HP.MSHP,HP.TenHP,
		LHP.TenLop, LHP.LT_TH, LHP.SiSo, COUNT(M.MaLHP) AS N'Đã đăng ký' 
FROM MOLOP AS M
INNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP 
INNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP
WHERE M.MaLHP IN (SELECT MaLHP
					FROM DANGKY
					GROUP BY MaLHP)
GROUP BY HP.MSHP,HP.TenHP,HP.SoTinChi,
		LHP.TenLop,LHP.SiSo,LHP.LT_TH


SELECT HP.MSHP, HP.TenHP, COUNT(M.MaLHP) AS N'Đã đăng ký' 
FROM MOLOP AS M
INNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP
WHERE M.MaLHP IN (SELECT MaLHP
					FROM DANGKY
					GROUP BY MaLHP)
GROUP BY HP.MSHP,HP.TenHP

SELECT  M.MaNV, NV.TenNV, 
		LHP.TenLop, HP.MSHP,HP.TenHP
FROM MOLOP AS M
INNER JOIN NVPDT AS NV ON M.MaNV = NV.MaNV
INNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP 
INNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP
GROUP BY M.MaNV, NV.TenNV, 
		HP.MSHP,HP.TenHP, LHP.TenLop

--danh sách thống kê số lượng SV đăng ký HP
SELECT HP.MaHP as N'Mã học phần', HP.TenHP as N'Tên học phần', HP.SoTinChi as N'Số tín chỉ',
LHP.TenLop as N'Lớp' ,LHP.LT_TH as N'Loại', LHP.SiSo as N'Sỉ số', COUNT(DK.MaLHP) AS N'Đã đăng ký',
'T'+cast(LHP.Thu as nvarchar(2))+' ('+cast(LHP.TietBD as nvarchar(2))+' - '+cast(LHP.TietKT as nvarchar(2))+')' AS N'Lịch học',
LHP.DiaDiem as N'Địa điểm'
FROM MOLOP AS M
INNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP 
INNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP
LEFT JOIN DANGKY AS DK ON M.MaLHP = DK.MaLHP
GROUP BY HP.MSHP,HP.MaHP,HP.TenHP,HP.SoTinChi,LHP.TenLop,LHP.SiSo,LHP.LT_TH,LHP.Thu,LHP.TietBD,LHP.TietKT,LHP.DiaDiem

--danh sách SV đăng ký các môn học
select SV.MSSV ,HP.MaHP, HP.TenHP, LHP.TenLop, LHP.LT_TH as N'Loại', 
'T'+cast(LHP.Thu as nvarchar(2))+' ('+cast(LHP.TietBD as nvarchar(2))+' - '+cast(LHP.TietKT as nvarchar(2))+')' AS N'Lịch học',
LHP.DiaDiem as N'Địa điểm'
from  HOCPHAN as HP
inner join MOLOP as M on M.MSHP = HP.MSHP 
inner join LOPHOCPHAN as LHP on LHP.MaLHP = M.MaLHP
LEFT JOIN DANGKY AS DK ON M.MaLHP = DK.MaLHP
inner join SINHVIEN as SV on SV.Id = DK.Id
group by HP.MaHP, HP.TenHP, LHP.TenLop,LHP.LT_TH, LHP.Thu, LHP.TietBD, LHP.TietKT, LHP.DiaDiem, SV.MSSV
order by SV.MSSV

select * from LOPHOCPHAN;
select * from HOCPHAN;
select * from DANGKY;


SELECT  HP.MaHP,HP.TenHP,HP.SoTinChi,LHP.MaLHP,LHP.TenLop,
		LHP.SiSo,LHP.LT_TH, LHP.Thu,LHP.TietBD,LHP.TietKT,
		LHP.Phong,LHP.DiaDiem,M.HocKy, LHP.KhoaHoc, 
		M.Nam,GV.HoTen,COUNT(DK.MaLHP) AS N'Đã đăng ký' 
FROM MOLOP AS M
INNER JOIN LOPHOCPHAN AS LHP ON M.MaLHP = LHP.MaLHP 
INNER JOIN HOCPHAN AS HP ON M.MSHP = HP.MSHP
INNER JOIN GIANGVIEN AS GV ON M.MaGV = GV.MaGV
LEFT JOIN DANGKY AS DK ON M.MaLHP = DK.MaLHP
GROUP BY HP.MaHP,HP.TenHP,HP.SoTinChi,LHP.MaLHP,LHP.TenLop,
		LHP.SiSo,LHP.LT_TH, LHP.Thu,LHP.TietBD,LHP.TietKT,
		LHP.Phong,LHP.DiaDiem,M.HocKy, LHP.KhoaHoc, 
		M.Nam,GV.HoTen