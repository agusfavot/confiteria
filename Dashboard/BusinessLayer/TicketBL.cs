using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class TicketBL
    {
        #region Patron Singleton
        private static TicketBL ticketBL = null;
        private TicketBL() { }
        public static TicketBL getInstance() {
            return ticketBL == null ? new TicketBL() : ticketBL;
        }
        #endregion

        public int insertTicket(Ticket ticket, int id,List<object> list) 
        {
            return AccessTicketData.getInstance().insertTicket(new Dictionary<object, object> { { "@date", ticket.Date }, { "@idEmployee", ticket.IdEmployee }, { "@state",ticket.State } } , id,list);
        }

        public int searchNextNumberTicket() {
            return AccessTicketData.getInstance().searchNextNumber();
        }
    }
}
