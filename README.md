# T4 WebApi Proxy Client Sample

Sample for using the T4 Templates (Text Template Transformation Toolkit)


## About

This is a simple class library project that demonstrates 
using a T4 template to generate C#t client side HttpClient proxy from Web Api Controllers in another project. 

This T4 template solution was made for a project some time ago so there may be better approaches to this problem now. 
Nonetheless, it serves as a demonstration of how T4 templates save you from typing things twice.

## How it works

A T4 template looks for all ApiController types in a project specified at the top of the template.

The web api project 'SampleWebSite' inlcludes controller './Controllers/ThingController' which 
gets, posts, deletes Things.

A shared library 'SharedEntities' has entities.

./SharedEntities/Thing

./SharedEntities/Whatsit

A client libarary has the T4 template and generated proxy clients.

The T4 template reads the definition of these controllers and generates C# proxy clients for each controller.

./SampleClient/WebProxies/clients.tt

Generates...

./SampleClient/WebProxies/clients.cs

## Using It

Build the project. This creates the assemblies that will be examined by the T4 Template.
Right click '/SampleClient/WebProxies/clients.tt' and select 'Run Custom Tool'.

This will generate the file './SampleClient/WebProxies/clients.cs' with the strongly typed proxies.

Set startup projects in Visual studio to:
- SampleClient
- SampleWebSite

F5 and look at the running console app.


## Changing It

Install a T4 template editor extension to Visual Studio to give 
you syntax highlighting and more. Some possible VS2017 extensions...

- Tangible T4 Editor (Free Edition available)
- T4 Toolbox

The template will run whenever you save it with a change.

## Extending It

The template currently checks for a RoutePrefix attribute. This check is not needed. Instead a custom attribute
could be used to limit which controllers are included.
