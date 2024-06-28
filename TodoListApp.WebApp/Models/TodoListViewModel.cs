namespace TodoListApp.WebApp.Models
{
    public class TodoListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TodoItemViewModel> Items { get; set; }
    }
}
