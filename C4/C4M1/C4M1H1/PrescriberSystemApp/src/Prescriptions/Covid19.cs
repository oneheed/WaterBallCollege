// Ignore Spelling: COVID

namespace PrescriberSystemApp.Prescriptions
{
    internal class Covid19 : Prescription
    {
        public override string Name => "清冠一號";

        public override string PotentialDisease => "新冠肺炎（專業學名：COVID-19）";

        public override string Medicines => "清冠一號";

        public override string Usage => "將相關藥材裝入茶包裡，使用500 mL 溫、熱水沖泡悶煮1~3 分鐘後即可飲用";
    }
}
