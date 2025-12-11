-- =============================================
-- Migration Script: Add TrangThai column to TaiKhoan table
-- Purpose: Enable lock/unlock account functionality
-- Date: 2025-12-09
-- =============================================

USE [QuanLyNhaSach]
GO

-- Check if column exists and add if not
IF NOT EXISTS (
    SELECT * FROM sys.columns 
    WHERE object_id = OBJECT_ID('dbo.TaiKhoan') 
    AND name = 'TrangThai'
)
BEGIN
    PRINT 'Adding TrangThai column to TaiKhoan table...'
    
    ALTER TABLE dbo.TaiKhoan 
    ADD TrangThai BIT NOT NULL DEFAULT 1;
    
    PRINT 'Column TrangThai added successfully with default value = 1 (Active)'
    PRINT 'All existing accounts are now Active by default'
END
ELSE
BEGIN
    PRINT 'Column TrangThai already exists - skipping'
END
GO

-- Verify the change
SELECT 
    c.name AS ColumnName,
    t.name AS DataType,
    c.max_length AS MaxLength,
    c.is_nullable AS IsNullable
FROM sys.columns c
INNER JOIN sys.types t ON c.user_type_id = t.user_type_id
WHERE object_id = OBJECT_ID('dbo.TaiKhoan')
ORDER BY c.column_id;
GO

PRINT 'Migration completed successfully!'
GO
