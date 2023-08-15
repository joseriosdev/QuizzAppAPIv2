using System;
using System.Collections.Generic;

namespace QuizzApp.Server.Models;

public partial class CategoriesQuize
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public int? QuizId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Quize? Quiz { get; set; }
}
