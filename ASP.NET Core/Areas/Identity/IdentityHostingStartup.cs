using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NashSneaker.Data;

[assembly: HostingStartup(typeof(NashSneaker.Areas.Identity.IdentityHostingStartup))]
namespace NashSneaker.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NashSneakerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NashSneakerContextConnection")));
            });
        }
    }
}