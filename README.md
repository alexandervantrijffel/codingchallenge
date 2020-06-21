# codingchallenge

This is a coding challenge for demonstrating the ability to work with a modern stack, dependency injection and possibly new libraries.

This repository contains a .NET core solution that offers an GraphQL endpoint for datarefs. The endpoint is based on [Hot Chocolate](https://hotchocolate.io). It supports a subscription, mutation and a query for listing datarefs.

Example GQL for retrieving the list of datarefs:

```
query datareferences{
  dataReferences{
    list(first:500){
			nodes{
        name,
        description
        canRead,
        canWrite
      }
    }
  }
}
```

Example GQL for retrieving the value of a dataref:
```
query datareferences{
  dataReferences{
    read(name:"aircraft.engine1.EGT")
  }
}
```

To execute the GraphQL queries on the service, use [GraphQL Playground](https://github.com/prisma-labs/graphql-playground) or [Banana Cake Pop](https://hotchocolate.io/docs/banana-cakepop#docsNav).

## Your task
- Add the implementation for the Read graphql query to the GqlService project. Use IDataRefRetriever which is implemented by DummyDataRefProvider to retrieve the value.
- Add [Serilog](https://serilog.net) to the project and make sure that calls to the Read query are logged including argument and response
- Submit your changes as a Pull Request for this repository
