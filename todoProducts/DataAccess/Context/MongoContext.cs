using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoProducts.DataAccess.Context
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        private readonly List<Func<Task>> _commands;

        public MongoContext(IConfiguration configuration)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy; //?
            _commands = new List<Func<Task>>();
            RegisterConventions();

            var client = new MongoClient(configuration.GetSection("MongoSettings").GetSection("ConnectionString").Value);
            Database = client.GetDatabase("coffee");



            //MongoClientSettings settings = new MongoClientSettings
            //{
            //    Server = new MongoServerAddress(
            //        host: configuration.GetSection("MongoSettings").GetSection("Host").Value,
            //        port: int.Parse(configuration.GetSection("MongoSettings").GetSection("Port").Value)),
            //    UseTls = false,
            //    Credential = MongoCredential.CreateCredential(
            //        databaseName: configuration.GetSection("MongoSettings").GetSection("DatabaseName").Value,
            //        username: configuration.GetSection("MongoSettings").GetSection("Username").Value,
            //        password: configuration.GetSection("MongoSettings").GetSection("Passowrd").Value)
            //};

            //var mongoClient = new MongoClient(settings);
            //Database = mongoClient.GetDatabase(configuration.GetSection("MongoSettings").GetSection("DatabaseName").Value);
        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("Solution Conventions", pack, t => true);
        }

        public async Task<int> SaveChanges()
        {
            var commandTasks = _commands.Select(c => c()); //? c()
            await Task.WhenAll(commandTasks);
            return _commands.Count; //? jak to czytać?
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}