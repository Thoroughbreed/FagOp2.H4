![Build succeeded][build-shield]
![Test passing][test-shield]
[![Issues][issues-shield]][issues-url]
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![License][license-shield]][license-url]
# FagOp2.H4
WebAPI and security
<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#requirements">Requirements</a></li>
    <li>
      <a href="#api-endpoints">API Endpoints</a></li>
    <li>
      <a href="#nuget-packs">NuGet packs</a></li>
    <li>
      <a href="#completed-tests">Completed tests</a></li>
    <li>
      <a href="changelog">Changelog</a></li>
    <li>
      <a href="#license">License</a></li>
    <li>
      <a href="#contact">Contact</a></li>
  </ol>
</details>

### Requirements
A to-do list with the following:
* Description
* Creation timestamp
* Completed flag
* Priority (low, normal, high)
* Specified endpoints (see below)
* .NET-6 *Minimal WebAPI Pattern*
* Support for OpenAPI (Swagger)
* ReadMe (this file)
<p align="right">(<a href="#top">back to top</a>)</p>

### API Endpoints
| Endpoint                   | Description                   | Request body | Response body        | Permission level |
|----------------------------|-------------------------------|--------------|----------------------|------------------|
| GET /                      | Browser test, "Hello World"   | None         | Hello World!         | None             |
| GET /todoitems             | Get non-completed to-do items | None         | Array of to-do items | User:read        |
| GET /todoitems/complete    | Get all to-do items           | None         | Array of to-do items | User:read        |
| GET /todoitems/{id}        | Get an item by ID             | None         | To-do item           | User:read        |
| POST /todoitems            | Add a new item                | To-do item   | To-do item           | User:write       |
| PUT /todoitems/{id}        | Update an item by ID          | To-do item   | None                 | User:write       |
| DELETE /todoitems/{id}     | Delete an item by ID          | None         | None                 | User:admin       |
<p align="right">(<a href="#top">back to top</a>)</p>

### NuGet packs
| Name                      | Version | Where  |
|---------------------------|---------|--------|
| Authentication JwtBearer  | 6.0.2   | WebAPI |
| Entity Framework Core     | 6.0.2   | WebAPI |
| Entity Framework InMemory | 6.0.2   | WebAPI |
| Swashbuckle               | 6.2.3   | WebAPI |
<p align="right">(<a href="#top">back to top</a>)</p>

### Completed tests
| Description               | Status    |
|---------------------------|-----------|
| Create new item           | Succeeded |
| Edit existing item        | Succeeded |
| Delete item by ID         | Succeeded |
| Show all items            | Succeeded |
| Show non-completed items  | Succeeded |
| Find item by ID           | Succeeded |
| Check authentication      | Succeeded |
| Check permissions         | Succeeded |
<p align="right">(<a href="#top">back to top</a>)</p>

### Changelog
| Version | Change |
|---------|--------|
| 0.1.0   | First release, smoke test |
| 0.1.1   | Changed to use DTO instead of direct |
| 0.2.0   | Added authentication via Auth0 |
| 0.2.1   | Added permissions via Auth0 |
<p align="right">(<a href="#top">back to top</a>)</p>

### License
* Software: GPLv3
<p align="right">(<a href="#top">back to top</a>)</p>


### Contact
Jan Andreasen - jan@tved.it

[![Twitter][twitter-shield]][twitter-url]

Project Link: [https://github.com/jaa2019/FagOp2.H4](https://github.com/jaa2019/FagOp2.H4)
<p align="right">(<a href="#top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
[build-shield]: https://img.shields.io/badge/Build-succeeded-brightgreen.svg
[test-shield]: https://img.shields.io/badge/Tests-passing-brightgreen.svg
[contributors-shield]: https://img.shields.io/github/contributors/jaa2019/FagOp2.H4.svg?style=badge
[contributors-url]: https://github.com/jaa2019/FagOp2.H4/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/jaa2019/FagOp2.H4.svg?style=badge
[forks-url]: https://github.com/jaa2019/FagOp2.H4/network/members
[issues-shield]: https://img.shields.io/github/issues/jaa2019/FagOp2.H4.svg?style=badge
[issues-url]: https://github.com/jaa2019/FagOp2.H4/issues
[license-shield]: https://img.shields.io/github/license/jaa2019/FagOp2.H4.svg?style=badge
[license-url]: https://github.com/jaa2019/FagOp2.H4/blob/master/LICENSE
[twitter-shield]: https://img.shields.io/twitter/follow/andreasen_jan?style=social
[twitter-url]: https://twitter.com/andreasen_jan
