using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ImageGallery.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory factory;
        private readonly IConfiguration configuration;
        public ImageOfDayModel Image;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory factory, IConfiguration configuration)
        {
            _logger = logger;
            this.factory = factory;
            this.configuration = configuration;
        }

        public async Task OnGetAsync()
        {
            var imageUrl = this.configuration["IMAGE_URL"];
            var httpclient = this.factory.CreateClient();
            var httpResponse = await httpclient.GetAsync(imageUrl);
            if(httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                this.Image = JsonSerializer.Deserialize<ImageOfDayModel>(content);
            }
        }
    }
}
