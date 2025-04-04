using System;
using System.Collections.Generic;

namespace FUBusiness;

public partial class EnrollmentRecord
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrollDate { get; set; }

    public bool Dropped { get; set; }

    public virtual User Id1 { get; set; } = null!;

    public virtual Course IdNavigation { get; set; } = null!;
}
