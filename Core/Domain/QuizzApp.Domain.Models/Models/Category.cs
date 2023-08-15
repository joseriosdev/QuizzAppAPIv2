using System;
using System.Collections.Generic;

namespace QuizzApp.Server.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CategoriesQuize> CategoriesQuizes { get; set; } = new List<CategoriesQuize>();
}
