use master
go

if exists(select * from sys.databases where name='ProductivityCoach')
drop database ProductivityCoach
go

create database ProductivityCoach
go