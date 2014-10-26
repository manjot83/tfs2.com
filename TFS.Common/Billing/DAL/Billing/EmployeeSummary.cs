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
    /// Strongly-typed collection for the EmployeeSummary class.
    /// </summary>
    [Serializable]
    public partial class EmployeeSummaryCollection : ReadOnlyList<EmployeeSummary, EmployeeSummaryCollection>
    {        
        public EmployeeSummaryCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_EmployeeSummary view.
    /// </summary>
    [Serializable]
    public partial class EmployeeSummary : ReadOnlyRecord<EmployeeSummary> 
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
                TableSchema.Table schema = new TableSchema.Table("vw_EmployeeSummary", TableType.View, DataService.GetInstance("Billing"));
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
                
                TableSchema.TableColumn colvarRategroupid = new TableSchema.TableColumn(schema);
                colvarRategroupid.ColumnName = "rategroupid";
                colvarRategroupid.DataType = DbType.Int32;
                colvarRategroupid.MaxLength = 0;
                colvarRategroupid.AutoIncrement = false;
                colvarRategroupid.IsNullable = false;
                colvarRategroupid.IsPrimaryKey = false;
                colvarRategroupid.IsForeignKey = false;
                colvarRategroupid.IsReadOnly = false;
                
                schema.Columns.Add(colvarRategroupid);
                
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
                DataService.Providers["Billing"].AddSchema("vw_EmployeeSummary",schema);
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
	    public EmployeeSummary()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public EmployeeSummary(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public EmployeeSummary(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public EmployeeSummary(string columnName, object columnValue)
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

	      
        [XmlAttribute("Rategroupid")]
        public int Rategroupid 
	    {
		    get
		    {
			    return GetColumnValue<int>("rategroupid");
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
		    
		    
            public static string Timesheetid = @"timesheetid";
            
            public static string Username = @"username";
            
            public static string Periodaccountid = @"periodaccountid";
            
            public static string Periodid = @"periodid";
            
            public static string Accountid = @"accountid";
            
            public static string Accountname = @"accountname";
            
            public static string Rategroupid = @"rategroupid";
            
            public static string Rategroupname = @"rategroupname";
            
            public static string Perdiemrate = @"perdiemrate";
            
            public static string Perdiemcount = @"perdiemcount";
            
            public static string Mileagerate = @"mileagerate";
            
            public static string Mileageclaimed = @"mileageclaimed";
            
            public static string Rate = @"rate";
            
            public static string IsDeleted = @"IsDeleted";
            
	    }

	    #endregion
    }

}

