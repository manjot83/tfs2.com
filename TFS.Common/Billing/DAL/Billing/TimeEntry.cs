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
	/// Strongly-typed collection for the TimeEntry class.
	/// </summary>
	[Serializable]
	public partial class TimeEntryCollection : ActiveList<TimeEntry, TimeEntryCollection> 
	{	   
		public TimeEntryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the TimeEntries table.
	/// </summary>
	[Serializable]
	public partial class TimeEntry : ActiveRecord<TimeEntry>
	{
		#region .ctors and Default Settings
		
		public TimeEntry()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public TimeEntry(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public TimeEntry(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public TimeEntry(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TimeEntries", TableType.Table, DataService.GetInstance("Billing"));
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
				
				TableSchema.TableColumn colvarTimesheetid = new TableSchema.TableColumn(schema);
				colvarTimesheetid.ColumnName = "timesheetid";
				colvarTimesheetid.DataType = DbType.Int32;
				colvarTimesheetid.MaxLength = 0;
				colvarTimesheetid.AutoIncrement = false;
				colvarTimesheetid.IsNullable = false;
				colvarTimesheetid.IsPrimaryKey = false;
				colvarTimesheetid.IsForeignKey = true;
				colvarTimesheetid.IsReadOnly = false;
				colvarTimesheetid.DefaultSetting = @"";
				
					colvarTimesheetid.ForeignKeyTableName = "Timesheets";
				schema.Columns.Add(colvarTimesheetid);
				
				TableSchema.TableColumn colvarDay = new TableSchema.TableColumn(schema);
				colvarDay.ColumnName = "day";
				colvarDay.DataType = DbType.Int32;
				colvarDay.MaxLength = 0;
				colvarDay.AutoIncrement = false;
				colvarDay.IsNullable = false;
				colvarDay.IsPrimaryKey = false;
				colvarDay.IsForeignKey = false;
				colvarDay.IsReadOnly = false;
				colvarDay.DefaultSetting = @"";
				colvarDay.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDay);
				
				TableSchema.TableColumn colvarTimein = new TableSchema.TableColumn(schema);
				colvarTimein.ColumnName = "timein";
				colvarTimein.DataType = DbType.AnsiStringFixedLength;
				colvarTimein.MaxLength = 8;
				colvarTimein.AutoIncrement = false;
				colvarTimein.IsNullable = false;
				colvarTimein.IsPrimaryKey = false;
				colvarTimein.IsForeignKey = false;
				colvarTimein.IsReadOnly = false;
				colvarTimein.DefaultSetting = @"";
				colvarTimein.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTimein);
				
				TableSchema.TableColumn colvarTimeout = new TableSchema.TableColumn(schema);
				colvarTimeout.ColumnName = "timeout";
				colvarTimeout.DataType = DbType.AnsiStringFixedLength;
				colvarTimeout.MaxLength = 8;
				colvarTimeout.AutoIncrement = false;
				colvarTimeout.IsNullable = false;
				colvarTimeout.IsPrimaryKey = false;
				colvarTimeout.IsForeignKey = false;
				colvarTimeout.IsReadOnly = false;
				colvarTimeout.DefaultSetting = @"";
				colvarTimeout.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTimeout);
				
				TableSchema.TableColumn colvarNotes = new TableSchema.TableColumn(schema);
				colvarNotes.ColumnName = "notes";
				colvarNotes.DataType = DbType.String;
				colvarNotes.MaxLength = 2147483647;
				colvarNotes.AutoIncrement = false;
				colvarNotes.IsNullable = false;
				colvarNotes.IsPrimaryKey = false;
				colvarNotes.IsForeignKey = false;
				colvarNotes.IsReadOnly = false;
				colvarNotes.DefaultSetting = @"";
				colvarNotes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotes);
				
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
				DataService.Providers["Billing"].AddSchema("TimeEntries",schema);
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

		  
		[XmlAttribute("Timesheetid")]
		public int Timesheetid 
		{
			get { return GetColumnValue<int>("timesheetid"); }

			set { SetColumnValue("timesheetid", value); }

		}

		  
		[XmlAttribute("Day")]
		public int Day 
		{
			get { return GetColumnValue<int>("day"); }

			set { SetColumnValue("day", value); }

		}

		  
		[XmlAttribute("Timein")]
		public string Timein 
		{
			get { return GetColumnValue<string>("timein"); }

			set { SetColumnValue("timein", value); }

		}

		  
		[XmlAttribute("Timeout")]
		public string Timeout 
		{
			get { return GetColumnValue<string>("timeout"); }

			set { SetColumnValue("timeout", value); }

		}

		  
		[XmlAttribute("Notes")]
		public string Notes 
		{
			get { return GetColumnValue<string>("notes"); }

			set { SetColumnValue("notes", value); }

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
		/// Returns a Timesheet ActiveRecord object related to this TimeEntry
		/// 
		/// </summary>
		public TFS.Intranet.Data.Billing.Timesheet Timesheet
		{
			get { return TFS.Intranet.Data.Billing.Timesheet.FetchByID(this.Timesheetid); }

			set { SetColumnValue("timesheetid", value.Id); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varTimesheetid,int varDay,string varTimein,string varTimeout,string varNotes,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy)
		{
			TimeEntry item = new TimeEntry();
			
			item.Timesheetid = varTimesheetid;
			
			item.Day = varDay;
			
			item.Timein = varTimein;
			
			item.Timeout = varTimeout;
			
			item.Notes = varNotes;
			
			item.IsDeleted = varIsDeleted;
			
			item.CreatedOn = varCreatedOn;
			
			item.CreatedBy = varCreatedBy;
			
			item.ModifiedOn = varModifiedOn;
			
			item.ModifiedBy = varModifiedBy;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varTimesheetid,int varDay,string varTimein,string varTimeout,string varNotes,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy)
		{
			TimeEntry item = new TimeEntry();
			
				item.Id = varId;
				
				item.Timesheetid = varTimesheetid;
				
				item.Day = varDay;
				
				item.Timein = varTimein;
				
				item.Timeout = varTimeout;
				
				item.Notes = varNotes;
				
				item.IsDeleted = varIsDeleted;
				
				item.CreatedOn = varCreatedOn;
				
				item.CreatedBy = varCreatedBy;
				
				item.ModifiedOn = varModifiedOn;
				
				item.ModifiedBy = varModifiedBy;
				
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
			 public static string Timesheetid = @"timesheetid";
			 public static string Day = @"day";
			 public static string Timein = @"timein";
			 public static string Timeout = @"timeout";
			 public static string Notes = @"notes";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedOn = @"CreatedOn";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
						
		}

		#endregion
	}

}

