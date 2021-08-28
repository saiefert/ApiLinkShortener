using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinkShortener.Model
{
    [Table("shortener", Schema = "public")]
    public class ShortenerModel
    {
        [Column("shortener_id")]
        public Guid ID { get; set; }
        [Column("url")]
        public string URL { get; set; }
        [Column("shortened_url")]
        public string ShortenedURL { get; set; }
        [Column("token")]
        public string Token { get; set; }
        [Column("analytics")]
        public bool Analytics { get; set; }
        [Column("clicked")]
        public int Clicked { get; set; } = 0;
        [Column("created")]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
