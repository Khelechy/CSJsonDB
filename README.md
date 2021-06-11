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

### Load the Sample DB `IMPORTANT`

```c#
var db = JsonDB.load("filetosampledb/users.db");
```

## Available Methods 🧨

>**NOTE**</br>
>Responses are returned as objects. You can use `.toJsonString()` method to return json string from a json object

### ToJsonString

```c#
db.select("users").where("id", 2).toJsonString();
```
reult: Returns the json string of the object.

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

### Where
```c#
db.select(string table).where(string key, dynamic value);
```
#### Sample
```c#
db.select("users").where("id", 2);
```
result:
```json
[
      {
        "id": 2,
        "firstname": "john",
        "lastname": "doe",
        "age": 33,
        "verified": true
      },
]
```

### Add
```c#
db.add(string table, object newData);
```
#### Sample
```c#
var newUser = new {
    id = 3,
    firstname = matt,
    lastname = doe,
    age = 23,
    verified = false
};

db.add("users", newUser);
```
result: void

### Delete
```c#
db.delete(string table, string key, dynamic value);
```
#### Sample
```c#
db.delete("users", "id", 1);
```
result: void

### Update
```c#
db.update(string table, string table, string key, dynamic value, object newData);
```
#### Sample
```c#
var updateUser = new {
    verified = true
};

db.update("users", "id", 3, updateUser);
```
result:
```json
[
      {
        "id": 3,
        "firstname": "mark",
        "lastname": "parker",
        "age": 20,
        "verified": true
      },
]
```
