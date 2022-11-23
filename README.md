# Scryber-Test

## Overview

This project is designed to illustrate how to use the [Scryber library](https://github.com/richard-scryber/scryber.core) to generate on-the-fly PDFs from an HTML template and CSS styling.

Once the files are generated, they're placed on the local filesystem, but they can optionally be stored in any reasonable document management system and a handle to the file generated so that it can be retrieved later without having to reprocess. This can be helpful in situations where regulators or legal entities require retaining a copy of the documents.

## Templates

There are 2 main templates provided:

- [SampleTemplate.html](./templates/SampleTemplate.html): This template is just a copy of the [sample template](https://github.com/richard-scryber/scryber.core#example-template) provided by the Scryber authors.

- [InsuranceCardTemplate.html](./templates/InsuranceCardTemplate.html): This template uses [InsuranceCardTemplateStyles.css](./templates/InsuranceCardTemplateStyles.css) to help with the look-and-feel of the insurance card so it renders nicely.

Additionally, any images required in the templates are stored in [templates/img](templates/img/). This makes it easier to use than trying to go out across the Interwebs to download.

## Programs

### Prerequisites

All of the applications in the repo are written in .NET 6.0 (tested with 6.0.400). You need to make sure that .NET 6.0+ is installed and you have access to the Internet to pull packages from [NuGet.org](https://www.nuget.org/).

### SampleApp

This is just a copy of the [sample program](https://github.com/richard-scryber/scryber.core#from-your-application-code) from the Scyber website. It's used just to make sure all of the dependencies are accounted for and the file system paths for templates and images work.

To run the program, navigate to `src/SampleApp/` and run `dotnet run` and it will generate `SampleDocument.pdf`.

### InsuranceCardWriter

This CLI application reads information from prompts on `stdin` and binds them to a model object that's passed to the template. The templating engine reads the model bindings and uses reflection to grab the contents of the model and render the HTML that then is used to produce the PDF. The output of the program is `InsuranceCard.pdf` and is written out in the same directory as the code.

To run the program, navigate to `src/InsuranceCardWriter/` and run `dotnet run`. There will be a series of prompts to fill in the information for the insurance card. Once complete, it will write out `InsuranceCard.pdf` in the same directory.

### InsuranceCardService

Since online LOB systems these days don't use CLI applications to process data, this is a web service that performs an identical operation to [InsuranceCardWriter](#insurancecardwriter). Rather than reading the model contents from `stdin`, it relies on the ASP.NET Core WebAPI model binding to deserialize the JSON string `POST` data into the model object.

To run the application, navigate to `src/InsuranceCardService/` and run `dotnet run`. Once the application is running, you can navigate to [https://localhost:7201/swagger](https://localhost:7201/swagger) (or [http://localhost:5194/swagger](http://localhost:5194/swagger) if your local dev cert configuration isn't working correctly) and see the Swagger UI for testing the application. Navigate to the `/write-card` `POST` operation and click the "Try it out" button. Adjust the parameters for the contents of the insurance card and click the "Execute" button. The service should respond with an `HTTP 200` and the body of the response will be the path on the file system where `InsuranceCard.pdf` was written.

Every time you run a new request through the service, `InsuranceCard.pdf` will be overwritten, so make sure you reopen the file if you want to see the changes.