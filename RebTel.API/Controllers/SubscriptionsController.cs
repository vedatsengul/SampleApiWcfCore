using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebTel.API.DTOs;
using SubscriptionService;

namespace RebTel.API.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private IMapper _mapper;
        public SubscriptionsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetSubscriptions()
        {

            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.GetSubscriptionsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetSubscription(string id)
        {
            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.GetSubscriptionAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscription([FromBody] SubscriptionDTO subscription)
        {
            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.CreateSubscriptionAsync(_mapper.Map<Subscription>(subscription));
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateSubscription(string id, [FromBody] SubscriptionDTO subscription)
        {
            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.UpdateSubscriptionAsync(_mapper.Map<Subscription>(subscription));
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteSubscription(string id)
        {

            SubscriptionServiceClient client = new SubscriptionServiceClient();
            var result = await client.DeleteSubscriptionAsync(id);
            return Ok(result);
        }
    }
}