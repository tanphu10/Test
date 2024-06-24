-- Calculate the total weight (tongheso) for each student's subjects in 2023
WITH TongHeSo AS (
    SELECT MaHV, MaMH, SUM(HeSo) AS TotalHeSo
    FROM BANGDIEM
    WHERE NamHoc = 2023
    GROUP BY MaHV, MaMH
),

-- Calculate the weighted average score (diemTBmon) for each student's subjects in 2023
DiemTB AS (
    SELECT bd.MaHV, bd.MaMH, 
           SUM(bd.Diem * bd.HeSo) / th.TotalHeSo AS diemTBmon
    FROM BANGDIEM bd
    JOIN TongHeSo th ON bd.MaHV = th.MaHV AND bd.MaMH = th.MaMH
    WHERE bd.NamHoc = 2023
    GROUP BY bd.MaHV, bd.MaMH, th.TotalHeSo
),

OverallDiemTBNH AS (
    SELECT dtb.MaHV, AVG(dtb.diemTBmon) AS DiemTBNH
    FROM DiemTB dtb
    JOIN MAHOCVIEN hv ON dtb.MaHV = hv.MaHV
    WHERE hv.Lop = '7A1'
    GROUP BY dtb.MaHV
),

MaxDiemTBNH AS (
    SELECT TOP 1 MaHV, DiemTBNH
    FROM OverallDiemTBNH
    ORDER BY DiemTBNH DESC
)

SELECT md.MaHV, hv.TenHV, md.DiemTBNH, 2023 AS NamHoc
FROM MaxDiemTBNH md
JOIN MAHOCVIEN hv ON md.MaHV = hv.MaHV;
