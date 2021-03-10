using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedRepository
{
    public class DhtMeasurement
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="char(17)")]
        public string DeviceId { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal Temperature { get; set; }

        [Required]
        [Column(TypeName ="decimal")]
        public decimal Humidity { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime MeasurementTime { get; set; }
    }
}
