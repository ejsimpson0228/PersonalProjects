use ProductivityCoach 
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DbReset')
		drop procedure DbReset
go

create procedure DbReset AS
BEGIN



	DELETE FROM UserTask;
	DELETE FROM DatesTasksComplete;
	DELETE FROM DateComplete;
	DELETE FROM Tasks;
	DELETE FROM DurationUnit;
	DELETE FROM CompleteEvery;
	DELETE FROM TaskType;

	DBCC CHECKIDENT ('Tasks', RESEED, 1)
	DBCC CHECKIDENT ('TaskType', RESEED, 1)
	DBCC CHECKIDENT ('CompleteEvery', RESEED, 1)
	DBCC CHECKIDENT ('DurationUnit', RESEED, 1)
	DBCC CHECKIDENT ('DateComplete', RESEED, 1)





	SET IDENTITY_INSERT TaskType ON;

	INSERT INTO TaskType(TypeId, TypeName)
		VALUES (1, 'Checklist'),
			(2, 'Countdown'),
			(3, 'TimeGrind'),
			(4, 'CompleteBy')

	SET IDENTITY_INSERT TaskType OFF;

	SET IDENTITY_INSERT CompleteEvery ON;

	INSERT INTO CompleteEvery(CompleteEveryId, CompleteEveryTimeUnit)
		VALUES (1, 'Day'),
			(2, 'Week'),
			(3, 'Month'),
			(4, 'Year')

	SET IDENTITY_INSERT CompleteEvery OFF;

	SET IDENTITY_INSERT DurationUnit ON;

	INSERT INTO DurationUnit(DurationUnitId, DurationUnit)
		VALUES (1, 'second'),
			(2, 'minute'),
			(3, 'hour')

	SET IDENTITY_INSERT DurationUnit OFF;



	SET IDENTITY_INSERT Tasks ON;

	INSERT INTO Tasks (TaskId, TaskName, TypeId, CompleteEveryNumber, CompleteEveryId, DurationNumber, DurationUnitId, DueDate, TotalTime, UserId)
		VALUES (1, 'Put the kids to bed', 1, 1, 1, null, null, null, null,'983101f5-9f5b-4d2d-b1dd-f73ad3e16d08'),
		(2, 'Clean a room of the house',2, 1, 1, 20, 2, null, null,'983101f5-9f5b-4d2d-b1dd-f73ad3e16d08'),
		(3, 'Program something',3,1,2,5,3,null, '03:27:54','983101f5-9f5b-4d2d-b1dd-f73ad3e16d08'),
		(4, 'Finish Productivity Coach', 4,null,null,null,null,'8/31/2017',null,'983101f5-9f5b-4d2d-b1dd-f73ad3e16d08')

	SET IDENTITY_INSERT Tasks OFF;


	SET IDENTITY_INSERT DateComplete ON;

	INSERT INTO DateComplete (DateId, [Date])
		VALUES (1, '8/10/2017'),
		(2, '8/11/2017'),
		(3, '8/12/2017')

	SET IDENTITY_INSERT DateComplete OFF;

	INSERT INTO DatesTasksComplete (DateId, TaskId)
		VALUES (1, 1),(1,2),
		(2,1),
		(3,1),(3,2),(3,3)

	INSERT INTO UserTask (UserId, TaskId)
		VALUES ('983101f5-9f5b-4d2d-b1dd-f73ad3e16d08', 1),
		('983101f5-9f5b-4d2d-b1dd-f73ad3e16d08', 2),
		('983101f5-9f5b-4d2d-b1dd-f73ad3e16d08', 3),
		('983101f5-9f5b-4d2d-b1dd-f73ad3e16d08', 4)


END