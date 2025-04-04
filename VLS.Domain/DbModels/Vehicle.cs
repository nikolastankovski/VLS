﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLS.Domain.DbModels
{
    [Table(nameof(Vehicle))]
    public class Vehicle : BaseEntity
    {
        public Vehicle()
        {
            TransactionVehicles = new List<TransactionVehicle>();
        }
        public long VehicleId { get; set; }
        public int CompanyId { get; set; }

        [MaxLength(50)]
        public string RegistrationNumber { get; set; } = null!;

        [Column(TypeName = "date"), DataType(DataType.Date)]
        public DateOnly TechnicalCorrectnessExpireDate { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public virtual Company? Company { get; set; }

        public virtual ICollection<TransactionVehicle>? TransactionVehicles { get; set; }
    }
}
