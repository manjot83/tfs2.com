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
	/// Strongly-typed collection for the BillingAccount class.
	/// </summary>
	[Serializable]
	public partial class BillingAccountCollection : ActiveList<BillingAccount, BillingAccountCollection> 
	{	   
		public BillingAccountCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the BillingAccounts table.
	/// </summary>
	[Serializable]
	public partial class BillingAccount : ActiveRecord<BillingAccount>
	{
		#region .ctors and Default Settings
		
		public BillingAccount()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public BillingAccount(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public BillingAccount(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public BillingAccount(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("BillingAccounts", TableType.Table, DataService.GetInstance("Billing"));
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
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 100;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarDefaultperdiemrate = new TableSchema.TableColumn(schema);
				colvarDefaultperdiemrate.ColumnName = "defaultperdiemrate";
				colvarDefaultperdiemrate.DataType = DbType.Double;
				colvarDefaultperdiemrate.MaxLength = 0;
				colvarDefaultperdiemrate.AutoIncrement = false;
				colvarDefaultperdiemrate.IsNullable = false;
				colvarDefaultperdiemrate.IsPrimaryKey = false;
				colvarDefaultperdiemrate.IsForeignKey = false;
				colvarDefaultperdiemrate.IsReadOnly = false;
				colvarDefaultperdiemrate.DefaultSetting = @"";
				colvarDefaultperdiemrate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDefaultperdiemrate);
				
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
				
				TableSchema.TableColumn colvarDefaultmileagerate = new TableSchema.TableColumn(schema);
				colvarDefaultmileagerate.ColumnName = "defaultmileagerate";
				colvarDefaultmileagerate.DataType = DbType.Double;
				colvarDefaultmileagerate.MaxLength = 0;
				colvarDefaultmileagerate.AutoIncrement = false;
				colvarDefaultmileagerate.IsNullable = false;
				colvarDefaultmileagerate.IsPrimaryKey = false;
				colvarDefaultmileagerate.IsForeignKey = false;
				colvarDefaultmileagerate.IsReadOnly = false;
				
						colvarDefaultmileagerate.DefaultSetting = @"((0))";
				colvarDefaultmileagerate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDefaultmileagerate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Billing"].AddSchema("BillingAccounts",schema);
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

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("name"); }

			set { SetColumnValue("name", value); }

		}

		  
		[XmlAttribute("Defaultperdiemrate")]
		public double Defaultperdiemrate 
		{
			get { return GetColumnValue<double>("defaultperdiemrate"); }

			set { SetColumnValue("defaultperdiemrate", value); }

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

		  
		[XmlAttribute("Defaultmileagerate")]
		public double Defaultmileagerate 
		{
			get { return GetColumnValue<double>("defaultmileagerate"); }

			set { SetColumnValue("defaultmileagerate", value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public TFS.Intranet.Data.Billing.BillingPeriodAccountCollection BillingPeriodAccounts()
		{
			return new TFS.Intranet.Data.Billing.BillingPeriodAccountCollection().Where(BillingPeriodAccount.Columns.Accountid, Id).Load();
		}

		public TFS.Intranet.Data.Billing.DefaultBillingRateCollection DefaultBillingRates()
		{
			return new TFS.Intranet.Data.Billing.DefaultBillingRateCollection().Where(DefaultBillingRate.Columns.Accountid, Id).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,double varDefaultperdiemrate,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy,double varDefaultmileagerate)
		{
			BillingAccount item = new BillingAccount();
			
			item.Name = varName;
			
			item.Defaultperdiemrate = varDefaultperdiemrate;
			
			item.IsDeleted = varIsDeleted;
			
			item.CreatedOn = varCreatedOn;
			
			item.CreatedBy = varCreatedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.Defaultmileagerate = varDefaultmileagerate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varName,double varDefaultperdiemrate,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy,double varDefaultmileagerate)
		{
			BillingAccount item = new BillingAccount();
			
				item.Id = varId;
				
				item.Name = varName;
				
				item.Defaultperdiemrate = varDefaultperdiemrate;
				
				item.IsDeleted = varIsDeleted;
				
				item.CreatedOn = varCreatedOn;
				
				item.CreatedBy = varCreatedBy;
				
				item.ModifiedOn = varModifiedOn;
				
				item.ModifiedBy = varModifiedBy;
				
				item.Defaultmileagerate = varDefaultmileagerate;
				
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
			 public static string Name = @"name";
			 public static string Defaultperdiemrate = @"defaultperdiemrate";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedOn = @"CreatedOn";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string Defaultmileagerate = @"defaultmileagerate";
						
		}

		#endregion
	}

}

