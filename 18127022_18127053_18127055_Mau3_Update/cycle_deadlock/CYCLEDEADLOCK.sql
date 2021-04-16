USE QLBAN_THUENHA
GO

/*CYCLE DEADLOCK*/

/*CHỨC NĂNG 1*/
/*Transaction quản lý danh sách tất cả nhân viên tại chi nhánh đó*/

IF OBJECT_ID('QL_TATCANV_NVQL','P') IS NOT NULL
	DROP PROC QL_TATCANV_NVQL
GO

CREATE PROCEDURE QL_TATCANV_NVQL
@NVQL CHAR(5),
@MANV CHAR(5) = NULL, /*Gía trị mặc định là null*/
@UPDATESALARY BIT = 0,
@LUONG FLOAT = 0
AS
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION
	BEGIN TRY
		--Không cho phép mã nhân viên và mã nhân viên quản lý là như nhau ==> vì bản thân nhân viên quản lý k thể xóa chính họ ra khỏi bảng nhân viên hoặc cập nhật lương cho mình
		IF (@MANV = @NVQL)
		BEGIN
			PRINT N'Không thể cập nhật lương hoặc xóa chính bản thân nhân viên quản lý'
			ROLLBACK TRANSACTION;
			RETURN;
		END
		--Không cho phép mã nhân viên truyền vào là một nhân viên quản lý khác
		IF (EXISTS (SELECT * FROM CHINHANH WHERE CHINHANH.NVQUANLY = @MANV))
		BEGIN
			PRINT N'Không được xóa/cập nhật lương của nhân viên quản lý khác';
			ROLLBACK TRANSACTION
			RETURN;
		END
		--Tìm ra chi nhánh của nhân viên quản lý được truyền vào --> hiển thị danh sách các nhân viên do nhân viên quản lý đó quản lý
		DECLARE @CHINHANHNVQL CHAR(5) = (SELECT NHANVIEN.LAMVIEC FROM NHANVIEN WHERE NHANVIEN.MA_NV = @NVQL)
		--Hiển thị danh sách các nhân viên do nhân viên quản lý đó quản lý
		PRINT N'Danh sách nhân viên (tính cả nhân viên quản lý) làm việc tại' + @CHINHANHNVQL + N' khi chưa cập nhật lương'
		SELECT NHANVIEN.MA_NV, NHANVIEN.TEN_NV,
		NHANVIEN.LUONG, NHANVIEN.LAMVIEC FROM NHANVIEN WHERE NHANVIEN.LAMVIEC = @CHINHANHNVQL
		-- nhân viên quản lý muốn cập nhật lương: có 1 mã nhân viên truyền vào, bit updatesalary thành 1 còn deletenhanvien vẫn là 0
		IF (@MANV IS NOT NULL AND @UPDATESALARY = 1)
		BEGIN
			IF(NOT EXISTS (SELECT * FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV AND NHANVIEN.LAMVIEC = @CHINHANHNVQL))
			BEGIN
				PRINT N'Không tồn tại nhân viên này trong bảng nhân viên'
				ROLLBACK TRANSACTION
				RETURN;
			END
			ELSE 
			BEGIN 
				PRINT N'Cập nhật lương cho nhân viên'
				--TEST
				WAITFOR DELAY '00:00:07'
				UPDATE NHANVIEN
				SET NHANVIEN.LUONG = @LUONG
				WHERE NHANVIEN.MA_NV = @MANV

				--PRINT N'Danh sách nhân viên (tính cả nhân viên quản lý) làm việc tại' + @CHINHANHNVQL + N' sau khi đã nhật lương'
				--SELECT NHANVIEN.MA_NV, NHANVIEN.TEN_NV,
				--NHANVIEN.LUONG, NHANVIEN.LAMVIEC FROM NHANVIEN WHERE NHANVIEN.LAMVIEC = @CHINHANHNVQL
			END
		END
	END TRY
	BEGIN CATCH
		PRINT N'Không thể thực hiện chức năng này' 
		ROLLBACK TRANSACTION
		RETURN;
	END CATCH
	PRINT N'Thành công!'
COMMIT TRANSACTION


/*CHỨC NĂNG 2*/
IF OBJECT_ID('CHINHSUA_PROFILENV','P') IS NOT NULL
BEGIN
	drop proc CHINHSUA_PROFILENV
END
go

CREATE PROCEDURE CHINHSUA_PROFILENV 
@MANV CHAR(5), @TENNV NVARCHAR(50) = NULL, @SDT VARCHAR(15) = NULL, @DCHI NVARCHAR(250) = NULL, @DOB DATE = NULL
AS
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRAN
		BEGIN TRY
			IF (NOT EXISTS (SELECT * FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV))
			BEGIN
				PRINT 'Nhân viên này không tồn tại'
				ROLLBACK TRANSACTION
				RETURN;
			END
			IF @TENNV IS NOT NULL
				UPDATE NHANVIEN
				SET NHANVIEN.TEN_NV = @TENNV
				WHERE NHANVIEN.MA_NV = @MANV 
			IF @SDT IS NOT NULL
				UPDATE NHANVIEN
				SET NHANVIEN.SDT = @SDT
				WHERE NHANVIEN.MA_NV = @MANV 
			IF @DCHI IS NOT NULL
				UPDATE NHANVIEN
				SET NHANVIEN.DCHI_NV = @DCHI
				WHERE NHANVIEN.MA_NV = @MANV 
			IF @DOB IS NOT NULL
				UPDATE NHANVIEN
				SET NHANVIEN.NGSINH = @DOB
				WHERE NHANVIEN.MA_NV = @MANV 
			--Show ra thong tin sau khi chinh sua---
			DECLARE @CHINHANHNVQL CHAR(5) = (SELECT NHANVIEN.LAMVIEC FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV)
			SELECT NHANVIEN.MA_NV, NHANVIEN.TEN_NV,
			NHANVIEN.LUONG, NHANVIEN.LAMVIEC FROM NHANVIEN WHERE NHANVIEN.LAMVIEC = @CHINHANHNVQL AND NHANVIEN.MA_NV = @MANV
		END TRY
		BEGIN CATCH
					IF(ERROR_NUMBER() = 1205)
				 BEGIN
					 SELECT 'Deadlock Occurred. The Transaction has failed. Please retry'
				 END
				 -- Rollback the transaction
				 ROLLBACK TRANSACTION
				 RETURN;
		END CATCH 
		PRINT N'Chỉnh sửa thông tin cá nhân thành công'
COMMIT TRAN