# CSJsonDB
## Introduction

This is a simple C# package that performs basic CRUD ( Create, Read, Update, Delete ) operations on a Json file, used for sample minimalistic DBs.

## Installation

Install via .NET CLI

```bash
dotnet add package CSJsonDB --version 1.0.1
```
Install via Package Manager

```bash
Install-Package CSJsonDB --version 1.0.1
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
var db = JsonDB.load("filepathtosampledb/users.db");
```

## Available Methods 🧨

>**NOTE**</br>
>Responses are returned as objects. You can use `.toJsonString()` method to return json string from a json object

### Load

```c#
var db = JsonDB.load(string filePath);
```


### ToJsonString

```c#
db.select("users").where("id", 2).toJsonString();
```
result: Returns the json string of the object.

### Select

```c#
db.select(string table);
```

#### Sample 
```c#
db.select("users");
```
result: `object`
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
result: `object`
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
result: `object`
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


## Contribution

If you find an issue with this package or you have any suggestion please help out. I am not perfect.
