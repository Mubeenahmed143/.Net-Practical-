﻿using System;
using System.Collections.Generic;

namespace Class_Task.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }
}