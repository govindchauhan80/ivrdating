namespace ivrdating.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ivrdating.sms_queue_active")]
    public partial class sms_queue_active
    {
        public int Id { get; set; }

        public int IVRId { get; set; }

        [Required]
        [StringLength(20)]
        public string SubscriberNo { get; set; }

        public int Acc_Number { get; set; }

        public int PassCode { get; set; }

        [Column(TypeName = "enum")]
        [Required]
        [StringLength(65532)]
        public string Grp_Id { get; set; }

        public int Port { get; set; }

        public int SMS_Id { get; set; }

        [StringLength(50)]
        public string Ticket_Id { get; set; }

        public int CarrierId { get; set; }

        public int ChargeType { get; set; }

        public double ChargeAmount { get; set; }

        [Required]
        [StringLength(20)]
        public string ProgramId { get; set; }

        public DateTime Job_Time { get; set; }

        public DateTime Queue_Time { get; set; }

        public DateTime NextRetryAt { get; set; }

        public DateTime MessageSendAt { get; set; }

        public DateTime TicketConfirmedAt { get; set; }

        public int RetryCounter { get; set; }

        public int ivr1sms2 { get; set; }

        public int? OM0_M1 { get; set; }

        public int? Carrier1Subscriber2 { get; set; }

        public int Q0A1S2F3 { get; set; }
    }
}
