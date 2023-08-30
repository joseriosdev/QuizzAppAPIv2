using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizzApp.Server.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }
    [JsonIgnore]
    public virtual ICollection<Quize> QuizeCreatedByNavigations { get; set; } = new List<Quize>();
    [JsonIgnore]
    public virtual ICollection<Quize> QuizeLatestScoreByNavigations { get; set; } = new List<Quize>();
    [JsonIgnore]
    public virtual ICollection<Quize> QuizeUpdatedByNavigations { get; set; } = new List<Quize>();
}
