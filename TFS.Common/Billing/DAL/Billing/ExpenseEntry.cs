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
	/// Strongly-typed collection for the ExpenseEntry class.
	/// </summary>
	[Serializable]
	public partial class ExpenseEntryCollection : ActiveList<ExpenseEntry, ExpenseEntryCollection> 
	{	   
		public ExpenseEntryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ExpenseEntries table.
	/// </summary>
	[Serializable]
	public partial class ExpenseEntry : ActiveRecord<ExpenseEntry>
	{
		#region .ctors and Default Settings
		
		public ExpenseEntry()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ExpenseEntry(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ExpenseEntry(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ExpenseEntry(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ExpenseEntries", TableType.Table, DataService.GetInstance("Billing"));
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
				
				TableSchema.TableColumn colvarExpensedate = new TableSchema.TableColumn(schema);
				colvarExpensedate.ColumnName = "expensedate";
				colvarExpensedate.DataType = DbType.DateTime;
				colvarExpensedate.MaxLength = 0;
				colvarExpensedate.AutoIncrement = false;
				colvarExpensedate.IsNullable = false;
				colvarExpensedate.IsPrimaryKey = false;
				colvarExpensedate.IsForeignKey = false;
				colvarExpensedate.IsReadOnly = false;
				colvarExpensedate.DefaultSetting = @"";
				colvarExpensedate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpensedate);
				
				TableSchema.TableColumn colvarCost = new TableSchema.TableColumn(schema);
				colvarCost.ColumnName = "cost";
				colvarCost.DataType = DbType.Double;
				colvarCost.MaxLength = 0;
				colvarCost.AutoIncrement = false;
				colvarCost.IsNullable = false;
				colvarCost.IsPrimaryKey = false;
				colvarCost.IsForeignKey = false;
				colvarCost.IsReadOnly = false;
				colvarCost.DefaultSetting = @"";
				colvarCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCost);
				
				TableSchema.TableColumn colvarExpensedesc = new TableSchema.TableColumn(schema);
				colvarExpensedesc.ColumnName = "expensedesc";
				colvarExpensedesc.DataType = DbType.String;
				colvarExpensedesc.MaxLength = 2147483647;
				colvarExpensedesc.AutoIncrement = false;
				colvarExpensedesc.IsNullable = false;
				colvarExpensedesc.IsPrimaryKey = false;
				colvarExpensedesc.IsForeignKey = false;
				colvarExpensedesc.IsReadOnly = false;
				colvarExpensedesc.DefaultSetting = @"";
				colvarExpensedesc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpensedesc);
				
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
				DataService.Providers["Billing"].AddSchema("ExpenseEntries",schema);
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

		  
		[XmlAttribute("Expensedate")]
		public DateTime Expensedate 
		{
			get { return GetColumnValue<DateTime>("expensedate"); }

			set { SetColumnValue("expensedate", value); }

		}

		  
		[XmlAttribute("Cost")]
		public double Cost 
		{
			get { return GetColumnValue<double>("cost"); }

			set { SetColumnValue("cost", value); }

		}

		  
		[XmlAttribute("Expensedesc")]
		public string Expensedesc 
		{
			get { return GetColumnValue<string>("expensedesc"); }

			set { SetColumnValue("expensedesc", value); }

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
		/// Returns a Timesheet ActiveRecord object related to this ExpenseEntry
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
		public static void Insert(int varTimesheetid,DateTime varExpensedate,double varCost,string varExpensedesc,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy)
		{
			ExpenseEntry item = new ExpenseEntry();
			
			item.Timesheetid = varTimesheetid;
			
			item.Expensedate = varExpensedate;
			
			item.Cost = varCost;
			
			item.Expensedesc = varExpensedesc;
			
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
		public static void Update(int varId,int varTimesheetid,DateTime varExpensedate,double varCost,string varExpensedesc,bool varIsDeleted,DateTime? varCreatedOn,string varCreatedBy,DateTime? varModifiedOn,string varModifiedBy)
		{
			ExpenseEntry item = new ExpenseEntry();
			
				item.Id = varId;
				
				item.Timesheetid = varTimesheetid;
				
				item.Expensedate = varExpensedate;
				
				item.Cost = varCost;
				
				item.Expensedesc = varExpensedesc;
				
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
			 public static string Expensedate = @"expensedate";
			 public static string Cost = @"cost";
			 public static string Expensedesc = @"expensedesc";
			 public static string IsDeleted = @"IsDeleted";
			 public static string CreatedOn = @"CreatedOn";
			 public static string CreatedBy = @"CreatedBy";
			 public static string ModifiedOn = @"ModifiedOn";
			 public static string ModifiedBy = @"ModifiedBy";
						
		}

		#endregion
	}

}

