using DbRelationships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRelationships.HelperFunctions
{
    public static class PrintModel
    {

        /// <summary>
        /// Tek bir node'u ve bir seviye alt node'larını yazdırır.
        /// </summary>
        /// <param name="node"></param>
        public static void PrintNode(Node node)
        {
            Console.WriteLine("-----------");
            Console.WriteLine("Table Name: " + node.TableName);
            Console.WriteLine("Primary Key: " + node.PrimaryKey);
            foreach (var item in node.Nodes)
            {
                Console.WriteLine("Sub Node Table Name: " + item.TableName);
                Console.WriteLine("Sub Node Primary Key: " + item.PrimaryKey);
            }
            Console.WriteLine("-----------");
        }

        /// <summary>
        /// Node listesini bir alt seviye node'larıyla birlikte yazdırır.
        /// </summary>
        /// <param name="listNode"></param>
        public static void PrintNodes(List<Node> listNode)
        {
            foreach (var node in listNode)
            {
                Console.WriteLine("-----------");
                Console.WriteLine("Table Name: " + node.TableName);
                Console.WriteLine("Primary Key: " + node.PrimaryKey);
                if (node.Nodes != null)
                {
                    foreach (var item in node.Nodes)
                    {
                        Console.WriteLine("Sub Node Table Name: " + item.TableName);
                        Console.WriteLine("Sub Node Primary Key: " + item.PrimaryKey);
                    }
                }
                Console.WriteLine("-----------");

            }
        }

        /// <summary>
        /// Sadece bir ilişki modelini yazdırır.
        /// </summary>
        /// <param name="relation"></param>
        public static void PrintRelationshipModel(RelationshipModel relation)
        {
            Console.WriteLine("----------");
            Console.WriteLine("Main Table: " + relation.PrimaryTable);
            Console.WriteLine("Primary Key: " + relation.PrimaryKey);
            Console.WriteLine("Foreign Table: " + relation.ForeignTable);
            Console.WriteLine("Foreign Key: " + relation.ForeignKey);
            Console.WriteLine("Constraint Name: " + relation.ConstraintName);
            Console.WriteLine("----------");
        }

        /// <summary>
        /// Liste halinde verilen tüm ilişki modellerini yazdırır.
        /// </summary>
        /// <param name="list"></param>
        public static void PrintRelationshipModels(List<RelationshipModel> list)
        {
            foreach (var relation in list)
            {
                Console.WriteLine("----------");
                Console.WriteLine("Main Table: " + relation.PrimaryTable);
                Console.WriteLine("Primary Key: " + relation.PrimaryKey);
                Console.WriteLine("Foreign Table: " + relation.ForeignTable);
                Console.WriteLine("Foreign Key: " + relation.ForeignKey);
                Console.WriteLine("Constraint Name: " + relation.ConstraintName);
                Console.WriteLine("----------");
            }
        }

        /// <summary>
        /// Verilen Node'u ilişkileriyle birlikte yazdırır.
        /// </summary>
        /// <param name="resultList"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static int PrintAllRelations(Node node, int layer)
        {
            string gap = "";
            for (int i = 0; i < layer; i++)
            {
                gap += "\t";
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/result.txt";
            File.AppendAllLines(path, new[] { gap + node.TableName + "(" + node.PrimaryKey + ")" });
            Console.WriteLine(gap + node.TableName + "("+ node.PrimaryKey+")");
            if (node.Nodes !=null)
            {
                layer++;
                foreach (var item in node.Nodes)
                {
                    if (item.Nodes!=null)
                    {
                        item.Nodes = item.Nodes.OrderBy(x => x.TableName).ToList();
                    }
                    PrintAllRelations(item, layer);
                }
            }
            return layer--;
        }
    }
}
