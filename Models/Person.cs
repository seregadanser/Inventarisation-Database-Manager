using System;
using System.Collections.Generic;

namespace DB_course;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? SecondName { get; set; }

    public string? Position { get; set; }

    public DateTime? DateOfBirthday { get; set; }

    public string? Login { get; set; }

    public virtual ICollection<Useful> Usefuls { get; } = new List<Useful>();
}
