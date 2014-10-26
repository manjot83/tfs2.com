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
	/// Strongly-typed collection for the BillingPeriodAccount class.
	/// </summary>
	[Serializable]
	public partial class BillingPeriodAccountCollection : ActiveList<BillingPeriodAccount, BillingPeriodAccountCollection> 
	{	   
		public BillingPeriodAccountCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the BillingPeriodAccounts table.
	/// </summary>
	[Serializable]
	public partial class BillingPeriodAccount : ActiveRecord<BillingPeriodAccount>
	{
		#region .ctors and Default Settings
		
		public BillingPeriodAccount()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public BillingPeriodAccount(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public BillingPeriodAccount(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public BillingPeriodAccount(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("BillingPeriodAccounts", TableType.Table, DataService.GetInstance("Billing"));
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
				
				TableSchema.TableColumn colvarPeriodid = new TableSchema.TableColumn(schema);
				colvarPeriodid.ColumnName = "periodid";
				colvarPeriodid.DataType = DbType.Int32;
				colvarPeriodid.MaxLength = 0;
				colvarPeriodid.AutoIncrement = false;
				colvarPeriodid.IsNullable = false;
				colvarPeriodid.IsPrimaryKey = false;
				colvarPeriodid.IsForeignKey = true;
				colvarPeriodid.IsReadOnly = false;
				colvarPeriodid.DefaultSetting = @"";
				
					colvarPeriodid.ForeignKeyTableName = "BillingPeriods";
				schema.Columns.Add(colvarPeriodid);
				
				TableSchema.TableColumn colvarAccountid = new TableSchema.TableColumn(schema);
				colvarAccountid.ColumnName = "accountid";
				colvarAccountid.DataType = DbType.Int32;
				colvarAccountid.MaxLength = 0;
				colvarAccountid.AutoIncrement = false;
				colvarAccountid.IsNullable = false;
				colvarAccountid.IsPrimaryKey = false;
				colvarAccountid.IsForeignKey = true;
				colvarAccountid.IsReadOnly = false;
				colvarAccountid.DefaultSetting = @"";
				
					colvarAccountid.ForeignKeyTableName = "BillingAccounts";
				schema.Columns.Add(colvarAccountid);
				
				TableSchema.TableColumn colvarPerdiemrate = new TableSchema.TableColumn(schema);
				colvarPerdiemrate.ColumnName = "perdiemrate";
				colvarPerdiemrate.DataType = DbType.Double;
				colvarPerdiemrate.MaxLength = 0;
				colvarPerdiemrate.AutoIncrement = false;
				colvarPerdiemrate.IsNullable = false;
				colvarPerdiemrate.IsPrimaryKey = false;
				colvarPerdiemrate.IsForeignKey = false;
				colvarPerdiemrate.IsReadOnly = false;
				colvarPerdiemrate.DefaultSetting = @"";
				colvarPerdiemrate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerdiemrate);
				
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
				
				TableSchema.TableColumn colvarMileagerate = new TableSchema.TableColumn(schema);
				colvarMileagerate.ColumnName = "mileagerate";
				colvarMileagerate.DataType = DbType.Double;
				colvarMileagerate.MaxLength = 0;
				colvarMileagerate.AutoIncrement = false;
				colvarMileagerate.IsNullable = false;
				colvarMileagerate.IsPrimaryKey = false;
				colvarMileagerate.IsForeignKey = false;
				colvarMileagerate.IsReadOnly = false;
				
						colvarMileagerate.DefaultSetting = @"((0))";
				colvarMileagerate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMileagerate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Billing"].AddSchema("BillingPeriodAccounts",schema);
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

		  
		[XmlAttribute("Periodid")]
		public int Periodid 
		{
			get { return GetColumnValue<int>("periodid"); }

			set { SetColumnValue("periodid", value); }

		}

		  
		[XmlAttribute("Accountid")]
		public int Accountid 
		{
			get { return GetColumnValue<int>("accountid"); }

			set { SetColumnValue("accountid", value); }

		}

		  
		[XmlAttribute("Perdiemrate")]
		public double Perdiemrate 
		{
			get { return GetColumnValue<double>("perdiemrate"); }

			set { SetColumnValue("perdiemrate", value); }

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

		  
		[XmlAttribute("Mileagerate")]
		public double Mileagerate 
		{
			get { return GetColumnValue<double>("mileagerate"); }

			set { SetColumnValue("mileagerate", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public TFS.Intranet.Data.Billing.BillingRateCollection BillingRates()
		{
			return new TFS.Intranet.Data.Billing.BillingRateCollection().Where(BillingRate.Columns.Periodaccountid, Id).Load();
		}

		public TFS.Intranet.Data.Billing.TimesheetCollection Timesheets()
		{
			return new TFS.Intranet.Data.Billing.TimesheetCollection().Where(Timesheet.Columns.Periodaccountid, Id).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a BillingAccount ActiveRecord object related to this BillingPeriodAccount
		/// 
		/// </summary>
		public TFS.Intranet.Data.Billing.BillingAccount BillingAccount
		{
			get { return TFS.Intranet.Data.Billing.BillingAccount.FetchByID(this.Accountid); }

			set { SetColumnValue("accountid", value.Id); }

		}

		
		
		/// <summary>
		/// Returns a BillingPeriod ActiveRecord object related to this BillingPeriodAccount
		/// 
		/// </summary>
		public TFS.Intranet.Data.Billing.BillingPeriod BillingPeriod
		{
			get { return TFS.Intranet.Data.Billing.BillingPeriod.FetchByID(this.Periodid); }

			set { SetColumnValue("periodid", value.Id); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varPeriodid,int varAccountid,double varPerdiemrate,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy,double varMileagerate)
		{
			BillingPeriodAccount item = new BillingPeriodAccount();
			
			item.Periodid = varPeriodid;
			
			item.Accountid = varAccountid;
			
			item.Perdiemrate = varPerdiemrate;
			
			item.IsDeleted = varIsDeleted;
			
			item.CreatedOn = varCreatedOn;
			
			item.CreatedBy = varCreatedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.Mileagerate = varMileagerate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varPeriodid,int varAccountid,double varPerdiemrate,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy,double varMileagerate)
		{
			BillingPeriodAccount item = new BillingPeriodAccount();
			
				item.Id = varId;
				
				item.Periodid = varPeriodid;
				
				item.Accountid = varAccountid;
				
				item.Perdiemrate = varPerdiemrate;
				
				item.IsDeleted = varIsDeleted;
				
				item.CreatedOn = varCreatedOn;
				
				item.CreatedBy = varCreatedBy;
				
				item.ModifiedOn = varModifiedOn;
				
				item.ModifiedBy = varModifiedBy;
				
				item.Mileagerate = varMileagerate;
				
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
			 public static string Periodid = @"periodid";
			 public static string Accountid = @"accountid";
			 public static string Perdiemrate = @"perdiemrate";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedOn = @"CreatedOn";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string Mileagerate = @"mileagerate";
						
		}

		#endregion
	}

}

