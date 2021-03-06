﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreeAdsDataAccessLayer.Entity
{
    public class EquipmentSpecificationType : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentSpecificationTypeID { get; set; }

        [Required]
        [MaxLength(40)]
        public string EquipmentSpecificationTypeName { get; set; }

        [Required]
        public DateTime TimeCreated { get; set; }

        [Required]
        public DateTime TimeUpdated { get; set; }

        public IList<BaseEquipmentSpecification> BaseEquipmentSpecifications { get; set; }

    }
}
