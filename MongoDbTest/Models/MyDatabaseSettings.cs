Myusing System;

using Microsoft.Extensions.Options;
using MongoDbTest.Models;

namespace MongoDbTest.Models
{
    public class MyDatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}
