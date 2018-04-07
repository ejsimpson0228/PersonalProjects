Use MyWorkoutLog
GO

--test user 1's password is 123456789
--test user 2's password is Password123$

if exists(select * from sys.procedures where name='DbReset')
	drop procedure DbReset
	go

CREATE PROCEDURE DbReset as 
	BEGIN
		DELETE FROM WorkoutExercise;
		DELETE FROM Workout;
		DELETE FROM Exercise

		SET IDENTITY_INSERT Workout ON
		INSERT INTO Workout (WorkoutId, WorkoutName, DaysPerWeek, StartDate, IsCurrent, UserId)
		VALUES (1, 'Beast Destroyer', 4, '2018-03-11', 0, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'), 
		(2, 'Cardio Madhouse', 3, '2018-03-25', 1, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'),
		(3, 'Weakling Featherweights', 1, '2018-03-25', 1, 'ade77a5f-1eb2-41bb-806d-3f2ef0713de9' ),
		(4, 'Cardio Madhouse', 3, '2018-03-18', 0, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2')
		SET IDENTITY_INSERT Workout OFF

		SET IDENTITY_INSERT Exercise ON
		INSERT INTO Exercise (ExerciseId, ExerciseName, TracksSets, [Sets], TracksReps, Reps, TracksTime, [Time], 
			TracksDistance, Distance, DistanceUnit, TracksWeight, [Weight], UserId)
		VALUES (1, 'Curls', 1, null, 1, null, 0, null, 0, null, null, 1, null, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'),
		(2, 'Deadlift', 1, null, 1, null, 0, null, 0, null, null, 1, null, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'),
		(3, 'Lunges', 1, null, 1, null, 0, null, 0, null, null, 1, null, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'),
		(4, 'Side Planks', 1, null, 1, null, 1, null, 0, null, null, 0, null, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'),
		(5, 'Jogging', 0, null, 0, null, 1, null, 1, null, null, 0, null, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'),
		(6, 'Bench Press', 1, null, 1, null, 0, null, 0, null, null, 1, null, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'),
		(7, 'Squats', 1, null, 1, null, 0, null, 0, null, null, 1, null, '8f4b02ca-4134-451c-ab5e-bd73c6a723b2'),
		(8, 'Squats', 1, null, 1, null, 0, null, 0, null, null, 1, null, 'ade77a5f-1eb2-41bb-806d-3f2ef0713de9')
		SET IDENTITY_INSERT Exercise OFF

		INSERT INTO WorkoutExercise (WorkoutId, ExerciseId, [Day])
		VALUES (2,5,1), (2,5,2), (2,5,3),
		(1,1,1), (1,2,1), (1,3,2),(1,4,2),(1,6,3),(1,7,4)


	END;
	