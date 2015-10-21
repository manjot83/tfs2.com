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

namespace TFS.Intranet.Data.Billing{
    /// <summary>
    /// Strongly-typed collection for the BillingPeriodCityRatesJoin class.
    /// </summary>
    [Serializable]
    public partial class BillingPeriodCityRatesJoinCollection : ReadOnlyList<BillingPeriodCityRatesJoin, BillingPeriodCityRatesJoinCollection>
    {        
        public BillingPeriodCityRatesJoinCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_BillingPeriodCityRates_Join view.
    /// </summary>
    [Serializable]
    public partial class BillingPeriodCityRatesJoin : ReadOnlyRecord<BillingPeriodCityRatesJoin> 
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("vw_BillingPeriodCityRates_Join", TableType.View, DataService.GetInstance("Billing"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "id";
                colvarId.DataType = DbType.Int32;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarPeriodaccountid = new TableSchema.TableColumn(schema);
                colvarPeriodaccountid.ColumnName = "periodaccountid";
                colvarPeriodaccountid.DataType = DbType.Int32;
                colvarPeriodaccountid.MaxLength = 0;
                colvarPeriodaccountid.AutoIncrement = false;
                colvarPeriodaccountid.IsNullable = false;
                colvarPeriodaccountid.IsPrimaryKey = false;
                colvarPeriodaccountid.IsForeignKey = false;
                colvarPeriodaccountid.IsReadOnly = false;
                
                schema.Columns.Add(colvarPeriodaccountid);
                
                TableSchema.TableColumn colvarPeriodid = new TableSchema.TableColumn(schema);
                colvarPeriodid.ColumnName = "periodid";
                colvarPeriodid.DataType = DbType.Int32;
                colvarPeriodid.MaxLength = 0;
                colvarPeriodid.AutoIncrement = false;
                colvarPeriodid.IsNullable = false;
                colvarPeriodid.IsPrimaryKey = false;
                colvarPeriodid.IsForeignKey = false;
                colvarPeriodid.IsReadOnly = false;
                
                schema.Columns.Add(colvarPeriodid);
                
                TableSchema.TableColumn colvarAccountid = new TableSchema.TableColumn(schema);
                colvarAccountid.ColumnName = "accountid";
                colvarAccountid.DataType = DbType.Int32;
                colvarAccountid.MaxLength = 0;
                colvarAccountid.AutoIncrement = false;
                colvarAccountid.IsNullable = false;
                colvarAccountid.IsPrimaryKey = false;
                colvarAccountid.IsForeignKey = false;
                colvarAccountid.IsReadOnly = false;
                
                schema.Columns.Add(colvarAccountid);
                
                TableSchema.TableColumn colvarAccountname = new TableSchema.TableColumn(schema);
                colvarAccountname.ColumnName = "accountname";
                colvarAccountname.DataType = DbType.String;
                colvarAccountname.MaxLength = 100;
                colvarAccountname.AutoIncrement = false;
                colvarAccountname.IsNullable = false;
                colvarAccountname.IsPrimaryKey = false;
                colvarAccountname.IsForeignKey = false;
                colvarAccountname.IsReadOnly = false;
                
                schema.Columns.Add(colvarAccountname);
                
                TableSchema.TableColumn colvarGroupid = new TableSchema.TableColumn(schema);
                colvarGroupid.ColumnName = "groupid";
                colvarGroupid.DataType = DbType.Int32;
                colvarGroupid.MaxLength = 0;
                colvarGroupid.AutoIncrement = false;
                colvarGroupid.IsNullable = false;
                colvarGroupid.IsPrimaryKey = false;
                colvarGroupid.IsForeignKey = false;
                colvarGroupid.IsReadOnly = false;
                
                schema.Columns.Add(colvarGroupid);
                
                TableSchema.TableColumn colvarRategroupname = new TableSchema.TableColumn(schema);
                colvarRategroupname.ColumnName = "rategroupname";
                colvarRategroupname.DataType = DbType.String;
                colvarRategroupname.MaxLength = 100;
                colvarRategroupname.AutoIncrement = false;
                colvarRategroupname.IsNullable = false;
                colvarRategroupname.IsPrimaryKey = false;
                colvarRategroupname.IsForeignKey = false;
                colvarRategroupname.IsReadOnly = false;
                
                schema.Columns.Add(colvarRategroupname);
                
                TableSchema.TableColumn colvarRate = new TableSchema.TableColumn(schema);
                colvarRate.ColumnName = "rate";
                colvarRate.DataType = DbType.Double;
                colvarRate.MaxLength = 0;
                colvarRate.AutoIncrement = false;
                colvarRate.IsNullable = false;
                colvarRate.IsPrimaryKey = false;
                colvarRate.IsForeignKey = false;
                colvarRate.IsReadOnly = false;
                
                schema.Columns.Add(colvarRate);
                
                TableSchema.TableColumn colvarIsDeleted = new TableSchema.TableColumn(schema);
                colvarIsDeleted.ColumnName = "IsDeleted";
                colvarIsDeleted.DataType = DbType.Boolean;
                colvarIsDeleted.MaxLength = 0;
                colvarIsDeleted.AutoIncrement = false;
                colvarIsDeleted.IsNullable = false;
                colvarIsDeleted.IsPrimaryKey = false;
                colvarIsDeleted.IsForeignKey = false;
                colvarIsDeleted.IsReadOnly = false;
                
                schema.Columns.Add(colvarIsDeleted);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Billing"].AddSchema("vw_BillingPeriodCityRates_Join",schema);
            }

        }

        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    
	    #region .ctors
	    public BillingPeriodCityRatesJoin()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public BillingPeriodCityRatesJoin(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public BillingPeriodCityRatesJoin(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public BillingPeriodCityRatesJoin(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        public int Id 
	    {
		    get
		    {
			    return GetColumnValue<int>("id");
		    }

            set 
		    {
			    SetColumnValue("id", value);
            }

        }

	      
        [XmlAttribute("Periodaccountid")]
        public int Periodaccountid 
	    {
		    get
		    {
			    return GetColumnValue<int>("periodaccountid");
		    }

            set 
		    {
			    SetColumnValue("periodaccountid", value);
            }

        }

	      
        [XmlAttribute("Periodid")]
        public int Periodid 
	    {
		    get
		    {
			    return GetColumnValue<int>("periodid");
		    }

            set 
		    {
			    SetColumnValue("periodid", value);
            }

        }

	      
        [XmlAttribute("Accountid")]
        public int Accountid 
	    {
		    get
		    {
			    return GetColumnValue<int>("accountid");
		    }

            set 
		    {
			    SetColumnValue("accountid", value);
            }

        }

	      
        [XmlAttribute("Accountname")]
        public string Accountname 
	    {
		    get
		    {
			    return GetColumnValue<string>("accountname");
		    }

            set 
		    {
			    SetColumnValue("accountname", value);
            }

        }

	      
        [XmlAttribute("Groupid")]
        public int Groupid 
	    {
		    get
		    {
			    return GetColumnValue<int>("groupid");
		    }

            set 
		    {
			    SetColumnValue("groupid", value);
            }

        }

	      
        [XmlAttribute("Rategroupname")]
        public string Rategroupname 
	    {
		    get
		    {
			    return GetColumnValue<string>("rategroupname");
		    }

            set 
		    {
			    SetColumnValue("rategroupname", value);
            }

        }

	      
        [XmlAttribute("Rate")]
        public double Rate 
	    {
		    get
		    {
			    return GetColumnValue<double>("rate");
		    }

            set 
		    {
			    SetColumnValue("rate", value);
            }

        }

	      
        [XmlAttribute("IsDeleted")]
        public bool IsDeleted 
	    {
		    get
		    {
			    return GetColumnValue<bool>("IsDeleted");
		    }

            set 
		    {
			    SetColumnValue("IsDeleted", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"id";
            
            public static string Periodaccountid = @"periodaccountid";
            
            public static string Periodid = @"periodid";
            
            public static string Accountid = @"accountid";
            
            public static string Accountname = @"accountname";
            
            public static string Groupid = @"groupid";
            
            public static string Rategroupname = @"rategroupname";
            
            public static string Rate = @"rate";
            
            public static string IsDeleted = @"IsDeleted";
            
	    }

	    #endregion
    }

}

