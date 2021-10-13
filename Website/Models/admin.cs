using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class admin

    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public String name { get; set; }

        [Required]
        public String email { get; set; }

        [Required]
        public String phone { get; set; }

        [Required]
        public String avatar { get; set; }

        [Required]
        public byte active { get; set; }

        [Required]
        public String password { get; set; }

        [Required]
        public String remember_token { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime created_at { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime updated_at { get; set; }
        
        [NotMapped]
        [Required]
        //[System.ComponentModel.DataAnnotations.Compare("password")]
        public string ConfirmPassword { get; set; }
    }
}