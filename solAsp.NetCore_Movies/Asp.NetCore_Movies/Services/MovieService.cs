using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore_Movies.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Asp.NetCore_Movies.Services
{
    public class MovieService
    {
        private readonly IMongoCollection<Movie> movies;

        public MovieService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("MoviesDB"));
            IMongoDatabase database = client.GetDatabase("MoviesDB");
            movies = database.GetCollection<Movie>("Movies");
        }

        public List<Movie> Get()
        {
            return movies.Find(movie => true).ToList();
        }

        public Movie Get(string id)
        {
            return movies.Find(movie => movie.Id == id).FirstOrDefault();
        }

        public Movie Create(Movie movie)
        {
            movies.InsertOne(movie);
            return movie;
        }

        public void Update(string id, Movie movieIn)
        {
            movies.ReplaceOne(movie => movie.Id == id, movieIn);
        }

        //public void Remove(Movie movieIn)
        //{
        //    movies.DeleteOne(movie => movie.Id == movieIn.Id);
        //}

        public void Remove(string id)
        {
            movies.DeleteOne(movie => movie.Id == id);
        }
    }
}
