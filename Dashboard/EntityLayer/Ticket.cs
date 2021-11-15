using System;

namespace EntityLayer
{
    public class Ticket
    {
        private int id;
        private DateTime date;
        private int idEmployee;
        private bool state;

        public Ticket( DateTime date, int idEmployee, bool state) {
            this.date = date;
            this.idEmployee = idEmployee;
            this.state = state;
        }

        public Ticket() { }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public bool State { get => state; set => state = value; }
    }
}
