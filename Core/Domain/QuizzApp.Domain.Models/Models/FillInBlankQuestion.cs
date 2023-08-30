using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizzApp.Server.Models;

public partial class FillInBlankQuestion
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public int? WordPosition { get; set; }
    [JsonIgnore]
    public virtual Question? Question { get; set; }
}
