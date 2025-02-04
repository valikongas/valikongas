
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo_DB
{
    internal class Playlist
    {
        public ObjectId Id {  get; set; }
        public string Name { get; set; } = null!;
        public List<string> Items { get; set; } = null!;
        public Playlist(string name)
        {
            Name=name;
            Items = new List<string>();
        }
    }
}
