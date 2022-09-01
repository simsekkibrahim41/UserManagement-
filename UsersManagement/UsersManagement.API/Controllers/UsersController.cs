using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.API.Fake;
using UsersManagement.API.Models;

namespace UsersManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {

        private List<User> _users = FakeData.GetUsers(200);

        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]//listele
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]//ekle
        public User Post([FromBody] User user)
        {
            _users.Add(user);
            return user;

        }

        [HttpPut]//güncelle
        public User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editedUser.FirstName = user.FirstName;
            editedUser.Lastname = user.Lastname;
            editedUser.Adress = user.Adress;
            
            return user;

        }

        [HttpDelete("{id}")]//sil
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);

        }




    }
}
