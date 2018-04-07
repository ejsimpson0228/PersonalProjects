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
		WHERE @WorkoutId = w.WorkoutId
	END
GO



if exists(select * from sys.procedures where name='spAddNewWorkoutOnSunday')
	drop procedure spAddNewWorkoutOnSunday
	go

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
			
	END
GO

exec dbreset

select * from Workout

exec spAddNewWorkoutOnSunday

select * from Workout
