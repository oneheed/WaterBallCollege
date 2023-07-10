namespace C4M1_PrescriberSystem_.Models.Prescriptions
{
    internal class SleepApneaSyndrome : IPrescription
    {
        public string Name => "打呼抑制劑";

        public string PotentialDisease => "睡眠呼吸中止症（專業學名：SleepApneaSyndrome）";

        public string Medicines => "一捲膠帶";

        public string Usage => "睡覺時，撕下兩塊膠帶，將兩塊膠帶交錯黏在關閉的嘴巴上，就不會打呼了。";
    }
}
