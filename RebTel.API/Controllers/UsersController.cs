using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebTel.API.DTOs;
using SubscriptionService;

namespace RebTel.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMapper _mapper;
        public UsersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            SubscriptionServiceClient client=new SubscriptionServiceClient();
            var result=await client.GetUsersAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.GetUserAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserDTO user)
        {
            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.CreateUserAsync(_mapper.Map<User>(user));
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}/{subscriptionId}")]
        public async Task<ActionResult> AddSubscription(int id, string subscriptionId)
        {

            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.AddSubscriptionToUserAsync(new UserSubscription()
            {
                UserId = id,
                SubscriptionId = subscriptionId
            });
            return Ok(result);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.DeleteUserAsync(id);
            return Ok(result);
        }
    }
}