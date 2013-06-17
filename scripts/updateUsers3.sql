

set ansi_warnings off
SET IDENTITY_INSERT talk2me.dbo.Users ON
update talk2me.dbo.Users set groups_friends = 'buddies[evelinad evelinad evelinad],friends[evelinad evelinad evelinad]' where username = 'dragos'
SET IDENTITY_INSERT talk2me.dbo.Users OFF