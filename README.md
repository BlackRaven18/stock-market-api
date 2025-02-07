# Stock Market API

The Stock Market API is a web application that allows users to create and manage stock portfolios, leave comments on stocks, and track market data. Built with C# and the .NET framework, it provides authentication, portfolio management, and interactive stock discussions.

## Features  

- **Stock Management** – Perform full **CRUD** (Create, Read, Update, Delete) operations on stock market data.  
- **Comment System** – Add, edit, delete, and retrieve comments related to stocks.  
- **Filtering & Sorting** – Easily filter and sort stocks and comments based on various criteria.  
- **User Authentication & Authorization** – Secure account creation, login, and JWT-based authentication.  
- **Portfolio Management** – Track and manage a personalized stock portfolio.  
- **Stock Data Seeding** – Automatically fetch missing stock data from an external API when a user searches for an unlisted stock.  

## Technologies Used

- **C#**: Core programming language for application development.
- **.NET Framework**: Provides a scalable and high-performance platform for building the API.
- **Entity Framework Core**: Facilitates efficient database operations and object-relational mapping.
- **ASP.NET Core**: Powers the web API, ensuring robust and secure HTTP services.
- **SQL Server**: Relational database for storing stock data and user information.

## Getting Started  

Follow these steps to set up and run the Stock Market API on your local machine.  

### Prerequisites  

- **.NET SDK** 8.0
- **SQL Server 2022**
- **Financial Modelling Prep API Key** (Required for sedding stock data)  

### Installation  

1. **Clone the Repository**  
   ```bash
   git clone https://github.com/BlackRaven18/stock-market-api.git
   cd stock-market-api
   ```  

2. **Restore Dependencies**  
   ```bash
   dotnet restore
   ```  

3. **Configure Database Connection (Optional)**  
   Update the connection string in `appsettings.json` to match your SQL Server instance:  
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database={YOUR_DATABASE_NAME};Trusted_Connection=True;TrustServerCertificate=True;"
   },
   ```  

4. **Apply Migrations**  
   ```bash
   dotnet ef database update
   ```  

5. **Create a `.env` File**  
   The application requires an **API key** from [Financial Modelling Prep](https://financialmodelingprep.com/) to fetch stock data.  
   Create a `.env` file in the project root and attach your FMP API key:  
   ```env
   FMP_API_KEY=your_fmp_api_key
   ```  

6. **Build the Application**  
   ```bash
   dotnet build
   ```  

7. **Run the Application**  
   ```bash
   dotnet watch run
   ```  
   The API will be accessible at `https://localhost:5069`.  

## Usage

After running the application, you can interact with the API endpoints using tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/). Detailed API documentation is available via Swagger at `https://localhost:5069/swagger/index.html`.
