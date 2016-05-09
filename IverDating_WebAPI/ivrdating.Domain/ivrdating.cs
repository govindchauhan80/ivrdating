namespace ivrdating.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ivrdating : DbContext
    {
        public ivrdating()
            : base("name=ivrdating")
        {
        }

        public virtual DbSet<acc_number_web> acc_number_web { get; set; }
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<accountid> accountids { get; set; }
        public virtual DbSet<action_queue> action_queue { get; set; }
        public virtual DbSet<api_servers> api_servers { get; set; }
        public virtual DbSet<customer_master> customer_master { get; set; }
        public virtual DbSet<group_association> group_association { get; set; }
        public virtual DbSet<ip2location_db15_ipv4m> ip2location_db15_ipv4m { get; set; }
        public virtual DbSet<ip2location_db15_ipv6m> ip2location_db15_ipv6m { get; set; }
        public virtual DbSet<liveuser> liveusers { get; set; }
        public virtual DbSet<login_log> login_log { get; set; }
        public virtual DbSet<market> markets { get; set; }
        public virtual DbSet<misc> miscs { get; set; }
        public virtual DbSet<mobile_carrier_account> mobile_carrier_account { get; set; }
        public virtual DbSet<payment_plan_list> payment_plan_list { get; set; }
        public virtual DbSet<paymentdetail> paymentdetails { get; set; }
        public virtual DbSet<serverdefn> serverdefns { get; set; }
        public virtual DbSet<servicesource> servicesources { get; set; }
        public virtual DbSet<sms_queue_active> sms_queue_active { get; set; }
        public virtual DbSet<user_minute> user_minute { get; set; }
        public virtual DbSet<ws_agent> ws_agent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<acc_number_web>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<acc_number_web>()
                .Property(e => e.Subscriber_Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.PassCode)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.callerid)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.AccountType)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.LookingFor)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.ScreenStatus_0N2D1S3Ok)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.AdminScreening_0Q1Ok)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.ProfileExists1)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Callout_Flag)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Callout_No)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Callout_Start)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Callout_End)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.Active0In1)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.DeadAccount1)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.PassCode)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id1)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id2)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id3)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id4)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id5)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id6)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id7)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id8)
                .IsUnicode(false);

            modelBuilder.Entity<accountid>()
                .Property(e => e.Grp_Id9)
                .IsUnicode(false);

            modelBuilder.Entity<action_queue>()
                .Property(e => e.Function1Table2)
                .IsUnicode(false);

            modelBuilder.Entity<action_queue>()
                .Property(e => e.FuncTable_Name)
                .IsUnicode(false);

            modelBuilder.Entity<action_queue>()
                .Property(e => e.Field_Name)
                .IsUnicode(false);

            modelBuilder.Entity<action_queue>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<action_queue>()
                .Property(e => e.WhereClause)
                .IsUnicode(false);

            modelBuilder.Entity<action_queue>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<action_queue>()
                .Property(e => e.Q0A1S2F3)
                .IsUnicode(false);

            modelBuilder.Entity<api_servers>()
                .Property(e => e.ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.WebUserName)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.WebPassword)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.State_Name)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.Zip_Code)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<customer_master>()
                .Property(e => e.Email_Address)
                .IsUnicode(false);

            modelBuilder.Entity<group_association>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<group_association>()
                .Property(e => e.Grp_Prefix)
                .IsUnicode(false);

            modelBuilder.Entity<group_association>()
                .Property(e => e.Grp_Name)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv4m>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv4m>()
                .Property(e => e.country_name)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv4m>()
                .Property(e => e.stateprov)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv4m>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv4m>()
                .Property(e => e.AreaCode)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv6m>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv6m>()
                .Property(e => e.country_name)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv6m>()
                .Property(e => e.stateprov)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv6m>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<ip2location_db15_ipv6m>()
                .Property(e => e.AreaCode)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.AcctType)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.LookingFor)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.CrossConnectFlag)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.Request2Connect)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.Ani)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.Dnis)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.Profile1Msg2)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.a_AccountType)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.c_Screen0123)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.c_ProfileListen10)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.ScreeningNotification)
                .IsUnicode(false);

            modelBuilder.Entity<liveuser>()
                .Property(e => e.ProfileExists1)
                .IsUnicode(false);

            modelBuilder.Entity<login_log>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<login_log>()
                .Property(e => e.SessionNo)
                .IsUnicode(false);

            modelBuilder.Entity<login_log>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<login_log>()
                .Property(e => e.TimeIn)
                .IsUnicode(false);

            modelBuilder.Entity<login_log>()
                .Property(e => e.TimeOut)
                .IsUnicode(false);

            modelBuilder.Entity<login_log>()
                .Property(e => e.DateIn)
                .IsUnicode(false);

            modelBuilder.Entity<login_log>()
                .Property(e => e.DateOut)
                .IsUnicode(false);

            modelBuilder.Entity<market>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<market>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<market>()
                .Property(e => e.TimeZone)
                .IsUnicode(false);

            modelBuilder.Entity<market>()
                .Property(e => e.GMT_Offset)
                .IsUnicode(false);

            modelBuilder.Entity<market>()
                .Property(e => e.AccessNumber_ANI)
                .IsUnicode(false);

            modelBuilder.Entity<misc>()
                .Property(e => e.SettingName)
                .IsUnicode(false);

            modelBuilder.Entity<misc>()
                .Property(e => e.SettingValue)
                .IsUnicode(false);

            modelBuilder.Entity<mobile_carrier_account>()
                .Property(e => e.PassCode)
                .IsUnicode(false);

            modelBuilder.Entity<mobile_carrier_account>()
                .Property(e => e.Ani)
                .IsUnicode(false);

            modelBuilder.Entity<mobile_carrier_account>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<payment_plan_list>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<payment_plan_list>()
                .Property(e => e.Payment_Type)
                .IsUnicode(false);

            modelBuilder.Entity<payment_plan_list>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<payment_plan_list>()
                .Property(e => e.FileName_S)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.FIRST_ONE_CC)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.LAST_FOUR_CC)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.EXP_DATE)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.FULL_CC_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.CVC)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.ResponseReasonCode)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.ResponseText)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.ApprovalCode)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.AVSResultCode)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.TransactionID)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.registeredby)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.Amount)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.pd_callerid)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.Dnis)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.TollFree)
                .IsUnicode(false);

            modelBuilder.Entity<paymentdetail>()
                .Property(e => e.Source_Description)
                .IsUnicode(false);

            modelBuilder.Entity<serverdefn>()
                .Property(e => e.ServerId)
                .IsUnicode(false);

            modelBuilder.Entity<serverdefn>()
                .Property(e => e.IPADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<servicesource>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<servicesource>()
                .Property(e => e.AreaCode)
                .IsUnicode(false);

            modelBuilder.Entity<sms_queue_active>()
                .Property(e => e.SubscriberNo)
                .IsUnicode(false);

            modelBuilder.Entity<sms_queue_active>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<sms_queue_active>()
                .Property(e => e.Ticket_Id)
                .IsUnicode(false);

            modelBuilder.Entity<sms_queue_active>()
                .Property(e => e.ProgramId)
                .IsUnicode(false);

            modelBuilder.Entity<user_minute>()
                .Property(e => e.Grp_Id)
                .IsUnicode(false);

            modelBuilder.Entity<user_minute>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ws_agent>()
                .Property(e => e.WS_Username)
                .IsUnicode(false);

            modelBuilder.Entity<ws_agent>()
                .Property(e => e.WS_Password)
                .IsUnicode(false);

            modelBuilder.Entity<ws_agent>()
                .Property(e => e.AuthKey)
                .IsUnicode(false);

            modelBuilder.Entity<ws_agent>()
                .Property(e => e.IP_Address)
                .IsUnicode(false);
        }
    }
}
