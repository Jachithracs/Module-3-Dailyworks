using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using RestSharp;

string baseUrl = "https://reqres.in/api/";
var client = new RestClient(baseUrl);

/*
//GET
var getUserRequest = new RestRequest("users/2", Method.Get);
var getUserResponse = client.Execute(getUserRequest);
Console.WriteLine("GET Response: \n" + getUserResponse.Content);

//POST
var createUserRequest = new RestRequest("users", Method.Post);
createUserRequest.AddParameter("name", "John Doe");
createUserRequest.AddParameter("job", "Software Developer");

var createUserResponse = client.Execute(createUserRequest);
Console.WriteLine("POST Response: \n" + createUserResponse.Content);

//PUT
var updateUserRequest = new RestRequest("users/2", Method.Put);
updateUserRequest.AddParameter("name", "Updated John Doe");
updateUserRequest.AddParameter("job", "Senior Software Developer");

var updateUserResponse = client.Execute(updateUserRequest);
Console.WriteLine("PUT Response: \n" + updateUserResponse.Content);

//DELETE
var deleteUserRequest = new RestRequest("users/2", Method.Delete);
var deleteUserResponse = client.Execute(deleteUserRequest);
Console.WriteLine("DELETE Response: \n" + deleteUserResponse.Content);
*/



//*******************************************************************
//Adding Query Parameter,Header & JsonBody
/*
//GET
var getUserRequest = new RestRequest("users", Method.Get);
getUserRequest.AddQueryParameter("page", "2"); //Adding Query Parameter

var getUserResponse = client.Execute(getUserRequest);
Console.WriteLine("GET Response: \n" + getUserResponse.Content);

//POST
var createUserRequest = new RestRequest("users", Method.Post);
createUserRequest.AddHeader("Content-Type", "application/json");
createUserRequest.AddJsonBody(new { name = "John Doe", job = "Sofware Developer"});

var createUserResponse = client.Execute(createUserRequest);
Console.WriteLine("POST Response: \n" + createUserResponse.Content);

//PUT
var updateUserRequest = new RestRequest("users/2", Method.Put);
updateUserRequest.AddHeader("Content-Type", "application/json");
updateUserRequest.AddJsonBody(new { name = "Updated John Doe", job = "Senior Sofware Developer" });

var updateUserResponse = client.Execute(updateUserRequest);
Console.WriteLine("PUT Response: \n" + updateUserResponse.Content);

//DELETE
var deleteUserRequest = new RestRequest("users/2", Method.Delete);
var deleteUserResponse = client.Execute(deleteUserRequest);
Console.WriteLine("DELETE Response: \n" + deleteUserResponse.Content);
*/
//**********************************************************************



//Parse & Handle API responses
//GET
/*var getUserRequest = new RestRequest("users/5", Method.Get);

var getUserResponse = client.Execute(getUserRequest);
if(getUserResponse.StatusCode == System.Net.HttpStatusCode.OK)
{
    //Parse Json response content
    JObject? userJson = JObject.Parse(getUserResponse.Content);

    string? userFirstName = userJson["data"]["first_name"].ToString();
    string? userLastName = userJson["data"]["last_name"].ToString();

    Console.WriteLine($"User Name: {userFirstName} {userLastName}");
}
else
{
    Console.WriteLine($"Error: {getUserResponse.ErrorMessage}");
}
*/

//*****************************************************************
//Modularized code

GetAllUsers(client);
CreateUser(client);
UpdateUser(client);
DeleteUser(client);
GetSingleUser(client);

//GET All Users
static void GetAllUsers(RestClient client)
{
    var getUserRequest = new RestRequest("users", Method.Get);
    getUserRequest.AddQueryParameter("page", "2"); //Adding Query Parameter

    var getUserResponse = client.Execute(getUserRequest);
    Console.WriteLine("GET Response: \n" + getUserResponse.Content);
}

//POST
static void CreateUser(RestClient client)
{
    var createUserRequest = new RestRequest("users", Method.Post);
    createUserRequest.AddHeader("Content-Type", "application/json");
    createUserRequest.AddJsonBody(new { name = "John Doe", job = "Sofware Developer" });

    var createUserResponse = client.Execute(createUserRequest);
    Console.WriteLine("POST Response: \n" + createUserResponse.Content);
}

//PUT
static void UpdateUser(RestClient client)
{
    var updateUserRequest = new RestRequest("users/2", Method.Put);
    updateUserRequest.AddHeader("Content-Type", "application/json");
    updateUserRequest.AddJsonBody(new { name = "Updated John Doe", job = "Senior Sofware Developer" });

    var updateUserResponse = client.Execute(updateUserRequest);
    Console.WriteLine("PUT Response: \n" + updateUserResponse.Content);
}

//DELETE
static void DeleteUser(RestClient client)
{
    var deleteUserRequest = new RestRequest("users/2", Method.Delete);
    var deleteUserResponse = client.Execute(deleteUserRequest);
    Console.WriteLine("DELETE Response: \n" + deleteUserResponse.Content);
}

//GET Single User
static void GetSingleUser(RestClient client)
{
    var getUserRequest = new RestRequest("users/5", Method.Get);

    var getUserResponse = client.Execute(getUserRequest);
    if (getUserResponse.StatusCode == System.Net.HttpStatusCode.OK)
    {
        //Parse Json response content
        JObject? userJson = JObject.Parse(getUserResponse.Content);

        string? userFirstName = userJson["data"]["first_name"].ToString();
        string? userLastName = userJson["data"]["last_name"].ToString();

        Console.WriteLine($"User Name: {userFirstName} {userLastName}");
    }
    else
    {
        Console.WriteLine($"Error: {getUserResponse.ErrorMessage}");
    }
}
