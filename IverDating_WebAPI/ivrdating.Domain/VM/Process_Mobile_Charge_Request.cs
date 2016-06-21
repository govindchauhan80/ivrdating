using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Domain.VM
{
    public class Process_Mobile_Charge_Request : RequestBase
    {
        public int Acc_Number { get; set; }
        public int PassCode { get; set; }

        public string SubscriberNo { get; set; }
        public int SMS_Id { get; set; }
        public string TicketId { get; set; }
        public int CarrierId { get; set; }
        public double Charged_Amount { get; set; }
    }
}
