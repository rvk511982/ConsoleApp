using FirebaseAuthWebAPI.Demo.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FirebaseAuthWebAPI.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirebaseDbController : ControllerBase
    {
        IFirebaseClient _firebaseClient;

        IFirebaseConfig _firebaseConfig = new FirebaseConfig
        {
            AuthSecret = "UpFlo9YLwiyWj4Tq8SjX6o96CfkzoLERGmZDDZNb", // Firebase Database Secret
            BasePath = "https://rvk-firebase-auth-default-rtdb.asia-southeast1.firebasedatabase.app", // Firebase Database URL
        };

        [HttpPost("Add")]
        public IActionResult Create(Student student)
        {
            try
            {
                _firebaseClient = new FireSharp.FirebaseClient(_firebaseConfig);
                var studentData = student;
                PushResponse response = _firebaseClient.Push("Students/", studentData);
                studentData.Id = response.Result.name;
                SetResponse setResponse = _firebaseClient.Set("Students/" + studentData.Id, studentData);

                if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //return Ok("Added Succesfully");
                    return Ok(studentData);
                }
                else
                {
                    return BadRequest("Something went wrong!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllStudent()
        {
            try
            {
                _firebaseClient = new FireSharp.FirebaseClient(_firebaseConfig);
                FirebaseResponse response = _firebaseClient.Get("Students");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                var list = new List<Student>();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        list.Add(JsonConvert.DeserializeObject<Student>(((JProperty)item).Value.ToString()));
                    }
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(string id)
        {
            try
            {
                _firebaseClient = new FireSharp.FirebaseClient(_firebaseConfig);
                FirebaseResponse response = _firebaseClient.Get("Students/" + id);
                Student data = JsonConvert.DeserializeObject<Student>(response.Body);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update")]
        public IActionResult Edit(Student student)
        {
            _firebaseClient = new FireSharp.FirebaseClient(_firebaseConfig);
            SetResponse response = _firebaseClient.Set("Students/" + student.Student_id, student);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            _firebaseClient = new FireSharp.FirebaseClient(_firebaseConfig);
            FirebaseResponse response = _firebaseClient.Delete("Students/" + id);
            return Ok(response);
        }

        [HttpPost("NewUser")]
        public IActionResult CreateUser(UserDemo userDemo)
        {
            try
            {
                _firebaseClient = new FireSharp.FirebaseClient(_firebaseConfig);
                //var studentData = student;
                PushResponse response = _firebaseClient.Push("UserDemo/", userDemo);
                userDemo.Id = response.Result.name;
                SetResponse setResponse = _firebaseClient.Set("UserDemo/" + userDemo.Id, userDemo);

                if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Ok(userDemo);
                }
                else
                {
                    return BadRequest("Something went wrong!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
