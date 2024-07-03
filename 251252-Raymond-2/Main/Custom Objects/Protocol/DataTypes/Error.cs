namespace HMI.CO.Protocol
{
    public class Alarm
    {

        public Alarm()
        {
        }

        public int Order_Id { set; get; } = -1;
        public int Box_Id { set; get; } = -1;
        public int Charge_Id { set; get; } = -1;
        public int Layer_Id { set; get; } = -1;
        public int AlarmNr { set; get; } = 0;
        public string ActivationTime { set; get; } = "";
        public string DeactivationTime { set; get; } = "";
        public string LocalizableText { set; get; } = "";
        public string User { set; get; } = "";
    }
}
