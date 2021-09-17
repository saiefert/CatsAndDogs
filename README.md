# 🐶🐱 Simple Web API Pets
### 👨🏻‍💻 About
This project was done only at the testing level, it is a very Simple Web API project, with basic CRUD, using the Entity Framework Core 5. 
To do the tests, the SQL is in the following repository: 
- https://github.com/saiefert/SimpleSQLCatsAndDogs/blob/7b7abd0de872819ab839a55fde35f78d4bd1054b/Data.sql

### 🚀 Running the project
- Insert the necessary environment variables named DB_CONN
- Insert SQL Server Connection string on DB_CONN using this following example: 
- ``` Server=yourServer;Database=DataPets;User Id=sa;Password=yourPassword ```
  - Configure database using the SQL File or use Entity Migrations
  
 ### 🚊 Routes
 - ## Pets/
  - **GET** /pets
  - **GET (FILTER)** /pets/{name}  
  - **PUT (ADD)** /pets/dog/{objectDog}
  - **PUT (ADD)** /pets/cat/{objectCat}
  - **POST (UPDATE)** /pets/cat/{objectCat}
  - **POST (UPDATE)** /pets/dogs/{objectDog}
  - **DELETE** /pets/cat/{petId}
  - **DELETE** /pets/dog/{petId}
  
 - ## Owner/
  - **GET** /owner/
  - **GET (FILTER)** /owner/{name}
