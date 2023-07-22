using System.ComponentModel.DataAnnotations;

namespace ToDoAppAPI.Dtos
{
    public class ListQueryParamsDto
    {
        [StringLength(maximumLength:10, 
            MinimumLength = 2, 
            ErrorMessage = "Sreach text must be between 2 and 10 charachters")]
        public string? Search { get; set; }


    }
}
