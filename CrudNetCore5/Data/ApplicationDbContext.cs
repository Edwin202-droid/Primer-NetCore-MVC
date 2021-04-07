﻿using CrudNetCore5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Data
{
    public class ApplicationDbContext : DbContext
    {   
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                    
        }

        public DbSet<Libro> Libro { get; set; }
    }
}
