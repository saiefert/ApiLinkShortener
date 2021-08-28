using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinkShortener.Model
{
    [Table("analytics", Schema = "public")]
    public class AnalyticsModel
    {

        [Column("id")]
        public int Id { get; set; }       
        [Column("city")]
        public string City { get; set; }
        [Column("region")]

        public string Region { get; set; }
        [Column("country")]

        public string Country { get; set; }
        [Column("loc")]

        public string Localization { get; set; }
        [Column("postal")]

        public string CodPostal { get; set; }
        [Column("timezone")]

        public string Timezone { get; set; }
        [Column("log_date")]

        public DateTime LogDate { get; set; }
        [Column("url_direcionada")]
        public string RedirectUrl { get; set; }
        [Column("so")]

        public string So { get; set; }
        [Column("org")]
        public string Org { get; set; }
    }

    [Table("simple_analytics", Schema = "public")]
    public class SimpleAnalyticsModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("log_date")]

        public DateTime LogDate { get; set; }
        [Column("id_shortener")]
        public Guid IdShortener { get; set; }
    }
}