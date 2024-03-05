
# BookShelf

## Overview

This ASP.NET Core 7 application serves as a GraphQL API for querying books along with their authors and editions. The API is built on top of the GraphQL framework using HotChocolate, providing a flexible and efficient way to retrieve information about books in your collection.

## Features

- GraphQL API for querying books,
- Integration with a database to store and retrieve book information
- Docker Compose setup for easily deploying the API along with the required database

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Docker](https://www.docker.com/get-started)

### Docker Compose

Before running the app, execute the following command

1. Navigate to the project directory.

2. Run the following command to start the application along with the database:

    ```bash
    docker-compose up -d
    ```

This will spin up the API container and the associated database container.

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/hernancote/books-shelf.git
    ```

2. Navigate to the project directory:

    ```bash
    cd books-shelf
    ```

3. Build the application:

    ```bash
    dotnet build
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

## API Usage

### GraphQL Endpoint

The GraphQL endpoint is available at:

```
http://localhost:5000/graphql
```

### Examples

#### Query All Books

```graphql
query {
  books {
    title
    author {
      name
    }
    editions {
      format
    }
  }
}
```

#### Query Book by title

```graphql
{
  bookByTitle(title: "New Test book 2") {
    id
    title
    author {
      id
      firstName
      lastName
    }
  }
}
```

### Filter Book by edition
```graphql
{
    books(where: {edition: { format: { eq: "Graphic" } }}) {
        id
        title
        author {
          id
          firstName
          lastName
        }
        edition {
          format
        }
    }
}
```