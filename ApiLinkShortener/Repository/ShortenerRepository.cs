using ApiLinkShortener.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinkShortener.Repository
{
    public class ShortenerRepository
    {
        public ShortenerModel URL(string token)
        {
            using (var db = new AppContext())
            {
                var shortened = db.TableShortener
                    .Where(x => x.Token == token)
                    .FirstOrDefault();
                shortened.Clicked += 1;

                db.TableShortener.Update(shortened);
                db.SaveChanges();

                return shortened;
            }
        }
    }
}

