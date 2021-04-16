/*Cập nhật, chỉnh sửa thông tin một nhà bán*/
/*Unrepeatable Data*/

USE QLBAN_THUENHA
GO



EXEC thongtinchitiet_NB 'N0010',1






SELECT * FROM NHA, NHABAN WHERE NHABAN.MA_NHA = NHA.MA_NHA AND NHA.MA_NHA = 'N0010'