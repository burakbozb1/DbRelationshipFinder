using DbRelationships.HelperFunctions;
using DbRelationships.Models;
using Microsoft.Data.SqlClient;
using System.Text.Json;

List<RelationshipModel> relationships = new List<RelationshipModel>();
List<Node> primaryNodes = new List<Node>();
List<Node> foreignNodes = new List<Node>(); List<Node> allTables = new List<Node>();
string connectionString = "Data Source=DESKTOP-5SNSKC0;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=1234;TrustServerCertificate=True";
SqlConnection cnn = new SqlConnection(connectionString);
try
{
    cnn.Open();
    SqlCommand command;
    SqlDataReader dataReader;
    string sql = @"select schema_name(fk_tab.schema_id) + '.' + fk_tab.name as foreign_table,
        '>-' as rel,
        schema_name(pk_tab.schema_id) + '.' + pk_tab.name as primary_table,
        fk_cols.constraint_column_id as no,
        fk_col.name as fk_column_name,
        ' = ' as [join],
        pk_col.name as pk_column_name,
        fk.name as fk_constraint_name
    from sys.foreign_keys fk
        inner
    join sys.tables fk_tab

    on fk_tab.object_id = fk.parent_object_id

    inner
    join sys.tables pk_tab

    on pk_tab.object_id = fk.referenced_object_id

    inner
    join sys.foreign_key_columns fk_cols

    on fk_cols.constraint_object_id = fk.object_id

    inner
    join sys.columns fk_col

    on fk_col.column_id = fk_cols.parent_column_id

    and fk_col.object_id = fk_tab.object_id
        inner join sys.columns pk_col
            on pk_col.column_id = fk_cols.referenced_column_id
            and pk_col.object_id = pk_tab.object_id
    order by schema_name(pk_tab.schema_id) + '.' + pk_tab.name";
    command = new SqlCommand(sql, cnn);
    dataReader = command.ExecuteReader();
    while (dataReader.Read())
    {
        RelationshipModel tmpModel = new RelationshipModel(dataReader.GetValue(2).ToString(),
            dataReader.GetValue(6).ToString(),
            dataReader.GetValue(0).ToString(),
            dataReader.GetValue(4).ToString(),
            dataReader.GetValue(7).ToString());
        relationships.Add(tmpModel);
    }
    dataReader.Close();
    command.Dispose();
    cnn.Close();


    List<string> prTables = new List<string>();
    List<string> frTables = new List<string>();
    List<string> allTableNames = new List<string>();
    relationships.GroupBy(x => x.PrimaryTable).ToList().ForEach(y => prTables.Add(y.Key));
    relationships.GroupBy(x => x.ForeignTable).ToList().ForEach(y => frTables.Add(y.Key));


    allTableNames = prTables.Union(frTables).ToList();

    foreach (var item in allTableNames)
    {
        foreach (var rl in relationships)
        {
            if (item == rl.PrimaryTable)
            {
                var control = primaryNodes.FirstOrDefault(x => x.TableName == item);
                if (control == null)
                {
                    primaryNodes.Add(new Node(rl.PrimaryTable, rl.PrimaryKey));
                }
            }
            else if (item == rl.ForeignTable)
            {
                var control = foreignNodes.FirstOrDefault(x => x.TableName == item);
                if (control == null)
                {
                    foreignNodes.Add(new Node(rl.ForeignTable, rl.ForeignKey));
                }
            }
        }
    }

    List<Node> resultTable = new List<Node>();
    foreach (var item in primaryNodes)
    {
        resultTable.Add(RelationshipCreator.NodeCreator(item, primaryNodes, foreignNodes, relationships));
    }

    //Console.WriteLine("PRIMARY NODES");
    //PrintModel.PrintNodes(primaryNodes);
    //Console.WriteLine();
    //Console.WriteLine();
    //Console.WriteLine("FOREIGN MODELS");
    //PrintModel.PrintNodes(foreignNodes);


    //Result
    foreach (var item in resultTable)
    {
        item.Nodes = item.Nodes.OrderBy(x => x.TableName).ToList();
        var x = PrintModel.PrintAllRelations(item,0);
    }

    //Altta verilen satır ilişki modelini json olarak verir.
    //string jsonString = JsonSerializer.Serialize(resultTable);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}