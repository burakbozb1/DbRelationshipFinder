using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRelationships.Models
{
    public class Node
    {
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
        public List<Node> Nodes { get; set; }

        public Node(string tableName, string primaryKey, List<Node> nodes)
        {
            TableName = tableName;
            PrimaryKey = primaryKey;
            Nodes = nodes;
        }

        public Node(string tableName, string primaryKey)
        {
            TableName = tableName;
            PrimaryKey = primaryKey;
            Nodes = null;
        }

        public Node()
        {

        }
    }
}
