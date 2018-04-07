use MyWorkoutLog
go

if exists(select * from sys.tables where name='WorkoutExercise')
	drop table WorkoutExercise
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
	[Sets] INT  NULL,
	TracksReps BIT NOT NULL,
	Reps INT  NULL,
	TracksTime BIT NOT NULL,
	[Time] INT  NULL,
	TracksDistance BIT NOT NULL,
	Distance INT  NULL,
	DistanceUnit VARCHAR(10) NULL,
	TracksWeight BIT NOT NULL,
	[Weight] INT  NULL,
	
	UserId NVARCHAR(100) NOT NULL
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

exec dbreset