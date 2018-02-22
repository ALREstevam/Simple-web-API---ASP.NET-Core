using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

/*
# Create the database context
The database context is the main class that coordinates Entity Framework functionality for a given data model. This class is created by deriving from the Microsoft.EntityFrameworkCore.DbContext class.
Add a TodoContext class. Right-click the Models folder and select Add > Class. Name the class TodoContext and select Add.
 */


namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
