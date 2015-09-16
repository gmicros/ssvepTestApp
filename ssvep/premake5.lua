-- blinking --
project "ssvep"
	location "."	
	targetdir "%{sln.location}/build/%{cfg.buildcfg}"
	objdir "%{sln.location}/build/obj/%{prj.name}/%{cfg.buildcfg}"
	
	kind "WindowedApp"
	language "C#"
	architecture "x64"
	
	

	
	files
	{
		"Properties/*",
		"Images/*",
		"Resources/*",
		"*.cs",
		"*.xaml",
		"*.ico",
		"*.config"
	}
	
	links
	{
		"ConfigManager",
		"Microsoft.CSharp",
		"DisplayManager",
		"PresentationCore", 
		"PresentationFramework",        
		"WindowsBase",
		"System",
		"System.Core",
		"System.Data",		
		"System.Drawing",
		"System.Xaml",
	}