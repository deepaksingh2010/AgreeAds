using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Entity
{
    [Table("Category")]
    public class Category:IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(40)]
        public string CategoryName { get; set; }

        [Required]
        public DateTime TimeCreated { get; set; }

        [Required]
        public DateTime TimeUpdated { get; set; }
        public IList<Equipment> Equipments { get; set; }
    }
}
