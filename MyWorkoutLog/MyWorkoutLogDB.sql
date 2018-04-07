Use master
go

IF EXISTS (SELECT * FROM sys.databases WHERE NAME = 'MyWorkoutLog')
DROP DATABASE MyWorkoutLog
GO

CREATE DATABASE MyWorkoutLog
GO