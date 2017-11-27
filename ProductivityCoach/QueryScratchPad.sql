--select  Email, UserName, TaskName, TypeName, TotalTime, [Date]from Tasks t
--	left join UserTask ut on t.TaskId = ut.TaskId
--	join TaskType tt on t.TypeId = tt.TypeId
--	left join AspNetUsers u on ut.UserId = u.Id
--	left join DatesTasksComplete dtc on t.TaskId = dtc.TaskId
--	left join DateComplete dc on dtc.DateId = dc.DateId

--select [Date], TaskName from DateComplete dc
--	left join DatesTasksComplete dtc on dc.DateId = dtc.DateId
--	left join Tasks t on dtc.TaskId = t.TaskIs

select * from Tasks

