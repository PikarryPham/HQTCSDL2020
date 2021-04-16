use QLBAN_THUENHA
go

IF OBJECT_ID('dbo.chucnangquanly_select','P') IS NOT NULL
BEGIN
	drop proc chucnangquanly_select
END
go
create proc chucnangquanly_select @MANV CHAR(5), @LUONG FLOAT , @SDT VARCHAR(15), @DCHI_NV NVARCHAR(250)
as 
begin transaction
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
		--SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
		select MA_NV, TEN_NV, SDT, DCHI_NV, NGSINH, LUONG, USER_NV, LAMVIEC
		from NHANVIEN
		where MA_NV = @MANV
		IF @LUONG IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET LUONG = @LUONG WHERE MA_NV = @MANV
		END
		IF @DCHI_NV IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET DCHI_NV = @DCHI_NV WHERE MA_NV = @MANV
		END
		WAITFOR DELAY '0:0:05'
		IF @SDT IS NOT NULL
			BEGIN try
				UPDATE NHANVIEN SET SDT = @SDT WHERE MA_NV = @MANV
			END try
	begin catch
		print N'Chức năng thực hiện không thành công.'
		rollback transaction
		return;
	end catch
commit transaction
go

IF OBJECT_ID('dbo.chucnangquanly_select_nv','P') IS NOT NULL
BEGIN
	drop proc chucnangquanly_select_nv
END
go
create proc chucnangquanly_select_nv @MANV CHAR(5) , @SDT VARCHAR(15),  @DCHI_NV NVARCHAR(250)
as 
begin transaction
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	--SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	select MA_NV, TEN_NV, SDT, DCHI_NV, NGSINH, LUONG, USER_NV, LAMVIEC
		from NHANVIEN
		where MA_NV = @MANV
	IF @DCHI_NV IS NOT NULL
		BEGIN
			UPDATE NHANVIEN SET DCHI_NV = @DCHI_NV WHERE MA_NV = @MANV
		END
	IF @SDT IS NOT NULL
	WAITFOR DELAY '0:0:05'
	begin try
				UPDATE NHANVIEN SET DCHI_NV= @DCHI_NV WHERE MA_NV = @MANV
	end try
	begin catch
		print N'Chức năng thực hiện không thành công.'
		rollback transaction
		return;
	end catch
commit transaction
go
