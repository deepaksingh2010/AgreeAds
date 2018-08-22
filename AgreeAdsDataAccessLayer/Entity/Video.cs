using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Entity
{
    public class Video:IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VideoID { get; set; }
        [Required]
        [MaxLength(216)]
        public string VideoUrl { get; set; }

        [Required]
        [MaxLength(200)]
        public string VideoDescription { get; set; }

        [Required]
        public DateTime TimeCreated { get; set; }

        [Required]
        public DateTime TimeUpdated { get; set; }
    }
}
