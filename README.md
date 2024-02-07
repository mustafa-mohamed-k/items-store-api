# items-store-api
A .NET API for the items store UI implemented in items-store-ui repository

## Local development.
The API is built with .NET.<br/>
To run the program, execute the following command in the root folder:<br/>
`dotnet run  --project ItemStoreAPI --urls=http://localhost:5001/`<br/>
The command will build the API and expose it on port 5001.
<br/>
<br/>
You may change the port number in the --urls parameter above to a port
number you prefer.<br/>
The Swagger docs will be at `http://localhost:[PORT]/swagger/index.html`
where [PORT] is the port number you used in the command above.<br/>
<br/>
To get the items, for example, make a GET request to 
`http://localhost:[PORT]/Items`. The endpoint returns a (possibly empty)
list of items.
