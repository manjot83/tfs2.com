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
    /// Strongly-typed collection for the PeriodAccountInfo class.
    /// </summary>
    [Serializable]
    public partial class PeriodAccountInfoCollection : ReadOnlyList<PeriodAccountInfo, PeriodAccountInfoCollection>
    {        
        public PeriodAccountInfoCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_PeriodAccountInfo view.
    /// </summary>
    [Serializable]
    public partial class PeriodAccountInfo : ReadOnlyRecord<PeriodAccountInfo> 
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
                TableSchema.Table schema = new TableSchema.Table("vw_PeriodAccountInfo", TableType.View, DataService.GetInstance("Billing"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarBillingperiodaccountid = new TableSchema.TableColumn(schema);
                colvarBillingperiodaccountid.ColumnName = "billingperiodaccountid";
                colvarBillingperiodaccountid.DataType = DbType.Int32;
                colvarBillingperiodaccountid.MaxLength = 0;
                colvarBillingperiodaccountid.AutoIncrement = false;
                colvarBillingperiodaccountid.IsNullable = false;
                colvarBillingperiodaccountid.IsPrimaryKey = false;
                colvarBillingperiodaccountid.IsForeignKey = false;
                colvarBillingperiodaccountid.IsReadOnly = false;
                
                schema.Columns.Add(colvarBillingperiodaccountid);
                
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
                
                TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
                colvarName.ColumnName = "name";
                colvarName.DataType = DbType.String;
                colvarName.MaxLength = 100;
                colvarName.AutoIncrement = false;
                colvarName.IsNullable = false;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                
                schema.Columns.Add(colvarName);
                
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
                DataService.Providers["Billing"].AddSchema("vw_PeriodAccountInfo",schema);
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
	    public PeriodAccountInfo()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public PeriodAccountInfo(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public PeriodAccountInfo(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public PeriodAccountInfo(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Billingperiodaccountid")]
        public int Billingperiodaccountid 
	    {
		    get
		    {
			    return GetColumnValue<int>("billingperiodaccountid");
		    }

            set 
		    {
			    SetColumnValue("billingperiodaccountid", value);
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

	      
        [XmlAttribute("Name")]
        public string Name 
	    {
		    get
		    {
			    return GetColumnValue<string>("name");
		    }

            set 
		    {
			    SetColumnValue("name", value);
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
		    
		    
            public static string Billingperiodaccountid = @"billingperiodaccountid";
            
            public static string Periodid = @"periodid";
            
            public static string Accountid = @"accountid";
            
            public static string Name = @"name";
            
            public static string Month = @"month";
            
            public static string Year = @"year";
            
            public static string Openuntil = @"openuntil";
            
            public static string IsDeleted = @"IsDeleted";
            
	    }

	    #endregion
    }

}

