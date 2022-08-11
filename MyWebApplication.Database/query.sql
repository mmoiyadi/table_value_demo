Alter Table Data
Add CreatedDate Datetime not null
Go

Alter Table Data Drop Column CreatedDate_new
Go

Exec sp_rename 'Data.CreatedDate_new', 'CreatedDate', 'Column'

truncate table Data;
