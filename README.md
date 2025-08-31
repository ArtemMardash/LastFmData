# LastFm Library Project

This project imports artist data (with albums and tags) from the [Last.fm API]( ), stores it in a PostgreSQL database, and exposes it through a .NET API. A Blazor Server UI consumes this API and displays the data in a user-friendly table.

---

Project Structure

- **LastFm.API**  
  - Minimal API service.  
  - Imports data from Last.fm API using Entity Framework Core.  
  - Stores data in PostgreSQL.  
  - Provides endpoints (e.g. `/GetAllData`) to fetch data from DB.  

- **LastFm.UI**  
  - Blazor Server application.  
  - Calls the API service using `HttpClient`.  
  - Displays artists with their tags and albums in a table.  

---
## Technologies

The project utilizes the following technologies and libraries:
- Programming languages: `C#`.
- Frameworks: `.NET 8.0`.
- Database: `PostgreSQL`.
- Libraries: `Microsoft.AspNetCore.OpenApi`, `Microsoft.EntityFrameworkCore.Design`,  `Swashbuckle.AspNetCore`, `Npgsql.EntityFrameworkCore.PostgreSQL`, `Microsoft.EntityFrameworkCore`


## Setup

### 1. Clone the repository
```bash
git clone https://github.com/<ArtemMardash/LastFmData.git
cd LastFmData
```
### 2. Configure the database connection and Last.fm credentials

In `MusicFM.API/appsettings.json`, replace the placeholder values:

"LastFm": {
  "ApplicationName": "MusicFM",
  "ApiKey": "YOUR_LASTFM_API_KEY",
  "SecretKey": "YOUR_LASTFM_SECRET_KEY",
  "Login": "YOUR_LASTFM_LOGIN",
  "Password": "YOUR_LASTFM_PASSWORD"
}

##   Usage

1. Start the **API service** (`dotnet run` in `LastFm.API`).  
   - API will be available at: `http://localhost:5156` or `https://localhost:7269`
     -Call
2. Load data into the database by calling the API endpoints in order (you can use Postman, cURL, or a browser for GET requests):
 - GET /topTags → loads top tags from Last.fm
 - GET /topArtists → loads artists for a given tag
 - GET /topAlbums → loads albums for a given artist
3. Start the **UI service** (`dotnet run` in `LastFm.UI`).  
   - UI will be available at: `http://localhost:5263`  or `https://localhost:7040`
4. Open the UI in a browser.  
5. Navigate to the **Artists** page in the sidebar.  
   - The UI calls the API → which loads artists, albums, and tags from the database.  
