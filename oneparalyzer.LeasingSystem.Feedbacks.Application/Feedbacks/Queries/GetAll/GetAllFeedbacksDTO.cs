

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Queries.GetAll;

public class GetAllFeedbacksDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }
    public DateTime DateTime { get; set; }
    public IEnumerable<GetAllFeedbacksDTO> Feedbacks { get; set; }
}
