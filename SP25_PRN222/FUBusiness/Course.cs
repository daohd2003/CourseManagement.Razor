using System;
using System.Collections.Generic;

namespace FUBusiness;

public partial class Course
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string CourseCode { get; set; } = null!;

    public int Capacity { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual EnrollmentRecord? EnrollmentRecord { get; set; }
}
