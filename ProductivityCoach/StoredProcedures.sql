use ProductivityCoach
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetTask')
		DROP PROCEDURE GetTask
GO

CREATE PROCEDURE GetTask (
	@TaskId INT
) AS
BEGIN
	SELECT TaskId, TaskName, TypeName, 
	CompleteEveryNumber, CompleteEveryTimeUnit, 
	DurationNumber, DurationUnit, DueDate, TotalTime, 
	UserId   FROM Tasks t
	left JOIN TaskType tt ON t.TypeId = tt.TypeId
	left JOIN CompleteEvery ce ON t.CompleteEveryId = ce.CompleteEveryId
	left JOIN DurationUnit du ON t.DurationUnitId = du.DurationUnitId
	WHERE TaskId = @TaskId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetTasksForUser')
		DROP PROCEDURE GetTasksForUser
GO

CREATE PROCEDURE GetTasksForUser (
	@UserId NVARCHAR(128)
) AS
BEGIN
	SELECT TaskId, TaskName, TypeName, CompleteEveryNumber, CompleteEveryTimeUnit, DurationNumber, DurationUnit, DueDate, TotalTime, UserId   FROM Tasks t
	left JOIN TaskType tt ON t.TypeId = tt.TypeId
	left JOIN CompleteEvery ce ON t.CompleteEveryId = ce.CompleteEveryId
	left JOIN DurationUnit du ON t.DurationUnitId = du.DurationUnitId
	WHERE @UserId = UserId
	Order by TaskName;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AddTask')
		DROP PROCEDURE AddTask
GO

CREATE PROCEDURE AddTask (
	@TaskId int output,
	@UserId NVARCHAR(128),
	@TypeName VARCHAR(50),
	@TaskName NVARCHAR(200),
	@CompleteEveryNumber INT = null,
	@CompleteEveryTimeUnit VARCHAR(10) = null,
	@DurationNumber INT = null,
	@DurationUnit VARCHAR(10) = null,
	@DueDate DATETIME2(7) = null
)
AS
	DECLARE @TypeId INT
	DECLARE @CompleteEveryId INT
	DECLARE @DurationUnitId INT

BEGIN
	SET @TypeId = (SELECT tt.TypeId FROM TaskType tt WHERE @TypeName = tt.TypeName) 
	IF @CompleteEveryTimeUnit IS NOT NULL
		BEGIN SET @CompleteEveryId = (SELECT ce.CompleteEveryId FROM CompleteEvery ce WHERE @CompleteEveryTimeUnit = ce.CompleteEveryTimeUnit) END
	IF @DurationUnit IS NOT NULL
		BEGIN SET @DurationUnitId = (SELECT du.DurationUnitId FROM DurationUnit du WHERE @DurationUnit = du.DurationUnit) END

	INSERT INTO Tasks (TaskName, TypeId, CompleteEveryNumber, CompleteEveryId, DurationNumber, DurationUnitId, DueDate, TotalTime, UserId)
	VALUES (@TaskName, @TypeId, @CompleteEveryNumber, @CompleteEveryId, @DurationNumber, @DurationUnitId, @DueDate, '00:00:00', @UserId)

	SET @TaskId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EditTask')
		DROP PROCEDURE EditTask
GO

CREATE PROCEDURE EditTask (
	@TaskId INT,
	@TypeName VARCHAR(50),
	@TaskName NVARCHAR(200),
	@CompleteEveryNumber INT = null,
	@CompleteEveryTimeUnit VARCHAR(10) = null,
	@DurationNumber INT = null,
	@DurationUnit VARCHAR(10) = null,
	@DueDate DATETIME2(7) = null
)
AS
	DECLARE @TypeId INT
	DECLARE @CompleteEveryId INT
	DECLARE @DurationUnitId INT

BEGIN
	SET @TypeId = (SELECT tt.TypeId FROM TaskType tt WHERE @TypeName = tt.TypeName) 
	IF @CompleteEveryTimeUnit IS NOT NULL
		BEGIN SET @CompleteEveryId = (SELECT ce.CompleteEveryId FROM CompleteEvery ce WHERE @CompleteEveryTimeUnit = ce.CompleteEveryTimeUnit) END
	IF @DurationUnit IS NOT NULL
		BEGIN SET @DurationUnitId = (SELECT du.DurationUnitId FROM DurationUnit du WHERE @DurationUnit = du.DurationUnit) END

	UPDATE Tasks 
		SET TaskName = @TaskName, TypeId = @TypeId, CompleteEveryNumber = @CompleteEveryNumber, CompleteEveryId = @CompleteEveryId, DurationNumber = @DurationNumber, DurationUnitId = @DurationUnitId,
		DueDate = @DueDate
	WHERE @TaskId = TaskId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteTask')
		DROP PROCEDURE DeleteTask
GO

CREATE PROCEDURE DeleteTask (
	@TaskId INT
)
AS
BEGIN
	DELETE FROM Tasks
	WHERE TaskId = @TaskId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateTotalTime')
		DROP PROCEDURE UpdateTotalTime
GO

--will probably need to do the addition in C# and pass in new value
CREATE PROCEDURE UpdateTotalTime (
	@TaskId INT,
	@TotalTime TIME(7)
)
AS
BEGIN
	UPDATE Tasks
		SET TotalTime = @TotalTime
		WHERE TaskId = @TaskId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AddDateCompleteToTask')
		DROP PROCEDURE AddDateCompleteToTask
GO

--will probably need to do the addition in C# and pass in new value
CREATE PROCEDURE AddDateCompleteToTask (
	@TaskId INT,
	@Date DATETIME2(7)
)
AS
	DECLARE @DateId INT
BEGIN
	IF NOT EXISTS (SELECT [Date] FROM DateComplete dc WHERE @Date = dc.Date)
		BEGIN
			INSERT INTO DateComplete ([Date])
			VALUES (@Date)
		END
	SET @DateId = (SELECT dc.DateId FROM DateComplete dc WHERE dc.Date = @Date)
	INSERT INTO DatesTasksComplete (TaskId, DateId)
		VALUES (@TaskId, @DateId)
END
GO

--Exec AddDateCompleteToTask 1, '8/29/17'

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'RemoveDateCompleteFromTask')
		DROP PROCEDURE RemoveDateCompleteFromTask
GO

CREATE PROCEDURE RemoveDateCompleteFromTask (
	@TaskId INT,
	@Date DATETIME2(7)
)
AS
	DECLARE @DateId INT
BEGIN
	SET @DateId = (SELECT dc.DateId FROM DateComplete dc WHERE dc.Date = @Date)
	DELETE FROM DatesTasksComplete 
	WHERE DateId = @DateId AND TaskId = @TaskId
END
GO

--exec RemoveDateCompleteFromTask 1, '8/29/17'

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDatesTaskComplete')
		DROP PROCEDURE GetDatesTaskComplete
GO

CREATE PROCEDURE GetDatesTaskComplete (
	@TaskId INT
)
AS
BEGIN
	SELECT [Date] FROM DateComplete dc
	JOIN DatesTasksComplete dtc ON dc.DateId = dtc.DateId
	WHERE dtc.TaskId = @TaskId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetTaskTypes')
		DROP PROCEDURE GetTaskTypes
GO

CREATE PROCEDURE GetTaskTypes 
AS
BEGIN
	SELECT * FROM TaskType 
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDurationUnits')
		DROP PROCEDURE GetDurationUnits
GO

CREATE PROCEDURE GetDurationUnits 
AS
BEGIN
	SELECT * FROM DurationUnit 
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetTimeUnits')
		DROP PROCEDURE GetTimeUnits
GO

CREATE PROCEDURE GetTimeUnits 
AS
BEGIN
	SELECT * FROM CompleteEvery 
END
GO
--exec GetDatesTaskComplete 1