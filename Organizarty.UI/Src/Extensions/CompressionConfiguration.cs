using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace Organizarty.UI.Extensions;

public static class CompressionConfiguration
{
    public static IServiceCollection AddTextCompression(this IServiceCollection services)
    {
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
        });

        services.Configure<BrotliCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.SmallestSize;
        });

        return services;
    }
}
