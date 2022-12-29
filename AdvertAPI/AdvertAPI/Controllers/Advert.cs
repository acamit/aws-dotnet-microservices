using AdvertApi.Models;
using AdvertAPI.Services.Interfaces;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdvertAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Advert : ControllerBase
    {
        private readonly IAdvertStorageService _advertStorageService;

        public Advert(IAdvertStorageService advertStorageService)
        {
            _advertStorageService = advertStorageService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CreateAdventResponse))]
        public async Task<IActionResult> Create(AdvertModel model)
        {
            string recordId = string.Empty;
            try
            {
                recordId = await _advertStorageService.Add(model);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode((int)HttpStatusCode.OK, new CreateAdventResponse() { Id = recordId });
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(CreateAdventResponse))]

        public async Task<IActionResult> Confirm(ConfirmAdvertModel model)
        {
            try
            {
                await _advertStorageService.Confirm(model);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return new OkResult();
        }
    }
}
