Note Taking Application
Description
This is a simple note-taking application built using Windows Forms and SQL Server. It allows users to create, save, delete, open, search, and export notes.

Setup Instructions
Prerequisites
Microsoft Visual Studio (or any other C# IDE)
SQL Server (SQL Express or higher)
Installation Steps
Clone or download the repository to your local machine.
Open the solution file (NoteTakingApp.sln) in Visual Studio.
Open SQL Server Management Studio and connect to your SQL Server instance.
Execute the SQL script (NoteDB.sql) located in the repository to create the database and notes table.
Modify the connection string in the Form1.cs file to match your SQL Server instance:
private const string connectionString = @"Data Source=YOUR_SERVER_NAME; Initial Catalog=NoteDB; Integrated Security=True;";
Build and run the application from Visual Studio.
Usage Instructions
Creating a New Note: Click the "New" button to clear the title and content fields for creating a new note.
Saving a Note: Enter a title and content for the note, then click the "Save" button to save it to the database.
Opening a Note: Click on a note in the list to select it, then click the "Open" button to view its content.
Deleting a Note: Select a note from the list and click the "Delete" button to remove it from the database.
Searching for Notes: Enter a keyword in the search box to filter notes by title.
Exporting a Note: Select a note from the list and click the "Export" button to save it as a text file.
Troubleshooting
If you encounter any issues during setup or usage, ensure that your SQL Server instance is running and accessible from the application.
Check the connection string in the Form1.cs file to ensure it is correctly configured.
