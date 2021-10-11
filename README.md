# Book History app

Technologies:
  - Angular 8 for front-end browser access
  - ASP.NET 5 for back-end 
  - PostgreSQL for database
  - PgAdmin4 DB management tool
  - Docker for containerization
  - Docker compose for container orchestration
  
# The idea of the app
Create or edit a book and then get list of all books as well as detailed pages for each book with history of all edits and changes.

# How to run BookHistory app
1. Make sure you have installed on your machine: 
    - Docker for Windows(if you are on Window OS)
    - Gitbash

2. Open Gitbash in the directory where you want to have the project and put the following command in the console to download the project:
    - git clone https://github.com/StoychoMihaylov/book-history.git

3. Go inside the project main directory and open Powershell or CMD. Make sure Docker for Windows is started and running and execute the following commands:
    - docker-compose build
    - docker-compose up
    
4. Or open Visual Studio, set "docker-compose" project as a "startup project" and run it from VS.
    
5. The browser will throw an exception that it can't find the page, wait for a while until Angular finish installing the packages and refresh the page.
