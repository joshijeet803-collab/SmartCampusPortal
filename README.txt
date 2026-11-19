SMART CAMPUS SERVICE PORTAL (MVC + DATABASE + API)

Requirements: .NET 8 SDK and internet connection for first package restore.

RUN:
1. Extract the ZIP.
2. Open folder in Visual Studio (Open a folder) or terminal.
3. In terminal in project folder run: dotnet restore
4. Then: dotnet run
5. Open the local URL shown in terminal.

Features:
- MVC dashboard
- Submit campus service request (stored in SQLite database)
- Recent requests table
- Students API: GET /api/students, GET /api/students/{id}, POST /api/students, DELETE /api/students/{id}
- SQLite database created automatically on startup

Note: This starter project has not been compiled in this environment because the .NET SDK is unavailable here. Test on your laptop and report any error for correction.
