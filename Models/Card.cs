using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Card
{
    public int Id { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }
}
