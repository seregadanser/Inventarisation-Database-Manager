﻿using System;
using System.Collections.Generic;

namespace DB_course;

public partial class InventoryProduct
{
    public int Id { get; set; }

    public int? InventoryNumber { get; set; }

    public int? ProductId { get; set; }

    public virtual ICollection<PlaceofObject> PlaceofObjects { get; } = new List<PlaceofObject>();

    public virtual Product? Product { get; set; }

    public virtual Useful? Useful { get; set; }
}
