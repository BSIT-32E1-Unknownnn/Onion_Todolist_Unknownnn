# Steps to set up the database to run the application


To run the application including the database, follow these steps:

1. After cloning the application, copy the path of the "todolist.db" file inside the "Onion_Todolist_Unknownnn" folder. You can find the "todolist.db" file inside the "Files" folder. Copy the path.

2. Open the application, then navigate to the "Models" folder and open "database.cs".

3. Inside "database.cs", locate the section where you can read " => options.UseSqlite(@"Data Source= Path");".

4. Paste the copied path inside the "Data Source" part of the connection string.

5. Finally, run the application.
