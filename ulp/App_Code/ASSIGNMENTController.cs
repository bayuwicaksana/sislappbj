using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace Data
{
    /// <summary>
    /// Controller class for ASSIGNMENT
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ASSIGNMENTController
    {
        // Preload our schema..
        ASSIGNMENT thisSchemaLoad = new ASSIGNMENT();
    
        private string userName = string.Empty;
        Smarty.Builder builder = Smarty.Factory.CreateBuilder();
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ASSIGNMENTCollection FetchAll()
        {
            ASSIGNMENTCollection coll = new ASSIGNMENTCollection();
            Query qry = new Query(ASSIGNMENT.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        
        private ASSIGNMENTCollection GetPagedItems(ASSIGNMENTCollection all, int startRowIndex, int maximumRows)
        {
            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            int count = maximumRows + startRowIndex;
            if(all.Count < count)
            {
                count = all.Count;
            }

            for (int j = startRowIndex; j < count; ++j)
            {
                items.Add(all[j]);
            }

            return items;
        }

        
        private void BuildOrderBy(string expression, ref string field, ref string direction)
        {
            field = string.Empty;
            direction = string.Empty;
            if (!string.IsNullOrEmpty(expression))
            {
                int lastSpace = expression.LastIndexOf(' ');
                if (lastSpace > 0)
                {
                    DataProvider provider = DataService.Providers["MyProvider"];
                    field = expression.Substring(0, lastSpace);
                    //field = provider.DelimitDbName(field);
                    direction = expression.Substring(lastSpace + 1);
                }

            }

        }

        
        private string GetTop(int startRowIndex, int maximumRows)
        {
            return (startRowIndex + maximumRows).ToString();
        }

        
        public Comparison GetComparison(string sSearchOperation)
        {
            Comparison cmprzn = Comparison.Blank;
            switch (sSearchOperation)
            {
                case "Starts with ...":
                    cmprzn = Comparison.Like; break;
                case "Not Starts with ...":
                    cmprzn = Comparison.NotLike; break;
                case "Contains":
                    cmprzn = Comparison.Like; break;
                case "Not Contains":
                    cmprzn = Comparison.NotLike; break;
                case "Equals":
                    cmprzn = Comparison.Equals; break;
                case "Not Equals":
                    cmprzn = Comparison.NotEquals; break;
                case "More than ...":
                    cmprzn = Comparison.GreaterThan; break;
                case "Not More than ...":
                    cmprzn = Comparison.LessOrEquals; break;
                case "Less than ...":
                    cmprzn = Comparison.LessThan; break;
                case "Not Less than ...":
                    cmprzn = Comparison.GreaterOrEquals; break;
                case "Equal or more than ...":
                    cmprzn = Comparison.GreaterOrEquals; break;
                case "Not Equal or more than ...":
                    cmprzn = Comparison.LessThan; break;
                case "Equal or less than ...":
                    cmprzn = Comparison.LessOrEquals; break;
                case "Not Equal or less than ...":
                    cmprzn = Comparison.GreaterThan; break;
                case "Empty":
                    cmprzn = Comparison.Is; break;
                case "IsNull":
                    cmprzn = Comparison.Is; break;
                case "Not Empty":
                    cmprzn = Comparison.IsNot; break;
                case "Between":
                    cmprzn = Comparison.Between; break;
                case "Not Between":
                    cmprzn = Comparison.NotBetween; break;
                default:
                    cmprzn = Comparison.Blank; break;
            }

            return cmprzn;
        }

        
        private string GetValue(string sSearchOperation, Comparison cmprzn, object value, string column)
        {
            string sValue = null;
            if (value != null)
            {
                sValue = value.ToString().Trim();
                TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(column);
                sValue = BuildWhereValue(col, sValue, cmprzn, sSearchOperation);
                if (sValue == null)
                {
                    return null;
                }

            }

            return sValue;
        }

        
        private bool CanConvert(TableSchema.TableColumn col, string value)
        {
            try
            {
                Convert.ChangeType(value, col.GetPropertyType());
            }

            catch 
            { 
                return false; 
            }

            return  true;
        }

        
        private string BuildWhereValue(TableSchema.TableColumn col, string sValue, Comparison cmprzn, string sSearchOperation)
        {
            if (!CanConvert(col, sValue))
            {
                return null;
            }

            
            //sValue = sValue.ToUpper();
            DataProvider provider = DataService.Providers["MyProvider"];
            if (sSearchOperation == "Starts with ..." || sSearchOperation == "Not Starts with ...")
            {
                sValue = sValue + provider.LikeWildCharacter;
            }

            else if (sSearchOperation == "Contains" || sSearchOperation == "Not Contains")
            {
                sValue = provider.LikeWildCharacter + sValue + provider.LikeWildCharacter;
            }

            
            return sValue;
        }

        
        private void AddWhere(Query qry, DataProvider provider, string column, string cmprzn, string searchfor,  string searchfor2, bool isAdd, bool not)
        {
            if (not)
            {
                cmprzn = "Not " + cmprzn;
            }

            Comparison comp = GetComparison(cmprzn);
            string sValue = null;
            if(comp != Comparison.Is && comp != Comparison.IsNot)
            {
                sValue = searchfor.Trim();
            }

            string param = provider.GetParameterPrefix() + column;
            string properTableName = SubSonic.TableSchema.AbstractTableSchema.TransformClassName(qry.Schema.Name, false, ASSIGNMENT.Schema.TableType,provider);
            string columnName = builder.SubSonicTables[properTableName].Fields[column].Name;
            TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(columnName);
            if (!string.IsNullOrEmpty(sValue))
            {
                sValue = BuildWhereValue(col, searchfor, comp, cmprzn);
            }

            if (comp == Comparison.Between || comp == Comparison.NotBetween)
            {
                Where w1 = new Where();
                w1.ColumnName = columnName;
                if(comp == Comparison.Between)
                {
                    w1.Comparison = Comparison.GreaterOrEquals;
                }

                else
                {
                    w1.Comparison = Comparison.LessThan;
                }

                
                if(comp == Comparison.Between)
                {
                    w1.Condition = SubSonic.Where.WhereCondition.AND;
                }

                else
                {
                    w1.Condition = SubSonic.Where.WhereCondition.OR;
                }

                w1.DbType = col.DataType;
                w1.ParameterName = param;
                w1.ParameterValue = sValue;
                qry.AddWhere(w1);
                Where w2 = new Where();
                w2.ColumnName = columnName;
                if(comp == Comparison.Between)
                {
                    w2.Comparison = Comparison.LessOrEquals;
                }

                else
                {
                    w2.Comparison = Comparison.LessThan;
                }

                
                if(comp == Comparison.Between)
                {
                    w2.Condition = SubSonic.Where.WhereCondition.AND;
                }

                else
                {
                    w2.Condition = SubSonic.Where.WhereCondition.OR;
                }

                w2.DbType = col.DataType;
                w2.ParameterName = param + "2";
                w2.ParameterValue = BuildWhereValue(col, searchfor2, comp, cmprzn); 
                qry.AddWhere(w2);
            }

            else
            {
                Where w = new Where();
                w.ColumnName = columnName;
                w.Comparison = comp;
                
                if(isAdd)
                {
                    w.Condition = SubSonic.Where.WhereCondition.AND;
                }

                else
                {
                    w.Condition = SubSonic.Where.WhereCondition.OR;
                }

                
                w.ParameterName = param;
                w.ParameterValue = sValue;
                if (comp == Comparison.Like || comp == Comparison.NotLike)
                {
                    w.DbType = DbType.String;
                    qry.AddWhereIgnoreColumnType(w);
                }

                else
                {
                    w.DbType = col.DataType;
                    qry.AddWhere(w);
                }

            }

        }

        
        private void AddWhere(Query qry, DataProvider provider, string[] wheres, string[] values, bool isAdd, ref int i)
        {
            string where = wheres[i];
            string[] tokens = where.Split(new char[] { '&' }
);
            Comparison comp = GetComparison(tokens[0]);
            string column = tokens[1];
            string param = provider.GetParameterPrefix() + tokens[2];
            string sValue = null;
            if(comp != Comparison.Is && comp != Comparison.IsNot)
            {
                sValue = values[i].ToString().Trim();
            }

            TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(column);
            if (!string.IsNullOrEmpty(sValue))
            {
                sValue = BuildWhereValue(col, values[i], comp, tokens[0]);
            }

            if (comp == Comparison.Between || comp == Comparison.NotBetween)
            {
                Where w1 = new Where();
                w1.ColumnName = column;
                if(comp == Comparison.Between)
                {
                    w1.Comparison = Comparison.GreaterOrEquals;
                }

                else
                {
                    w1.Comparison = Comparison.LessThan;
                }

                
                if(comp == Comparison.Between)
                {
                    w1.Condition = SubSonic.Where.WhereCondition.AND;
                }

                else
                {
                    w1.Condition = SubSonic.Where.WhereCondition.OR;
                }

                w1.DbType = col.DataType;
                w1.ParameterName = param;
                w1.ParameterValue = sValue;
                qry.AddWhere(w1);
                Where w2 = new Where();
                w2.ColumnName = column;
                if(comp == Comparison.Between)
                {
                    w2.Comparison = Comparison.LessOrEquals;
                }

                else
                {
                    w2.Comparison = Comparison.LessThan;
                }

                
                if(comp == Comparison.Between)
                {
                    w2.Condition = SubSonic.Where.WhereCondition.AND;
                }

                else
                {
                    w2.Condition = SubSonic.Where.WhereCondition.OR;
                }

                w2.DbType = col.DataType;
                w2.ParameterName = param + "2";
                ++i;
                w2.ParameterValue = BuildWhereValue(col, values[i], comp, tokens[0]); ;
                qry.AddWhere(w2);
            }

            else
            {
                Where w = new Where();
                w.ColumnName = column;
                w.Comparison = comp;
                
                if(isAdd)
                {
                    w.Condition = SubSonic.Where.WhereCondition.AND;
                }

                else
                {
                    w.Condition = SubSonic.Where.WhereCondition.OR;
                }

                w.ParameterName = param;
                w.ParameterValue = sValue;
                if (comp == Comparison.Like || comp == Comparison.NotLike)
                {
                    w.DbType = DbType.String;
                    qry.AddWhereIgnoreColumnType(w);
                }

                else
                {
                    w.DbType = col.DataType;
                    qry.AddWhere(w);
                }

            }

        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<string> FetchForSearchSuggest(string column, object value, bool startsWith, string ownerCol, string userId)
        {
            string sValue = null;
            Comparison cmprzn = Comparison.Like;
            if (value != null)
            {
                sValue = value.ToString().Trim();
                TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(column);
                sValue = BuildWhereValue(col, sValue, cmprzn, startsWith ? "Starts with ..." : "Contains");
                if (sValue == null)
                {
                    return new List<string>();
                }

            }

            else
            {
                return new List<string>();
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            qry.Top = GetTop(0, 10);
            qry.SelectList = column;
            qry = qry.DISTINCT();
            if (!string.IsNullOrEmpty(column))
            {
                qry.OrderBy = OrderBy.Asc(Utility.QualifyColumnName("ASSIGNMENT", column, qry.Provider));
            }

            qry.AddWhereIgnoreColumnType(column, cmprzn, sValue, DbType.String);
            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            IDataReader reader =  DataService.GetReader(qry.BuildSelectCommand());
            List<string> items = new List<string>();
            while (reader.Read())
            {
                if(reader[0] != null)
                {
                    items.Add(reader[0].ToString());
                }

            }

            // Call Close when done reading.
            reader.Close();
            return items;
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchByParameter(string column, string sSearchOperation, object value, int startRowIndex, int maximumRows, string sortColumnsBy, string ownerCol, string userId, IDictionary<string, object> par)
        {
            string sValue;
            Comparison cmprzn;
            if (value != null)
            {
                sValue = value.ToString().Trim();
                TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(column);
                cmprzn = GetComparison(sSearchOperation);
                if (cmprzn == Comparison.Is)
                {
                    sValue = null;
                }

                else
                {
                    sValue = BuildWhereValue(col, sValue, cmprzn, sSearchOperation);
                    if (sValue == null)
                    {
                        return new ASSIGNMENTCollection();
                    }

                }

            }

            else
            {
                cmprzn = Comparison.Is;
                sValue = null;
            }

            
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.Top = GetTop(startRowIndex, maximumRows);
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
            {
                qry.AddWhereIgnoreColumnType(column, cmprzn, sValue, DbType.String);
            }

            else
            {
                qry.AddWhere(column, cmprzn, sValue);
            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            if (par != null)
            {
                foreach (string field in par.Keys)
                {
                    if (!string.IsNullOrEmpty(field))
                    {
                        qry.AddFilter(field, par[field]);
                    }

                }

            }

            
            IDataReader reader =  DataService.GetReader(qry.BuildSelectCommand());
            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(reader);
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchByParameter(string column, string sSearchOperation, object value, int startRowIndex, int maximumRows, string sortColumnsBy, string ownerCol, string userId)
        {
            string sValue;
            Comparison cmprzn;
            if (value != null)
            {
                sValue = value.ToString().Trim();
                TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(column);
                cmprzn = GetComparison(sSearchOperation);
                if (cmprzn == Comparison.Is)
                {
                    sValue = null;
                }

                else
                {
                    sValue = BuildWhereValue(col, sValue, cmprzn, sSearchOperation);
                    if (sValue == null)
                    {
                        return new ASSIGNMENTCollection();
                    }

                }

            }

            else
            {
                cmprzn = Comparison.Is;
                sValue = null;
            }

            
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.Top = GetTop(startRowIndex, maximumRows);
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
            {
                qry.AddWhereIgnoreColumnType(column, cmprzn, sValue, DbType.String);
            }

            else
            {
                qry.AddWhere(column, cmprzn, sValue);
            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            IDataReader reader =  DataService.GetReader(qry.BuildSelectCommand());
            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(reader);
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IDataReader FetchByParameter(string column, string sSearchOperation, object value, string sortColumnsBy, string ownerCol, string userId)
        {
            string sValue;
            Comparison cmprzn;
            if (value != null)
            {
                sValue = value.ToString().Trim();
                TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(column);
                cmprzn = GetComparison(sSearchOperation);
                if (cmprzn == Comparison.Is)
                {
                    sValue = null;
                }

                else
                {
                    sValue = BuildWhereValue(col, sValue, cmprzn, sSearchOperation);
                    if (sValue == null)
                    {
                        return null;
                    }

                }

            }

            else
            {
                cmprzn = Comparison.Is;
                sValue = null;
            }

            
            Query qry = new Query(ASSIGNMENT.Schema);
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
            {
                qry.AddWhereIgnoreColumnType(column, cmprzn, sValue, DbType.String);
            }

            else
            {
                qry.AddWhere(column, cmprzn, sValue);
            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            return DataService.GetReader(qry.BuildSelectCommand());
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchByAllParameters(string sSearchOperation, object value, int startRowIndex, int maximumRows, string sortColumnsBy, string ownerCol, string userId)
        {
            Comparison cmprzn = (value == null) ? Comparison.Is : GetComparison(sSearchOperation);
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.Top = GetTop(startRowIndex, maximumRows);
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            foreach (TableSchema.TableColumn col in ASSIGNMENT.Schema.Columns)
            {
                string sValue = BuildWhereValue(col, value.ToString(), cmprzn, sSearchOperation);
                if (string.IsNullOrEmpty(sValue))
                {
                    continue;
                }

                if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
                {
                    qry.AddWhereIgnoreColumnType(ASSIGNMENT.Schema.TableName,
                            Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                            col.ColumnName,
                            cmprzn,
                            sValue, 
                            SubSonic.Where.WhereCondition.OR,
                            DbType.String);
                }

                else
                {
                    qry.AddWhere(ASSIGNMENT.Schema.TableName,
                        Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                        col.ColumnName,
                        cmprzn,
                        sValue, 
                        SubSonic.Where.WhereCondition.OR);
                }

            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

              
            IDataReader reader = DataService.GetReader(qry.BuildSelectCommand());
            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(reader);
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchByAllParameters(string sSearchOperation, object value, int startRowIndex, int maximumRows, string sortColumnsBy, string ownerCol, string userId, IDictionary<string, object> par)
        {
            Comparison cmprzn = (value == null) ? Comparison.Is : GetComparison(sSearchOperation);
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.Top = GetTop(startRowIndex, maximumRows);
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            foreach (TableSchema.TableColumn col in ASSIGNMENT.Schema.Columns)
            {
                if (value == null)
                {
                    continue;
                }

                
                string sValue = value.ToString();
                if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
                {
                    qry.AddWhereIgnoreColumnType(ASSIGNMENT.Schema.TableName,
                            Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                            col.ColumnName,
                            cmprzn,
                            sValue, 
                            SubSonic.Where.WhereCondition.OR,
                            DbType.String);
                }

                else
                {
                    qry.AddWhere(ASSIGNMENT.Schema.TableName,
                        Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                        col.ColumnName,
                        cmprzn,
                        sValue, 
                        SubSonic.Where.WhereCondition.OR);
                }

            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            if (par != null)
            {
                foreach (string field in par.Keys)
                {
                    if (!string.IsNullOrEmpty(field))
                    {
                        qry.AddFilter(field, par[field]);
                    }

                }

            }

            
            IDataReader reader = DataService.GetReader(qry.BuildSelectCommand());
            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(reader);
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IDataReader FetchReaderByAllParameters(List<string> fields, string sSearchOperation, object value,  int startRowIndex, int maximumRows, string sortColumnsBy, string ownerCol, string userId)
        {
            Comparison cmprzn = (value == null) ? Comparison.Is : GetComparison(sSearchOperation);
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.Top = GetTop(startRowIndex, maximumRows);
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            StringBuilder selectList = new StringBuilder();
            foreach (string field in fields)
            {
                TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(field);
                selectList.Append(col.ColumnName).Append(",");
                string sValue = BuildWhereValue(col, value.ToString(), cmprzn, sSearchOperation);
                if (string.IsNullOrEmpty(sValue))
                {
                    continue;
                }

                
                if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
                {
                    qry.AddWhereIgnoreColumnType(ASSIGNMENT.Schema.TableName,
                            Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                            col.ColumnName,
                            cmprzn,
                            sValue,
                            SubSonic.Where.WhereCondition.OR,
                            DbType.String);
                }

                else
                {
                    qry.AddWhere(ASSIGNMENT.Schema.TableName,
                        Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                        col.ColumnName,
                        cmprzn,
                        sValue,
                        SubSonic.Where.WhereCondition.OR);
                }

            }

            if(selectList.Length > 0)
            {
                qry.SelectList  = selectList.ToString();
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            return DataService.GetReader(qry.BuildSelectCommand());
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<string> FetchForSearchSuggestAll(List<string> fields, object value, bool startsWith, string ownerCol, string userId)
        {
            IDataReader reader = FetchReaderByAllParameters(fields, startsWith ? "Starts with ..." : "Contains", value, 0, 10, "", ownerCol, userId);
            List<string> items = new List<string>();
            int i = 0;
            while (reader.Read() && i < 10)
            {
                foreach (string field in fields)
                {
                    if (reader[field] != null)
                    {
                        string val = reader[field].ToString();
                        if (startsWith)
                        {
                            if (val.StartsWith(value.ToString()))
                            {
                                items.Add(reader[field].ToString());
                                ++i;
                            }

                        }

                        else
                        {
                            if (val.Contains(value.ToString()))
                            {
                                items.Add(reader[field].ToString());
                                ++i;
                            }

                        }

                    }

                    if (i == 10)
                    {
                        break;
                    }

                }

            }

            return items;
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IDataReader FetchByAllParameters(string sSearchOperation, object value, string sortColumnsBy, string ownerCol, string userId)
        {
            Comparison cmprzn = (value == null) ? Comparison.Is : GetComparison(sSearchOperation);
            Query qry = new Query(ASSIGNMENT.Schema);
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            foreach (TableSchema.TableColumn col in ASSIGNMENT.Schema.Columns)
            {
                string sValue = BuildWhereValue(col, value.ToString(), cmprzn, sSearchOperation);
                if (string.IsNullOrEmpty(sValue))
                {
                    continue;
                }

                if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
                {
                    qry.AddWhereIgnoreColumnType(ASSIGNMENT.Schema.TableName,
                            Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                            col.ColumnName,
                            cmprzn,
                            sValue, 
                            SubSonic.Where.WhereCondition.OR,
                            DbType.String);
                }

                else
                {
                    qry.AddWhere(ASSIGNMENT.Schema.TableName,
                        Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                        col.ColumnName,
                        cmprzn,
                        sValue, 
                        SubSonic.Where.WhereCondition.OR);
                }

            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

                      
            return DataService.GetReader(qry.BuildSelectCommand());
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchByParameter(string condition, string sSearchOperation, object value, int startRowIndex, int maximumRows, string ownerCol, string userId)
        {
            Comparison cmprzn = GetComparison(sSearchOperation);
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.Top = GetTop(startRowIndex, maximumRows);
            TableSchema.Table schema = ASSIGNMENT.Schema;
            string sValue;
            foreach (TableSchema.TableColumn col in schema.Columns)
            {
                if (value == null)
                {
                    cmprzn = Comparison.Is;
                }

                else
                {
                    sValue = value.ToString();
                    sValue = BuildWhereValue(col, sValue, cmprzn, sSearchOperation);
                    if (sValue == null)
                    {
                        continue;
                    }

                    qry.AddWhere(ASSIGNMENT.Schema.TableName,
                        Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                        col.ColumnName,
                        cmprzn,
                        sValue, (condition == "OR") ? 
                        SubSonic.Where.WhereCondition.OR : SubSonic.Where.WhereCondition.AND);
                }

            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(DataService.GetReader(qry.BuildSelectCommand()));
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchForAdvancedSearch(string[] fields, 
            IDictionary<string, string> searchopt,
            IDictionary<string, string> searchfor,
            IDictionary<string, string> searchfor2,
            IDictionary<string, bool> searchnot, 
            bool isAdd, 
            int startRowIndex, 
            int maximumRows, 
            string sortColumnsBy, 
            string ownerCol, 
            string userId)
        {
            if (fields == null)
            {
                return new ASSIGNMENTCollection();
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            qry.Top = GetTop(startRowIndex, maximumRows);
            foreach (string field in fields)
            {
                if(!string.IsNullOrEmpty(searchfor[field]))
                {
                    AddWhere(qry, provider, field, searchopt[field], searchfor[field], searchfor2[field], isAdd, searchnot[field]);
                }

            }

            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchForAdvancedSearch(string[] fields, 
            IDictionary<string, string> searchopt,
            IDictionary<string, string> searchfor,
            IDictionary<string, string> searchfor2,
            IDictionary<string, bool> searchnot, 
            bool isAdd, 
            int startRowIndex, 
            int maximumRows, 
            string sortColumnsBy, 
            string ownerCol, 
            string userId,
            IDictionary<string, object> par)
        {
            if (fields == null)
            {
                return new ASSIGNMENTCollection();
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            qry.Top = GetTop(startRowIndex, maximumRows);
            foreach (string field in fields)
            {
                if(!string.IsNullOrEmpty(searchfor[field]))
                {
                    AddWhere(qry, provider, field, searchopt[field], searchfor[field], searchfor2[field], isAdd, searchnot[field]);
                }

            }

            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            if (par != null)
            {
                foreach (string field in par.Keys)
                {
                    if (!string.IsNullOrEmpty(field))
                    {
                        qry.AddFilter(field, par[field]);
                    }

                }

            }

            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchForDetails(
            IDictionary<string, object> par,
            string sortColumnsBy, 
            string ownerCol, 
            string userId)
        {
            if (par == null)
            {
                return new ASSIGNMENTCollection();
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            foreach (string field in par.Keys)
            {
                if(!string.IsNullOrEmpty(field))
                {
                    qry.AddWhere(field, Comparison.Equals, par[field]);
                }

            }

            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            return items;
        }

        
       [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchSelected(
            string[] columns,
            string[] selection,
            string sortColumnsBy, 
            string ownerCol, 
            string userId)
        {
            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            if(columns == null)
            {
                throw new ArgumentNullException("Cannot be null or empty", "columns");
            }

            if(selection == null)
            {
                throw new ArgumentNullException("Cannot be null or empty", "selection");
            }

            List<string> idTable = func.GetSelection(columns, selection);
            for (int i = 0; i < columns.Length; ++ i)
            {
                string[] ids = idTable[i].Split(new char[] { '\0' }
, StringSplitOptions.RemoveEmptyEntries);
                string column = columns[i];
                if (string.IsNullOrEmpty(column))
                {
                    throw new ArgumentNullException("Cannot be null or empty", "column");
                }

                if (i == 0 && columns.Length > 1)
                {
                    qry.AddWhere(column, ids[0]);
                }

                else
                {
                    qry.IN(column, ids);
                }

                
            }

            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            return items;
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchForDetails(
            IDictionary<string, object> par,
            int startRowIndex, 
            int maximumRows, 
            string sortColumnsBy, 
            string ownerCol, 
            string userId)
        {
            if (par == null)
            {
                return new ASSIGNMENTCollection();
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            qry.Top = GetTop(startRowIndex, maximumRows);
            foreach (string field in par.Keys)
            {
                if(!string.IsNullOrEmpty(field))
                {
                    qry.AddWhere(field, Comparison.Equals, par[field]);
                }

            }

            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        public int FetchForDetailsCount(
            IDictionary<string, object> par,
            string ownerCol, 
            string userId)
        {
            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            foreach (string field in par.Keys)
            {
                if(!string.IsNullOrEmpty(field))
                {
                    qry.AddWhere(field, Comparison.Equals, par[field]);
                }

            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            return qry.GetRecordCount();
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchForDetails(
            string masterColumn, 
            object[] masterids,
            string ownerCol, 
            string userId)
        {
            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            qry.IN(masterColumn, masterids);
            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            return items;
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchReaderByQuery(string sql, string parms, int startRowIndex, int maximumRows, string sortColumnsBy, string ownerCol, string userId)
        {
            if (string.IsNullOrEmpty(parms) || string.IsNullOrEmpty(sql))
            {
                return new ASSIGNMENTCollection();
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            qry.Top = GetTop(startRowIndex, maximumRows);
            string[] wheres = sql.Split(new string[] { " And ", " Or " }
, StringSplitOptions.RemoveEmptyEntries);
            string[] values = parms.Split(new char[] { '\0' }
, StringSplitOptions.RemoveEmptyEntries);
            bool isAdd = false;
            if(wheres.Length == 1)
            {
                isAdd = true;
            }

            else
            {
                isAdd = sql.Contains(" And ");
            }

            for (int i = 0; i <  wheres.Length; ++ i)
            {
                AddWhere(qry, provider, wheres, values, isAdd, ref i);
            }

	        
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

       
            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IDataReader FetchReaderByQuery(string sql, string parms, string sortColumnsBy, string ownerCol, string userId)
        {
            if (string.IsNullOrEmpty(parms) || string.IsNullOrEmpty(sql))
            {
                return null;
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            string[] wheres = sql.Split(new string[] { " And ", " Or " }
, StringSplitOptions.RemoveEmptyEntries);
            string[] values = parms.Split(new char[] { '\0' }
, StringSplitOptions.RemoveEmptyEntries);
            bool isAdd = false;
            if(wheres.Length == 1)
            {
                isAdd = true;
            }

            else
            {
                isAdd = sql.Contains(" And ");
            }

            for (int i = 0; i <  wheres.Length; ++ i)
            {
                AddWhere(qry, provider, wheres, values, isAdd, ref i);
            }

	        
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

       
            return qry.ExecuteReader();
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static IDataReader FetchReaderForFullTextSearch(string sFieldName, string sKeyFields, string ownerCol, string userId)
        {
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.SelectList = sFieldName;
            foreach (string s in sKeyFields.Split(";".ToCharArray()))
            {
                if (s.Split('=').Length != 2) continue;
                string sKeyFieldName = s.Split('=')[0];
                qry = qry.AddWhere(sKeyFieldName, s.Split('=')[1]);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            return qry.ExecuteReader();
        }

		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchByQuery(Query qry)
        {
            ASSIGNMENTCollection coll = new ASSIGNMENTCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IDataReader FetchReaderAll()
        {
            return ASSIGNMENT.FetchAll();
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IDataReader FetchReaderAll(string sortColumnsBy, string ownerCol, string userId)
        {
            Query qry = new Query(ASSIGNMENT.Schema);
	        
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
               string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

       
            return qry.ExecuteReader();
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENTCollection FetchAll(string sortColumnsBy, string ownerCol, string userId)
        {
            ASSIGNMENTCollection coll = new ASSIGNMENTCollection();
            Query qry = new Query(ASSIGNMENT.Schema);
	        
            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

       
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        
        // paging support
        public int FetchAllCount(string ownerCol, string userId)
        {
	        Query qry = new Query( ASSIGNMENT.Schema );
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

	        return qry.GetRecordCount();
        }

        
        public int FetchByParameterCount(string column, string sSearchOperation, object value, string ownerCol, string userId)
        {
            string sValue;
            Comparison cmprzn;
            if (value != null)
            {
                sValue = value.ToString().Trim();
                TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(column);
                cmprzn = GetComparison(sSearchOperation);
                if (cmprzn == Comparison.Is)
                {
                    sValue = null;
                }

                else
                {
                    sValue = BuildWhereValue(col, sValue, cmprzn, sSearchOperation);
                    if (sValue == null)
                    {
                        return 0;
                    }

                }

            }

            else
            {
                cmprzn = Comparison.Is;
                sValue = null;
            }

           
            Query qry = new Query(ASSIGNMENT.Schema);
            if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
            {
                qry.AddWhereIgnoreColumnType(column, cmprzn, sValue, DbType.String);
            }

            else
            {
                qry.AddWhere(column, cmprzn, sValue);
            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            return qry.GetRecordCount();
        }

        
        public int FetchByParameterCount(string column, string sSearchOperation, object value, string ownerCol, string userId, IDictionary<string, object> par)
        {
            string sValue;
            Comparison cmprzn;
            if (value != null)
            {
                sValue = value.ToString().Trim();
                TableSchema.TableColumn col = ASSIGNMENT.Schema.GetColumn(column);
                cmprzn = GetComparison(sSearchOperation);
                if (cmprzn == Comparison.Is)
                {
                    sValue = null;
                }

                else
                {
                    sValue = BuildWhereValue(col, sValue, cmprzn, sSearchOperation);
                    if (sValue == null)
                    {
                        return 0;
                    }

                }

            }

            else
            {
                cmprzn = Comparison.Is;
                sValue = null;
            }

           
            Query qry = new Query(ASSIGNMENT.Schema);
            if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
            {
                qry.AddWhereIgnoreColumnType(column, cmprzn, sValue, DbType.String);
            }

            else
            {
                qry.AddWhere(column, cmprzn, sValue);
            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            if (par != null)
            {
                foreach (string field in par.Keys)
                {
                    if (!string.IsNullOrEmpty(field))
                    {
                        qry.AddFilter(field, par[field]);
                    }

                }

            }

            
            return qry.GetRecordCount();
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int FetchByAllParametersCount(string sSearchOperation, object value, string ownerCol, string userId, IDictionary<string, object> par)
        {
            Comparison cmprzn = (value == null) ? Comparison.Is : GetComparison(sSearchOperation);
            Query qry = new Query(ASSIGNMENT.Schema);
            foreach (TableSchema.TableColumn col in ASSIGNMENT.Schema.Columns)
            {
                if (value == null)
                {
                    continue;
                }

                
                string sValue = value.ToString();
                if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
                {
                    qry.AddWhereIgnoreColumnType(ASSIGNMENT.Schema.TableName,
                            Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                            col.ColumnName,
                            cmprzn,
                            sValue, 
                            SubSonic.Where.WhereCondition.OR,
                            DbType.String);
                }

                else
                {
                    qry.AddWhere(ASSIGNMENT.Schema.TableName,
                        Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                        col.ColumnName,
                        cmprzn,
                        sValue, 
                        SubSonic.Where.WhereCondition.OR);
                }

            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            return qry.GetRecordCount();
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int FetchByAllParametersCount(string sSearchOperation, object value, string ownerCol, string userId)
        {
            Comparison cmprzn = (value == null) ? Comparison.Is : GetComparison(sSearchOperation);
            Query qry = new Query(ASSIGNMENT.Schema);
            foreach (TableSchema.TableColumn col in ASSIGNMENT.Schema.Columns)
            {
                string sValue = BuildWhereValue(col, value.ToString(), cmprzn, sSearchOperation);
                if (string.IsNullOrEmpty(sValue))
                {
                    continue;
                }

                if (cmprzn == Comparison.Like || cmprzn == Comparison.NotLike)
                {
                    qry.AddWhereIgnoreColumnType(ASSIGNMENT.Schema.TableName,
                            Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                            col.ColumnName,
                            cmprzn,
                            sValue, 
                            SubSonic.Where.WhereCondition.OR,
                            DbType.String);
                }

                else
                {
                    qry.AddWhere(ASSIGNMENT.Schema.TableName,
                        Utility.BuildParameterNameIgnorePrefix(col.ParameterName),
                        col.ColumnName,
                        cmprzn,
                        sValue, 
                        SubSonic.Where.WhereCondition.OR);
                }

            }

            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            return qry.GetRecordCount();
        }

        
        public int FetchForAdvancedSearchCount(string[] fields, 
            IDictionary<string, string> searchopt,
            IDictionary<string, string> searchfor,
            IDictionary<string, string> searchfor2,
            IDictionary<string, bool> searchnot, 
            bool isAdd, 
            int startRowIndex, 
            int maximumRows, 
            string sortColumnsBy, 
            string ownerCol, 
            string userId)
        {
            if (fields == null)
            {
                return 0;
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            qry.Top = GetTop(startRowIndex, maximumRows);
            foreach (string field in fields)
            {
                if(!string.IsNullOrEmpty(searchfor[field]))
                {
                    AddWhere(qry, provider, field, searchopt[field], searchfor[field], searchfor2[field], isAdd, searchnot[field]);
                }

            }

            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            return qry.GetRecordCount();
        }

        public int FetchForAdvancedSearchCount(string[] fields, 
            IDictionary<string, string> searchopt,
            IDictionary<string, string> searchfor,
            IDictionary<string, string> searchfor2,
            IDictionary<string, bool> searchnot, 
            bool isAdd, 
            int startRowIndex, 
            int maximumRows, 
            string sortColumnsBy, 
            string ownerCol, 
            string userId,
            IDictionary<string, object> par)
        {
            if (fields == null)
            {
                return 0;
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            qry.Top = GetTop(startRowIndex, maximumRows);
            foreach (string field in fields)
            {
                if(!string.IsNullOrEmpty(searchfor[field]))
                {
                    AddWhere(qry, provider, field, searchopt[field], searchfor[field], searchfor2[field], isAdd, searchnot[field]);
                }

            }

            if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            
            if (par != null)
            {
                foreach (string field in par.Keys)
                {
                    if (!string.IsNullOrEmpty(field))
                    {
                        qry.AddFilter(field, par[field]);
                    }

                }

            }

            return qry.GetRecordCount();
        }

        
        public int FetchReaderByQueryCount(string sql, string parms, string ownerCol, string userId)
        {
            if (string.IsNullOrEmpty(parms) || string.IsNullOrEmpty(sql))
            {
                return 0;
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            string[] wheres = sql.Split(new string[] { " And ", " Or " }
, StringSplitOptions.RemoveEmptyEntries);
            string[] values = parms.Split(new char[] { '\0' }
, StringSplitOptions.RemoveEmptyEntries);
            bool isAdd = false;
            if(wheres.Length == 1)
            {
                isAdd = true;
            }

            else
            {
                isAdd = sql.Contains(" And ");
            }

            for (int i = 0; i < wheres.Length; ++i)
            {
                AddWhere(qry, provider, wheres, values, isAdd, ref i);
            }

            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

            return qry.GetRecordCount();;
        }

        
        [DataObjectMethod( DataObjectMethodType.Select, false )]
        public ASSIGNMENTCollection FetchAllPaged(int startRowIndex, int maximumRows, string sortColumnsBy, string ownerCol, string userId)
        {
	        ASSIGNMENTCollection items = new ASSIGNMENTCollection();
	        Query qry = new Query( ASSIGNMENT.Schema );
	        qry.Top = GetTop(startRowIndex, maximumRows);
	        if (!string.IsNullOrEmpty(sortColumnsBy))
            {
                string field = string.Empty;
                string direction = string.Empty;
                BuildOrderBy(sortColumnsBy, ref field, ref direction);
                qry = qry.ORDER_BY(field, direction);
            }
 
            
            if (!string.IsNullOrEmpty(ownerCol) && !string.IsNullOrEmpty(userId))
            {
                qry.AddWhere(ownerCol, Comparison.Equals, userId);
            }

	        items.LoadAndCloseReader( qry.ExecuteReader() );
	        return GetPagedItems(items, startRowIndex, maximumRows);
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ASSIGNMENT FetchByManyID(IDictionary<string, object> par)
        {
            if (par == null)
            {
                return new ASSIGNMENT();
            }

            Query qry = new Query(ASSIGNMENT.Schema);
            DataProvider provider = DataService.Providers["MyProvider"];
            foreach (string field in par.Keys)
            {
                if(!string.IsNullOrEmpty(field))
                {
                    qry.AddWhere(field, Comparison.Equals, par[field]);
                }

            }

            ASSIGNMENTCollection items = new ASSIGNMENTCollection();
            items.LoadAndCloseReader(qry.ExecuteReader());
            if(items != null && items.Count > 0)
            {
                return items[0];
            }

            return new ASSIGNMENT();
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public string FetchFullText(IDictionary<string, object> par, string field)
        {
            if (par == null)
            {
                return null;
            }

            
            string result = string.Empty;
            Query qry = new Query(ASSIGNMENT.Schema);
            qry.SelectList = field;
            DataProvider provider = DataService.Providers["MyProvider"];
            foreach (string key in par.Keys)
            {
                if(!string.IsNullOrEmpty(field))
                {
                    qry.AddWhere(key, Comparison.Equals, par[key]);
                }

            }

            DbDataReader reader = (DbDataReader)qry.ExecuteReader();
            
            if (reader.Read())
            {
                result = reader.GetString(0);
            }

            // Call Close when done reading.
            reader.Close();
            
            return result;
        }

        
        
    }

}

