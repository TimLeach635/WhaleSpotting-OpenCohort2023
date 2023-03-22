# Whale Spotting

## Getting started

1. Fork this repo
    * Click `Fork` in the top-right of the page - this will create a copy of this repo in **your own GitHub account**
2. Clone (download) the repo
    * Go to your newly-created fork of the repo (on GitHub).
    * Click `Clone or download` (the green button on the right).
    * Make sure the page says `Clone with SSH` (rather than `Clone with HTTPS`).
    * Open your git client (e.g. GitKraken) and use this link to clone the repo.  
      Your trainer will able to help you with this.
3. "Cloning the repo" will create a folder on your computer with the files from this repo.  
   Open this folder in your IDE.
4. Open a command-prompt in this same folder.  
   Your trainer can show you how to do this, if you need any help.
5. Make sure you've got PostgreSQL installed. You'll notice that the `appsettings.json` and `appsettings.Development.json` files contain connection strings for connecting to a local PostgreSQL database. As well as installing Postgres we need to make sure we have a user set up to match that config, with the right permissions to create the database when the app runs. All instructions for this step are in the `Setting up Postgres` section below.
6. Install the Entity Framework command-line tools with `dotnet tool install --global dotnet-ef` (if you don't already have them installed).
7. Update your database schema with `dotnet ef database update` from inside the project directory (the directory containing the file `WhaleSpotting.csproj`).
   
   If this fails, it's usually because the login details are wrong—check the connection string in `appsettings.json` or `appsettings.Development.json`, and ensure you have set up the user in Postgres.
8. Run the app with `dotnet run`.
9. The app should now be available at `https://localhost:7132`!

## Setting up Postgres

Before you run the app you will need to make sure you've got Postgres installed and a database set up by following the instructions below.

### Install Postgres

1. Download and install the [PostgreSQL server software](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads) if you haven't already.

2. Make sure you've added Postgres to your PATH (`C:\Program Files\PostgreSQL\<your version number>\bin`).

3. Open the Windows Start menu and search for "pgAdmin". When you start "pgAdmin" for the first time, you'll be asked to set a password for your superuser.

### Set up Whalespotting user

1. Inside your `PostgreSQL <version number>` server, right-click on Login/Group Roles and create a new Login/Group Role with the name `whale-spotting` (in the General tab), the password `whale-spotting` (in the Definition tab) and the ability to log in and create databases (in the Privileges tab).

2. Click `Save` to create the user.

### Set up Whalespotting database

1. Inside your `PostgreSQL <version number>` server, right-click on Databases and create a new Database with the name `whale-spotting` and the owner `whale-spotting` (both in the General tab).

2. Click `Save` to create the database.

## Adding pages

Pages related to accounts and Identity are all in `/Areas/Identity/Pages`. There are a lot of files in here, but don't worry: they were all automatically generated. If, for example, you want to make changes to the login page, then you can do so by editing `/Areas/Identity/Pages/Account/Login.cshtml`.

To add other pages not related to user accounts, the views can be found in the `/Views` directory. Refer to `/Views/Home/Index.cshtml` for examples.
