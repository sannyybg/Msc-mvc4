using muscshop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace muscshop.Controllers
{
    public class StoreController : Controller
    {
        // private static FakeDatabase _database = new FakeDatabase();

        StoreContext _storeContext = new StoreContext();
        // GET: Store
        public ActionResult Index()
        {
            var genres = _storeContext.Genres;
            // var genres = _database.Genres;
            return View(genres);
        }

        public ActionResult Browse(string genre)
        {
            var genreModel = _storeContext.Genres.Where(x => x.Name == genre).FirstOrDefault();

            var albums = _storeContext.Albums.Where(x => x.Genre.Name == genre).ToList();

            genreModel.Albums = albums;

            return View(genreModel);
        }

        public ActionResult Detail(int id)
        {
            var album = _storeContext.Albums.Where(x => x.AlbumId == id).FirstOrDefault();


            return View(album);
        }
    }
}