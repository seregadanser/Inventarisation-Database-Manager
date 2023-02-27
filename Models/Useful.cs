using System;
using System.Collections.Generic;

namespace DB_course;

public partial class Useful
{
    public int Id { get; set; }

    public int? InventoryId { get; set; }

    public int? PersonId { get; set; }

    public DateTime? DateOfStart { get; set; }

    public virtual InventoryProduct? Inventory { get; set; }

    public virtual Person? Person { get; set; }
}
