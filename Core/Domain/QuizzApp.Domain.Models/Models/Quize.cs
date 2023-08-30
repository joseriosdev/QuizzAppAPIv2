using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizzApp.Server.Models;

public partial class Quize
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? PossibleScore { get; set; }

    public int? LatestScore { get; set; }

    public int? LatestScoreBy { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CategoriesQuize> CategoriesQuizes { get; set; } = new List<CategoriesQuize>();
    [JsonIgnore]
    public virtual User? CreatedByNavigation { get; set; }
    [JsonIgnore]
    public virtual User? LatestScoreByNavigation { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    [JsonIgnore]
    public virtual User? UpdatedByNavigation { get; set; }
}
