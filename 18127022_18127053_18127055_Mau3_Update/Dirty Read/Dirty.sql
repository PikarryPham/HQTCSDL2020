﻿use QLBAN_THUENHA
go

-- Chức năng chỉnh sửa loại nhà bán
IF OBJECT_ID('dbo.chinhsua_loainha_ban','P') IS NOT NULL
BEGIN
	drop proc chinhsua_loainha_ban
END
go

create proc chinhsua_loainha_ban @MANHA CHAR(5) = NULL,@MA_LN CHAR(5) = NULL, @GIABAN INTEGER = NULL, @SLP INTEGER = NULL,
	 @KHUVUC NVARCHAR(30) = NULL, @DUONG NVARCHAR(30) = NULL, @QUAN NVARCHAR(30) = NULL,
	@TPHO NVARCHAR(40) = NULL, @NHH DATE = NULL,  @TINHTRANG NVARCHAR(100) = NULL, @CHINHANH CHAR(5) = NULL

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
				WAITFOR DELAY '00:00:10'
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
	end catch
commit transaction
go


/* Thong tin chi tiet cua mot nha ban*/
IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'thongtinchitiet_NB')
begin
	drop procedure thongtinchitiet_NB
end
go
create procedure thongtinchitiet_NB
	@MANHA CHAR(5), @MUAHAYKHONG BIT  = 0
as
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	BEGIN TRAN
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
				END
				ELSE PRINT(N'Trạng thái: Đã bán');
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
				-----
				IF (@MUAHAYKHONG = 1)
				BEGIN
					--PRINT N'BẠN ĐANG ĐĂNG KÝ MUA ' + @MANHA + N' CỦA CHỦ NHÀ ' + @TENCNHA + N' VỚI GIÁ BÁN LÀ ' + CAST(@GIABAN as varchar(10))
					PRINT N'THÔNG TIN NHÀ BẠN ĐĂNG KÝ MUA SƠ LƯỢC GỒM'
					SELECT NHA.MA_NHA, CHUNHA.TEN_CNHA, NHABAN.GIABAN
					FROM NHA, CHUNHA, NHABAN WHERE NHABAN.MA_NHA = @MANHA AND NHA.MA_NHA = @MANHA AND CHUNHA.MA_CNHA = NHA.MA_CNHA
				END
COMMIT
GO
