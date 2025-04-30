using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tedu.KnowledgeSpace.BackendServer.Data;
using Tedu.KnowledgeSpace.BackendServer.Data.Entities;

[assembly: HostingStartup(typeof(Tedu.KnowledgeSpace.BackendServer.Areas.Identity.IdentityHostingStartup))]
namespace Tedu.KnowledgeSpace.BackendServer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
