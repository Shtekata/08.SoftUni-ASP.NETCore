namespace WebApiDemo.Web.ViewModels.TodoItems
{
    using WebApiDemo.Common.Mapping;
    using WebApiDemo.Data.Models;

    public class TodoItemViewModel : IMapFrom<TodoItem>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}
