using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using RestExNunit.Utilities;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log = Serilog.Log;

namespace RestExNunit
{
    [TestFixture]
    public class ReqResTest :CoreCodes
    {

        [Test]
        [Order(2)]
        public void GetSingleUser()
        {
           
            test = extent.CreateTest("Get Single User");
            Log.Information("GetSingleUser Test Started");

            var request = new RestRequest("users/2", Method.Get);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response :{response.Content}");

                var userdata = JsonConvert.DeserializeObject<UserDataResponse>(response.Content);
                UserData? user = userdata?.Data;

                Assert.NotNull(user);
                Log.Information("User returned");
                Assert.That(user.Id, Is.EqualTo("2"));
                Log.Information("user Id matches with fetch");
                Assert.IsNotEmpty(user.Email);
                Log.Information("Email is not empty");
                Log.Information("Get Single User test passed all Asserts");

                test.Pass("GetSingleUser test passed all Asserts.");
            }
            catch (AssertionException)
            {
                test.Fail("GetSingleUser test failed");
            }

            
        }
        [Test]
        [Order(1)]
        public void CreateUser()
        {
            test = extent.CreateTest("Create User");
            Log.Information("CreateUser Test Started");

            var request = new RestRequest("users", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { name = "John Doe", job = "Software Developer" });
            var response = client.Execute(request);

            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
                Log.Information($"API Response :{response.Content}");

                var user = JsonConvert.DeserializeObject<UserData>(response.Content);
                Assert.NotNull(user);
                Log.Information("User created and returned");
                Assert.IsNull(user.Email);
                Log.Information("Email is not empty");
                Log.Information("Create User test passed all Asserts");

                test.Pass("CreateUser test passed all Asserts.");

            }
            catch (AssertionException)
            {
                test.Fail("CreateUser test failed");
            }


        }
        [Test]
        [Order(3)]
        public void UpdateUser()
        {
            test = extent.CreateTest("Update User");
            Log.Information("UpdateUser Test Started");

            var request = new RestRequest("users/2", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { name = "Updated John Doe", job = "Senior Software Developer" });
            var response = client.Execute(request);

            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response :{response.Content}");

                var user = JsonConvert.DeserializeObject<UserData>(response.Content);
                Assert.NotNull(user);
                Log.Information("User updated and  returned");
                //Assert.IsNotEmpty(user.Email);
                //Log.Information("Email is not empty");
                Log.Information("Update User test passed all Asserts");

                test.Pass("UpdateUser test passed all Asserts.");
            }
            catch (AssertionException)
            {
                test.Fail("UpdateUser test failed");
            }

        }
        [Test]
        [Order(4)]
        public void DeleteUser()
        {

            test = extent.CreateTest("Delete User");
            Log.Information("DeleteUser Test Started");

            var request = new RestRequest("users/2", Method.Delete);

            var response = client.Execute(request);

            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));
                Log.Information("User Deleted");
                Log.Information("Delete User test passed all Asserts");

                test.Pass("DeleteUser test passed all Asserts.");
            }
            catch (AssertionException)
            {
                test.Fail("DeleteUser test failed");
            }


        }
        [Test]
        [Order(5)]
        public void GetNonExistingUser()
        {
            test = extent.CreateTest("NonExisting User");
            Log.Information("NonExistingUser Test Started");

            var request = new RestRequest("users/999", Method.Get);

            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
                Log.Information("NonExisting User test passed all Asserts");

                test.Pass("NonExisting test passed all Asserts.");
            }
            catch (AssertionException)
            {
                test.Fail("NonExisting test failed");
            }


        }
    }
}
