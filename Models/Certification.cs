using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Certification
{
    public int Id { get; set; }

    public byte? Employee { get; set; }

    public string? Employeeid { get; set; }

    public string? Certname { get; set; }

    public string? Revision { get; set; }

    public DateTime? Certdate { get; set; }

    public DateTime? Revisedate { get; set; }

    public int? Bu { get; set; }

    public string? Comments { get; set; }
}
