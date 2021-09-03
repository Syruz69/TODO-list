using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListLibrary;

namespace TODO_list
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoList list = new TodoList("list1");
            Todo todo1 = new Todo("Nezapomeň, že se dá psát diakritikou", 1, 2021, 9, 2);
            Todo todo2 = new Todo("Do. Or do not. There is no try.", 2, 2021, 10, 5);
            Todo todo3 = new Todo("Arise!", 2, 2020, 5, 6);
            list.AddToList("Look on the bright side of life", 2, 2021, 9, 3);
            list.AddToList("On the dawn of the third day, look to the east", 1, 2021, 9, 6);
            list.AddToList("Don't forget to bring a towel!", 0, 2021, 10, 20);
            list.AddToList(todo1, todo2, todo3);
            
            Guid id1 = todo1.uniqueID;
            Guid id2 = todo3.uniqueID;
            list.UpdateTodo(id2, "Arise! Arise!", 2, 2020, 5, 6);

            list.PrintByDate();

            list.MarkAsDone(todo2);
            list.MarkAsDone(id1);
            string id3 = id2.ToString();
            list.UpdateTodo(id3, "Arise! Arise! Arise!", 2, 2021, 6, 20);

            list.PrintByPriority();

            list.Delete(id3);
            Todo todo4 = new Todo("", 1, 1990, 5, 20);
            Todo todo5 = new Todo(new string('f', 1000), 2, 2000, 5, 5);
            list.AddToList(todo4, todo5);
            list.PrintByDate();

            list.PrintAll();

            Console.ReadLine();
        }
    }
}
