using System;
using System.Collections.Generic;

namespace DB_course.Models.DBModels;

public partial class Useful
{
    public int InventoryId { get; set; }

    public string? PersonId { get; set; }

    public DateTime? DateOfStart { get; set; }

    public virtual InventoryProduct Inventory { get; set; } = null!;

    public virtual Person? Person { get; set; }
}
