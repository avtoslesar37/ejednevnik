using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejednevnik
{
    class Theme
    {
        private int id;
        private String name;
        private String content;
        private DateTime date;
        private int priority;

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public String Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public int Priority { get => priority; set => priority = value; }

        public override string ToString()
        {
            return name;
        }
    }
}