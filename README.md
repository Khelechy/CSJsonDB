# CSJsonDB
## Introduction

This is a simple C# package that performs basic CRUD ( Create, Read, Update, Delete ) operations on a Json file, used for sample minimalistic DBs.

## Installation

Install via .NET CLI

```bash
dotnet add package CSJsonDB --version 1.1.0
```
Install via Package Manager

```bash
Install-Package CSJsonDB --version 1.1.0
```

### Add the namespace directive `using CSJsonDB;`  `IMPORTANT`

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
var db = JsonDB.Load("filepathtosampledb/users.db");
```

## Available Methods 🧨

>**NOTE**</br>
>Responses are returned as objects. You can use `.ToJsonString()` method to return json string from a json object

### Load

```c#
var db = JsonDB.Load(string filePath);
```


### ToJsonString

```c#
db.Select("users").Where("id", 2).ToJsonString();
```
result: `string` Returns the json string of the object.

### Select

```c#
db.Select(string table);
```

#### Sample 
```c#
db.Select("users");
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
db.Select(string table).Where(string key, dynamic value);
```
#### Sample
```c#
db.Select("users").Where("id", 2);
```
result: `List<dynamic>`
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
db.Add(string table, object newData);
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

db.Add("users", newUser);
```
result: void

### Delete
```c#
db.Delete(string table, string key, dynamic value);
```
#### Sample
```c#
db.Delete("users", "id", 1);
```
result: void

### Update
```c#
db.Update(string table, string key, dynamic value, object newData);
```
#### Sample
```c#
var updateUser = new {
    verified = true
};

db.Update("users", "id", 3, updateUser);
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
