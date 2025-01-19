using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public byte? Employee { get; set; }

    public string? Employeeid { get; set; }
}
