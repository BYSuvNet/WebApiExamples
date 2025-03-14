# Web API Examples in ASP.Net

Different ways to organize API endpoints in ASP.Net Core Web API projects.
All projects use a very simple ItemRepository to demonstrate how Dependency Injection works in the different cases.

## 1. Basic Minimal API
The simplest way to create a Web API in ASP.Net Core using the minimal API approach. This is a single file with all the endpoints defined in one place. Good if you have a small number of endpoints and want to keep things simple. This is the most basic example of a minimal API, with no additional libraries or frameworks used.

## 2. Minimal API with endpoints separeted into classes
This example shows how to organize your minimal API endpoints into separate classes. This is a good way to keep your code organized and maintainable as your API grows. Each class represents one endpoint and encloses the response and request objects as nested classes to the the class names short. The endpoint mapping is done by calling the extensionmethods defined in AddEndpointsExtensions.cs and MapEndpointsExtension.cs. All endpoint classes implementing the IEndpoint interface will then be mapped automatically.

## 3. Classic ASP.Net API Controllers
The standard built-in way to create APIs in ASP.Net Core using controllers and action methods. Routing is set up by using attributes on the controller and action methods. This is a more traditional approach and is useful if you are already familiar with ASP.Net MVC. This example uses the standard ASP.Net Core libraries and does not use any additional libraries or frameworks. The endpoints are organized into controllers, each representing a resource in the API. Each controller has action methods that handle the HTTP requests for that resource.

## 4. FastEndpoints (COMING SOON)
Using the popular FastEndpoints library to create a minimal API with a focus on performance and simplicity.