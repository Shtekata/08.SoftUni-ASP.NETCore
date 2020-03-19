namespace WebApiDemo.Web.ViewModels.TodoItems
{
    using System.ComponentModel.DataAnnotations;

    using WebApiDemo.Common.Mapping;
    using WebApiDemo.Data.Models;

    public class TodoItemBindingModel : IMapTo<TodoItem>
    {
        [Required]
        public string Title { get; set; }
    }
}
