# OpenWeatherAPI TESTS

This repo contains OpenWeatherAPI tests 

## CONFIG

1.  `Path` value is where the git clone https://github.com/Suresh0607/APITestingRepo.git is done.
     Example Cd C:\git Note : This can be changed
	`Path` = "C:\git"
	 Then do Git Clone https://github.com/Suresh0607/APITestingRepo.git
	
2.   Set the `Path` value in `Path`\`APITestingRepo\WeatherAPI\WeatherAPI\app.config` 
     to "C:\git"

3.   Set the `Path` value in `Path`\APITestingRepo\TestExecution.bat` to `C:\git`


## RUN

Build the Project 

	Open Command Prompt 
	Add Env 
	>path = %path%;C:\Program Files (x86)\MSBuild\14.0\Bin
	>msbuild 'Path'\APITestingRepo\WeatherAPI\WeatherAPI\APITesting.csproj

Normal Run:

Run the 'TestExecution.bat' in `Path`\`APITestingRepo\TestExecution.bat`
Check the Results in 
`Path'\APITestingRepo\WeatherAPI\TestReport`

Schedule Run for Every Hour :

1.  
	Run the following Command in the command Promt to Create a Scedule Task which runs every 1 

	Modify the `Path`

	schtasks /create /sc minute /mo 60 /tn "WeatherAPIScheduleExecution" /tr `Path`\APITestingRepo\TestExecution.bat
		
		or 
	Modify the 'Path' and run the ScheduleTestExecution Batch File
		

2. 
     TeamCity 

3.
     Jenkins

