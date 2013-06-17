


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
groups_friends,
secret_question,
secret_answer,
email,
status,
first_name,
last_name)
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
'default[]',
'where I was born?',
'bucharest',
'evelina_dumitrescu@yahoo.com',
'Available',
'Evelina',
'Dumitrescu'
)
SELECT  *
FROM  talk2me.dbo.Users
SET IDENTITY_INSERT talk2me.dbo.Users OFF