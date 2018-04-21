use MyWorkoutLog
go

if exists(select * from sys.tables where name='WorkoutExercise')
	drop table WorkoutExercise
	go

if exists(select * from sys.tables where name='ExerciseDetails')
	drop table ExerciseDetails
	go

if exists(select * from sys.tables where name='Exercise')
	drop table Exercise
	go



if exists(select * from sys.tables where name='Workout')
	drop table Workout
	go


CREATE TABLE Exercise(
	ExerciseId INT IDENTITY PRIMARY KEY NOT NULL,
	ExerciseName VARCHAR(50) NOT NULL,
	TracksSets BIT NOT NULL,
	TracksReps BIT NOT NULL,
	TracksTime BIT NOT NULL,
	TracksDistance BIT NOT NULL,
	TracksWeight BIT NOT NULL,
	UserId NVARCHAR(100) NOT NULL
)

CREATE TABLE ExerciseDetails (
	ExerciseDetailsId INT IDENTITY PRIMARY KEY NOT NULL,
	ExerciseId INT FOREIGN KEY REFERENCES Exercise(ExerciseId) NOT NULL,
	[Sets] INT  NULL,
	Reps INT  NULL,
	[Time] TIME  NULL,
	Distance DECIMAL  NULL,
	DistanceUnit VARCHAR(10) NULL,
	[Weight] INT  NULL
)


CREATE TABLE Workout (
	WorkoutId INT IDENTITY PRIMARY KEY NOT NULL,
	WorkoutName VARCHAR(100) NOT NULL,
	DaysPerWeek INT NOT NULL,
	StartDate DATETIME2 NOT NULL,
	IsCurrent BIT NOT NULL,
	UserId NVARCHAR(100) NOT NULL
)


CREATE TABLE WorkoutExercise(
	WorkoutId INT FOREIGN KEY REFERENCES Workout(WorkoutId) NOT NULL,
	ExerciseId INT FOREIGN KEY REFERENCES Exercise(ExerciseId) NOT NULL,
	[Day] INT NOT NULL
)

