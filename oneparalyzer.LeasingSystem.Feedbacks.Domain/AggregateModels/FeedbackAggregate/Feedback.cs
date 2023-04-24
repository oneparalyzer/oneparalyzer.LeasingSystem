using oneparalyzer.LeasingSystem.Feedbacks.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;

public sealed class Feedback : AggregateRoot<Guid>
{
    private readonly List<Feedback> _feedbacks = new();

    public Feedback(Guid id, Guid userId, string text) : base(id)
    {
        UserId = userId;
        Text = text;
        IsRoot = true;
    }

    private Feedback(Guid id, Guid userId, string text, bool isRoot) : base(id)
    {
        UserId = userId;
        Text = text;
        IsRoot = isRoot;
    }

    public Guid UserId { get; private set; }
    public string Text { get; private set; }
    public bool IsRoot { get; private set; }
    public DateTime DateTime { get; private set; } = DateTime.Now;
    public IReadOnlyList<Feedback> Feedbacks => _feedbacks;

    public void AddFeedback(Guid userId, string text)
    {
        var feedback = new Feedback(Guid.NewGuid(), UserId, text, false);
        _feedbacks.Add(feedback);
    }
}
