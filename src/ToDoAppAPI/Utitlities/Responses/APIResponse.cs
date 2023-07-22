namespace ToDoAppAPI.Utitlities.Responses
{
    public class APIResponse<TResult>
    {
        public TResult? Result { get; set; }
        public TResult? Errors { get; set; }

    }
}
