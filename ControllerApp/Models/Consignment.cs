using ControllerApp.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerApp.Models
{
    public class Consignment : IDbObject
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public static string MongoTableName => "Consignment";
        public static string LocalJsonFileName => Path.Combine(Constants.WorkingPath, "Consignment.Json");

        public override string ToString()
        {
            return $"Code: {Code}, Name: {Name}";
        }

        public static async Task UpdateLocalData()
        {
            IList<Consignment> consignments = await FindAllFromRemoteDatabase();

            JsonServices.SerializeToJson(consignments, LocalJsonFileName);
        }

        public static async Task CommitToRemoteBase()
        {
            IList<Consignment> remoteConsignments = await FindAllFromRemoteDatabase();
            IList<Consignment> localConsignments = FindAllLocalConsignment();

            foreach (Consignment local in localConsignments)
                if (!remoteConsignments.Any(r => r.Code == local.Code))
                    await DatabaseService.Instance.SaveAsync(local);

            foreach (Consignment remote in remoteConsignments)
                if (!localConsignments.Any(l => l.Code == remote.Code))
                    await DatabaseService.Instance.DeleteAsync<Consignment>(remote.Code, MongoTableName);
        }

        public static async Task<IList<Consignment>> FindAllFromRemoteDatabase()
        {
            IList<Consignment> consignments = await DatabaseService.Instance.FindAllAsync<Consignment>(MongoTableName);

            return consignments;
        }

        public static IList<Consignment> FindAllLocalConsignment()
        {
            if (File.Exists(LocalJsonFileName))
            {
                string json = File.ReadAllText(LocalJsonFileName);

                List<Consignment> localConsignments = [];

                if (JsonServices.DeserializeFromJson<List<Consignment>>(json) is List<Consignment> deserialized)
                    localConsignments = deserialized;

                return localConsignments;
            }

            return [];
        }


        public static void DeleteLocalConsignment(Consignment consignment)
        {
            if (File.Exists(LocalJsonFileName))
            {
                string json = File.ReadAllText(LocalJsonFileName);
                List<Consignment> localConsignments = [];

                if (JsonServices.DeserializeFromJson<List<Consignment>>(json) is List<Consignment> deserialized)
                    localConsignments = deserialized;

                if (localConsignments.Any(a => a.Code == consignment.Code))
                {
                    localConsignments.RemoveAll(r => r.Code == consignment.Code);
                    JsonServices.SerializeToJson(localConsignments, LocalJsonFileName);
                }
                else
                {
                    throw new System.Exception($"Consignment with code {consignment.Code} does not exist in local data.");
                }
            }
        }

        public static void AddLocalConsignment(Consignment consignment)
        {
            if (File.Exists(LocalJsonFileName))
            {
                string json = File.ReadAllText(LocalJsonFileName);

                List<Consignment> localConsignments = [];

                if (JsonServices.DeserializeFromJson<List<Consignment>>(json) is List<Consignment> deserialized)
                    localConsignments = deserialized;

                if (!localConsignments.Any(a => a.Code == consignment.Code))
                {
                    localConsignments.Add(consignment);
                    JsonServices.SerializeToJson(localConsignments, LocalJsonFileName);
                }
                else
                {
                    throw new System.Exception($"Consignment with code {consignment.Code} already exists in local data.");
                }
            }
        }
    }
}
