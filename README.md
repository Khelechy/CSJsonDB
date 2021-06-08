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
