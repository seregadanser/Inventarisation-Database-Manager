using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DB_course.Models.DBModels;

public partial class Person
{
    [DisplayName ("Person ID")]
    public int Id { get; set; }

    [DisplayName("Person Name")]
    [Required(ErrorMessage = "Person name is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person name must be between 3 and 50 characters")]
    public string? Name { get; set; }

    [DisplayName("Person Second Name")]
    [Required(ErrorMessage = "Person second name is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person second name must be between 3 and 50 characters")]
    public string? SecondName { get; set; }

    [DisplayName("Person Position")]
    [Required(ErrorMessage = "Person position name is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person position must be between 3 and 50 characters")]
    public string? Position { get; set; }

    public DateTime? DateOfBirthday { get; set; }

    [DisplayName("Person Login")]
    [Required(ErrorMessage = "Person login name is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person login must be between 3 and 50 characters")]
    public string? Login { get; set; }

    public virtual ICollection<Useful> Usefuls { get; } = new List<Useful>();
}
