# ApiAi
[![NuGet version](https://badge.fury.io/nu/ApiAi.svg)](https://www.nuget.org/packages/ApiAi/)

Api.ai .NET library with fully documented public methods. More information about natural language processing API on the API.AI website http://api.ai/

# How to use
## Instalation

Library can be installed with [Nuget](https://www.nuget.org/packages/ApiAi/)
```
PM> Install-Package ApiAi
```

Or can be downloaded as DLL library or sources from the [Releases](https://github.com/NickRimmer/ApiAi/releases) page.

## Usage
Assumed you already have API.AI account and have at least one agent configured. If no, please see [documentation](http://api.ai/docs/index.html) on the API.AI website.

### Queries
The query endpoint is used to process natural language in the form of text. More inforamtion [on the website](https://api.ai/docs/reference/agent/query).

- __ApiAi.QueryService.SendRequest__ method is simple method to make queries


### Entities
The entities endpoint is used to create, retrieve, update, and delete developer-defined entity objects. More information [on the website](https://api.ai/docs/reference/agent/entities).

- __ApiAi.EntityService.GetEntities__ method retrieves a list of all entities for the agent
- __ApiAi.EntityService.CreateEntity__ method for create a new entity
- __ApiAi.EntityService.UpdateEntity__ method proposed to update the specified entity
- __ApiAi.EntityService.DeleteEntity__ method for delete the specified entity.

- __ApiAi.EntityService.GetEntries__ method retrieves the specified entity with its entries
- __ApiAi.EntityService.AddEntries__ method for adding entries to the specified entity
- __ApiAi.EntityService.UpdateEntries__ method for updates specified entity entries
- __ApiAi.EntityService.DeleteEntries__ method delete entity entries

All examples you can find in [ApiAi.Tests/MainTests.cs](https://github.com/NickRimmer/ApiAi/blob/master/ApiAi.Tests/MainTests.cs) file.

## Open Source Project Credits

* JSON parsing implemented using [Json.NET](http://www.newtonsoft.com/json).
