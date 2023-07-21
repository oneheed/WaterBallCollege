// Ignore Spelling: Apnea

namespace PrescriberSystemApp.Prescriptions
{
    internal class SleepApneaSyndrome : Prescription
    {
        public override string Name => "打呼抑制劑";

        public override string PotentialDisease => "睡眠呼吸中止症（專業學名：SleepApneaSyndrome）";

        public override string Medicines => "一捲膠帶";

        public override string Usage => "睡覺時，撕下兩塊膠帶，將兩塊膠帶交錯黏在關閉的嘴巴上，就不會打呼了。";
    }
}
