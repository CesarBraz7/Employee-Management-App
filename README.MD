
# Employee Management App

An app that facilitates the registration and manipulation of employees.

## Stacks

**Front-end:** Typescript, Angular, Angular Material, Bootstrap

**Back-end:** C#, .NET 7, Entity Framework Core

**Database:** SQL Server


## API Documentation


```http
  GET https://localhost:7012/api/Employee
```

| Parameter   | Type       | Description                           |
| :---------- | :--------- | :---------------------------------- |
| `No parameters` | `string` | `return all employees` |



```http
  GET https://localhost:7012/api/Employee/?id=${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | `return an employee` |

```http
  POST https://localhost:7012/api/Employee/
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `employee`      | `any` | `create an employee` |

```http
  PUT https://localhost:7012/api/Employee/?id=${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `employee`      | `any` | `edit an employee` |

```http
  DELETE https://localhost:7012/api/Employee/?id=${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | `delete an employee` |

```http
  PUT https://localhost:7012/api/Employee/inactiveEmployee?id=${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | `inactivate an employee` |

```http
  PUT https://localhost:7012/api/Employee/activeEmployee?id=${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | `activate an employee` |




## Demo

[Here](https://youtu.be/MfcF3Y4VfF4) is a demo of the project.

## Development server

Run `ng serve` in the front-end project for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.