use QLBAN_THUENHA
go

IF OBJECT_ID ('HDB ','TR') IS NOT NULL
   DROP TRIGGER HDB;
GO
--Không cho cập nhập ngày kết thúc của HĐB
create trigger HDB on HOPDONG
after insert, update
as 
begin
	if (select inserted.TRANGTHAI_HD from inserted, HOPDONG where inserted.MA_HD = HOPDONG.MA_HD) = 'HDB'
		begin
			declare @temp CHAR(5)
			set @temp = (select inserted.MA_HD from inserted, HOPDONG where inserted.MA_HD = HOPDONG.MA_HD)
			update HOPDONG set NGAYKT_HD = NULL where HOPDONG.MA_HD = @temp
			print('Khong duoc them ngay ket thuc')
		end
	else
		begin
			declare @value DATE
			SET @value = (select inserted.NGAYKT_HD from inserted, HOPDONG where inserted.MA_HD = HOPDONG.MA_HD)
			declare @ma_hd CHAR(5)
			set @ma_hd = (select inserted.MA_HD from inserted, HOPDONG where inserted.MA_HD = HOPDONG.MA_HD)
			update HOPDONG set NGAYKT_HD = @value where MA_HD = @ma_hd
		end
end
go


--Kiểm tra trạng thái nhà bán, nhà thuê
IF OBJECT_ID ('trang_thai_nha','TR') IS NOT NULL
   DROP TRIGGER trang_thai_nha;
GO

create trigger trang_thai_nha on HOPDONG
after insert, update
as
begin
	declare @ma_nha CHAR(5)
	set @ma_nha = (Select inserted.MA_NHA from inserted, HOPDONG WHERE inserted.MA_NHA = HOPDONG.MA_NHA)
	declare @status CHAR(5)
	set @status = (Select inserted.TRANGTHAI_HD from inserted, HOPDONG WHERE inserted.MA_NHA = HOPDONG.MA_NHA)
	IF EXISTS(select MA_NHA from NHABAN where MA_NHA = @ma_nha and @status = 'HDT')
		begin
			update HOPDONG set TRANGTHAI_HD = 'HDB' where MA_NHA = @ma_nha
			print('Sai trang thai. Trang thai da duoc update = HDB')
		end
	ELSE IF EXISTS(select MA_NHA from NHATHUE where MA_NHA = @ma_nha and @status = 'HDB')
		begin
			update HOPDONG set TRANGTHAI_HD = 'HDT' where MA_NHA = @ma_nha
			print('Sai trang thai. Trang thai da duoc update = HDT')
		end
end
go

-- Kiểm tra view
IF OBJECT_ID ('kt_view','TR') IS NOT NULL
   DROP TRIGGER kt_view;
GO

create trigger kt_view on NHA
after update
as
begin
	declare @check int
	set @check = (select count(inserted.MA_NHA) FROM inserted, XEM where inserted.MA_NHA = XEM.MA_NHA)
	if (select inserted.VIEW_NHA from inserted, NHA where inserted.MA_NHA = NHA.MA_NHA) != @check
	begin
		declare @temp CHAR(5)
		set @temp = (select inserted.MA_NHA from inserted, NHA where inserted.MA_NHA = NHA.MA_NHA)
		update NHA set VIEW_NHA = 0 where NHA.MA_NHA = @temp
		print('So view khong hop le.')
	end
end
go

-- Kiểm tra view ban đầu
IF OBJECT_ID ('kt_view_start','TR') IS NOT NULL
   DROP TRIGGER kt_view;
GO

create trigger kt_view_start on NHA
after insert
as
begin
	if (select inserted.VIEW_NHA from inserted, NHA where inserted.MA_NHA = NHA.MA_NHA) != 0
	begin
		declare @temp CHAR(5)
		set @temp = (select inserted.MA_NHA from inserted, NHA where inserted.MA_NHA = NHA.MA_NHA)
		update NHA set VIEW_NHA = 0 where NHA.MA_NHA = @temp
		print('So view khong hop le.')
	end
end
go





-- Giá bán 1 tháng của nhà không được <0, phải là số chẵn, (tối thiểu 100.000 da check constraint)
IF OBJECT_ID ('gia_ban','TR') IS NOT NULL
   DROP TRIGGER gia_ban;
GO
create trigger gia_ban on NHABAN
after insert, update
as 
begin
	DECLARE @CHECK INT
	SET @CHECK = (SELECT inserted.GIABAN FROM inserted, NHABAN where inserted.MA_NHA = NHABAN.MA_NHA)
	IF (SELECT inserted.GIABAN FROM inserted, NHABAN where inserted.MA_NHA = NHABAN.MA_NHA) < 0 OR @CHECK % 100 != 0
	begin
		declare @temp CHAR(5)
		set @temp = (select MA_NHA FROM inserted)
		update NHABAN set GIABAN = 100000 where NHABAN.MA_NHA = @temp
		print('Gia nha ban khong hop le.')
	end
end
go



-- Giá thuê 1 tháng của nhà không được <0, phải là số chẵn, tối thiểu là 100.000
IF OBJECT_ID ('tien_thue_thang','TR') IS NOT NULL
   DROP TRIGGER tien_thue_thang;
GO
create trigger tien_thue_thang on NHATHUE
after insert, update
as
begin
	declare @check INT
	set @check = (select inserted.TIENTHUETHANG FROM inserted, NHATHUE WHERE inserted.MA_NHA = NHATHUE.MA_NHA)
	IF (SELECT inserted.TIENTHUETHANG FROM inserted, NHATHUE where inserted.MA_NHA = NHATHUE.MA_NHA) < 0 OR @check % 100 != 0
	begin
		declare @temp CHAR(5)
		set @temp = (select MA_NHA FROM inserted)
		update NHATHUE set TIENTHUETHANG = 100 where NHATHUE.MA_NHA = @temp
		print('Tien thue thang khong hop le.')
	end
end
go

IF OBJECT_ID ('RBTV18 ','TR') IS NOT NULL
   DROP TRIGGER RBTV18;
GO

create trigger RBTV18 
ON HOPDONG
AFTER UPDATE, INSERT
AS
BEGIN
	/*Kiem tra nếu các dòng vừa mới update hoặc insert không thỏa thì IN THÔNG BÁO LỖI VÀ sửa lại giá trị đó*/
	IF (EXISTS (SELECT * FROM NHA, inserted as I WHERE I.MA_NHA = NHA.MA_NHA AND I.MA_CNHA <> NHA.MA_CNHA) OR EXISTS (SELECT * FROM NHA, inserted as I WHERE I.MA_NHA <> NHA.MA_NHA AND I.MA_CNHA = NHA.MA_CNHA))
	BEGIN
		RAISERROR ('Tồn tại 1 dòng có MACN đăng kí hợp đồng không trùng khớp với MACN của thực thể Nhà. Đã sửa lại', 16, 1);
		UPDATE HOPDONG
		SET HOPDONG.MA_CNHA = (
		SELECT NHA.MA_CNHA FROM NHA WHERE HOPDONG.MA_NHA = NHA.MA_NHA)
		FROM HOPDONG
		JOIN inserted AS I ON I.MA_NHA = HOPDONG.MA_NHA
		--ROLLBACK TRANSACTION;
		RETURN; 
	END
END
GO
--CÂU 16: Các trường họ tên, SDT, username, password khi tạo TK không được để chuỗi rỗng "" hoặc bằng NULL, hoặc để trống mà k điền vào. Bên cạnh đó, password cũng bắt buộc phải lớn hơn một độ dài MIN ký tự nhất định.
IF OBJECT_ID ('RBTV16_NV ','TR') IS NOT NULL
   DROP TRIGGER RBTV16_NV;
GO
IF OBJECT_ID ('RBTV16_KH ','TR') IS NOT NULL
   DROP TRIGGER RBTV16_KH;
GO
IF OBJECT_ID ('RBTV16_CN ','TR') IS NOT NULL
   DROP TRIGGER RBTV16_CN;
GO
---Tạo trigger cho NHANVIEN khi họ tạo TK
create trigger RBTV16_NV
ON NHANVIEN
AFTER UPDATE, INSERT
AS
BEGIN
	DECLARE @MIN INT = 6;
	IF (EXISTS (SELECT * FROM inserted as I where I.USER_NV IS NULL) OR (EXISTS (SELECT * FROM inserted as I where I.PASS_NV IS NULL) 
	OR (EXISTS (SELECT * FROM inserted as I where I.SDT IS NULL) OR (EXISTS (SELECT * FROM inserted as I where I.TEN_NV IS NULL))
	OR (EXISTS (SELECT * FROM inserted as I where I.USER_NV = '') OR (EXISTS (SELECT * FROM inserted as I where I.PASS_NV = ''))
	OR ((EXISTS (SELECT * FROM inserted as I where I.SDT = '')) OR (EXISTS (SELECT * FROM inserted as I where I.TEN_NV = ''))
	OR ((EXISTS (SELECT * FROM inserted as I where LEN(I.PASS_NV) < @MIN))))))))
	BEGIN
		RAISERROR ('Username/Password/SĐT/Họ tên KHI ĐĂNG KÝ TÀI KHOẢN không được phép rỗng hoặc bằng NULL. Password phải ít nhất 6 ký tự', 16, 1);
		ROLLBACK TRANSACTION;
		RETURN; 
	END
END
GO
---Tạo trigger cho CHUNHA khi họ tạo TK
create trigger RBTV16_CN
ON CHUNHA
AFTER UPDATE, INSERT
AS
BEGIN
	DECLARE @MIN INT = 6;
	IF (EXISTS (SELECT * FROM inserted as I where I.USER_CNHA IS NULL) OR (EXISTS (SELECT * FROM inserted as I where I.PASS_CNHA IS NULL) 
	OR (EXISTS (SELECT * FROM inserted as I where I.SDT IS NULL) OR (EXISTS (SELECT * FROM inserted as I where I.TEN_CNHA IS NULL))
	OR (EXISTS (SELECT * FROM inserted as I where I.USER_CNHA = '') OR (EXISTS (SELECT * FROM inserted as I where I.PASS_CNHA = ''))
	OR ((EXISTS (SELECT * FROM inserted as I where I.SDT = '')) OR (EXISTS (SELECT * FROM inserted as I where I.TEN_CNHA = ''))
	OR ((EXISTS (SELECT * FROM inserted as I where LEN(I.PASS_CNHA)  < @MIN))))))))
	BEGIN
		RAISERROR ('Username/Password/SĐT/Họ tên KHI ĐĂNG KÝ TÀI KHOẢN không được phép rỗng hoặc bằng NULL. Password phải ít nhất 6 ký tự', 16, 1);
		ROLLBACK TRANSACTION;
		RETURN; 
	END
END
GO
---Tạo trigger cho KHACHHANG khi họ tạo TK
create trigger RBTV16_KH
ON KHACHHANG
AFTER UPDATE, INSERT
AS
BEGIN
	DECLARE @MIN INT = 6;
	IF (EXISTS (SELECT * FROM inserted as I where I.USER_KH IS NULL) OR (EXISTS (SELECT * FROM inserted as I where I.PASS_KH IS NULL) 
	OR (EXISTS (SELECT * FROM inserted as I where I.SDT IS NULL) OR (EXISTS (SELECT * FROM inserted as I where I.TEN_KH IS NULL))
	OR (EXISTS (SELECT * FROM inserted as I where I.USER_KH = '') OR (EXISTS (SELECT * FROM inserted as I where I.PASS_KH = ''))
	OR ((EXISTS (SELECT * FROM inserted as I where I.SDT = '')) OR (EXISTS (SELECT * FROM inserted as I where I.TEN_KH = ''))
	OR ((EXISTS (SELECT * FROM inserted as I where LEN(I.PASS_KH) < @MIN))))))))
	BEGIN
		RAISERROR ('Username/Password/SĐT/Họ tên KHI ĐĂNG KÝ TÀI KHOẢN không được phép rỗng hoặc bằng NULL. Password phải ít nhất 6 ký tự', 16, 1);
		ROLLBACK TRANSACTION;
		RETURN; 
	END
END
GO

--Câu 13: Nội dung hợp đồng k được để chuỗi rỗng, hoặc bằng NULL và phải có độ dài lớn hơn 20 ký tự.
IF OBJECT_ID ('RBTV13 ','TR') IS NOT NULL
   DROP TRIGGER RBTV13;
GO

CREATE TRIGGER RBTV13
ON HOPDONG
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @MIN INT = 20;
	IF (EXISTS (SELECT * FROM inserted as I where I.NDCV = '') OR (EXISTS (SELECT * FROM inserted as I where LEN(I.NDCV) < @MIN))
	OR (EXISTS (SELECT * FROM inserted as I where I.NDCV IS NULL)))
	BEGIN
		RAISERROR('Nội dung hợp đồng không được để chuỗi rỗng, hoặc bằng NULL và phải có độ dài lớn hơn 20 ký tự.',16,1)
		ROLLBACK TRANSACTION;
	END
END
GO

--Câu 14: Một username bất kỳ không được trùng với bất cứ username nào trong db ==> kiểm tra username khi tạo TK
IF OBJECT_ID ('RBTV14_NV','TR') IS NOT NULL
   DROP TRIGGER RBTV14_NV;
GO
CREATE TRIGGER RBTV14_NV
ON NHANVIEN
FOR INSERT, UPDATE
AS
BEGIN
	IF(EXISTS(SELECT * FROM inserted AS I WHERE I.USER_NV = ANY (SELECT KHACHHANG.USER_KH FROM KHACHHANG))
	OR (EXISTS(SELECT * FROM inserted AS I WHERE I.USER_NV = ANY (SELECT CHUNHA.USER_CNHA FROM CHUNHA))))
	BEGIN
		SELECT * FROM inserted AS I
		RAISERROR('Username này đã có. Vui lòng chọn username khác',16,1)
		ROLLBACK TRANSACTION;
	END
	
END 
GO

IF OBJECT_ID ('RBTV14_KH','TR') IS NOT NULL
   DROP TRIGGER RBTV14_KH;
GO
CREATE TRIGGER RBTV14_KH
ON KHACHHANG
FOR INSERT, UPDATE
AS
BEGIN
	IF(EXISTS(SELECT * FROM inserted AS I WHERE I.USER_KH = ANY (SELECT NHANVIEN.USER_NV FROM NHANVIEN))
	OR (EXISTS(SELECT * FROM inserted AS I WHERE I.USER_KH = ANY (SELECT CHUNHA.USER_CNHA FROM CHUNHA))))
	BEGIN
		SELECT * FROM inserted AS I
		RAISERROR('Username này đã có. Vui lòng chọn username khác',16,1)
		ROLLBACK TRANSACTION;
	END
	
END 
GO


IF OBJECT_ID ('RBTV14_CHUNHA','TR') IS NOT NULL
   DROP TRIGGER RBTV14_CHUNHA;
GO
CREATE TRIGGER RBTV14_CHUNHA
ON CHUNHA
FOR INSERT, UPDATE
AS
BEGIN
	IF(EXISTS(SELECT * FROM inserted AS I WHERE I.USER_CNHA= ANY (SELECT NHANVIEN.USER_NV FROM NHANVIEN))
	OR (EXISTS(SELECT * FROM inserted AS I WHERE I.USER_CNHA = ANY (SELECT KHACHHANG.USER_KH FROM KHACHHANG))))
	BEGIN
		SELECT * FROM inserted AS I
		RAISERROR('Username này đã có. Vui lòng chọn username khác',16,1)
		ROLLBACK TRANSACTION;
	END
	
END 
GO

--câu 12: lời bình luận, tiêu chí phải bằng NULL (khi chưa bình luận hoặc chưa điền tiêu chí vào) hoặc phải có độ dài lớn hơn MIN ký tự. Không được để rỗng.
IF OBJECT_ID ('RBTV12_COMMENT','TR') IS NOT NULL
   DROP TRIGGER RBTV12_COMMENT;
GO
CREATE TRIGGER RBTV12_COMMENT
ON XEM
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @MIN INT = 20
	IF(EXISTS(SELECT * FROM inserted AS I WHERE I.BINHLUAN = ''))
	BEGIN
		RAISERROR('Bình luận không được để trống!',16,1)
		UPDATE XEM
		SET XEM.BINHLUAN = NULL
		FROM XEM
		JOIN inserted as I ON I.MA_NHA = XEM.MA_NHA AND I.MA_KH = XEM.MA_KH
	END
	ELSE IF(EXISTS(SELECT * FROM inserted AS I WHERE LEN(I.BINHLUAN) < @MIN ))
	BEGIN
		RAISERROR('Bình luận không được ngắn hơn 20 kí tự!',16,1)
		ROLLBACK TRANSACTION;
	END 
END
GO

IF OBJECT_ID ('RBTV12_TIEUCHI','TR') IS NOT NULL
   DROP TRIGGER RBTV12_TIEUCHI;
GO
CREATE TRIGGER RBTV12_TIEUCHI
ON KHACHHANG
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @MIN INT = 20
	IF(EXISTS(SELECT * FROM inserted AS I WHERE I.TIEUCHI = ''))
	BEGIN
		RAISERROR('Tiêu chí không được để trống!',16,1)
		UPDATE KHACHHANG
		SET KHACHHANG.TIEUCHI = NULL
		FROM KHACHHANG
		JOIN inserted as I ON I.MA_KH = KHACHHANG.MA_KH
	END
	ELSE IF(EXISTS(SELECT * FROM inserted AS I WHERE LEN(I.TIEUCHI) < @MIN ))
	BEGIN
		RAISERROR('Tiêu chí không được ngắn hơn 20 kí tự!',16,1)
		ROLLBACK TRANSACTION;
	END 
END
GO

--câu 19: Nhà nào có tồn tại trong bảng XEM thì phải có ngày xem. Ngày xem phải lớn hơn ngày đăng
IF OBJECT_ID ('RBTV19_NGAYXEM','TR') IS NOT NULL
   DROP TRIGGER RBTV19_NGAYXEM;
GO
CREATE TRIGGER RBTV19_NGAYXEM
ON XEM
AFTER INSERT, UPDATE
AS
BEGIN
	IF(EXISTS(SELECT * FROM inserted AS I WHERE I.NGAYXEM IS NULL) OR 
	(EXISTS(SELECT * FROM inserted AS I WHERE I.MA_NHA IN (SELECT NHA.MA_NHA FROM NHA WHERE NHA.NGAYDANG >= CAST(I.NGAYXEM AS DATE)))
	OR ((EXISTS(SELECT * FROM inserted AS I WHERE I.NGAYXEM = '')))))
	BEGIN
		RAISERROR('Ngày xem phải lớn hơn ngày đăng của nhà và không được phép bằng NULL hoặc bằng rỗng',16,1);
		ROLLBACK TRANSACTION
	END
END
GO

--CÂU 15

IF OBJECT_ID ('RBTV15_HDMT','TR') IS NOT NULL
   DROP TRIGGER RBTV15_HDMT;
GO

CREATE TRIGGER RBTV15_HDMT
ON HOPDONG
AFTER INSERT, UPDATE
AS
BEGIN
	IF(EXISTS (SELECT DISTINCT HD.MA_NHA
						FROM HOPDONG AS HD
								WHERE EXISTS (
											SELECT 1
											FROM inserted L1
											WHERE L1.MA_NHA = HD.MA_NHA AND L1.TRANGTHAI_HD = 'HDB' AND HD.TRANGTHAI_HD = 'HDB'
											AND EXISTS (
													SELECT 1
													FROM HOPDONG L2
													WHERE L2.MA_NHA = L1.MA_NHA AND L2.TRANGTHAI_HD = 'HDB' AND L1.TRANGTHAI_HD = 'HDB'
													AND L1.MA_HD <> L2.MA_HD))))
	BEGIN
		RAISERROR('Nhà đã bán rồi không thể tạo thêm hợp đồng mới!',16,1);
		ROLLBACK TRANSACTION;
	END
	IF (EXISTS (SELECT 1
	FROM inserted AS I, HOPDONG
	WHERE I.TRANGTHAI_HD = 'HDT' AND HOPDONG.MA_HD <> I.MA_HD AND HOPDONG.NGAYKT_HD > I.NGAYBD_HD))
	OR (EXISTS (SELECT 1
	FROM inserted AS I, HOPDONG
	WHERE I.TRANGTHAI_HD = 'HDT' AND HOPDONG.MA_HD <> I.MA_HD AND HOPDONG.NGAYBD_HD > I.NGAYBD_HD))
	BEGIN
		RAISERROR('Sai thông tin ngày hết hạn hợp đồng',16,1);
		ROLLBACK TRANSACTION;
	END
END
GO

--CÂU 1
IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'delete_chunha')
begin
	drop procedure delete_chunha
end
go
create procedure delete_chunha
	@macnha char(5)
as
	if(not exists (select * from CHUNHA WHERE CHUNHA.MA_CNHA = @macnha))
	begin
		print 'MA_CNHA doesnt exist'
		return;
	end
	if exists(select HOPDONG.MA_CNHA from HOPDONG)
	begin
		delete from hopdong where hopdong.MA_CNHA=@macnha
	end
	if exists(select nhathue.MA_NHA from nhathue,nha where nha.MA_CNHA=@macnha and nha.MA_NHA=NHATHUE.MA_NHA)
	begin 
		delete from nhathue where nhathue.MA_NHA in (select nha.MA_NHA from nha where nha.MA_CNHA=@macnha)	
	end
	if exists(select NHABAN.MA_NHA from NHABAN,nha where nha.MA_CNHA=@macnha and nha.MA_NHA=NHABAN.MA_NHA)
	begin 
		delete from nhaban where nhaban.MA_NHA in (select nha.MA_NHA from nha where nha.MA_CNHA=@macnha)	
	end
	if exists(select NHA.MA_NHA from NHA,DCHINHA where nha.MA_CNHA=@macnha and nha.MA_NHA=DCHINHA.MA_NHA)
	begin 
		delete from  dchinha where dchinha.MA_NHA in (select nha.MA_NHA from nha where nha.MA_CNHA=@macnha)	
	end
	if exists(select NHA.MA_NHA from NHA,XEM where nha.MA_CNHA=@macnha and nha.MA_NHA=XEM.MA_NHA)
	begin 
		delete from  xem where xem.MA_NHA in (select nha.MA_NHA from nha where nha.MA_CNHA=@macnha)	
	end
	delete from nha where nha.MA_CNHA=@macnha
	delete from chunha where chunha.MA_CNHA=@macnha
go 
exec delete_chunha 'CN007'