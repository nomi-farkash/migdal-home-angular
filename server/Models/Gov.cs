using System.Text.Json.Serialization;

namespace server.Models
{


    public class GovApiResponse
    {
        [JsonPropertyName("result")]
        public GovResult Result { get; set; }
    }

    public class GovResult
    {
        [JsonPropertyName("records")]
        public List<GovGarageRecord> Records { get; set; }
    }

    public class GovGarageRecord
    {
        [JsonPropertyName("_id")]
        public int InternalId { get; set; }

        [JsonPropertyName("mispar_mosah")]
        public int MisparMosah { get; set; }

        [JsonPropertyName("shem_mosah")]
        public string ShemMosah { get; set; }

        [JsonPropertyName("cod_sug_mosah")]
        public int CodSugMosah { get; set; }

        [JsonPropertyName("sug_mosah")]
        public string SugMosah { get; set; }

        [JsonPropertyName("ktovet")]
        public string Ktovet { get; set; }

        [JsonPropertyName("yishuv")]
        public string Yishuv { get; set; }

        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }

        [JsonPropertyName("mikud")]
        public int Mikud { get; set; }

        [JsonPropertyName("cod_miktzoa")]
        public int CodMiktzoa { get; set; }

        [JsonPropertyName("miktzoa")]
        public string Miktzoa { get; set; }

        [JsonPropertyName("menahel_miktzoa")]
        public string MenahelMiktzoa { get; set; }

        [JsonPropertyName("rasham_havarot")]
        public long RashamHavarot { get; set; }

        [JsonPropertyName("TESTIME")]
        public string Testime { get; set; }
    }
}