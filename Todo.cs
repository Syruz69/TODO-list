using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListLibrary
{
    public class Todo
    {
        public Guid uniqueID { get; }
        string text { get; set; }
        public Priority priority { get; set; }
        public DateTime deadline { get; set; }
        public bool state { get; set; }

        public Todo(string txt, Priority priority, DateTime date)
        {
            uniqueID = Guid.NewGuid();
            text = TextRange(txt);
            this.priority = priority;
            deadline = date;
            state = false;
        }

        //for ease of use in console
        public Todo(string txt, int priority, int year, int month, int day)
        {
            uniqueID = Guid.NewGuid();
            text = TextRange(txt);
            this.priority = (Priority)priority;
            deadline = new DateTime(year, month, day);
            state = false;
        }

        public void Update(string txt, Priority priority, DateTime date)
        {
            text = TextRange(txt);
            this.priority = priority;
            deadline = date;
        }

        //for ease of use in console
        public void Update(string txt, int priority, int year, int month, int day)
        {
            text = TextRange(txt);
            this.priority = (Priority)priority;
            deadline = new DateTime(year, month, day);
        }

        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("");
            sb.Append("ID: ");
            sb.AppendLine(uniqueID.ToString());
            sb.Append("Priority: ");
            sb.AppendLine(priority.ToString());
            sb.Append("Deadline: ");
            sb.AppendLine(deadline.ToString("dd-MM-yyyy"));
            sb.Append(text);
            Console.WriteLine(sb);
            if (state) Console.WriteLine("DONE");
        }

        public void MarkAsDone()
        {
            state = true;
        }

        /* I was considering whether to throw an exception or change the text,
        but I think in this case it might be easier for a user in this way,
        to be informed of the constraints, but have the item there regardless,
        and the text "empty" or shortened */
        string TextRange(string txt)
        {
            int minimum = 2;
            int maximum = 500;
            int length = txt.Length;

            if (length < minimum)
            {
                Console.WriteLine("Text needs a minimum size of {0:d} characters. The following ID is now empty: " + uniqueID.ToString(), minimum);
                return ("  ");
            }
            else if (length > maximum)
            {
                Console.WriteLine("Text needs a maximum size of {0:d} characters. The following ID has been shortened: " + uniqueID.ToString(), maximum);

                return txt.Substring(0, maximum);
            }
            else return txt;
        }
    }
}
