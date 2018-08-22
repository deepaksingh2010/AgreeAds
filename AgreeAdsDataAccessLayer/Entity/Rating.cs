using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Entity
{
    public class Rating : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingID { get; set; }
        public int OneStar { get; set; }
        public int TwoStar { get; set; }
        public int ThreeStar { get; set; }
        public int FourStar { get; set; }
        
        public int FiveStar { get; set; }
        [Required]
        public DateTime TimeCreated { get; set; }

        [Required]
        public DateTime TimeUpdated { get; set; }
    }
}
