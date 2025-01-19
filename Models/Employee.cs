using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Employeeid { get; set; }

    public string? Employeetenure { get; set; }

    public DateTime? Employeestartdate { get; set; }

    public DateTime? EmployeeReturndate { get; set; }

    public string? Hrid { get; set; }

    public string? Hrsystemconstring { get; set; }
}
