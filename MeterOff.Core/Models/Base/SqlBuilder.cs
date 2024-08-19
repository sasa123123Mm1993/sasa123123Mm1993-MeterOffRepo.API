using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base
{
    public class SqlBuilder
    {

        private MetersDataInput metersDataInput;

        private List<string> WhereList = new List<string>();
        private string Coloumns { get; set; }
        private string TableName { get; set; }
        private string JoinColoumn { get; set; }
        private string WhereConditions { get; set; }
        private string JoinCondition1 { get; set; }
        private string JoinCondition2 { get; set; }



        public SqlBuilder(MetersDataInput metersDataInput)
        {
            this.metersDataInput = metersDataInput;
        }
        public void SetSelectedColoumn(string coloumns)
        {
            this.Coloumns = coloumns;
        }

        public void SetTableName(string tableName)

        {
            this.TableName = tableName;
        }

        public void SetJoinColumn(string joinColoumn)

        {
            this.JoinColoumn = joinColoumn;
        }

        public void SetJoinCondition(string joinCondition1, string joinCondition2)

        {
            this.JoinCondition1 = joinCondition1;
            this.JoinCondition2 = joinCondition2;

        }


        public void SetWhere(string WhereCondition)
        {

            if (!string.IsNullOrEmpty(metersDataInput.SectorNo))
            {
                WhereList.Add("");
            }


            this.WhereConditions = WhereCondition;
        }


        public string Build()
        {
            try
            {
                // string.Join("AND ", WhereList);

                string Result = $"SELECT  {this.Coloumns} " +
                    $"FROM {this.TableName} " +
                    //$"INNER JOIN{this.TableName}"+"ON"+
                    //$"{this.JoinCondition1} = {this.JoinCondition2}"+
                    $"WHERE {this.WhereConditions} ";
                return Result;
            }
            catch (System.Exception)
            {
                return null;
            }
        }


    }
}
