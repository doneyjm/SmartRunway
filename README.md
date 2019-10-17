# SmartRunwayAPI
**************

Tech Stack - .NET CORE APIs

Middlewares used
================

EF CORE - In memory database is used
Swagger - NSwag Nuget package
JsonException Filter - For catching all exceptions in this app and to show a nice message back to the client
Dependency Injection - Services, repository, option for default settings are injected through constructor
AutoMapper - used for mapping between Models and Entities
Used configuration to pick 'BufferTime' default values from appsettings.json
Seed data is used for loading in-memory database.

Flow:
====

API end points were given for scheduling take offs and landings

Client can send the flight information through request body and buffer time for the operation if any through query string

Weather service is configured for getting the delays due to the extreme weather conditions. If the delay is more than 2 hrs, the operation (take off or landing) will be cancelled.

Schedular utilises repository underneath for data access.

Scheduler service will look for the updated landing/take off detail for the given flight and look for next available runway by looking at the next available time of the runways.

Then schedular service will update the landing info and update the next available time for the runway selected by adding the time required for this particular operation.

Once all calculations are over, data will be saved to the db

Then the details of landing/take off will be given back to the client app.
