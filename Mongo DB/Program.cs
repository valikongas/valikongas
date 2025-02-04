using MongoDB.Driver;

namespace Mongo_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<robot> robotai = TextFileService.CreateRobotFromFile();


            var client = new MongoClient ("mongodb+srv://gedas:Aaaaaa111999...@cluster0.0irtu.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var playlistColection =client.GetDatabase("Playlists").GetCollection < Playlist>("playlist");
            //List<Playlist> playlistbase = new List<Playlist> ();
            //for (int i = 0; i < 5; i++)
            //{
            //    var playlist = new Playlist("User"+i);
            //    var songs = new List<string>
            //    {
            //    "Highway to hell"+i
            //    };
            //    playlist.Items = songs;
            //    playlistbase.Add(playlist);
            //}
            //playlistColection.InsertMany(playlistbase);

            //var filter = Builders<Playlist>.Filter.Eq("Name", "Atnaujintas");
            //var result=playlistColection.Find(filter).ToList();

            // playlistColection.DeleteOne(filter);

            //var update = Builders<Playlist>.Update.AddToSet<string>("Items", "Song6");
            
            //playlistColection.UpdateMany(filter, update);

            //update = Builders<Playlist>.Update.Set<string>("Name", "Atnaujintas");
            //playlistColection.UpdateOne(filter, update);

            // regex bet kur
            //filter = Builders<Playlist>.Filter.Regex("Items", new MongoDB.Bson.BsonRegularExpression("hell"));
            //regex pradzioje
            //filter = Builders<Playlist>.Filter.Regex("Items", new MongoDB.Bson.BsonRegularExpression("^Hi"));
            ////regex gale
            //filter = Builders<Playlist>.Filter.Regex("Items", new MongoDB.Bson.BsonRegularExpression("2$"));
            //result = playlistColection.Find(filter).ToList();

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Name);
            //    foreach (var item2 in item.Items)
            //    { Console.WriteLine(item2); }
        }

    }
}
