## Prerequisites
* [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) must be installed on the computer for this code to be compiled and run.

## How to test this code?

* Clone this repo to local machine.
* Open command prompt or terminal.
* Navigate to `src` folder.
* Run command 
  ```
    dotnet run --project FormulaTree.Api/FormulaTree.Api.csproj.
  ```
* Open browser and browse http://localhost:5081/swagger/index.html.
* Expand **POST /api/expr/tree**.
* Click on *Try it out*.
* Replace `string` with the math expression in Reqeust body.
  ```
    {
        "expression": "5 + 3"
    }
  ```
* Click *Execute* button.
* Observe the outcome in the Response body.
* Example 
*   Request
  ```
  {
    "expression": "(6 * 4) + (150 / 3)"
  }
  ```
*   Response
  ```
  {
    "Answer": 74,
    "Tree": {
      "+": [
        {
          "*": [
            "6",
            "4"
          ]
        },
        {
          "/": [
            "150",
            "3"
          ]
        }
      ]
    }
  }
  ```
