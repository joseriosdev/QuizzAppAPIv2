﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizzApp.Server.Models;

public partial class MultipleChoiceQuestion
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public string? Value1 { get; set; }

    public string? Value2 { get; set; }

    public string? Value3 { get; set; }

    public string? Value4 { get; set; }
    [JsonIgnore]
    public virtual Question? Question { get; set; }
}
