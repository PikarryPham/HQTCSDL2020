use QLBAN_THUENHA
go

IF OBJECT_ID('dbo.laphopdong_b2','P') IS NOT NULL
BEGIN
	drop proc laphopdong_b2
END
go

create proc laphopdong_b2 @manha char(5), @manv char(5)
AS
SET TRAN ISOLATION LEVEL REPEATABLE READ
begin transaction
	begin try
		declare @ngaybd date
		declare @ngaykt date      
		set @ngaybd = getdate()
		set @ngaykt = DATEADD(day,2,@ngaybd)

		select TEN_CNHA, DCHI_CNHA, SDT
		FROM CHUNHA
		WHERE MA_CNHA = 'CN001'

		select TEN_KH, DCHI_KH,SDT
		FROM KHACHHANG
		WHERE MA_KH = 'KH001'

		WAITFOR DELAY '0:0:03'
		select TEN_NV, MA_HD, NGAYBD_HD, NGAYKT_HD
		FROM NHANVIEN, HOPDONG
		WHERE LAMVIEC = (select MA_CN from NHA where MA_NHA = @manha) 
			AND HOPDONG.MA_NHA = @manha
			AND NHANVIEN.MA_NV = @manv
	end try
	begin catch
		print N'Chức năng thực hiện không thành công.'
		rollback transaction
		return;
	end catch
commit transaction
go

--select * from chunha

IF OBJECT_ID('dbo.capnhat_thongtin_chunha','P') IS NOT NULL
BEGIN
	drop proc capnhat_thongtin_chunha
END
go

create proc capnhat_thongtin_chunha @machunha char(5), @ten NVARCHAR(50), @dchi NVARCHAR(250),  @SDT VARCHAR(15),  @PASS_CNHA VARCHAR(50)
as 
begin transaction
	begin try
		IF @ten is not null
		BEGIN
			UPDATE CHUNHA SET TEN_CNHA = @ten WHERE MA_CNHA = @machunha
		END
		IF @dchi is not null
		BEGIN
			UPDATE CHUNHA SET DCHI_CNHA= @dchi WHERE MA_CNHA = @machunha
		END
		IF @SDT IS NOT NULL
		BEGIN
			UPDATE CHUNHA SET SDT = @SDT WHERE MA_CNHA = @machunha
		END
		IF @PASS_CNHA IS NOT NULL
		BEGIN
			UPDATE CHUNHA SET PASS_CNHA = @PASS_CNHA WHERE MA_CNHA = @machunha
		END
	end try
	begin catch
		print N'Chức năng thực hiện không thành công.'
		rollback transaction
		return;
	end catch
commit transaction
go
