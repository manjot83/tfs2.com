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
    /// Strongly-typed collection for the BillingCityRateJoin class.
    /// </summary>
    [Serializable]
    public partial class BillingCityRateJoinCollection : ReadOnlyList<BillingCityRateJoin, BillingCityRateJoinCollection>
    {        
        public BillingCityRateJoinCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_BillingCityRate_Join view.
    /// </summary>
    [Serializable]
    public partial class BillingCityRateJoin : ReadOnlyRecord<BillingCityRateJoin> 
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
                TableSchema.Table schema = new TableSchema.Table("vw_BillingCityRate_Join", TableType.View, DataService.GetInstance("Billing"));
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
                
                TableSchema.TableColumn colvarDefaultCityRateId = new TableSchema.TableColumn(schema);
                colvarDefaultCityRateId.ColumnName = "DefaultCityRateId";
                colvarDefaultCityRateId.DataType = DbType.Int32;
                colvarDefaultCityRateId.MaxLength = 0;
                colvarDefaultCityRateId.AutoIncrement = false;
                colvarDefaultCityRateId.IsNullable = false;
                colvarDefaultCityRateId.IsPrimaryKey = false;
                colvarDefaultCityRateId.IsForeignKey = false;
                colvarDefaultCityRateId.IsReadOnly = false;
                
                schema.Columns.Add(colvarDefaultCityRateId);


                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 250;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = false;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;

                schema.Columns.Add(colvarCity);


                TableSchema.TableColumn colvarPerDiemRate = new TableSchema.TableColumn(schema);
                colvarPerDiemRate.ColumnName = "PerDiemRate";
                colvarPerDiemRate.DataType = DbType.Double;
                colvarPerDiemRate.MaxLength = 0;
                colvarPerDiemRate.AutoIncrement = false;
                colvarPerDiemRate.IsNullable = false;
                colvarPerDiemRate.IsPrimaryKey = false;
                colvarPerDiemRate.IsForeignKey = false;
                colvarPerDiemRate.IsReadOnly = false;

                schema.Columns.Add(colvarPerDiemRate);
                
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
                DataService.Providers["Billing"].AddSchema("vw_BillingCityRate_Join",schema);
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
	    public BillingCityRateJoin()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public BillingCityRateJoin(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public BillingCityRateJoin(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public BillingCityRateJoin(string columnName, object columnValue)
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


        [XmlAttribute("DefaultCityRateId")]
        public int DefaultCityRateId 
	    {
		    get
		    {
                return GetColumnValue<int>("DefaultCityRateId");
		    }

            set 
		    {
                SetColumnValue("DefaultCityRateId", value);
            }

        }


        [XmlAttribute("City")]
        public string City 
	    {
		    get
		    {
                return GetColumnValue<string>("City");
		    }

            set 
		    {
                SetColumnValue("City", value);
            }

        }


        [XmlAttribute("PerDiemRate")]
        public double PerDiemRate 
	    {
		    get
		    {
                return GetColumnValue<double>("PerDiemRate");
		    }

            set 
		    {
                SetColumnValue("PerDiemRate", value);
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

            public static string DefaultCityRateId = @"DefaultCityRateId";

            public static string City = @"City";

            public static string PerDiemRate = @"PerDiemRate";
            
            public static string IsDeleted = @"IsDeleted";
            
	    }

	    #endregion
    }

}

