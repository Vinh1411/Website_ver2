using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Website.Models
{
    public class product
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string pro_name { get; set; }

        [Required]
        public string pro_slug { get; set; }

        [Required]
        public int pro_category_id { get; set; }

        [Required]
        public int pro_price { get; set; }

        [Required]
        public int pro_author_id { get; set; }

        [Required]
        public int s_supplier_id { get; set; }

        [Required]
        public byte pro_sale { get; set; }

        [Required]
        public byte pro_active { get; set; }

        [Required]
        public byte pro_hot { get; set; }

        [Required]
        public byte pro_pay { get; set; }

        [Required]
        public byte pro_number { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime pro_waranty { get; set; }

        [Required]
        public int pro_view { get; set; }

        [Required]
        public String pro_description { get; set; }

        [Required]
        public String pro_avatar { get; set; }

        [Required]
        public String pro_description_seo { get; set; }

        [Required]
        public String pro_keyword_seo { get; set; }

        [Required]
        public String pro_title_seo { get; set; }

        [Required]
        public String pro_content { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime created_at { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime updated_at { get; set; }
    }
}
