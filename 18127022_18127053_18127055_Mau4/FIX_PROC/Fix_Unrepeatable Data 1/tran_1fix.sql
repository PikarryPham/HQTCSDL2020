/*Xem thong tin chi tiet cua nha ban*/
/*Unrepeatable Data*/
USE QLBAN_THUENHA
GO


DECLARE @CODE INT, @MESS NVARCHAR(100)
EXEC chinhsua_loainha_ban_FIX 'N0010','LN002',700000, @RETURNCODE = @CODE, @RETURNMESS = @MESS

