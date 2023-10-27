using System;
using System.Collections.Generic;

namespace _07_Demo_2_3.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
