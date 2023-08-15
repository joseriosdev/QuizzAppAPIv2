using System;
using System.Collections.Generic;

namespace QuizzApp.Server.Models;

public partial class FillInBlankQuestion
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public int? WordPosition { get; set; }

    public virtual Question? Question { get; set; }
}
