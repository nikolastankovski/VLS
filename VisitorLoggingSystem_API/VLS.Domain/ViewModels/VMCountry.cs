﻿using System.ComponentModel.DataAnnotations;

namespace VLS.Domain.ViewModels
{
    public class VMCountry : VMBaseEntity
    {
        public int Country_ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        public string Code { get; set; } = null!;

        [MaxLength(50)]
        public string Region { get; set; } = null!;

        [DataType(DataType.Url), MaxLength(255)]
        public string? FlagURL { get; set; }
        public bool IsEUMember { get; set; } = false;

        [MaxLength(10)]
        public string? PhoneCode { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
    }
}
