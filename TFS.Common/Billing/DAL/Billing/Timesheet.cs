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

namespace TFS.Intranet.Data.Billing
{
	/// <summary>
	/// Strongly-typed collection for the Timesheet class.
	/// </summary>
	[Serializable]
	public partial class TimesheetCollection : ActiveList<Timesheet, TimesheetCollection> 
	{	   
		public TimesheetCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Timesheets table.
	/// </summary>
	[Serializable]
	public partial class Timesheet : ActiveRecord<Timesheet>
	{
		#region .ctors and Default Settings
		
		public Timesheet()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Timesheet(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Timesheet(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Timesheet(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}

		
		protected static void SetSQLProps() { GetTableSchema(); }

		
		#endregion
		
		#region Schema and Query Accessor
		public static Query CreateQuery() { return new Query(Schema); }

		
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}

		}

		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("Timesheets", TableType.Table, DataService.GetInstance("Billing"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(schema);
				colvarUsername.ColumnName = "username";
				colvarUsername.DataType = DbType.String;
				colvarUsername.MaxLength = 100;
				colvarUsername.AutoIncrement = false;
				colvarUsername.IsNullable = false;
				colvarUsername.IsPrimaryKey = false;
				colvarUsername.IsForeignKey = false;
				colvarUsername.IsReadOnly = false;
				colvarUsername.DefaultSetting = @"";
				colvarUsername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsername);
				
				TableSchema.TableColumn colvarPeriodaccountid = new TableSchema.TableColumn(schema);
				colvarPeriodaccountid.ColumnName = "periodaccountid";
				colvarPeriodaccountid.DataType = DbType.Int32;
				colvarPeriodaccountid.MaxLength = 0;
				colvarPeriodaccountid.AutoIncrement = false;
				colvarPeriodaccountid.IsNullable = false;
				colvarPeriodaccountid.IsPrimaryKey = false;
				colvarPeriodaccountid.IsForeignKey = true;
				colvarPeriodaccountid.IsReadOnly = false;
				colvarPeriodaccountid.DefaultSetting = @"";
				
					colvarPeriodaccountid.ForeignKeyTableName = "BillingPeriodAccounts";
				schema.Columns.Add(colvarPeriodaccountid);

                TableSchema.TableColumn colvarCityRateId = new TableSchema.TableColumn(schema);
                colvarCityRateId.ColumnName = "CityRateId";
                colvarCityRateId.DataType = DbType.Int32;
                colvarCityRateId.MaxLength = 0;
                colvarCityRateId.AutoIncrement = false;
                colvarCityRateId.IsNullable = false;
                colvarCityRateId.IsPrimaryKey = false;
                colvarCityRateId.IsForeignKey = true;
                colvarCityRateId.IsReadOnly = false;
                colvarCityRateId.DefaultSetting = @"";

                colvarPeriodaccountid.ForeignKeyTableName = "BillingCityRates";
                schema.Columns.Add(colvarCityRateId);
				
				TableSchema.TableColumn colvarPerdiemcount = new TableSchema.TableColumn(schema);
				colvarPerdiemcount.ColumnName = "perdiemcount";
				colvarPerdiemcount.DataType = DbType.Int32;
				colvarPerdiemcount.MaxLength = 0;
				colvarPerdiemcount.AutoIncrement = false;
				colvarPerdiemcount.IsNullable = false;
				colvarPerdiemcount.IsPrimaryKey = false;
				colvarPerdiemcount.IsForeignKey = false;
				colvarPerdiemcount.IsReadOnly = false;
				colvarPerdiemcount.DefaultSetting = @"";
				colvarPerdiemcount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerdiemcount);
				
				TableSchema.TableColumn colvarIsDeleted = new TableSchema.TableColumn(schema);
				colvarIsDeleted.ColumnName = "IsDeleted";
				colvarIsDeleted.DataType = DbType.Boolean;
				colvarIsDeleted.MaxLength = 0;
				colvarIsDeleted.AutoIncrement = false;
				colvarIsDeleted.IsNullable = false;
				colvarIsDeleted.IsPrimaryKey = false;
				colvarIsDeleted.IsForeignKey = false;
				colvarIsDeleted.IsReadOnly = false;
				
						colvarIsDeleted.DefaultSetting = @"((0))";
				colvarIsDeleted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsDeleted);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = true;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.String;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = true;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarMileageclaimed = new TableSchema.TableColumn(schema);
				colvarMileageclaimed.ColumnName = "mileageclaimed";
				colvarMileageclaimed.DataType = DbType.Double;
				colvarMileageclaimed.MaxLength = 0;
				colvarMileageclaimed.AutoIncrement = false;
				colvarMileageclaimed.IsNullable = false;
				colvarMileageclaimed.IsPrimaryKey = false;
				colvarMileageclaimed.IsForeignKey = false;
				colvarMileageclaimed.IsReadOnly = false;
				colvarMileageclaimed.DefaultSetting = @"((0))";
				colvarMileageclaimed.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMileageclaimed);

                TableSchema.TableColumn colvarRategroupid = new TableSchema.TableColumn(schema);
                colvarRategroupid.ColumnName = "rategroupid";
                colvarRategroupid.DataType = DbType.Int32;
                colvarRategroupid.MaxLength = 0;
                colvarRategroupid.AutoIncrement = false;
                colvarRategroupid.IsNullable = false;
                colvarRategroupid.IsPrimaryKey = false;
                colvarRategroupid.IsForeignKey = true;
                colvarRategroupid.IsReadOnly = false;
                colvarRategroupid.DefaultSetting = @"";
                colvarRategroupid.ForeignKeyTableName = "RateGroups";
                schema.Columns.Add(colvarRategroupid);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Billing"].AddSchema("Timesheets",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("Id")]
		public int Id 
		{
			get { return GetColumnValue<int>("id"); }

			set { SetColumnValue("id", value); }

		}

		  
		[XmlAttribute("Username")]
		public string Username 
		{
			get { return GetColumnValue<string>("username"); }

			set { SetColumnValue("username", value); }

		}

		  
		[XmlAttribute("Periodaccountid")]
		public int Periodaccountid 
		{
			get { return GetColumnValue<int>("periodaccountid"); }

			set { SetColumnValue("periodaccountid", value); }

		}

        [XmlAttribute("CityRateId")]
        public int CityRateId
        {
            get { return GetColumnValue<int>("CityRateId"); }

            set { SetColumnValue("CityRateId", value); }

        }

		  
		[XmlAttribute("Perdiemcount")]
		public int Perdiemcount 
		{
			get { return GetColumnValue<int>("perdiemcount"); }

			set { SetColumnValue("perdiemcount", value); }

		}

		  
		[XmlAttribute("IsDeleted")]
		public bool IsDeleted 
		{
			get { return GetColumnValue<bool>("IsDeleted"); }

			set { SetColumnValue("IsDeleted", value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>("CreatedOn"); }

			set { SetColumnValue("CreatedOn", value); }

		}

		  
		[XmlAttribute("CreatedBy")]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>("CreatedBy"); }

			set { SetColumnValue("CreatedBy", value); }

		}

		  
		[XmlAttribute("ModifiedOn")]
		public DateTime? ModifiedOn 
		{
			get { return GetColumnValue<DateTime?>("ModifiedOn"); }

			set { SetColumnValue("ModifiedOn", value); }

		}

		  
		[XmlAttribute("ModifiedBy")]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>("ModifiedBy"); }

			set { SetColumnValue("ModifiedBy", value); }

		}

		  
		[XmlAttribute("Mileageclaimed")]
		public double Mileageclaimed 
		{
			get { return GetColumnValue<double>("mileageclaimed"); }

			set { SetColumnValue("mileageclaimed", value); }

		}

        [XmlAttribute("Rategroupid")]
        public int Rategroupid
        {
            get { return GetColumnValue<int>("rategroupid"); }

            set { SetColumnValue("rategroupid", value); }

        }

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public TFS.Intranet.Data.Billing.ExpenseEntryCollection ExpenseEntries()
		{
			return new TFS.Intranet.Data.Billing.ExpenseEntryCollection().Where(ExpenseEntry.Columns.Timesheetid, Id).Load();
		}

		public TFS.Intranet.Data.Billing.TimeEntryCollection TimeEntries()
		{
			return new TFS.Intranet.Data.Billing.TimeEntryCollection().Where(TimeEntry.Columns.Timesheetid, Id).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a BillingPeriodAccount ActiveRecord object related to this Timesheet
		/// 
		/// </summary>
		public TFS.Intranet.Data.Billing.BillingPeriodAccount BillingPeriodAccount
		{
			get { return TFS.Intranet.Data.Billing.BillingPeriodAccount.FetchByID(this.Periodaccountid); }

			set { SetColumnValue("periodaccountid", value.Id); }

		}

        public RateGroup RateGroup
        {
            get { return RateGroup.FetchByID(this.Rategroupid); }
            set { SetColumnValue("rategroupid", value.Id); }
        }
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUsername,int varPeriodaccountid,int varPerdiemcount,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy,double varMileageclaimed,int varRategroupid)
		{
			Timesheet item = new Timesheet();
			
			item.Username = varUsername;
			
			item.Periodaccountid = varPeriodaccountid;
			
			item.Perdiemcount = varPerdiemcount;
			
			item.IsDeleted = varIsDeleted;
			
			item.CreatedOn = varCreatedOn;
			
			item.CreatedBy = varCreatedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.Mileageclaimed = varMileageclaimed;

            item.Rategroupid = varRategroupid;
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
        public static void Update(int varId, string varUsername, int varPeriodaccountid, int varPerdiemcount, bool varIsDeleted, DateTime? varCreatedOn, string varCreatedBy, DateTime? varModifiedOn, string varModifiedBy, double varMileageclaimed, int varRategroupid)
		{
			Timesheet item = new Timesheet();
			
				item.Id = varId;
				
				item.Username = varUsername;
				
				item.Periodaccountid = varPeriodaccountid;
				
				item.Perdiemcount = varPerdiemcount;
				
				item.IsDeleted = varIsDeleted;
				
				item.CreatedOn = varCreatedOn;
				
				item.CreatedBy = varCreatedBy;
				
				item.ModifiedOn = varModifiedOn;
				
				item.ModifiedBy = varModifiedBy;
				
				item.Mileageclaimed = varMileageclaimed;

                item.Rategroupid = varRategroupid;
				
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Username = @"username";
			 public static string Periodaccountid = @"periodaccountid";
             public static string Perdiemcount = @"perdiemcount";
             public static string CityRateId = @"CityRateId";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedOn = @"CreatedOn";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string Mileageclaimed = @"mileageclaimed";
             public static string Rategroupid = @"rategroupid";
						
		}

		#endregion
	}

}

