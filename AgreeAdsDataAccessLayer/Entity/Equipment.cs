using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Entity
{
    public class Equipment:IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string EquipmentName { get; set; }

        [Required]
        [MaxLength(500)]
        public string EquipmentDescription { get; set; }

        [Required]
        [MaxLength(200)]
        public string EquipmentPicture { get; set; }

        [Required]
        [MaxLength(100)]
        public string EquipmentPriceRange { get; set; }

        [Required]
        [MaxLength(200)]
        public string EquipmentVideo { get; set; }

        [Required]
        [Index("IX_CategoryID")]
        public int? CategoryID { get; set; }

        [Required]
        [Index("IX_ManuFacturerID")]
        public int? ManuFacturerID { get; set; }

        [Required]
        public DateTime TimeCreated { get; set; }

        [Required]
        public DateTime TimeUpdated { get; set; }
    }
}
