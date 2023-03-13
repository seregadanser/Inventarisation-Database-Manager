using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DB_course.Models.DBModels;

public partial class Person
{
    public string Login { get; set; } = null!;
    [DisplayName("Person Name")]
    [Required(ErrorMessage = "Person name is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person name must be between 3 and 50 characters")]

    public string? Name { get; set; }

    public string? SecondName { get; set; }

    public string? Position { get; set; }

    public DateTime? DateOfBirthday { get; set; }

    public string? Password { get; set; }

    public int? NumberOfCome { get; set; }

    public virtual ICollection<Useful> Usefuls { get; } = new List<Useful>();
}
