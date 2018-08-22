using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Entity
{
    [Table("ManuFacturer")]
    public class ManuFacturer: IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManuFacturerID { get; set; }

        [Required]
        [MaxLength(40)]
        public string ManuFacturerName { get; set; }

        
        [MaxLength(500)]
        public string ManuFacturerDiscription { get; set; }


        [Required]
        public DateTime TimeCreated { get; set; }

        [Required]
        public DateTime TimeUpdated { get; set; }
        public IList<Equipment> Equipments { get; set; }
    }
}
