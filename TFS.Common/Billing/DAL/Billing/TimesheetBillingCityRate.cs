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
	/// Strongly-typed collection for the TimesheetBillingCityRate class.
	/// </summary>
	[Serializable]
	public partial class TimesheetBillingCityRateCollection : ActiveList<TimesheetBillingCityRate, TimesheetBillingCityRateCollection> 
	{	   
		public TimesheetBillingCityRateCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the TimesheetBillingCityRate table.
	/// </summary>
	[Serializable]
	public partial class TimesheetBillingCityRate : ActiveRecord<TimesheetBillingCityRate>
	{
		#region .ctors and Default Settings
		
		public TimesheetBillingCityRate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public TimesheetBillingCityRate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public TimesheetBillingCityRate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public TimesheetBillingCityRate(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("TimesheetBillingCityRates", TableType.Table, DataService.GetInstance("Billing"));
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

                TableSchema.TableColumn colvarTimesheetId = new TableSchema.TableColumn(schema);
				colvarTimesheetId.ColumnName = "TimesheetId";
				colvarTimesheetId.DataType = DbType.Int32;
				colvarTimesheetId.MaxLength = 0;
				colvarTimesheetId.AutoIncrement = false;
				colvarTimesheetId.IsNullable = false;
				colvarTimesheetId.IsPrimaryKey = false;
				colvarTimesheetId.IsForeignKey = true;
				colvarTimesheetId.IsReadOnly = false;
				colvarTimesheetId.DefaultSetting = @"";

                colvarTimesheetId.ForeignKeyTableName = "Timesheets";
				schema.Columns.Add(colvarTimesheetId);

                TableSchema.TableColumn colvarBillingCityRateId = new TableSchema.TableColumn(schema);
                colvarBillingCityRateId.ColumnName = "BillingCityRateId";
				colvarBillingCityRateId.DataType = DbType.Int32;
				colvarBillingCityRateId.MaxLength = 0;
				colvarBillingCityRateId.AutoIncrement = false;
				colvarBillingCityRateId.IsNullable = false;
				colvarBillingCityRateId.IsPrimaryKey = false;
				colvarBillingCityRateId.IsForeignKey = true;
				colvarBillingCityRateId.IsReadOnly = false;
				colvarBillingCityRateId.DefaultSetting = @"";

                colvarBillingCityRateId.ForeignKeyTableName = "BillingCityRates";
				schema.Columns.Add(colvarBillingCityRateId);

                TableSchema.TableColumn colvarPerdiemCount = new TableSchema.TableColumn(schema);
                colvarPerdiemCount.ColumnName = "PerdiemCount";
                colvarPerdiemCount.DataType = DbType.Int32;
                colvarPerdiemCount.MaxLength = 0;
                colvarPerdiemCount.AutoIncrement = false;
                colvarPerdiemCount.IsNullable = false;
                colvarPerdiemCount.IsPrimaryKey = false;
                colvarPerdiemCount.IsForeignKey = false;
                colvarPerdiemCount.IsReadOnly = false;
                colvarPerdiemCount.DefaultSetting = @"";
                colvarPerdiemCount.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPerdiemCount);

				
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
                DataService.Providers["Billing"].AddSchema("TimesheetBillingCityRates", schema);
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

		  
		[XmlAttribute("TimesheetId")]
        public int TimesheetId 
		{
            get { return GetColumnValue<int>("TimesheetId"); }

            set { SetColumnValue("TimesheetId", value); }

		}


        [XmlAttribute("BillingCityRateId")]
        public int BillingCityRateId 
		{
            get { return GetColumnValue<int>("BillingCityRateId"); }

            set { SetColumnValue("BillingCityRateId", value); }

		}


        [XmlAttribute("PerdiemCount")]
        public int PerdiemCount 
		{
            get { return GetColumnValue<int>("PerdiemCount"); }

            set { SetColumnValue("PerdiemCount", value); }

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
		/// Returns a BillingPeriodAccount ActiveRecord object related to this TimesheetBillingCityRate
		/// 
		/// </summary>
        public TFS.Intranet.Data.Billing.Timesheet Timesheet
		{
            get { return TFS.Intranet.Data.Billing.Timesheet.FetchByID(this.TimesheetId); }

            set { SetColumnValue("TimesheetId", value.Id); }

		}

		
		
		/// <summary>
		/// Returns a RateGroup ActiveRecord object related to this TimesheetBillingCityRate
		/// 
		/// </summary>
        public TFS.Intranet.Data.Billing.BillingCityRate BillingCityRate
		{
            get { return TFS.Intranet.Data.Billing.BillingCityRate.FetchByID(this.BillingCityRateId); }

            set { SetColumnValue("BillingCityRateId", value.Id); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
             public static string TimesheetId = @"TimesheetId";
             public static string BillingCityRateId = @"BillingCityRateId";
             public static string PerdiemCount = @"PerdiemCount";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedOn = @"CreatedOn";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
						
		}

		#endregion
	}

}

