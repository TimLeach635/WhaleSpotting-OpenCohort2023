# Whale Spotting

## Setup instructions

Ensure PostgreSQL is installed on your computer and is running (usually it will be running by default if you have installed it).

Create a new role on your local PostgreSQL server with the following details:

* Username: `whale-spotting`
* Password: `whale-spotting`
* Can login
* Can create databases

Then, run the command `dotnet ef database update` in the project directory (the directory that contains `WhaleSpotting.csproj`) to update the database schema to the latest version defined by the migrations. If this fails, it's usually because the login details are wrong—check the connection string in `appsettings.json` or `appsettings.Development.json`.

Finally, run `dotnet run` in the same directory, and the app will be available at `https://localhost:7132`.
