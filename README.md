Advanced In-Memory Caching in ASP.NET Core API
Overview
This project demonstrates an advanced caching mechanism using In-Memory Caching in an ASP.NET Core Web API. The API retrieves data from an SQL Server database and caches the results for optimized performance.

Technologies Used
ASP.NET Core 8
Entity Framework Core
SQL Server
In-Memory Caching
Swagger for API Documentation
Dependency Injection
Setup Instructions
1. Clone the Repository
sh
Copy
Edit
git clone https://github.com/atarek872/AdvancedCachingAPI.git
cd your-repository
2. Configure Database Connection
Modify the appsettings.json file with your SQL Server connection string:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=CacheDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
3. Apply Migrations & Update Database
Run the following commands in the terminal (within the project directory):

sh
Copy
Edit
# Install Entity Framework Core Tools (if not installed)
dotnet tool install --global dotnet-ef

# Add Migrations
dotnet ef migrations add InitialCreate

# Update Database
dotnet ef database update
✅ This will create the required database and tables.

How Caching Works
First API request → Fetches data from SQL Database and stores it in In-Memory Cache.
Subsequent requests → Fetches data directly from Cache (Faster Response).
Cache expires after a specific time → Data is refreshed from the database.
API Endpoints
1. Get All Weather Data
Request
http
Copy
Edit
GET /api/weather/get-all
Response
json
Copy
Edit
{
  "source": "Cache",
  "data": [
    {
      "id": 1,
      "city": "Cairo",
      "temperature": "30°C",
      "date": "2024-02-17"
    }
  ]
}
✅ First request will return "source": "Database".
✅ Subsequent requests will return "source": "Cache".

2. Clear Cache
http
Copy
Edit
DELETE /api/cache/clear
✅ Use this to manually reset cache.

Project Structure
mathematica
Copy
Edit
📂 YourProject
 ┣ 📂 Controllers
 ┃ ┗ 📄 WeatherController.cs
 ┣ 📂 Data
 ┃ ┗ 📄 AppDbContext.cs
 ┣ 📂 Models
 ┃ ┗ 📄 WeatherData.cs
 ┣ 📂 Services
 ┃ ┗ 📄 CacheService.cs
 ┣ 📄 appsettings.json
 ┣ 📄 Program.cs
 ┗ 📄 README.md
How to Run the Project
sh
Copy
Edit
dotnet run
✅ Open Swagger UI at:

bash
Copy
Edit
https://localhost:5001/swagger
Next Steps
🔹 Enhance Cache using Redis for distributed caching.
🔹 Implement Cache Expiration Policies (e.g., Sliding Expiration).
🔹 Use Cache in Multi-Node Deployments.