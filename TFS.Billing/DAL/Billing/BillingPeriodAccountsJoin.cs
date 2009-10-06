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
    /// Strongly-typed collection for the BillingPeriodAccountsJoin class.
    /// </summary>
    [Serializable]
    public partial class BillingPeriodAccountsJoinCollection : ReadOnlyList<BillingPeriodAccountsJoin, BillingPeriodAccountsJoinCollection>
    {        
        public BillingPeriodAccountsJoinCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_BillingPeriodAccounts_Join view.
    /// </summary>
    [Serializable]
    public partial class BillingPeriodAccountsJoin : ReadOnlyRecord<BillingPeriodAccountsJoin> 
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
                TableSchema.Table schema = new TableSchema.Table("vw_BillingPeriodAccounts_Join", TableType.View, DataService.GetInstance("Billing"));
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
                
                TableSchema.TableColumn colvarMonth = new TableSchema.TableColumn(schema);
                colvarMonth.ColumnName = "month";
                colvarMonth.DataType = DbType.Int32;
                colvarMonth.MaxLength = 0;
                colvarMonth.AutoIncrement = false;
                colvarMonth.IsNullable = false;
                colvarMonth.IsPrimaryKey = false;
                colvarMonth.IsForeignKey = false;
                colvarMonth.IsReadOnly = false;
                
                schema.Columns.Add(colvarMonth);
                
                TableSchema.TableColumn colvarYear = new TableSchema.TableColumn(schema);
                colvarYear.ColumnName = "year";
                colvarYear.DataType = DbType.Int32;
                colvarYear.MaxLength = 0;
                colvarYear.AutoIncrement = false;
                colvarYear.IsNullable = false;
                colvarYear.IsPrimaryKey = false;
                colvarYear.IsForeignKey = false;
                colvarYear.IsReadOnly = false;
                
                schema.Columns.Add(colvarYear);
                
                TableSchema.TableColumn colvarOpenuntil = new TableSchema.TableColumn(schema);
                colvarOpenuntil.ColumnName = "openuntil";
                colvarOpenuntil.DataType = DbType.DateTime;
                colvarOpenuntil.MaxLength = 0;
                colvarOpenuntil.AutoIncrement = false;
                colvarOpenuntil.IsNullable = false;
                colvarOpenuntil.IsPrimaryKey = false;
                colvarOpenuntil.IsForeignKey = false;
                colvarOpenuntil.IsReadOnly = false;
                
                schema.Columns.Add(colvarOpenuntil);
                
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
                
                TableSchema.TableColumn colvarPerdiemrate = new TableSchema.TableColumn(schema);
                colvarPerdiemrate.ColumnName = "perdiemrate";
                colvarPerdiemrate.DataType = DbType.Double;
                colvarPerdiemrate.MaxLength = 0;
                colvarPerdiemrate.AutoIncrement = false;
                colvarPerdiemrate.IsNullable = false;
                colvarPerdiemrate.IsPrimaryKey = false;
                colvarPerdiemrate.IsForeignKey = false;
                colvarPerdiemrate.IsReadOnly = false;
                
                schema.Columns.Add(colvarPerdiemrate);
                
                TableSchema.TableColumn colvarMileagerate = new TableSchema.TableColumn(schema);
                colvarMileagerate.ColumnName = "mileagerate";
                colvarMileagerate.DataType = DbType.Double;
                colvarMileagerate.MaxLength = 0;
                colvarMileagerate.AutoIncrement = false;
                colvarMileagerate.IsNullable = false;
                colvarMileagerate.IsPrimaryKey = false;
                colvarMileagerate.IsForeignKey = false;
                colvarMileagerate.IsReadOnly = false;
                
                schema.Columns.Add(colvarMileagerate);
                
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
                DataService.Providers["Billing"].AddSchema("vw_BillingPeriodAccounts_Join",schema);
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
	    public BillingPeriodAccountsJoin()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public BillingPeriodAccountsJoin(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public BillingPeriodAccountsJoin(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public BillingPeriodAccountsJoin(string columnName, object columnValue)
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

	      
        [XmlAttribute("Month")]
        public int Month 
	    {
		    get
		    {
			    return GetColumnValue<int>("month");
		    }

            set 
		    {
			    SetColumnValue("month", value);
            }

        }

	      
        [XmlAttribute("Year")]
        public int Year 
	    {
		    get
		    {
			    return GetColumnValue<int>("year");
		    }

            set 
		    {
			    SetColumnValue("year", value);
            }

        }

	      
        [XmlAttribute("Openuntil")]
        public DateTime Openuntil 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("openuntil");
		    }

            set 
		    {
			    SetColumnValue("openuntil", value);
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

	      
        [XmlAttribute("Perdiemrate")]
        public double Perdiemrate 
	    {
		    get
		    {
			    return GetColumnValue<double>("perdiemrate");
		    }

            set 
		    {
			    SetColumnValue("perdiemrate", value);
            }

        }

	      
        [XmlAttribute("Mileagerate")]
        public double Mileagerate 
	    {
		    get
		    {
			    return GetColumnValue<double>("mileagerate");
		    }

            set 
		    {
			    SetColumnValue("mileagerate", value);
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
            
            public static string Periodid = @"periodid";
            
            public static string Month = @"month";
            
            public static string Year = @"year";
            
            public static string Openuntil = @"openuntil";
            
            public static string Accountid = @"accountid";
            
            public static string Accountname = @"accountname";
            
            public static string Perdiemrate = @"perdiemrate";
            
            public static string Mileagerate = @"mileagerate";
            
            public static string IsDeleted = @"IsDeleted";
            
	    }

	    #endregion
    }

}

