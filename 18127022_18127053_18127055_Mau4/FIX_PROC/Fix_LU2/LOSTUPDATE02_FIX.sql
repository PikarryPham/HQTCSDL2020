﻿USE QLBAN_THUENHA
GO

/*Demo lỗi lost update*/
/*T1: */

/*Tăng thưởng/trừ lương: dựa trên số nhà phụ trách được + nếu số nhà phụ trách được > 3 ==> cộng thêm 3000, ngược lại trừ đi 2000  */
IF OBJECT_ID('TANGGIAM_LUONGNV_FIX','P') IS NOT NULL
BEGIN
	drop proc TANGGIAM_LUONGNV_FIX
END
go

CREATE PROC TANGGIAM_LUONGNV_FIX @MANV CHAR(5), @BONUSTIP FLOAT =0
AS
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRANSACTION
	BEGIN TRY
		IF (NOT EXISTS (SELECT * FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV))
		BEGIN
			print N'Không tồn tại mã nhân viên này'
			rollback transaction
			return;
		END
		DECLARE @SONHAPHUTRACH INT = (SELECT COUNT(MA_NHA)
											FROM NHA
											WHERE NVPT = @MANV
											GROUP BY NVPT)
		DECLARE @LUONGNV FLOAT
		SELECT @LUONGNV = LUONG
		FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV

		DECLARE @SOTIENBITRU FLOAT = 0;
		/*Nếu số nhà phụ trách lớn hơn 10 ==> thưởng 5000 */
		/*Nếu số nhà phụ trách < 10 && >= 5 ==> trừ 2000 */
		/*Nếu số nhà phụ trách < 5 && >= 2 ==> trừ 3000 */
		/*Nếu số nhà phụ trách < 2 ==> trừ 4500 */
		WAITFOR DELAY '00:00:07'
		IF(@SONHAPHUTRACH >= 10)
		BEGIN
			SET @SOTIENBITRU = 5000
			SET @LUONGNV = @LUONGNV + @SOTIENBITRU + @BONUSTIP
				---Cập nhật lương
			UPDATE NHANVIEN SET LUONG = @LUONGNV
			WHERE NHANVIEN.MA_NV = @MANV
		END
		ELSE IF (@SONHAPHUTRACH >=5 AND @SONHAPHUTRACH <10 )
		BEGIN
			SET @SOTIENBITRU = 2000
			SET @LUONGNV = @LUONGNV + @BONUSTIP - @SOTIENBITRU 
			---Cập nhật lương
			UPDATE NHANVIEN SET LUONG = @LUONGNV
			WHERE NHANVIEN.MA_NV = @MANV
		END
		ELSE IF (@SONHAPHUTRACH >=2 AND @SONHAPHUTRACH < 5)
		BEGIN
			SET @SOTIENBITRU = 3000
			SET @LUONGNV = @LUONGNV  + @BONUSTIP - @SOTIENBITRU
			---Cập nhật lương
			UPDATE NHANVIEN SET LUONG = @LUONGNV
			WHERE NHANVIEN.MA_NV = @MANV
		END
		ELSE IF (@SONHAPHUTRACH < 2)
		BEGIN
			SET @SOTIENBITRU = 4500
			SET @LUONGNV = @LUONGNV  + @BONUSTIP - @SOTIENBITRU
			---Cập nhật lương
			UPDATE NHANVIEN SET LUONG = @LUONGNV
			WHERE NHANVIEN.MA_NV = @MANV
		END
		PRINT @LUONGNV
	END TRY
	BEGIN CATCH
		print N'Chức năng thực hiện không thành công.'
		SELECT ERROR_MESSAGE() AS ErrorMessage;  
		rollback transaction
		return;
	END CATCH
	PRINT N'Cập nhật lương cho nhân viên thành công';
COMMIT TRANSACTION


/*T2:*/
-- Chức năng quản lý 1 nhân viên (quản lý)
IF OBJECT_ID('dbo.chucnangquanly_select_LU2_FIX','P') IS NOT NULL
BEGIN
	drop proc chucnangquanly_select_LU2_FIX
END
go
create proc chucnangquanly_select_LU2_FIX @MANV CHAR(5), @LUONG FLOAT , @SDT VARCHAR(15), @DCHI_NV NVARCHAR(250)
as 
--SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
--THẬT RA CÓ THỂ ĐỂ MẶC ĐỊNH ISOLATION LEVEL CHO THẰNG NÀY LÀ RC LUÔN
begin transaction
BEGIN TRY
		select MA_NV, TEN_NV, SDT, DCHI_NV, NGSINH, LUONG, USER_NV, LAMVIEC
		from NHANVIEN
		where MA_NV = @MANV
		IF @LUONG IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET LUONG = @LUONG WHERE MA_NV = @MANV
			DECLARE @LUONGHIENTAI FLOAT
			SELECT @LUONGHIENTAI = (SELECT LUONG FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV)
			PRINT N'Lương hiện tại của nhân viên đó sau khi được cập nhật là' + CONVERT(VARCHAR, @LUONGHIENTAI)
		END
		IF @DCHI_NV IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET DCHI_NV = @DCHI_NV WHERE MA_NV = @MANV
			DECLARE @DCHIHIENTAI NVARCHAR(250)
			SELECT @DCHIHIENTAI = (SELECT DCHI_NV FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV)
			PRINT N'Địa chỉ hiện tại của nhân viên đó sau khi được cập nhật là' + @DCHIHIENTAI
		END
		IF @SDT IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET SDT = @SDT WHERE MA_NV = @MANV
			DECLARE @SDTHIENTAI CHAR(11)
			SELECT @SDTHIENTAI = (SELECT SDT FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV)
			PRINT N'SĐT hiện tại của NV đó sau khi dc cập nhật là ' + @SDTHIENTAI
		END
END TRY
	begin catch
		print N'Chức năng thực hiện không thành công.'
		SELECT ERROR_MESSAGE() AS ErrorMessage;  
		rollback transaction
		return;
	end catch
commit transaction
go




/*Fix chức năng tăng giảm lương để hợp với UI*/
ALTER PROCEDURE [dbo].[TANGGIAM_LUONGNV_FIX]
	@MANV CHAR(5), @BONUSTIP FLOAT =0,
	@RETURNCODE INT OUTPUT,
	@RETURNMESS NVARCHAR(100) OUTPUT
AS
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRANSACTION
	BEGIN TRY
		IF (NOT EXISTS (SELECT * FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV))
		BEGIN
			print N'Không tồn tại mã nhân viên này'
			rollback transaction
			return;
		END
		DECLARE @SONHAPHUTRACH INT = (SELECT COUNT(MA_NHA)
											FROM NHA
											WHERE NVPT = @MANV
											GROUP BY NVPT)
		DECLARE @LUONGNV FLOAT
		SELECT @LUONGNV = LUONG
		FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV

		DECLARE @SOTIENBITRU FLOAT = 0;
		/*Nếu số nhà phụ trách lớn hơn 10 ==> thưởng 5000 */
		/*Nếu số nhà phụ trách < 10 && >= 5 ==> trừ 2000 */
		/*Nếu số nhà phụ trách < 5 && >= 2 ==> trừ 3000 */
		/*Nếu số nhà phụ trách < 2 ==> trừ 4500 */
		WAITFOR DELAY '00:00:07'
		IF(@SONHAPHUTRACH >= 10)
		BEGIN
			SET @SOTIENBITRU = 5000
			SET @LUONGNV = @LUONGNV + @SOTIENBITRU + @BONUSTIP
				---Cập nhật lương
			UPDATE NHANVIEN SET LUONG = @LUONGNV
			WHERE NHANVIEN.MA_NV = @MANV
		END
		ELSE IF (@SONHAPHUTRACH >=5 AND @SONHAPHUTRACH <10 )
		BEGIN
			SET @SOTIENBITRU = 2000
			SET @LUONGNV = @LUONGNV + @BONUSTIP - @SOTIENBITRU 
			---Cập nhật lương
			UPDATE NHANVIEN SET LUONG = @LUONGNV
			WHERE NHANVIEN.MA_NV = @MANV
		END
		ELSE IF (@SONHAPHUTRACH >=2 AND @SONHAPHUTRACH < 5)
		BEGIN
			SET @SOTIENBITRU = 3000
			SET @LUONGNV = @LUONGNV  + @BONUSTIP - @SOTIENBITRU
			---Cập nhật lương
			UPDATE NHANVIEN SET LUONG = @LUONGNV
			WHERE NHANVIEN.MA_NV = @MANV
		END
		ELSE IF (@SONHAPHUTRACH < 2)
		BEGIN
			SET @SOTIENBITRU = 4500
			SET @LUONGNV = @LUONGNV  + @BONUSTIP - @SOTIENBITRU
			---Cập nhật lương
			UPDATE NHANVIEN SET LUONG = @LUONGNV
			WHERE NHANVIEN.MA_NV = @MANV
		END
		PRINT @LUONGNV
		SET @RETURNCODE = 0;
		SET @RETURNMESS = @LUONGNV
	END TRY
	BEGIN CATCH
		print N'Chức năng thực hiện không thành công.'
		SET @RETURNCODE = 1;
		SET @RETURNMESS = ERROR_MESSAGE();
		--SELECT ERROR_MESSAGE() AS ErrorMessage;  
		rollback transaction
		return;
	END CATCH
	SET @RETURNCODE = 0;
	PRINT N'Cập nhật lương cho nhân viên thành công';
COMMIT TRANSACTION

DECLARE @CODE INT, @MESS NVARCHAR(100)
EXEC TANGGIAM_LUONGNV_FIX 'NV001',5000,@RETURNCODE = @CODE, @RETURNMESS = @MESS

/*Fix chức năng để phù hợp hơn với UI*/
ALTER PROCEDURE [dbo].[chucnangquanly_select_LU2_FIX]
	@MANV CHAR(5), @LUONG FLOAT , @SDT VARCHAR(15), @DCHI_NV NVARCHAR(250), @RETURNCODE INT OUTPUT, @RETURNMESS NVARCHAR(200) OUTPUT
AS
begin transaction
BEGIN TRY
		select MA_NV, TEN_NV, SDT, DCHI_NV, NGSINH, LUONG, USER_NV, LAMVIEC
		from NHANVIEN
		where MA_NV = @MANV
		IF @LUONG IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET LUONG = @LUONG WHERE MA_NV = @MANV
			DECLARE @LUONGHIENTAI FLOAT
			SELECT @LUONGHIENTAI = (SELECT LUONG FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV)
			PRINT N'Lương hiện tại của nhân viên đó sau khi được cập nhật là' + CONVERT(VARCHAR, @LUONGHIENTAI)
			SET @RETURNMESS = N'Lương hiện tại của nhân viên đó đã khi được cập nhật là' + CONVERT(VARCHAR,@LUONGHIENTAI)
		END
		IF @DCHI_NV IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET DCHI_NV = @DCHI_NV WHERE MA_NV = @MANV
			DECLARE @DCHIHIENTAI NVARCHAR(250)
			SELECT @DCHIHIENTAI = (SELECT DCHI_NV FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV)
			PRINT N'Địa chỉ hiện tại của nhân viên đó sau khi được cập nhật là' + @DCHIHIENTAI
			--SET @RETURNMESS = N'Địa chỉ hiện tại của nhân viên đó sau khi được cập nhật là' + @DCHIHIENTAI
		END
		IF @SDT IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET SDT = @SDT WHERE MA_NV = @MANV
			DECLARE @SDTHIENTAI CHAR(11)
			SELECT @SDTHIENTAI = (SELECT SDT FROM NHANVIEN WHERE NHANVIEN.MA_NV = @MANV)
			PRINT N'SĐT hiện tại của NV đó sau khi dc cập nhật là ' + @SDTHIENTAI
			--SET @RETURNMESS = N'SĐT hiện tại của NV đó sau khi dc cập nhật là ' + @SDTHIENTAI
		END
END TRY
	begin catch
		print N'Chức năng thực hiện không thành công.'
		SET @RETURNCODE = 1;
		SET @RETURNMESS = ERROR_MESSAGE() ;
		rollback transaction
		return;
	end catch
	SET @RETURNCODE = 0;
	PRINT N'Chức năng thực hiện thành công.'
commit transaction
go

SELECT * FROM NHANVIEN