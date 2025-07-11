# Job-portal-test
A test implementation of a Job Portal using ASP.NET , Entity Framework Core, MediatR, and Clean Architecture principles.

Job API Documentation

Authentication
Get API Key
• URL: /api/Authenticate/GetAPIKey
• Method: GET
• Purpose: This generates or retrieves your API key so that you can use the rest of the system securely.
• Who should use: Developers or systems needing secure access.


Department Management
Used to create, update, or view departments like HR, Marketing, etc.

Create Department
• URL: /api/Department/Create
• Method: POST
• Input: title – The name of the department.
• Purpose: Adds a new department to the system.

 Update Department
• URL: /api/Department/Update?id=1
• Method: POST
• Input:
  - id – The ID of the department to update (in the URL).
  - title – The new department name (in the request body).
• Purpose: Updates the name of an existing department.

 Get All Departments
• URL: /api/Department/GetAll
• Method: GET
• Purpose: Returns a list of all departments.


Location Management
 Used to manage locations like offices in different cities or countries.
 
 Create Location
• URL: /api/Location/Create
• Method: POST
• Input: title, city, state, country, zip – Address details
• Purpose: Adds a new location to the system.

 Update Location
• URL: /api/Location/Update?id=1
• Method: PUT
• Input:
  - id – The ID of the location to update (in the URL).
  - Updated location details (in the request body).
• Purpose: Updates details of an existing location.

 Get All Locations
• URL: /api/Location/GetAll
• Method: GET
• Purpose: Retrieves a list of all locations.


Job Management
Manage job openings posted by the company.

 Create Job
• URL: /api/Jobs/Create
• Method: POST
• Input:
  - title
  - description
  - locationId
  - departmentId
  - closingDate
• Purpose: Adds a new job posting.

 Update Job
• URL: /api/Jobs/Update?id=5
• Method: PUT
• Input:
  - id – ID of the job to update (in the URL).
  - Updated job information (in the body).
• Purpose: Updates an existing job posting.

 Get Job by ID
• URL: /api/Jobs/GetById?id=5
• Method: GET
• Purpose: Retrieves the job details for the given job ID.

List Jobs (Filter/Search)
• URL: /api/Jobs/List
• Method: POST
• Input:
  - title
  - pageNo
  - pageSize
  - locationId
  - departmentId
    
• Purpose: Returns a list of jobs, with optional filters like location, department, or job title.

Security Notes
• Most endpoints require Bearer Token Authentication.
• When calling APIs, make sure to include your API Key as a token.
• Format: Bearer your-token-goes-here


Data Examples

Location Example
{
  "id": 1,
  "title": "India Office",
  "city": "Panjim.",
  "state": Goa,
  "country": “India”,
  "Zip": 403507
}

Department Example
{
  "id": 2,
  "title": "Human Resources"
}

Job Example
{
  "id": 101,
  "title": "Software Developer",
  "description": "Develop internal applications.",
  "locationId": 1,
  "departmentId": 2,
  "closingDate": "2025-08-01T00:00:00"
}

