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
	/// Strongly-typed collection for the BillingCityRate class.
	/// </summary>
	[Serializable]
	public partial class BillingCityRateCollection : ActiveList<BillingCityRate, BillingCityRateCollection> 
	{	   
		public BillingCityRateCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the BillingCityRate table.
	/// </summary>
	[Serializable]
	public partial class BillingCityRate : ActiveRecord<BillingCityRate>
	{
		#region .ctors and Default Settings
		
		public BillingCityRate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public BillingCityRate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public BillingCityRate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public BillingCityRate(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("BillingCityRates", TableType.Table, DataService.GetInstance("Billing"));
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

                TableSchema.TableColumn colvarDefaultCityRateId = new TableSchema.TableColumn(schema);
				colvarDefaultCityRateId.ColumnName = "DefaultCityRateId";
				colvarDefaultCityRateId.DataType = DbType.Int32;
				colvarDefaultCityRateId.MaxLength = 0;
				colvarDefaultCityRateId.AutoIncrement = false;
				colvarDefaultCityRateId.IsNullable = false;
				colvarDefaultCityRateId.IsPrimaryKey = false;
				colvarDefaultCityRateId.IsForeignKey = true;
				colvarDefaultCityRateId.IsReadOnly = false;
				colvarDefaultCityRateId.DefaultSetting = @"";

                colvarDefaultCityRateId.ForeignKeyTableName = "BillingDefaultCityRates";
				schema.Columns.Add(colvarDefaultCityRateId);

                TableSchema.TableColumn colvarPerDiemRate = new TableSchema.TableColumn(schema);
                colvarPerDiemRate.ColumnName = "PerDiemRate";
				colvarPerDiemRate.DataType = DbType.Double;
				colvarPerDiemRate.MaxLength = 0;
				colvarPerDiemRate.AutoIncrement = false;
				colvarPerDiemRate.IsNullable = false;
				colvarPerDiemRate.IsPrimaryKey = false;
				colvarPerDiemRate.IsForeignKey = false;
				colvarPerDiemRate.IsReadOnly = false;
				colvarPerDiemRate.DefaultSetting = @"";
				colvarPerDiemRate.ForeignKeyTableName = "";
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Billing"].AddSchema("BillingCityRates",schema);
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

		  
		[XmlAttribute("Periodaccountid")]
		public int Periodaccountid 
		{
			get { return GetColumnValue<int>("periodaccountid"); }

			set { SetColumnValue("periodaccountid", value); }

		}


        [XmlAttribute("DefaultCityRateId")]
        public int DefaultCityRateId 
		{
			get { return GetColumnValue<int>("DefaultCityRateId"); }

			set { SetColumnValue("DefaultCityRateId", value); }

		}


        [XmlAttribute("PerDiemRate")]
        public double PerDiemRate 
		{
            get { return GetColumnValue<double>("PerDiemRate"); }

            set { SetColumnValue("PerDiemRate", value); }

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

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a BillingPeriodAccount ActiveRecord object related to this BillingCityRate
		/// 
		/// </summary>
		public TFS.Intranet.Data.Billing.BillingPeriodAccount BillingPeriodAccount
		{
			get { return TFS.Intranet.Data.Billing.BillingPeriodAccount.FetchByID(this.Periodaccountid); }

			set { SetColumnValue("periodaccountid", value.Id); }

		}

		
		
		/// <summary>
		/// Returns a RateGroup ActiveRecord object related to this BillingCityRate
		/// 
		/// </summary>
        public TFS.Intranet.Data.Billing.BillingDefaultCityRate BillingDefaultCityRate
		{
            get { return TFS.Intranet.Data.Billing.BillingDefaultCityRate.FetchByID(this.DefaultCityRateId); }

			set { SetColumnValue("DefaultCityRateId", value.Id); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varPeriodaccountid,int varDefaultCityRateId,double varPerDiemRate)
		{
			BillingCityRate item = new BillingCityRate();
			
			item.Periodaccountid = varPeriodaccountid;

            item.DefaultCityRateId = varDefaultCityRateId;

            item.PerDiemRate = varPerDiemRate;
			
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varPeriodaccountid,int varDefaultCityRateId,double varPerDiemRate)
		{
			BillingCityRate item = new BillingCityRate();
			
				item.Id = varId;
				
				item.Periodaccountid = varPeriodaccountid;
				
				item.DefaultCityRateId = varDefaultCityRateId;
				
				item.PerDiemRate = varPerDiemRate;
				
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
			 public static string Periodaccountid = @"periodaccountid";
             public static string DefaultCityRateId = @"DefaultCityRateId";
             public static string PerDiemRate = @"PerDiemRate";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedOn = @"CreatedOn";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
						
		}

		#endregion
	}

}

