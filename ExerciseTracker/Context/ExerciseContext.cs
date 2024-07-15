using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseTracker.Models;

namespace ExerciseTracker.Context
{
    public class ExerciseContext : DbContext
    {
        public DbSet<Exercise> Exercises {  get; set; }
        public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
        {

        }
    }
}
