


set ansi_warnings off
SET IDENTITY_INSERT talk2me.dbo.Users ON
delete from talk2me.dbo.Users  where id<4
SELECT  *
FROM  talk2me.dbo.Users
SET IDENTITY_INSERT talk2me.dbo.Users OFF