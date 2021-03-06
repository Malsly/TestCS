﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DAL.Implementation
{
    public class TestCSContext : DbContext
    {
        public TestCSContext()
        : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnotherDBTestCS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var conn = ConfigurationManager.ConnectionStrings["DatabaseCS"].ConnectionString;
            optionsBuilder.UseSqlServer(conn);
        }   

        public DbSet<ShipmentRegistration> ShipmentRegistrations { get; set; }
    }
}
