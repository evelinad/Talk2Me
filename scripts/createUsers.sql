
set ansi_warnings off
SET IDENTITY_INSERT talk2me.dbo.Users ON
insert into talk2me.dbo.Users 
(ID, 
username,
password, 
gender, 
birthdate, 
birthplace, 
telephone, 
personal_interest, 
education, 
workplace, 
current_city, 
country, 
address, 
nationality, 
languages, 
favourite_quatations, 
groups_friends)
values(
' 1 ',
'evelinad', 
'andreia', 
'F',
'11/16/90',
'bucharest',
'0720822616',
'movies & ski',
'CNMV, UPB',
'UPB',
'Bucharest',
'Romania',
'Ceaikowski Street',
'Romanian',
'english',
'less is more',
'default[]'
)

insert into talk2me.dbo.Users 
(ID, 
username,
password, 
gender, 
birthdate, 
birthplace, 
telephone, 
personal_interest, 
education, 
workplace, 
current_city, 
country, 
address, 
nationality, 
languages, 
favourite_quatations, 
groups_friends)
values(
' 4 ',
'dragoss', 
'dragoss', 
'M',
null,
'bucharest',
null,
null,
'UPB',
'UPB',
'Bucharest',
'Romania',
null,
'Romanian',
null,
null,
'default[]'
)
insert into talk2me.dbo.Users 
(ID, 
username,
password, 
gender, 
birthdate, 
birthplace, 
telephone, 
personal_interest, 
education, 
workplace, 
current_city, 
country, 
address, 
nationality, 
languages, 
favourite_quatations, 
groups_friends)
values(
' 3 ',
'andreeas', 
'andreeas', 
'F',
null,
'bucharest',
null,
null,
'UPB',
'UPB',
'Bucharest',
'Romania',
null,
'Romanian',
null,
null,
'default[]'
)
insert into talk2me.dbo.Users 
(ID, 
username,
password, 
gender, 
birthdate, 
birthplace, 
telephone, 
personal_interest, 
education, 
workplace, 
current_city, 
country, 
address, 
nationality, 
languages, 
favourite_quatations, 
groups_friends)
values(
' 2 ',
'gabim', 
'gabim', 
'F',
null,
'bucharest',
null,
null,
'CNIH, UPB',
'UPB',
'Bucharest',
'Romania',
null,
null,
null,
null,
'default[]'
)
SET IDENTITY_INSERT talk2me.dbo.Users OFF