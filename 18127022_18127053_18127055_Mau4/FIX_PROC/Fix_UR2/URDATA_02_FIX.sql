﻿USE QLBAN_THUENHA
-- T1 : TIM KIEM NHA DUA TREN TIEU CHI CU THE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'TRAN_TIMKIEMTIEUCHI_NB1')
begin
	drop procedure TRAN_TIMKIEMTIEUCHI_NB1
end
go
CREATE PROCEDURE TRAN_TIMKIEMTIEUCHI_NB1
	@GIABAN INTEGER,
	@RETURNCODE INT OUTPUT,
	@RETURNMESS NVARCHAR(100) OUTPUT
AS
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	BEGIN TRAN
	BEGIN TRY 
			SELECT NHA.MA_NHA,CHUNHA.TEN_CNHA AS CHUNHA, NHA.SLPHONG, NHA.VIEW_NHA, NHABAN.GIABAN, NHA.NGAYDANG, NHA.NGAYHETHAN
			FROM NHA, NHABAN, CHUNHA
			WHERE NHA.MA_NHA= NHABAN.MA_NHA AND NHABAN.GIABAN <= @GIABAN AND NHA.MA_CNHA = CHUNHA.MA_CNHA
			set @RETURNCODE = 0
			--ĐỂ TEST
			WAITFOR DELAY '00:00:06'
			---------------
			PRINT N'Số lượng nhà thỏa điều kiện trên là'
			set @RETURNCODE = 0;
			set @RETURNMESS = N'Số lượng nhà thỏa điều kiện trên là'
			SELECT COUNT(*) AS SOLUONGNHATHOADK
			FROM NHA,NHABAN,CHUNHA
			WHERE NHA.MA_NHA = NHABAN.MA_NHA AND NHABAN.GIABAN <=@GIABAN AND NHA.MA_CNHA=CHUNHA.MA_CNHA
	END TRY
	BEGIN CATCH
		PRINT N'Không thể Tim kiem nha ban dua tren tieu chi';
		set @RETURNCODE = 1
		set @RETURNMESS = N'Không thể Tim kiem nha ban dua tren tieu chi';
		ROLLBACK TRANSACTION
		RETURN;
	END CATCH
	COMMIT
GO


-- T2 CAP NHAT CHINH SUA THONG TIN NHA

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('dbo.chinhsua_loainha_ban_FIX','P') IS NOT NULL
BEGIN
	drop proc chinhsua_loainha_ban_FIX
END
go

create proc chinhsua_loainha_ban_FIX @MANHA CHAR(5) = NULL,@MA_LN CHAR(5) = NULL, @GIABAN INTEGER = NULL, @SLP INTEGER = NULL,
	 @KHUVUC NVARCHAR(30) = NULL, @DUONG NVARCHAR(30) = NULL, @QUAN NVARCHAR(30) = NULL,
	@TPHO NVARCHAR(40) = NULL, @NHH DATE = NULL,  @TINHTRANG NVARCHAR(100) = NULL, @CHINHANH CHAR(5) = NULL,
	@RETURNCODE INT OUTPUT, @RETURNMESS NVARCHAR(100) OUTPUT
as
begin transaction
	begin try
		IF @MA_LN IS NOT NULL
		BEGIN
			UPDATE NHA SET MALN = @MA_LN WHERE MA_NHA = @MANHA
		END

		IF @TINHTRANG IS NOT NULL
		BEGIN
			UPDATE NHA SET TINHTRANG = @TINHTRANG WHERE MA_NHA = @MANHA
		END

		IF @GIABAN IS NOT NULL
		BEGIN
			UPDATE NHABAN SET GIABAN = @GIABAN WHERE MA_NHA = @MANHA
			IF  @GIABAN % 100 != 0
			begin
				rollback transaction
				return;
			end
		END

		IF @KHUVUC IS NOT NULL
		BEGIN
			UPDATE DCHINHA SET KHUVUC = @KHUVUC WHERE MA_NHA = @MANHA
		END

		IF @DUONG IS NOT NULL
		BEGIN
			UPDATE DCHINHA SET DUONG = @DUONG WHERE MA_NHA = @MANHA
		END

		IF @QUAN IS NOT NULL
		BEGIN
			UPDATE DCHINHA SET QUAN = @QUAN WHERE MA_NHA = @MANHA
		END

		IF @TPHO IS NOT NULL
		BEGIN
			UPDATE DCHINHA SET TPHO = @TPHO WHERE MA_NHA = @MANHA
		END

		IF @NHH IS NOT NULL
		BEGIN
			UPDATE NHA SET NGAYHETHAN = @NHH WHERE MA_NHA = @MANHA
		END

		IF @SLP IS NOT NULL
		BEGIN
			UPDATE NHA SET SLPHONG = @SLP WHERE MA_NHA = @MANHA
		END

		IF @CHINHANH IS NOT NULL
		BEGIN
			UPDATE NHA SET MA_CN = @CHINHANH WHERE MA_NHA = @MANHA
		END
	end try
	begin catch
		print N'Chức năng thực hiện không thành công.'
		set @RETURNCODE = 1
		set @RETURNMESS = N'Chức năng thực hiện không thành công.'
		rollback transaction
		return;
	end catch
	set @RETURNCODE = 0
	set @RETURNMESS = N'Chức năng thực hiện thành công.'
commit transaction
go

/*fix tìm nhà để chạy trên UI hợp lý hơn*/
ALTER PROCEDURE [dbo].[TRAN_TIMKIEMTIEUCHI_NB1]
	@GIABAN INTEGER = 500000,
	@RETURNCODE INT OUTPUT,
	@RETURNMESS NVARCHAR(100) OUTPUT
AS
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	BEGIN TRAN
	BEGIN TRY 
			SELECT NHA.MA_NHA,CHUNHA.TEN_CNHA AS CHUNHA, NHA.SLPHONG, NHA.VIEW_NHA, NHABAN.GIABAN, NHA.NGAYDANG, NHA.NGAYHETHAN
			FROM NHA, NHABAN, CHUNHA
			WHERE NHA.MA_NHA= NHABAN.MA_NHA AND (@GIABAN is null or NHABAN.GIABAN <= @GIABAN) AND NHA.MA_CNHA = CHUNHA.MA_CNHA
			set @RETURNCODE = 0
			--ĐỂ TEST
			WAITFOR DELAY '00:00:06'
			---------------
			PRINT N'Số lượng nhà thỏa điều kiện trên là'
			set @RETURNCODE = 0;
			set @RETURNMESS = N'Số lượng nhà thỏa điều kiện trên là'
			SELECT COUNT(*) AS SOLUONGNHATHOADK
			FROM NHA,NHABAN,CHUNHA
			WHERE NHA.MA_NHA = NHABAN.MA_NHA AND (@GIABAN is null or NHABAN.GIABAN <= @GIABAN) AND NHA.MA_CNHA=CHUNHA.MA_CNHA
	END TRY
	BEGIN CATCH
		PRINT N'Không thể Tim kiem nha ban dua tren tieu chi';
		set @RETURNCODE = 1
		set @RETURNMESS = N'Không thể Tim kiem nha ban dua tren tieu chi';
		ROLLBACK TRANSACTION
		RETURN;
	END CATCH
	COMMIT