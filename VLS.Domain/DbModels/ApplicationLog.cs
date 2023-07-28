using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLS.Domain.DbModels
{
    [Table(nameof(ApplicationLog))]
    public class ApplicationLog
    {
        public long ApplicationLogId { get; set; }

        [MaxLength(50)]
        public string Application { get; set; } = string.Empty;

        [MaxLength(256)]
        public string Source { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = false;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "datetime2(3)"), DataType(DataType.DateTime)]
        public DateTime LogDateTime { get; set; }

    }
}
