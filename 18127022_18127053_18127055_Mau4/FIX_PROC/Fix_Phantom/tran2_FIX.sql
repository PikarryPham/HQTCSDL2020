/*transaction 2*/

USE QLBAN_THUENHA
GO

DECLARE @CODE INT, @MESS NVARCHAR(100)
EXEC THONGKE_FIX 'NV001',NULL,N'TP.HCM',@RETURNCODE = @CODE, @RETURNMESS = @MESS