using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListLibrary
{
    public class TodoList
    {
        string name { get; }
        List<Todo> list { get; }

        public TodoList(string name)
        {
            this.name = name;
            list = new List<Todo>();
        }

        public void AddToList(params Todo[] todo)
        {
            foreach (Todo t in todo)
            {
                list.Add(t);
            }
        }

        public void AddToList(string text, Priority priority, DateTime date)
        {
            Todo todo = new Todo(text, priority, date);
            AddToList(todo);
        }

        //for ease of use in console
        public void AddToList(string text, int priority, int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            AddToList(text, (Priority)priority, date);
        }

        //prints
        public void PrintByDate()
        {
            Console.WriteLine("Printing ordered by Date...");

            IEnumerable<Todo> todos = UndoneTodos();
            todos = todos.OrderBy(t => t.deadline);

            foreach (Todo t in todos)
            {
                t.Print();
            }

            Console.WriteLine("");
        }

        public void PrintByPriority()
        {
            Console.WriteLine("Printing ordered by Priority...");

            IEnumerable<Todo> todos = UndoneTodos();
            todos = todos.OrderByDescending(t => t.priority);

            foreach (Todo t in todos)
            {
                t.Print();
            }
            Console.WriteLine("");
        }

        //filter only undone
        private IEnumerable<Todo> UndoneTodos()
        {
            IEnumerable<Todo> todos = (from t in list
                                       where !t.state
                                       select t);
            return (todos);
        }

        public void MarkAsDone(Todo todo)
        {
            todo.MarkAsDone();
        }

        public void MarkAsDone(Guid id)
        {
            MarkAsDone(list.FirstOrDefault<Todo>(t => t.uniqueID == id));
        }

        //for ease of use in console
        public void MarkAsDone(string id)
        {
            MarkAsDone(Guid.Parse(id));
        }

        /* in a dektop application, I would make the updates one by one,
        to only update text, priority, or date, or all at once,
        given by a textbox, a calendar, and a selection of the given priorities */
        public void UpdateTodo(Guid id, string text, Priority priority, DateTime date)
        {
            Todo todo = list.FirstOrDefault<Todo>(t => t.uniqueID == id);
            list.Remove(todo);
            todo.Update(text, priority, date);
            AddToList(todo);
        }

        public void UpdateTodo(string id, string text, Priority priority, DateTime date)
        {
            Guid guid = Guid.Parse(id);

            UpdateTodo(guid, text, priority, date);
        }

        //for ease of use in console
        public void UpdateTodo(Guid id, string text, int priority, int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            UpdateTodo(id, text, (Priority)priority, date);
        }

        //for ease of use in console
        public void UpdateTodo(string id, string text, int priority, int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            UpdateTodo(id, text, (Priority)priority, date);
        }

        public void Delete(Guid id)
        {
            Todo todo = list.FirstOrDefault<Todo>(t => t.uniqueID == id);
            list.Remove(todo);
        }

        //for ease of use in console
        public void Delete(string id)
        {
            Guid guid = Guid.Parse(id);
            Delete(guid);
        }
        
    }


}