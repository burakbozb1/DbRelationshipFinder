using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRelationships.Models
{

    public class RelationshipModel
    {
        public string PrimaryTable { get; set; }
        public string PrimaryKey { get; set; }
        public string ForeignTable { get; set; }
        public string ForeignKey { get; set; }
        public string ConstraintName { get; set; }

        public RelationshipModel(string primaryTable, string primaryKey, string foreignTable, string foreignKey, string constraintName)
        {
            PrimaryTable = primaryTable;
            PrimaryKey = primaryKey;
            ForeignTable = foreignTable;
            ForeignKey = foreignKey;
            ConstraintName = constraintName;
        }
    }
}
