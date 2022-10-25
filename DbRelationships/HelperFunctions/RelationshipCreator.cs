using DbRelationships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRelationships.HelperFunctions
{
    public static class RelationshipCreator
    {
        public static Node NodeCreator(Node node, List<Node> primaryNodes, List<Node> foreignNodes, List<RelationshipModel> relationships)
        {
            var allNodes = relationships.Where(x => x.PrimaryTable == node.TableName).ToList();
            Node newNode = new Node(node.TableName, node.PrimaryKey, new List<Node>());
            int j = 0;
            foreach (var item in allNodes)
            {
                var tmpNode = new Node(item.ForeignTable, item.ForeignKey, new List<Node>());
                if (item.PrimaryTable != item.ForeignTable)//Kendisiyle ilişkisi olan tablolarda sonsuz döngüye girilmesini önler.
                {
                    var foreignControl = primaryNodes.FirstOrDefault(y => y.TableName == item.ForeignTable);
                    if (foreignControl != null)
                    {
                        newNode.Nodes.Add(NodeCreator(tmpNode, primaryNodes, foreignNodes, relationships));
                    }
                    else
                    {
                        newNode.Nodes.Add(tmpNode);
                    }
                }
                else
                {
                    newNode.Nodes.Add(new Node(newNode.TableName + (" ***!!!It has relationship with itself!!!***"), newNode.PrimaryKey));
                }
            }
            return newNode;
        }
    }
}
