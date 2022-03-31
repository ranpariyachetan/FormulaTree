# How to test this code?

* Clode this repo to local machine.
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