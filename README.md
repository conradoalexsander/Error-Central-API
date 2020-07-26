<!--
*** Thanks for checking out this README Template. If you have a suggestion that would
*** make this better, please fork the Error-Central-API and create a pull request or simply open
*** an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
***
***
***
*** To avoid retyping too much info. Do a search and replace for the following:
*** conradoalexsander, Error-Central-API, twitter_handle, email
-->

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/conradoalexsander/Error-Central-API">
    <img src="Sample/Logo.png" alt="Logo" width="200" height="200">
  </a>

  <h1 align="center">Error Central API</h1>

  <h2 align="center">
    Save your application's error logs!
  </h2>
    <br />
 
</p>

<!-- ABOUT THE PROJECT -->
## <h2 id="about-the-project"> :mortar_board: &nbsp; &nbsp; About The Project </h2>

<p align="center">
<img
src="SwaggerImage"
raw=true
alt="Web Home Screen" 
height="512px" 
/>
</p>


"In modern projects it is increasingly common to use architectures based on services or microservices. In these complex environments, errors can arise in different layers of the application (backend, frontend, mobile, desktop) and even in different services. Thus, it is very important that developers can centralize all error records in one place, from where they can monitor and make better decisions. In this project, we will implement a system to centralize application error records." - Codenation

Project developed during the AceleraDev C#, a developer bootcamp organized by <a href="https://www.codenation.dev/">Codenation</a> focused in C# and ASP .NET Core API application.


<!-- TABLE OF CONTENTS -->
## :bookmark: &nbsp; &nbsp; Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Prerequisites](#prerequisites)
* [Installation](#installation)
* [Getting Started](#getting-started)
* [Endpoints](#endpoints)
* [Usage](#usage)
* [Schemas](#schemas)
* [Executing Tests](#executing-tests)
* [License](#license)
* [Contact](#contact)
* [Acknowledgements](#acknowledgements)

<!-- BUILT WITH -->
## <h2 id="built-with">:rocket: &nbsp; &nbsp; Built With</h2> 

### Web API
* []() C#
* []() ASP .NET Core ```3.1``` 
* []() Entity Framework Core
* []() Automapper

### Database
* []() SQL Server (localdb)
* []() Fluent API (Entity Framework, code first)
* []() Expo
* []() Typescript

### Login and Authorization
* []() ASP .NET Core EF Identity
* []() JWT Token

### Tests
* []() .Net Core dotnet test
* []() .Net Core xUnit

## <h3 id="prerequisites"> :pushpin: &nbsp; &nbsp; Prerequisites </h2>

* []() .NET / .NET Core 3.1
* []() MS SQL Server - localdb
* []() Visual Studio 2019 

Obs.: Visual Studio 2019 is a .NET framework and this project was made using it. Therefore I am putting it here as a prerequisite because the Getting Started
Section will consider the user is using it. However, it should be perfectly possible to run this project in another version of this application or even in totally different
frameworks and setups, with the properly configuration.

## <h3 id="installation"> :computer: &nbsp; &nbsp; Installation </h2>
 
1. Clone the Error-Central-API
```sh
git clone https://github.com/conradoalexsander/Error-Central-API.git
```

2. Create a database to in MSSQL Server (sugggested name ErrorCentral) to use it in this application, the tables will be automatically created in the migration proccess later (see more in the Getting Started section).

<!-- GETTING STARTED -->
## <h2 id="getting-started">:fire: &nbsp; &nbsp; Getting Started </h2>

Before following the next steps, make sure to have the prerequisites installed and configurated. 

This project was built using MS Visual Studio 2019. Therefore, the next steps considers this 

1. Double-click ErrorCentral.sln file

2. Open the Package Manager console and change de Default project to ErrorCentral.Data:

2. To update the database with the correct tables and columns through migration, open the Package Manager console and run the following command:
```sh
Update-Database
```

3. Click in the run (IIS Express) or press F5 to run the application.
```sh
expo start
```
The application will launch in the Swagger documentation home page.


<!-- ENDPOINTS -->
## <h2 id="endpoints"> :sparkles: &nbsp; &nbsp; Endpoints </h2>

After the application start, it is possible to access the Swagger live documentation about endpoints and schemas in the application index: https://localhost:44369/swagger/index.html.

<!-- USAGE -->
## <h2 id="usage"> :sparkles: &nbsp; &nbsp; Usage </h2>

By design, all actions routes in this project requires Authorization (Bearer Token). Because of that, remember to make a login through the /api/User/Login to get your Token

<p align="center" float="left">
  <img src="images/mobile-screen-sample.gif" width="200" />
  <img src="images/Top Mercados.gif" width="680" height="306" /> 

</p>

And authorize your access with it:


<p align="center" float="left">
  <img src="images/mobile-screen-sample.gif" width="200" />
  <img src="images/Top Mercados.gif" width="680" height="306" /> 
</p>

Now, you can execution all actions in the API.

<!-- SCHEMAS -->
## <h2 id="schemas"> :sparkles: &nbsp; &nbsp; Schemas </h2>
<h3> Database Schema </h3>

<p align="center">
  <img src="images/mobile-screen-sample.gif" width="200" />
</p>

<h3> Class-Service Schema </h3>

<p align="center">
  <img src="images/mobile-screen-sample.gif" width="200" />
</p>

<!-- EXECUTING TESTS -->
## <h2 id="executing-tests"> :sparkles: &nbsp; &nbsp; Executing tests </h2>

To execute the xUnit tests in this application, right click the ErrorCentral.Test project and click in run:

<p align="center" float="left">
  <img src="images/Top Mercados.gif" width="680" height="306" /> 
</p>

<!-- LICENSE -->
## <h2 id="license"> :scroll: &nbsp; &nbsp; License </h2>

Distributed under the MIT License.


<!-- CONTACT -->
## <h2 id="contact"> :telephone_receiver: &nbsp; &nbsp; Contact </h2>

Conrado Alexsander </br>
Github: [https://github.com/conradoalexsander](https://github.com/conradoalexsander) </br>
Project Link: [https://github.com/conradoalexsander/Error-Central-API](https://github.com/conradoalexsander/Error-Central-API)



<!-- ACKNOWLEDGEMENTS -->
## <h2 id="acknowledgements"> :thumbsup: &nbsp; &nbsp; Acknowledgements </h2>

* []() <a href="https://rocketseat.com.br/">Rocketseat</a>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/conradoalexsander/Error-Central-API.svg?style=flat-square
[contributors-url]: https://github.com/conradoalexsander/Error-Central-API/graphs/contributors

[forks-shield]:  https://img.shields.io/github/forks/conradoalexsander/Error-Central-API.svg?style=flat-square

[forks-url]: https://github.com/conradoalexsander/Error-Central-API/network/members

[stars-shield]: https://img.shields.io/github/stars/conradoalexsander/Error-Central-API.svg?style=flat-square
[stars-url]: https://github.com/conradoalexsander/Error-Central-API/stargazers
[issues-shield]: https://img.shields.io/github/issues/conradoalexsander/Error-Central-API.svg?style=flat-square
[issues-url]: https://github.com/conradoalexsander/Error-Central-API/issues
[license-shield]: https://img.shields.io/github/license/conradoalexsander/Error-Central-API.svg?style=flat-square
[license-url]: https://github.com/conradoalexsander/Error-Central-API/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/conrado-alexsander
[product-screenshot]: images/screenshot.png
