# Dialog
Valia Dempsey, Susannah Lowe, Joseph Tomlinson, Rakhee Gandhi

![preview](https://raw.githubusercontent.com/bizzclaw/Epicodus-Dialog/master/preview.png)

Dialog is an open ended web forum designed to enable communities to share ideas in a clean and efficient way.

Website is designed used ASP .NET framework using C#, HTML5 and CSS.

Being a collaborative project, Dialog was created by a group of developers with a diverse skill set in design and backend, as a result, accommodating the experience of and workflow of these different development approaches was also part of the project.

## Build Instructions

### Requirements for building
__.NET 1.1 SDK__ [Windows](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe) | [Mac OSX](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-osx-x64.1.1.4.pkg)

__.NET Runtime__ [Windows](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe) | [Max OSX](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-osx-x64.1.1.4.pkg)

__MySQL Server__ [NAMP](https://www.mamp.info/en/) | [MySQL Workbench](https://www.mysql.com/products/workbench/)

__GIT CLI__ [Git-SCM](https://git-scm.com/downloads)


### Instructions
Clone with git or download as a zip file and extract to a directory on your machine.

### Sql Setup
In order to load the proper information into a database, some tables must be created.
You can create these tables by importing the dialog.sql file using your database manager.

## Build Instructions
1. Clone with git to your local machine.
2. cd into `epicodus-dialog/dialog` with your terminal/command prompt.
3. run `dotnet restore`, this will install needed packaged for the app.
4. run `dotnet run`, this will run the app from the IP of the machine with the port: 5000.

## Client Stories
### Pages and Views
* A user needs to be able too view all of the topics on the forum on the home page
* A User needs to be able to see a list of the latest topics on the home page
* A User needs to be able to select a topic and see a new page containing all of the threads contained within that topic.
* On the topic page, a user should be able create a new thread, which will prompt them to create that thread's first post.
* Each thread will show the original post on the top, followed by all of the replies to that post.
* A user should be able to sort all of the posts by ascending or descending date.
* A user will be able to reply to a thread by writing a message into a box at the bottom of the page, thy can also optionally supply a subject for that reply,
a author name to use as opposed to "Anonymous" and an "Avatar" image representing their post.
* A thread will only show 20 posts at once, and a thread page will show a "next page" button which will show the next 20 posts if there are more than 20.
### Searching
* A User should be able to run a "search" on the home page. The search will return any matches on thread names, post content and post author.
* Each Topic page will also have a search box, a search box used within that topic will only return what is found in relation to that topic.
* Each thread will also have a search box, this will only search within that thread.
