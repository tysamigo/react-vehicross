# Description

For my project I chose to implement a Web API for a previous React application I have worked on. This API will feed data to the frontend that is stored within JSON files, while allowing for extra functionality like searching and real-time calculations. 

## Requirements Met

### Read data from an external file, such as text, JSON, CSV, etc and use that data in your application

I am housing custom data exported from an automobile maintenance application that I use. I have both parts and maintenance data that lives in the api/Data folder in JSON format.

### Calculate and display data based on an external factor (ex: get the current date, and display how many days remaining until some event)

During serialization of the maintenance data a custom Property getter is called to calculate the number of days since the service date in the maintenance record.

### Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program

There is functionality exposed via the PartsController that allows a user to search the parts data by passing in a search term. In order to facilitate this functionality I deserialize the parts JSON data in to a C# object which allows me to perform a Where call to return only items with a part name which contains the provided search term.

### Create a class, then create at least one object of that class and populate it with data

This happens during deserialization of both the parts and maintenance data within their respective controllers.

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.<br>
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.<br>

## Run API Project

In the api/ folder you can use the dotnet CLI to run the project:

### `dotnet run`