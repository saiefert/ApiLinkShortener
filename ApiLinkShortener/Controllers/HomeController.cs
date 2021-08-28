using ApiLinkShortener.Model;
using ApiLinkShortener.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinkShortener.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet, Route("/{token}")]
        public IActionResult Index([FromRoute] string token)
        {
            ShortenerRepository shortener = new();
            var tableShortener = shortener.URL(token);
            var fullUrl = tableShortener.URL;
            ViewBag.Url = fullUrl;

            var clicks = new AnalyticsRepository();
            clicks.SaveClick(tableShortener.ID);

            if (tableShortener.Analytics)
            {
                return View("Redirect");
            }

            return Redirect(fullUrl);

        }

        [HttpPost, Route("GenerateUrl")]
        public IActionResult PostURL([FromBody] string url)
        {
            try
            {
                using (var db = new AppContext())
                {
                    if (db.TableShortener.Any(x => x.ShortenedURL == url))
                    {
                        Response.StatusCode = 405;
                        return Json(new { url = url, status = "already shortened", token = "" });
                    }

                    Shortener shortURL = new Shortener(url);
                    Settings settings = new();
                    var baseUrl = settings.Config.BASE_URL;

                    return Json(new { url = url, status = "Shortened", shortenedUrl = $"{baseUrl}{shortURL.Token}" });
                }

            }
            catch (Exception ex)
            {
                if (ex.Message == "URL already exists")
                {
                    using (var db = new AppContext())
                    {
                        var json = new
                        {
                            url = url,
                            status = "URL already exists",
                            token = db.TableShortener.ToList().Find(x => x.URL == url).Token
                        };

                        return Json(json);
                    }

                }
                throw new Exception(ex.Message);
            }
        }
    }
}
