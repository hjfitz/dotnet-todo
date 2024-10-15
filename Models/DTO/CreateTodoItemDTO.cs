using System.ComponentModel.DataAnnotations;

namespace Todo.Models.DTO
{

    public class CreateTodoItemDTO
    {
        [Required]
        public string Title { get; set; }
    }

}
