use ProductivityCoach
go

if exists(select * from sys.tables where name='DatesTasksComplete')
	drop table DatesTasksComplete
go

if exists(select * from sys.tables where name='DateComplete')
	drop table DateComplete
go

if exists(select * from sys.tables where name='UserTask')
	drop table UserTask
go

if exists(select * from sys.tables where name='Tasks')
	drop table Tasks
go

if exists(select * from sys.tables where name='TaskType')
	drop table TaskType
go

if exists(select * from sys.tables where name='DurationUnit')
	drop table DurationUnit
go

if exists(select * from sys.tables where name='CompleteEvery')
	drop table CompleteEvery
go





create table CompleteEvery (
	CompleteEveryId int primary key identity (1,1) not null,
	CompleteEveryTimeUnit varchar(10) not null
)

create table DurationUnit (
	DurationUnitId int primary key identity (1,1) not null,
	DurationUnit varchar(10) not null
)

create table TaskType (
	TypeId int primary key identity(1,1) not null,
	TypeName varchar(50) not null
)

create table Tasks (
	TaskId int primary key identity(1,1) not null,
	TaskName nvarchar(200) not null,
	TypeId int foreign key references TaskType(TypeId) not null,
	CompleteEveryNumber int,
	CompleteEveryId int foreign key references CompleteEvery(CompleteEveryId),
	DurationNumber int,
	DurationUnitId int foreign key references DurationUnit(DurationUnitId),
	DueDate datetime2,
	TotalTime time(7),
	UserId nvarchar(128) not null
)

create table UserTask (
	TaskId int foreign key references Tasks(TaskId) not null,
	UserId nvarchar(40) not null
)

create table DateComplete (
	DateId int primary key identity(1,1) not null,
	[Date] datetime2 not null
)

create table DatesTasksComplete (
	TaskId int foreign key references Tasks(TaskId) not null,
	DateId int foreign key references DateComplete(DateId) not null
)