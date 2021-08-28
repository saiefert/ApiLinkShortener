using ApiLinkShortener.Model;
using System;
using System.Linq;

namespace ApiLinkShortener
{
    public class Shortener
    {
        public string Token { get; set; }
        private ShortenerModel biturl;
        // The method with which we generate the token
        public Shortener GenerateToken()
        {
            string urlsafe = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => new Random().Next())
              .ToList()
              .ForEach(i => urlsafe += Convert.ToChar(i)); // Store each char into urlsafe
            Token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
            
            return this;
        }

        public Shortener(string url)
        {
            using (var db = new AppContext())
            {
                var urls = db.TableShortener;

                // While the token exists in our PostgreSQL we generate a new one
                // It basically means that if a token already exists we simply generate a new one

                while (urls.Any(u => u.Token == GenerateToken().Token)) ;
                
                biturl = new ShortenerModel()
                {
                    Token = Token,
                    URL = url,
                    ShortenedURL = new Settings().Config.BASE_URL + Token
                };

                if (urls.Any(u => u.URL == url))
                    throw new Exception("URL already exists");

                urls.Add(biturl);
                db.SaveChanges();
            }
        }
    }
}
