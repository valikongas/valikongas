

namespace Mongo_DB
{
    public static class TextFileService
    {
        public static List<robot> CreateRobotFromFile ()
        {
            string path = @"C:\Users\gedasvalikonis\Documents\GitHub\valikongas\Mongo DB\robotai.txt";
            string [] fileContent=File.ReadAllLines(path);
            List<robot> robots = new List<robot> ();
            var arms = new List<Arm>();

            foreach (string line in fileContent)
            {
                string[] strings = line.Split(',');
                robot robot = new robot();
                robot.Id = int.Parse(strings[0]);
                
               arms.Add(new Arm
                {
                    Material = strings[1],                  // Pirmas elementas - Material
                    NumberOfJoints = int.Parse(strings[2]), // Antras elementas - NumberOfJoints
                    NumberOfFingers = int.Parse(strings[3]) // Trečias elementas - NumberOfFingers
                });
                Leg leg = new Leg
                {
                    Material = strings[4],
                    NumberOfJoints = int.Parse(strings[5]),
                    SizeOfFoot = int.Parse(strings[6])
                };
                Torso torso = new Torso();
                torso.ChestMeasurements = double.Parse(strings[7]);
                torso.WaistMeasurements = double.Parse(strings[8]);
                robot.Head = (Head)int.Parse(strings[9]);
                robots.Add(robot);
            }
                




            
            return robots;
        }

    }
}
