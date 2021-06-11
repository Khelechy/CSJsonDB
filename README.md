# CSJsonDB
## Introduction

This is a simple C# package that performs basic CRUD ( Create, Read, Update, Delete ) operations on a Json file, used for sample minimalistic DBs.

## Installation

Install via .NET CLI

```bash
dotnet add package CSJsonDB --version 1.0.0
```
Install via Package Manager

```bash
Install-Package CSJsonDB --version 1.0.0
```

Add the directive `using CSJsonDB;`

Sample DB `users.db`

```json
{
    "users": [
      {
        "id": 1,
        "firstname": "kelechi",
        "lastname": "onyekwere",
        "age": 19,
        "verified": true
      },
      {
        "id": 2,
        "firstname": "john",
        "lastname": "doe",
        "age": 33,
        "verified": true
      },
      {
        "id": 3,
        "firstname": "mark",
        "lastname": "parker",
        "age": 20,
        "verified": false
      }
    ]
  }
  ```

### Load the Sample DB

```c#
var db = JsonDB.load("filetosampledb/users.db");
```

## Available Methods 🧨

>**NOTE**</br>
>Responses are returned as objects. You can use `.toJsonString()` method to return json string from a json object

### Select

```c#
db.select(string table);
```

#### Sample 
```c#
db.select("users");
```
result:
```json
[
      {
        "id": 1,
        "firstname": "kelechi",
        "lastname": "onyekwere",
        "age": 19,
        "verified": true
      },
      {
        "id": 2,
        "firstname": "john",
        "lastname": "doe",
        "age": 33,
        "verified": true
      },
      {
        "id": 3,
        "firstname": "mark",
        "lastname": "parker",
        "age": 20,
        "verified": false
      }
]
```
