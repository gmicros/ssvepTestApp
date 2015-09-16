-- This is the premake5 build script to generate the solution and projects for Meeting Canvas

-- Actions --
newaction 
{
	trigger = "clean", description = "Cleaning project space",
	execute = function ()
		os.rmdir('build')
		os.rmdir('ipch')
		os.remove('*.sln')
		os.remove('*.sdf')
		os.remove('*.suo')
		
		for dir in io.popen([[dir /b /ad]]):lines() do			
			os.rmdir(dir..'/obj')
			os.remove(dir..'/*.csproj')
			os.remove(dir..'/*.vcxproj')
			os.remove(dir..'/*.user')
			os.remove(dir..'/Properties/AssemblyInfo.cs')
		end
		
		for dir in io.popen([[dir TestApps /b /ad]]):lines() do			
			os.rmdir('TestApps/'..dir..'/obj')
			os.remove('TestApps/'..dir..'/*.csproj')
			os.remove('TestApps/'..dir..'/*.vcxproj')
			os.remove('TestApps/'..dir..'/*.user')
			os.remove('TestApps/'..dir..'/Properties/AssemblyInfo.cs')
		end
		
		for dir in io.popen([[dir UnitTests /b /ad]]):lines() do			
			os.rmdir('UnitTests/'..dir..'/obj')
			os.remove('UnitTests/'..dir..'/*.csproj')
			os.remove('UnitTests/'..dir..'/*.vcxproj')
			os.remove('UnitTests/'..dir..'/*.user')
			os.remove('UnitTests/'..dir..'/Properties/AssemblyInfo.cs')
		end
	end	
}


-- Solution --
solution "SSVEPtestApp"
	configurations { "Debug", "Release" }
	startproject "SSVEPtestApp"

	filter "configurations:Debug"
		defines { "DEBUG" }	
		
	filter "configurations:Release"
		defines { "NDEBUG" }
		optimize "On"
		
-- Projects --
include "ssvep"
