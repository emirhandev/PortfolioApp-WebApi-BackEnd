# ASP.Net Core WebApi PortfolioApp
## Project Overview:
This project is an ASP.NET Web API application that allows users to perform various operations related to stocks. Users can view stock information, leave comments, manage their portfolios, and perform user login/registration operations. The project utilizes technologies like Identity, JWT Authentication, and EF Core. Additionally, financial data is sourced from Financial Modeling Prep, and users can also manually input stock information if they wish.
## Features:
- User Operations: User registration, login, and token generation.
- Stock Management: Listing, adding, updating, and deleting stocks. Users can also manually input stock information.
- Portfolio Management: Users can create and manage their own portfolio.
- Commenting: Users can leave comments about stocks and manage those comments.
- Financial Data Integration: Stock data is fetched from Financial Modeling Prep API, providing up-to-date financial information. Users can manually add their own stock details if desired.


## Tools & Libraries
- **ASP.NET Core**: Framework for building the Web API.
- **Entity Framework Core (EF Core)**: ORM used for database interactions.
- **ASP.NET Core Identity**: For user authentication and role management.
- **JWT Authentication**: Used for securing API endpoints and handling user tokens.
- **Financial Modeling Prep API**: Used for retrieving real-time stock data.
- **SQL Server**: Database used for storing user data, stock data, and portfolio information.
- **Swagger**: Used for API documentation and testing.


## Endpoints:

### 1. User Operations (Account Controller)

| Method | Endpoint              | Description                                      |
|--------|-----------------------|--------------------------------------------------|
| POST   | `api/account/login`    | User login and JWT token generation.             |
| POST   | `api/account/register` | Create a new user account and assign roles.      |

### 2. Stock Comment Operations (Comment Controller)

| Method | Endpoint                     | Description                                           |
|--------|------------------------------|-------------------------------------------------------|
| GET    | `api/comment`                | List comments made by users.                          |
| GET    | `api/comment/{id}`           | View details of a specific comment.                   |
| POST   | `api/comment/{symbol}`       | Add a new comment for a specific stock.               |
| PUT    | `api/comment/{id}`           | Update an existing comment.                           |
| DELETE | `api/comment/{id}`           | Delete a specific comment.                            |

### 3. Portfolio Management (Portfolio Controller)

| Method | Endpoint                        | Description                                           |
|--------|---------------------------------|-------------------------------------------------------|
| GET    | `api/portfolio`                 | List the user's current portfolio.                    |
| POST   | `api/portfolio?symbol={symbol}` | Add a specified stock to the user's portfolio.        |
| DELETE | `api/portfolio?symbol={symbol}` | Remove a specified stock from the user's portfolio.   |

### 4. Stock Management (Stock Controller)

| Method | Endpoint              | Description                                           |
|--------|-----------------------|-------------------------------------------------------|
| GET    | `api/stock`           | List all available stocks from Financial Modeling Prep. |
| GET    | `api/stock/{id}`      | View details of a specific stock.                     |
| POST   | `api/stock`           | Add a new stock manually or via Financial Modeling Prep API. |
| PUT    | `api/stock/{id}`      | Update information of an existing stock.              |
| DELETE | `api/stock/{id}`      | Delete a specific stock.                              |


## Images:

### Account
![Account](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/1.png)

### Stock
![Stock](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/2.png)
![Stock](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/3.png)

### Portfolio
![Portfolio](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/4.png)
![Portfolio](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/5.png)

### Comment
![Comment](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/6.png)
![Comment](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/7.png)
![Comment](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/8.png)

### Database Structure
![Database Structure](https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd/blob/main/Images/9.png)



## Installation Instructions:
1. Clone the repository:  
   `git clone https://github.com/emirhandev/PortfolioApp-WebApi-BackEnd.git`

2. Install required packages using NuGet:
   - `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.SqlServer`
   - `Microsoft.EntityFrameworkCore.Tools`
   - `System.IdentityModel.Tokens.Jwt`

3. Configure the app settings and database connection in `appsettings.json`.

4. Run the application using Visual Studio or via command line:
   - `dotnet run`

