using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore_Movies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.NetCore_Movies.Services;

namespace Asp.NetCore_Movies.Controllers
{
    public class MoviesController : Controller
    {

        private readonly MovieService movieService;

        public MoviesController(MovieService movieService)
        {
            this.movieService = movieService;
        }




        // GET: Movies
        public ActionResult Index()
        {
            return View(movieService.Get());
        }


        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieService.Create(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);

        }

        // GET: Movies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movieService.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                movieService.Update(id, movie);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(movie);
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movieService.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }



        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var movie = movieService.Get(id);

                if (movie == null)
                {
                    return NotFound();
                }

                movieService.Remove(movie.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}