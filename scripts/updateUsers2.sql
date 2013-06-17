

set ansi_warnings off
SET IDENTITY_INSERT talk2me.dbo.Users ON
update talk2me.dbo.Users set groups_friends = 'default[me ana ion], friends[george andrei paul]' where username = 'evelinad'
SET IDENTITY_INSERT talk2me.dbo.Users OFF