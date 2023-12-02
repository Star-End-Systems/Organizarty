using System.Net.Http.Headers;
using Organizarty.Adapters;

namespace Organizarty.Infra.Providers.ImageUpload;


public class SupabaseImageUpload : IImageUpload
{
    public class Configuration
    {
        public string ApplicationId { get; }
        public string Token { get; }
        public string ApplicationURL { get; }

        public Configuration()
        {
            Token = Environment.GetEnvironmentVariable("SUPABASE_TOKEN") ?? throw new InvalidOperationException("<SUPABASE_TOKEN> not found");
            ApplicationId = Environment.GetEnvironmentVariable("SUPABASE_APPLICATION_ID") ?? throw new InvalidOperationException("<SUPABASE_APPLICATION_ID> not found");
            ApplicationURL = $"https://{ApplicationId}.supabase.co";
        }
    }

    private readonly Configuration _configuration;

    public SupabaseImageUpload(Configuration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> UploadImage(string bucket, string folder, byte[] fileBytes)
    {
        string imagename = Guid.NewGuid().ToString();

        var path = Path.Combine(folder, imagename);

        var client = new HttpClient();

        client.BaseAddress = new Uri(_configuration.ApplicationURL);

        client.DefaultRequestHeaders.Add("apikey", _configuration.Token);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration.Token}");


        // Read the file as a byte array
        // var fileBytes = File.ReadAllBytes("test.png");

        // Create the multipart form data content
        var content = new MultipartFormDataContent();
        var fileContent = new ByteArrayContent(fileBytes);
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
        content.Add(fileContent, "file", path);

        // Send the POST request
        var response = await client.PostAsync($"/storage/v1/object/{bucket}/{path}", content);

        // Check for errors
        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {errorMessage}");
        }
        else
        {
            Console.WriteLine("Image uploaded successfully");
        }

        return $"{_configuration.ApplicationURL}/storage/v1/object/public/{bucket}/{path}";
    }
}
