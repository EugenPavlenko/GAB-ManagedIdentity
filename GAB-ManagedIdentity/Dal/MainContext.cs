using System;
using GAB_ManagedIdentity.Dal.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace GAB_ManagedIdentity.Dal
{

    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options, IWebHostEnvironment env) : base(options)
        {
            if (env.IsProduction())
            {
                var connection = (SqlConnection)Database.GetDbConnection();
                connection.AccessToken = (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;
            }
        }

        public DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>().ToTable("Contacts");
        }
    }

}