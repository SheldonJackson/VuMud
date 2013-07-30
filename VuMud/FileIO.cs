using System.Xml;
using System.Xml.Serialization;
using Creatures;

namespace VuMud {
    public class FileIO {
        public void ExportCreature(string filename, Creature creature)
        {
            using (XmlWriter writer = XmlWriter.Create(filename))
            {
                var serializer = new XmlSerializer(creature.GetType());
                serializer.Serialize(writer, creature);
            }
            
        }
    }
}

