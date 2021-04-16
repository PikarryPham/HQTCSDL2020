-- nhà bán

use QLBAN_THUENHA
go
EXEC chinhsua_loainha_ban @MANHA = 'N0001', @MA_LN = NULL, @TINHTRANG = NULL,
	@GIABAN = 123456, @KHUVUC = NULL, @DUONG =NULL, @QUAN = NULL,
	@TPHO = NULL, @NHH = NULL, @SLP = NULL, @CHINHANH = NULL
go

select * from nhaban