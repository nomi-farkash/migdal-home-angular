using Microsoft.Extensions.Options;
using MongoDB.Driver;
using server.Models;
using server.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Net.Http.Json;

namespace server.Services
{
    

        public class GaragesService : IGaragesService
        {
            private readonly IMongoCollection<Garage> _garagesCollection;
            private readonly HttpClient _httpClient;
            private const string GovApiUrl =
                "https://data.gov.il/api/3/action/datastore_search?resource_id=bb68386a-a331-4bbc-b668-bba2766d517d&limit=5";

            public GaragesService(
                IOptions<MongoDbSettings> mongoSettings,
                IHttpClientFactory httpClientFactory)
            {
                var settings = mongoSettings.Value;
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.DatabaseName);
                _garagesCollection = database.GetCollection<Garage>(settings.CollectionName);

                _httpClient = httpClientFactory.CreateClient();
            }

            public async Task<List<Garage>> SyncFromGovAsync()
            {
                var response = await _httpClient.GetAsync(GovApiUrl);

                response.EnsureSuccessStatusCode();

                var govData = await response.Content.ReadFromJsonAsync<GovApiResponse>();

                if (govData?.Result?.Records == null)
                    return new List<Garage>();

                var garages = govData.Result.Records.Select(r => new Garage
                {
                    GovInternalId = r.InternalId,
                    MisparMosah = r.MisparMosah,
                    ShemMosah = r.ShemMosah,
                    CodSugMosah = r.CodSugMosah,
                    SugMosah = r.SugMosah,
                    Ktovet = r.Ktovet,
                    Yishuv = r.Yishuv,
                    Telephone = r.Telephone,
                    Mikud = r.Mikud,
                    CodMiktzoa = r.CodMiktzoa,
                    Miktzoa = r.Miktzoa,
                    MenahelMiktzoa = r.MenahelMiktzoa,
                    RashamHavarot = r.RashamHavarot,
                    Testime = r.Testime
                }).ToList();

                if (garages.Any())
                    await _garagesCollection.InsertManyAsync(garages);

                return garages;
            }

            public async Task<List<Garage>> GetAllAsync()
            {
                return await _garagesCollection.Find(_ => true).ToListAsync();
            }

            public async Task<Garage?> GetByIdAsync(string id)
            {
                return await _garagesCollection.Find(g => g.Id == id).FirstOrDefaultAsync();
            }

            public async Task<Garage> AddGarageAsync(Garage garage)
            {
                await _garagesCollection.InsertOneAsync(garage);
                return garage;
            }
        }
    

}
