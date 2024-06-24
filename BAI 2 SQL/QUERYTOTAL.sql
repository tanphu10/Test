--học lại
WITH TongHeSo AS (
    SELECT MaHV, MaMH, SUM(HeSo) AS TotalHeSo
    FROM BANGDIEM
    WHERE NamHoc = 2024
    GROUP BY MaHV, MaMH
),

DiemTB AS (
    SELECT bd.MaHV, bd.MaMH, 
           SUM(bd.Diem * bd.HeSo) / th.TotalHeSo AS diemTBmon
    FROM BANGDIEM bd
    JOIN TongHeSo th ON bd.MaHV = th.MaHV AND bd.MaMH = th.MaMH
    WHERE bd.NamHoc = 2023
    GROUP BY bd.MaHV, bd.MaMH, th.TotalHeSo
)

SELECT hv.MaHV, hv.TenHV, mh.TenMH, dtb.diemTBmon
FROM DiemTB dtb
JOIN MAHOCVIEN hv ON dtb.MaHV = hv.MaHV
JOIN MONHOC mh ON dtb.MaMH = mh.MaMH
WHERE dtb.diemTBmon < 5;
