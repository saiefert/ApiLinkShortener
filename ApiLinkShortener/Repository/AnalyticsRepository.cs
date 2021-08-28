using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiLinkShortener.Controllers;
using ApiLinkShortener.Model;
using IpInfo;

namespace ApiLinkShortener.Repository
{
    public class AnalyticsRepository
    {
        public void SaveInfo(Data dados)
        {
            using (var db = new AppContext())
            {
                using var client = new HttpClient();
                var api = new IpInfoApi("tokenHere", client);

                var response = api.GetInformationByIpAsync(dados.Ip);

                AnalyticsModel log = new();
                log.City = response.Result.City;
                log.CodPostal = response.Result.Postal;
                log.Localization = response.Result.Loc;
                log.Timezone = response.Result.Timezone;
                log.Region = response.Result.Region;
                log.Country = response.Result.Country;
                log.LogDate = DateTime.Now;
                log.RedirectUrl = dados.Site;
                log.So = dados.So;
                log.Org = response.Result.Org;

                db.TableAnalytics.Add(log);
                db.SaveChanges();
            }
        }

        public void SaveClick(Guid uiid)
        {
            using (var db = new AppContext())
            {
                var clique = new SimpleAnalyticsModel
                {
                    IdShortener = uiid,
                    LogDate = DateTime.Now
                };

                db.TableSimpleAnalytics.Add(clique);
                db.SaveChanges();
            }
        }

        public string Platform()
        {
            return File.ReadAllText("platform.js");
        }
    }
}
