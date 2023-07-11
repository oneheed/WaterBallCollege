// Ignore Spelling: COVID

namespace C4M1_PrescriberSystem_.Models.Prescriptions
{
    internal class Covid19 : IPrescription
    {
        public string Name => "清冠一號";

        public string PotentialDisease => "新冠肺炎（專業學名：COVID-19）";

        public string Medicines => "清冠一號";

        public string Usage => "將相關藥材裝入茶包裡，使用500 mL 溫、熱水沖泡悶煮1~3 分鐘後即可飲用";
    }
}
