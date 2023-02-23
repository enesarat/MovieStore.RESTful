﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public interface IMovieStoreDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> ActorActress { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ActorMovieJoint> actorActressMovieJoints { get; set; }

        public int SaveChanges();
    }
}
