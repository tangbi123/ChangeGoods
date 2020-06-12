create database Change
on
(
name = 'Change',
filename = 'E:\DATA\Change_data.mdf',
size = 5,
maxsize = 500,
filegrowth = 10%
)

log on
(
name = 'Change_log',
filename = 'E:\DATA\Change_log.ldf',
size = 3,
filegrowth = 1
)


