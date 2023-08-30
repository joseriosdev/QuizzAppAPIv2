using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizzApp.Server.Models;

public partial class Question
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? CorrectAnswer { get; set; }

    public int? Score { get; set; }

    public int? QuizId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<FillInBlankQuestion> FillInBlankQuestions { get; set; } = new List<FillInBlankQuestion>();

    public virtual ICollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; } = new List<MultipleChoiceQuestion>();
    [JsonIgnore]
    public virtual Quize? Quiz { get; set; }
}
