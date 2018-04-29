Use MyWorkoutLog
GO

if exists(select * from sys.procedures where name='spGetExercisesForUser')
	drop procedure spGetExercisesForUser
	go

CREATE PROCEDURE spGetExercisesForUser (
	@UserId NVARCHAR(100)
)
AS 
	BEGIN
		SELECT * FROM Exercise
		WHERE @UserId = UserId
	END
GO

if exists(select * from sys.procedures where name='spGetWorkoutsForUser')
	drop procedure spGetWorkoutsForUser
	go

CREATE PROCEDURE spGetWorkoutsForUser (
	@UserId NVARCHAR(100)
)
AS 
	BEGIN
		SELECT * FROM Workout
		WHERE @UserId = UserId
	END
GO

if exists(select * from sys.procedures where name='spGetExercisesForWorkout')
	drop procedure spGetExercisesForWorkout
	go

CREATE PROCEDURE spGetExercisesForWorkout (
	@WorkoutId INT
)
AS 
	BEGIN
		SELECT e.* FROM Workout w
		JOIN WorkoutExercise we ON w.WorkoutId = we.WorkoutId
		JOIN Exercise e on we.ExerciseId = e.ExerciseId
		LEFT JOIN ExerciseDetails ed ON e.ExerciseId = ed.ExerciseId
		WHERE @WorkoutId = w.WorkoutId
	END
GO

if exists(select * from sys.procedures where name='spAddExerciseToWorkout')
	drop procedure spAddExerciseToWorkout
	go

CREATE PROCEDURE spAddExerciseToWorkout (
	@WorkoutId INT,
	@ExerciseId INT
)
AS 
	INSERT INTO WorkoutExercise (WorkoutId, ExerciseId)
	Values (@WorkoutId, @ExerciseId)
GO



if exists(select * from sys.procedures where name='spInputExerciseNumbers')
	drop procedure spInputExerciseNumbers
	go

CREATE PROCEDURE spInputExerciseNumbers (
	@ExerciseId INT,
	@Sets INT,
	@Reps INT ,
	@Time TIME ,
	@Distance DECIMAL ,
	@DistanceUnit VARCHAR(10),
	@Weight INT 
)


AS 
	INSERT INTO ExerciseDetails(ExerciseId, [Sets], Reps, [Time], Distance, DistanceUnit, [Weight])
	VALUES (@ExerciseId, @Sets, @Reps, @Time, @Distance, @DistanceUnit, @Weight)
GO



--select * from Exercise


if exists(select * from sys.procedures where name='spAddNewWorkoutOnSunday')
	drop procedure spAddNewWorkoutOnSunday
	go

--will need to add the exercises in code when this is run

CREATE PROCEDURE spAddNewWorkoutOnSunday 
AS 
	BEGIN
		


		Insert INTO Workout 
			Select WorkoutName, DaysPerWeek, DATEADD(day, 7, StartDate), 1, UserId
			from Workout
			where IsCurrent = 1

		UPDATE Workout
			Set IsCurrent = 0
			Where DATEDIFF(day, StartDate, GETDATE()) >= 7
			AND IsCurrent = 1

		--DELETE FROM Workout
		--where WorkoutId in (
		--	SELECT w.WorkoutId
		--	FROM Workout w
		--	JOIN WorkoutExercise we on w.WorkoutId = we.WorkoutId
		--	JOIN Exercise e on we.ExerciseId = e.ExerciseId
		--	WHERE e.Distance is null
		--	AND e.Reps is null
		--	AND e.[Sets] is null
		--	AND e.[Time] is null
		--	AND e.[Weight] is null
		--	)
			
	END
GO



if exists(select * from sys.procedures where name='spAddExerciseForUser')
	drop procedure spAddExerciseForUser
	go

CREATE PROCEDURE spAddExerciseForUser  (
	@UserId NVARCHAR(100),
	@ExerciseName VARCHAR(50),
	@TracksSets BIT,
	@TracksReps BIT,
	@TracksTime BIT,
	@TracksDistance BIT,
	@TracksWeight BIT
)
AS 
	BEGIN
		


		Insert INTO Exercise (UserId, ExerciseName, TracksSets, TracksReps, TracksTime, TracksDistance, TracksWeight)
		VALUES (@UserId, @ExerciseName, @TracksSets, @TracksReps, @TracksTime, @TracksDistance, @TracksWeight)
			
	END
GO

if exists(select * from sys.procedures where name='spDropExerciseForUser')
	drop procedure spDropExerciseForUser
	go

CREATE PROCEDURE spDropExerciseForUser  (
	@UserId NVARCHAR(100),
	@ExerciseId INT
)
AS 
	BEGIN
		
		UPDATE Exercise
		SET UserId = null
		WHERE ExerciseId = @ExerciseId
		AND UserId = @UserId
			
	END
GO


if exists(select * from sys.procedures where name='spAddWorkoutForUser')
	drop procedure spAddWorkoutForUser
	go

CREATE PROCEDURE spAddWorkoutForUser  (
	@UserId NVARCHAR(100),
	@WorkoutName VARCHAR (50),
	@DaysPerWeek INT
)
AS 
	BEGIN
		


		Insert INTO Workout(UserId, WorkoutName, DaysPerWeek, StartDate)
		VALUES (@UserId, @WorkoutName, @DaysPerWeek, DATEADD(wk, DATEDIFF(wk,0,GETDATE()), -1))
			
	END
GO


if exists(select * from sys.procedures where name='spGetCurrentWeeklyWorkoutForUser')
	drop procedure spGetCurrentWeeklyWorkoutForUser
	go

CREATE PROCEDURE spGetCurrentWeeklyWorkoutForUser  (
	@UserId NVARCHAR(100)
)
AS 
	BEGIN
		Select  w.*
		From Workout w
		WHERE @UserId = w.UserId
		AND w.IsCurrent = 1
		ORDER BY w.StartDate DESC
			
	END
GO




--probably not needed, cause it's wrong
if exists(select * from sys.procedures where name='spGetWorkoutViewForUser')
	drop procedure spGetWorkoutViewForUser
	go

CREATE PROCEDURE spGetWorkoutViewForUser  (
	@UserId NVARCHAR(100),
	@WorkoutStartDate DATETIME2
)
AS 
	BEGIN
		Select w.WorkoutId, w.WorkoutName, w.StartDate, w.DaysPerWeek, we.[Day], e.ExerciseId, e.ExerciseName, e.TracksDistance
		, e.TracksReps, e.TracksSets, e.TracksReps, e.TracksSets, e.TracksTime, e.TracksWeight,
		ed.*
		From Workout w
		JOIN WorkoutExercise we ON w.WorkoutId = we.WorkoutId
		JOIN Exercise e ON we.ExerciseId = e.ExerciseId
		left JOIN ExerciseDetails ed ON e.ExerciseId = ed.ExerciseId
		WHERE @UserId = w.UserId
		AND @UserId = e.UserId
		AND @WorkoutStartDate = w.StartDate
		ORDER BY w.StartDate DESC
			
	END
GO


if exists(select * from sys.procedures where name='spGetWorkoutDatesForUser')
	drop procedure spGetWorkoutDatesForUser
	go

CREATE PROCEDURE spGetWorkoutDatesForUser  (
	@UserId NVARCHAR(100)
)
AS 
	BEGIN
		SELECT w.StartDate, w.WorkoutId
		FROM Workout w
		WHERE @UserId = w.UserId
		ORDER BY w.StartDate DESC
			
	END
GO

if exists(select * from sys.procedures where name='spMakeWorkoutActive')
	drop procedure spMakeWorkoutActive
	go

CREATE PROCEDURE spMakeWorkoutActive  (
	@UserId NVARCHAR(100),
	@WorkoutId INT
)
AS 
	BEGIN
		UPDATE Workout
		SET IsCurrent = 0
		WHERE @UserId = UserId
		AND IsCurrent = 1

		UPDATE Workout
		SET IsCurrent = 1
		WHERE @WorkoutId = WorkoutId
			
	END
GO

