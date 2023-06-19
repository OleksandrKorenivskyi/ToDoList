using DataLayer;
using GraphQL.Types;

namespace ToDoListReact.GraphQL.Types
{
    public class DataStorageEnumerationType : EnumerationGraphType<DataStorageType>
    {
        public DataStorageEnumerationType() 
        {
            Name = "DataStorage";
            Description = "The storage to retrieve data from.";
            Add("DATABASE", DataStorageType.Database, "Database");
            Add("XML_FILE", DataStorageType.XmlFile, "XML file");
        }
    }
}
