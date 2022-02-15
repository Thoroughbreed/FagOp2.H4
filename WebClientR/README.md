![Build succeeded][build-shield]
![Test passing][test-shield]
[![Issues][issues-shield]][issues-url]
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![License][license-shield]][license-url]
# FagOp2.H4
Razor frontend and security
<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href=#what-is-this">What is this?</a></li>
    <li>
      <a href="#requirements">Requirements</a></li>
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

### What is this
This is the web frontend for the API created in this project. It is a fairly straightforward Razor web server contacting the API via HTTP, giving the user a nice overview and CRUD capabilities to the to-do list. 
The site is made purely with education in mind, and should not be used as a proper to-do list without tweaks and hotfixes.

### Requirements
A web-frontend with anonymous access
* TodoItems page showing all non-completed items
* TodoItem detail page
* CRUD (with deletion confirmation)
* A service via DI
* Application constants in seperate class
* ReadMe (this file)
<p align="right">(<a href="#top">back to top</a>)</p>

### NuGet packs
| Name                      | Version | Where  |
|---------------------------|---------|--------|
<p align="right">(<a href="#top">back to top</a>)</p>

### Completed tests
| Description               | Status    |
|---------------------------|-----------|
| Create new item           | Succeeded |
| Edit existing item        | Succeeded |
| Delete item               | Succeeded |
| Show all items            | Not run   |
| Show non-completed items  | Succeeded |
| Find item by ID           | Succeeded |
<p align="right">(<a href="#top">back to top</a>)</p>

### Changelog
| Version | Change |
|---------|--------|
| 0.1.0   | First release, smoke test |
| 0.2.0   | Changed to use DI service |
| 0.2.1   | Added data validation to add/edit |
| 0.2.2   | Removed data validation because of issues with the modal behaviour |
<p align="right">(<a href="#top">back to top</a>)</p>

### License
* Software: GPLv3
<p align="right">(<a href="#top">back to top</a>)</p>


### Contact
Jan Andreasen - jan@tved.it

[![Twitter][twitter-shield]][twitter-url]

Project Link: [https://github.com/jaa2019/FagOp2.H4/tree/Razor/WebClientR](https://github.com/jaa2019/FagOp2.H4/tree/Razor/WebClientR)
<p align="right">(<a href="#top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
[build-shield]: https://img.shields.io/badge/Build-succeeded-brightgreen.svg
[test-shield]: https://img.shields.io/badge/Tests-5%20passing%2C%201%20skipped-yellow.svg
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

