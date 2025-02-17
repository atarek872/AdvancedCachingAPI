
# **Advanced In-Memory Caching in ASP.NET Core API**

## **Overview**
This project demonstrates an **advanced caching mechanism** using **In-Memory Caching** in an **ASP.NET Core Web API**. The API retrieves data from an **SQL Server database** and caches the results for optimized performance.

## **Technologies Used**
- **ASP.NET Core 8**
- **Entity Framework Core**
- **SQL Server**
- **In-Memory Caching**
- **Swagger for API Documentation**
- **Dependency Injection**

---

## **Setup Instructions**
### **1. Clone the Repository**
```sh
git clone https://github.com/your-username/your-repository.git
cd your-repository
```

### **2. Configure Database Connection**
Modify the **`appsettings.json`** file with your SQL Server connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=CacheDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### **3. Apply Migrations & Update Database**
Run the following commands in the terminal (within the project directory):

```sh
# Install Entity Framework Core Tools (if not installed)
dotnet tool install --global dotnet-ef

# Add Migrations
dotnet ef migrations add InitialCreate

# Update Database
dotnet ef database update
```

✅ **This will create the required database and tables.**

---

## **How Caching Works**
1. **First API request** → Fetches data from **SQL Database** and stores it in **In-Memory Cache**.
2. **Subsequent requests** → Fetches data directly from **Cache (Faster Response)**.
3. **Cache expires after a specific time** → Data is refreshed from the database.

---

## **API Endpoints**
### **1. Get All Weather Data**
#### **Request**
```http
GET /api/weather/get-all
```
#### **Response**
```json
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
```
✅ **First request** will return `"source": "Database"`.  
✅ **Subsequent requests** will return `"source": "Cache"`.

### **2. Clear Cache**
```http
DELETE /api/cache/clear
```
✅ **Use this to manually reset cache.**

---

## **Project Structure**
```
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
```

---

## **How to Run the Project**
```sh
dotnet run
```
✅ Open **Swagger UI** at:
```
https://localhost:5001/swagger
```

---

## **Next Steps**
- 🔹 **Enhance Cache** using **Redis for distributed caching**.
- 🔹 **Implement Cache Expiration Policies** (e.g., **Sliding Expiration**).
- 🔹 **Use Cache in Multi-Node Deployments**.

---

## **License**
This project is open-source under the **TK License**.

---

Let me know if you need any modifications! 🚀
