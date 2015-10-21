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
    /// Strongly-typed collection for the EmployeeTimesheetInfo class.
    /// </summary>
    [Serializable]
    public partial class EmployeeTimesheetInfoCollection : ReadOnlyList<EmployeeTimesheetInfo, EmployeeTimesheetInfoCollection>
    {        
        public EmployeeTimesheetInfoCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_EmployeeTimesheetInfo view.
    /// </summary>
    [Serializable]
    public partial class EmployeeTimesheetInfo : ReadOnlyRecord<EmployeeTimesheetInfo> 
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
                TableSchema.Table schema = new TableSchema.Table("vw_EmployeeTimesheetInfo", TableType.View, DataService.GetInstance("Billing"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarTimesheetid = new TableSchema.TableColumn(schema);
                colvarTimesheetid.ColumnName = "timesheetid";
                colvarTimesheetid.DataType = DbType.Int32;
                colvarTimesheetid.MaxLength = 0;
                colvarTimesheetid.AutoIncrement = false;
                colvarTimesheetid.IsNullable = false;
                colvarTimesheetid.IsPrimaryKey = false;
                colvarTimesheetid.IsForeignKey = false;
                colvarTimesheetid.IsReadOnly = false;
                
                schema.Columns.Add(colvarTimesheetid);
                
                TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(schema);
                colvarUsername.ColumnName = "username";
                colvarUsername.DataType = DbType.String;
                colvarUsername.MaxLength = 100;
                colvarUsername.AutoIncrement = false;
                colvarUsername.IsNullable = false;
                colvarUsername.IsPrimaryKey = false;
                colvarUsername.IsForeignKey = false;
                colvarUsername.IsReadOnly = false;
                
                schema.Columns.Add(colvarUsername);
                
                TableSchema.TableColumn colvarPerdiemcount = new TableSchema.TableColumn(schema);
                colvarPerdiemcount.ColumnName = "perdiemcount";
                colvarPerdiemcount.DataType = DbType.Int32;
                colvarPerdiemcount.MaxLength = 0;
                colvarPerdiemcount.AutoIncrement = false;
                colvarPerdiemcount.IsNullable = false;
                colvarPerdiemcount.IsPrimaryKey = false;
                colvarPerdiemcount.IsForeignKey = false;
                colvarPerdiemcount.IsReadOnly = false;
                
                schema.Columns.Add(colvarPerdiemcount);
                
                TableSchema.TableColumn colvarMileageclaimed = new TableSchema.TableColumn(schema);
                colvarMileageclaimed.ColumnName = "mileageclaimed";
                colvarMileageclaimed.DataType = DbType.Double;
                colvarMileageclaimed.MaxLength = 0;
                colvarMileageclaimed.AutoIncrement = false;
                colvarMileageclaimed.IsNullable = false;
                colvarMileageclaimed.IsPrimaryKey = false;
                colvarMileageclaimed.IsForeignKey = false;
                colvarMileageclaimed.IsReadOnly = false;
                
                schema.Columns.Add(colvarMileageclaimed);
                
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
                
                TableSchema.TableColumn colvarBillingperiodid = new TableSchema.TableColumn(schema);
                colvarBillingperiodid.ColumnName = "billingperiodid";
                colvarBillingperiodid.DataType = DbType.Int32;
                colvarBillingperiodid.MaxLength = 0;
                colvarBillingperiodid.AutoIncrement = false;
                colvarBillingperiodid.IsNullable = false;
                colvarBillingperiodid.IsPrimaryKey = false;
                colvarBillingperiodid.IsForeignKey = false;
                colvarBillingperiodid.IsReadOnly = false;
                
                schema.Columns.Add(colvarBillingperiodid);
                
                TableSchema.TableColumn colvarBillingaccountid = new TableSchema.TableColumn(schema);
                colvarBillingaccountid.ColumnName = "billingaccountid";
                colvarBillingaccountid.DataType = DbType.Int32;
                colvarBillingaccountid.MaxLength = 0;
                colvarBillingaccountid.AutoIncrement = false;
                colvarBillingaccountid.IsNullable = false;
                colvarBillingaccountid.IsPrimaryKey = false;
                colvarBillingaccountid.IsForeignKey = false;
                colvarBillingaccountid.IsReadOnly = false;
                
                schema.Columns.Add(colvarBillingaccountid);
                
                TableSchema.TableColumn colvarRategroupid = new TableSchema.TableColumn(schema);
                colvarRategroupid.ColumnName = "rategroupid";
                colvarRategroupid.DataType = DbType.Int32;
                colvarRategroupid.MaxLength = 0;
                colvarRategroupid.AutoIncrement = false;
                colvarRategroupid.IsNullable = true;
                colvarRategroupid.IsPrimaryKey = false;
                colvarRategroupid.IsForeignKey = false;
                colvarRategroupid.IsReadOnly = false;
                
                schema.Columns.Add(colvarRategroupid);
                
                TableSchema.TableColumn colvarRategroupname = new TableSchema.TableColumn(schema);
                colvarRategroupname.ColumnName = "rategroupname";
                colvarRategroupname.DataType = DbType.String;
                colvarRategroupname.MaxLength = 100;
                colvarRategroupname.AutoIncrement = false;
                colvarRategroupname.IsNullable = true;
                colvarRategroupname.IsPrimaryKey = false;
                colvarRategroupname.IsForeignKey = false;
                colvarRategroupname.IsReadOnly = false;
                
                schema.Columns.Add(colvarRategroupname);
                
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


                TableSchema.TableColumn colvarTimeSheetCreatedOn = new TableSchema.TableColumn(schema);
                colvarTimeSheetCreatedOn.ColumnName = "TimesheetCreatedOn";
                colvarTimeSheetCreatedOn.DataType = DbType.DateTime;
                colvarTimeSheetCreatedOn.MaxLength = 0;
                colvarTimeSheetCreatedOn.AutoIncrement = false;
                colvarTimeSheetCreatedOn.IsNullable = true;
                colvarTimeSheetCreatedOn.IsPrimaryKey = false;
                colvarTimeSheetCreatedOn.IsForeignKey = false;
                colvarTimeSheetCreatedOn.IsReadOnly = false;
                colvarTimeSheetCreatedOn.DefaultSetting = @"";
                colvarTimeSheetCreatedOn.ForeignKeyTableName = "";

                schema.Columns.Add(colvarTimeSheetCreatedOn);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Billing"].AddSchema("vw_EmployeeTimesheetInfo",schema);
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
	    public EmployeeTimesheetInfo()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public EmployeeTimesheetInfo(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public EmployeeTimesheetInfo(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public EmployeeTimesheetInfo(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Timesheetid")]
        public int Timesheetid 
	    {
		    get
		    {
			    return GetColumnValue<int>("timesheetid");
		    }

            set 
		    {
			    SetColumnValue("timesheetid", value);
            }

        }

	      
        [XmlAttribute("Username")]
        public string Username 
	    {
		    get
		    {
			    return GetColumnValue<string>("username");
		    }

            set 
		    {
			    SetColumnValue("username", value);
            }

        }

	      
        [XmlAttribute("Perdiemcount")]
        public int Perdiemcount 
	    {
		    get
		    {
			    return GetColumnValue<int>("perdiemcount");
		    }

            set 
		    {
			    SetColumnValue("perdiemcount", value);
            }

        }

	      
        [XmlAttribute("Mileageclaimed")]
        public double Mileageclaimed 
	    {
		    get
		    {
			    return GetColumnValue<double>("mileageclaimed");
		    }

            set 
		    {
			    SetColumnValue("mileageclaimed", value);
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

	      
        [XmlAttribute("Billingperiodid")]
        public int Billingperiodid 
	    {
		    get
		    {
			    return GetColumnValue<int>("billingperiodid");
		    }

            set 
		    {
			    SetColumnValue("billingperiodid", value);
            }

        }

	      
        [XmlAttribute("Billingaccountid")]
        public int Billingaccountid 
	    {
		    get
		    {
			    return GetColumnValue<int>("billingaccountid");
		    }

            set 
		    {
			    SetColumnValue("billingaccountid", value);
            }

        }

	      
        [XmlAttribute("Rategroupid")]
        public int? Rategroupid 
	    {
		    get
		    {
			    return GetColumnValue<int?>("rategroupid");
		    }

            set 
		    {
			    SetColumnValue("rategroupid", value);
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

        [XmlAttribute("TimesheetCreatedOn")]
        public DateTime TimesheetCreatedOn
        {
            get
            {
                return GetColumnValue<DateTime>("TimesheetCreatedOn");
            }

            set
            {
                SetColumnValue("TimesheetCreatedOn", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Timesheetid = @"timesheetid";
            
            public static string Username = @"username";
            
            public static string Perdiemcount = @"perdiemcount";
            
            public static string Mileageclaimed = @"mileageclaimed";
            
            public static string Month = @"month";
            
            public static string Year = @"year";
            
            public static string Openuntil = @"openuntil";
            
            public static string Accountname = @"accountname";
            
            public static string Billingperiodid = @"billingperiodid";
            
            public static string Billingaccountid = @"billingaccountid";
            
            public static string Rategroupid = @"rategroupid";
            
            public static string Rategroupname = @"rategroupname";
            
            public static string IsDeleted = @"IsDeleted";

            public static string TimesheetCreatedOn = @"TimesheetCreatedOn";
            
	    }

	    #endregion
    }

}

