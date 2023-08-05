namespace ToDoAppAPI.Dtos.Steps;

public class StepDto
{
        public string Body { get; set; } = null!;
        public bool IsComplete { get; set; } = false;

        public int OwnerId { get; set; }

        public string? UserCompletedId { get; set; } = null!;
}
