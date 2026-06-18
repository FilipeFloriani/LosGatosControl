using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ControllerApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ControllerApp.Repository
{

    public class DatabaseService
    {
        private const string DbUser = "filipe300398_db_user";
        private const string DbPwd = "DUJt4HoeJL4Oi8Ht";

        //private static string ConnectionString = $"mongodb+srv://{DbUser}:{DbPwd}@cluster.qj9klai.mongodb.net/?retryWrites=true&w=majority&appName=Cluster";
        private static string ConnectionString = $"mongodb+srv://filipe300398_db_user:{DbPwd}@cluster.qj9klai.mongodb.net/?appName=Cluster";

        public static DatabaseService _instance;
        public static DatabaseService Instance {
            get
            { 
                if (_instance == null)
                    _instance = new DatabaseService();
                 
                return _instance;
            }
            set { _instance = value; }
        }

        private readonly IMongoDatabase _database;

        public DatabaseService()
        {
            var client = new MongoClient(ConnectionString);

            _database = client.GetDatabase("ControllerApp");

            _instance = this;
        }

        public async Task SaveAsync<T>(T obj)
        {
            await _database
                  .GetCollection<T>(typeof(T).Name)
                  .InsertOneAsync(obj);
        }

        public async Task DeleteAsync<T>(string code, string collectionName) where T : IDbObject
        {
            await _database
                .GetCollection<T>(collectionName)
                .DeleteOneAsync(c => c.Code == code);
        }

        public async Task<List<T>> FindAllAsync<T>(string collectionName)
        {
            try
            {
                return await _database
                            .GetCollection<T>(collectionName)
                            .Find(_ => true)
                            .ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error fetching data from collection {collectionName}: {e.Message}"); 
                Debug.WriteLine(e);
                return null;
            }

        }
    }
}
