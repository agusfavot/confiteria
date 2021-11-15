using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Employee
    {
        private int id;
        private string name;
        private string lastName;
        private float commission;

        public Employee(int id, string name, string lastName, float commission) {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.commission = commission;
        }

        public Employee( string name, string lastName, float commission)
        {
            this.name = name;
            this.lastName = lastName;
            this.commission = commission;
        }

        public Employee() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public float Commission { get => commission; set => commission = value; }
    }
}
