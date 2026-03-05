using System;
using System.Collections.Generic;

namespace LazyLoading.Models;

public partial class SohPractice
{
    public int SalesOrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal SubTotal { get; set; }

    public decimal TaxAmt { get; set; }

    public decimal Freight { get; set; }

    public decimal TotalDue { get; set; }
}
