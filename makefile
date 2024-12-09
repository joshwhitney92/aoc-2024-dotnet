build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project aoc-2024-dotnet.Driver/aoc-2024-dotnet.Driver.csproj
start:
	dotnet run --project aoc-2024-dotnet.Driver/aoc-2024-dotnet.Driver.csproj
test:
	dotnet build && dotnet test --logger "console;verbosity=detailed"


