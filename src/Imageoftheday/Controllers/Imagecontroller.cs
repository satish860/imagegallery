using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Imageoftheday.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imageoftheday.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Imagecontroller : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var image = JsonSerializer.Deserialize<ImageofDay>(content);
                return Ok(image);
            }
            return Ok(new ImageofDay());
        }
    }
}
