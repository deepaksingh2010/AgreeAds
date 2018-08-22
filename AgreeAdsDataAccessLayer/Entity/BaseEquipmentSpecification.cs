using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Entity
{

    public class BaseEquipmentSpecification : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BaseEquipmentSpecificationID { set; get; }
        public string SKU { set; get; }


        
        public string SubType { set; get; }
        public string EngineType { set; get; }
        public string EnginePower { set; get; }
        public string Displacement { set; get; }
        public string FuelOilRatio { set; get; }
        public string Weight { set; get; }
        public string GearRation { set; get; }
        public string RPMSpeed { get; set; }
        public string Carburetor { get; set; }
        public string Ignition { set; get; }

        [ForeignKey("EquipmentSpecificationTypeID")]
        public EquipmentSpecificationType EquipmentSpecificationType { set; get; }

        [Required]
        [Index("IX_EquipmentSpecificationTypeID")]

        public int? EquipmentSpecificationTypeID { set; get; }

        [ForeignKey("EquipmentID")]
        public Equipment Equipment { set; get; }

        [Required]
        [Index("IX_EquipmentID")]

        public int? EquipmentID { set; get; }


        [Required]
        public DateTime TimeCreated { get; set; }

        [Required]
        public DateTime TimeUpdated { get; set; }
    }
}
