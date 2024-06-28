namespace TodoListApp.WebApp.Models
{
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int TodoListId { get; set; }
        public TodoListViewModel TodoList { get; set; }
    }
}
