using System;
using System.Collections.Generic;

namespace FUBusiness;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual EnrollmentRecord? EnrollmentRecord { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
