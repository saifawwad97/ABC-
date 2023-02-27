CREATE USER aspnetcore FOR LOGIN [BUILTIN\IIS_IUSRS]



Grant EXECUTE ON AddProgram To aspnetcore


Grant EXECUTE ON AddStudent To aspnetcore


Grant EXECUTE ON DeleteStudent To aspnetcore



Grant EXECUTE ON GetProgram To aspnetcore


Grant EXECUTE ON GetStudent To aspnetcore


Grant EXECUTE ON UpdateStudent To aspnetcore

Grant EXECUTE ON GetStudentsByProgram To aspnetcore


select * from student