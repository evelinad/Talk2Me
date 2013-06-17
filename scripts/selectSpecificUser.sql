

set ansi_warnings off
SET IDENTITY_INSERT talk2me.dbo.Users ON
select id from talk2me.dbo.Users
where  username= 'evelinad'
SET IDENTITY_INSERT talk2me.dbo.Users OFF