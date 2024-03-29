﻿USE QLBAN_THUENHA
GO

/*CHỨC NĂNG 1*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'thongtinchitiet_NB_FIX_UR1')
begin
	drop procedure thongtinchitiet_NB_FIX_UR1
end
go
create procedure thongtinchitiet_NB_FIX_UR1
	@MANHA CHAR(5), @MUAHAYKHONG BIT  = 0, @RETURNCODE INT OUTPUT, @RETURNMESS NVARCHAR(100) OUTPUT
as
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	BEGIN TRAN
		BEGIN TRY
					DECLARE @TENCNHA NVARCHAR(20)
					DECLARE @SLPHONG INTEGER
					DECLARE @LOAINHA  NVARCHAR(20)
					DECLARE @GIABAN INTEGER
					DECLARE @TINHTRANG NVARCHAR(100) 
					DECLARE @DKCHUNHA NVARCHAR(50)
					DECLARE @TRANGTHAI BIT
					DECLARE @XEM INTEGER
					DECLARE @NGAYDANGBAI DATE
					DECLARE @NGAYHETHAN DATE
					DECLARE @DIACHI NVARCHAR(54)
					SET @DIACHI=(SELECT DCHINHA.DUONG FROM DCHINHA WHERE DCHINHA.MA_NHA=@MANHA)+' '+(SELECT DCHINHA.QUAN FROM DCHINHA WHERE DCHINHA.MA_NHA=@MANHA)+' '+(SELECT DCHINHA.TPHO FROM DCHINHA WHERE DCHINHA.MA_NHA=@MANHA)
					SET @TENCNHA=(SELECT CHUNHA.TEN_CNHA FROM CHUNHA,NHA WHERE NHA.MA_NHA=@MANHA AND CHUNHA.MA_CNHA=NHA.MA_CNHA)
					SET @SLPHONG=(SELECT NHA.SLPHONG FROM NHA WHERE NHA.MA_NHA=@MANHA)
					SET @LOAINHA=(SELECT LOAINHA.TENLN FROM LOAINHA,NHA WHERE NHA.MA_NHA=@MANHA AND LOAINHA.MA_LN=NHA.MALN)
					SET @GIABAN=(SELECT NHABAN.GIABAN FROM NHABAN WHERE NHABAN.MA_NHA=@MANHA)
					SET @TINHTRANG=(SELECT NHA.TINHTRANG FROM NHA WHERE NHA.MA_NHA=@MANHA)
					SET @DKCHUNHA=(SELECT NHABAN.DKCHUNHA FROM NHABAN WHERE NHABAN.MA_NHA=@MANHA)
					SET @TRANGTHAI=(SELECT NHA.TRANGTHAI FROM NHA WHERE NHA.MA_NHA=@MANHA)
					SET @XEM=(SELECT NHA.VIEW_NHA FROM NHA WHERE NHA.MA_NHA=@MANHA)
					SET @NGAYDANGBAI=(SELECT NHA.NGAYDANG FROM NHA WHERE NHA.MA_NHA=@MANHA)
					SET @NGAYHETHAN=(SELECT NHA.NGAYHETHAN FROM NHA WHERE NHA.MA_NHA=@MANHA)
	
					PRINT(N'Xem :'+CAST(@XEM AS CHAR(3)))
					PRINT(N'Ngày Đăng Bài: '+cast ( @NGAYDANGBAI as char(20)))
					PRINT(N'Ngày Hết Hạn: '+ cast( @NGAYHETHAN as char(20)))
					PRINT(N'Địa chỉ: '+@DIACHI)
					PRINT(N'Chủ nhà: '+@TENCNHA)
					PRINT(N'Số lượng phòng ở: '+ CAST( @SLPHONG as varchar(10)))
					PRINT(N'Loại nhà:'+@LOAINHA)
					PRINT(N'Giá bán: '+CAST(@GIABAN AS VARCHAR(10)))
					PRINT(N'Tình trạng: '+@TINHTRANG)
					PRINT(N'Điều kiện chủ nhà: '+@DKCHUNHA)
					IF (@TRANGTHAI=0)
					BEGIN
						PRINT(N'Trạng thái: Chưa bán');
						SET @RETURNMESS = N'Trạng thái: Chưa bán';
					END
					ELSE 
						BEGIN
							PRINT(N'Trạng thái: Đã bán');
							SET @RETURNMESS = N'Trạng thái: Đã bán';
						END
					PRINT(N'Bình luận:')
					DECLARE @MAKH NVARCHAR(20),@BINHLUAN NVARCHAR(100);
					declare cursor_binhluan CURSOR
					FOR SELECT KHACHHANG.TEN_KH,XEM.BINHLUAN FROM XEM,KHACHHANG
					WHERE KHACHHANG.MA_KH=XEM.MA_KH AND XEM.MA_NHA = @MANHA
					OPEN CURSOR_BINHLUAN;
					FETCH NEXT FROM CURSOR_BINHLUAN INTO
					@MAKH,
					@BINHLUAN;
					WHILE(@@FETCH_STATUS=0)
					BEGIN
						PRINT @MAKH +'-'+ @BINHLUAN
						FETCH NEXT FROM CURSOR_BINHLUAN INTO
							@MAKH, 
							@BINHLUAN;
					END;
					CLOSE CURSOR_BINHLUAN
					DEALLOCATE CURSOR_BINHLUAN
					-----ĐỂ TEST
					WAITFOR DELAY '00:00:06'
					---------------------------
					IF (@MUAHAYKHONG = 1)
					BEGIN
						DECLARE @TRANGTHAINHA BIT = (SELECT NHA.TRANGTHAI FROM NHA WHERE NHA.MA_NHA = @MANHA)
						IF (@TRANGTHAINHA = 1)
						BEGIN
									PRINT N' NHÀ ĐÃ ĐƯỢC BÁN RỒI. KHÔNG THỂ MUA NỮA';
									SET @RETURNCODE = 1;
									SET @RETURNMESS = N' NHÀ ĐÃ ĐƯỢC BÁN RỒI. KHÔNG THỂ MUA NỮA';
									ROLLBACK TRANSACTION
									RETURN;
						END
						ELSE 
						BEGIN
									PRINT N'THÔNG TIN NHÀ BẠN ĐĂNG KÝ MUA SƠ LƯỢC GỒM'
									SET @RETURNMESS = N'THÔNG TIN NHÀ BẠN ĐĂNG KÝ MUA SƠ LƯỢC GỒM'
									SELECT NHA.MA_NHA, CHUNHA.TEN_CNHA, NHABAN.GIABAN
									FROM NHA, CHUNHA, NHABAN WHERE NHABAN.MA_NHA = @MANHA AND NHA.MA_NHA = @MANHA AND CHUNHA.MA_CNHA = NHA.MA_CNHA
						END
					END
			END TRY
			BEGIN CATCH
				PRINT N'CHỨC NĂNG NÀY KHÔNG THỂ THỰC HIỆN THÀNH CÔNG'
				SET @RETURNCODE = 1;
				SET @RETURNMESS = N'CHỨC NĂNG NÀY KHÔNG THỂ THỰC HIỆN THÀNH CÔNG'
				ROLLBACK TRANSACTION;
				RETURN
			END CATCH
			SET @RETURNCODE = 0;
			SET @RETURNMESS = N'CHỨC NĂNG NÀY ĐÃ THỰC HIỆN THÀNH CÔNG'
			PRINT N'CHỨC NĂNG NÀY ĐÃ THỰC HIỆN THÀNH CÔNG'
	COMMIT
GO




/*CHỨC NĂNG 2*/
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