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
    /// Strongly-typed collection for the TimesheetBillingCityRateJoin class.
    /// </summary>
    [Serializable]
    public partial class TimesheetBillingCityRateJoinCollection : ReadOnlyList<TimesheetBillingCityRateJoin, TimesheetBillingCityRateJoinCollection>
    {        
        public TimesheetBillingCityRateJoinCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_TimesheetBillingCityRate_Join view.
    /// </summary>
    [Serializable]
    public partial class TimesheetBillingCityRateJoin : ReadOnlyRecord<TimesheetBillingCityRateJoin> 
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
                TableSchema.Table schema = new TableSchema.Table("vw_TimesheetBillingCityRate_Join", TableType.View, DataService.GetInstance("Billing"));
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

                TableSchema.TableColumn colvarTimesheetId = new TableSchema.TableColumn(schema);
                colvarTimesheetId.ColumnName = "TimesheetId";
                colvarTimesheetId.DataType = DbType.Int32;
                colvarTimesheetId.MaxLength = 0;
                colvarTimesheetId.AutoIncrement = false;
                colvarTimesheetId.IsNullable = false;
                colvarTimesheetId.IsPrimaryKey = false;
                colvarTimesheetId.IsForeignKey = false;
                colvarTimesheetId.IsReadOnly = false;

                schema.Columns.Add(colvarTimesheetId);

                TableSchema.TableColumn colvarBillingCityRateId = new TableSchema.TableColumn(schema);
                colvarBillingCityRateId.ColumnName = "BillingCityRateId";
                colvarBillingCityRateId.DataType = DbType.Int32;
                colvarBillingCityRateId.MaxLength = 0;
                colvarBillingCityRateId.AutoIncrement = false;
                colvarBillingCityRateId.IsNullable = false;
                colvarBillingCityRateId.IsPrimaryKey = false;
                colvarBillingCityRateId.IsForeignKey = false;
                colvarBillingCityRateId.IsReadOnly = false;

                schema.Columns.Add(colvarBillingCityRateId);
                
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

                TableSchema.TableColumn colvarPerdiemCount = new TableSchema.TableColumn(schema);
                colvarPerdiemCount.ColumnName = "PerdiemCount";
                colvarPerdiemCount.DataType = DbType.Int32;
                colvarPerdiemCount.MaxLength = 0;
                colvarPerdiemCount.AutoIncrement = false;
                colvarPerdiemCount.IsNullable = false;
                colvarPerdiemCount.IsPrimaryKey = false;
                colvarPerdiemCount.IsForeignKey = false;
                colvarPerdiemCount.IsReadOnly = false;
                
                schema.Columns.Add(colvarPerdiemCount);


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
                DataService.Providers["Billing"].AddSchema("vw_TimesheetBillingCityRate_Join",schema);
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
	    public TimesheetBillingCityRateJoin()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public TimesheetBillingCityRateJoin(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public TimesheetBillingCityRateJoin(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public TimesheetBillingCityRateJoin(string columnName, object columnValue)
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

        [XmlAttribute("TimesheetId")]
        public int TimesheetId
        {
            get
            {
                return GetColumnValue<int>("TimesheetId");
            }

            set
            {
                SetColumnValue("TimesheetId", value);
            }

        }

        [XmlAttribute("BillingCityRateId")]
        public int BillingCityRateId
        {
            get
            {
                return GetColumnValue<int>("BillingCityRateId");
            }

            set
            {
                SetColumnValue("BillingCityRateId", value);
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


        [XmlAttribute("PerdiemCount")]
        public int PerdiemCount 
	    {
		    get
		    {
                return GetColumnValue<int>("PerdiemCount");
		    }

            set 
		    {
                SetColumnValue("PerdiemCount", value);
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

            public static string TimesheetId = @"TimesheetId";

            public static string BillingCityRateId = @"BillingCityRateId";

            public static string Periodaccountid = @"periodaccountid";

            public static string PerdiemCount = @"PerdiemCount";

            public static string City = @"City";

            public static string PerDiemRate = @"PerDiemRate";
            
            public static string IsDeleted = @"IsDeleted";
            
	    }

	    #endregion
    }

}

