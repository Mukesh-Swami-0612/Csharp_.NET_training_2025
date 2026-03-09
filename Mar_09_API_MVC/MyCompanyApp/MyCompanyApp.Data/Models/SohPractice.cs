using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyCompanyApp.Data.Models;

[Keyless]
[Table("SOH_Practice")]
public partial class SohPractice
{
    [Column("SalesOrderID")]
    public int SalesOrderId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [Column(TypeName = "money")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal TaxAmt { get; set; }

    [Column(TypeName = "money")]
    public decimal Freight { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalDue { get; set; }
}
