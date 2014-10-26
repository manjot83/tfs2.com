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
namespace TFS.OpCenter.Data
{
	/// <summary>
	/// Strongly-typed collection for the Availability class.
	/// </summary>
    [Serializable]
	public partial class AvailabilityCollection : ActiveList<Availability, AvailabilityCollection>
	{	   
		public AvailabilityCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AvailabilityCollection</returns>
		public AvailabilityCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Availability o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the availability table.
	/// </summary>
	[Serializable]
	public partial class Availability : ActiveRecord<Availability>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Availability()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Availability(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Availability(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Availability(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("availability", TableType.Table, DataService.GetInstance("OpCenter"));
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
				
				TableSchema.TableColumn colvarPersonid = new TableSchema.TableColumn(schema);
				colvarPersonid.ColumnName = "personid";
				colvarPersonid.DataType = DbType.Int32;
				colvarPersonid.MaxLength = 0;
				colvarPersonid.AutoIncrement = false;
				colvarPersonid.IsNullable = false;
				colvarPersonid.IsPrimaryKey = false;
				colvarPersonid.IsForeignKey = true;
				colvarPersonid.IsReadOnly = false;
				colvarPersonid.DefaultSetting = @"";
				
					colvarPersonid.ForeignKeyTableName = "persons";
				schema.Columns.Add(colvarPersonid);
				
				TableSchema.TableColumn colvarMonth = new TableSchema.TableColumn(schema);
				colvarMonth.ColumnName = "month";
				colvarMonth.DataType = DbType.Int32;
				colvarMonth.MaxLength = 0;
				colvarMonth.AutoIncrement = false;
				colvarMonth.IsNullable = false;
				colvarMonth.IsPrimaryKey = false;
				colvarMonth.IsForeignKey = false;
				colvarMonth.IsReadOnly = false;
				colvarMonth.DefaultSetting = @"";
				colvarMonth.ForeignKeyTableName = "";
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
				colvarYear.DefaultSetting = @"";
				colvarYear.ForeignKeyTableName = "";
				schema.Columns.Add(colvarYear);
				
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
				
				TableSchema.TableColumn colvarIsavailable = new TableSchema.TableColumn(schema);
				colvarIsavailable.ColumnName = "isavailable";
				colvarIsavailable.DataType = DbType.Boolean;
				colvarIsavailable.MaxLength = 0;
				colvarIsavailable.AutoIncrement = false;
				colvarIsavailable.IsNullable = false;
				colvarIsavailable.IsPrimaryKey = false;
				colvarIsavailable.IsForeignKey = false;
				colvarIsavailable.IsReadOnly = false;
				
						colvarIsavailable.DefaultSetting = @"((0))";
				colvarIsavailable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsavailable);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OpCenter"].AddSchema("availability",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Personid")]
		[Bindable(true)]
		public int Personid 
		{
			get { return GetColumnValue<int>(Columns.Personid); }
			set { SetColumnValue(Columns.Personid, value); }
		}
		  
		[XmlAttribute("Month")]
		[Bindable(true)]
		public int Month 
		{
			get { return GetColumnValue<int>(Columns.Month); }
			set { SetColumnValue(Columns.Month, value); }
		}
		  
		[XmlAttribute("Year")]
		[Bindable(true)]
		public int Year 
		{
			get { return GetColumnValue<int>(Columns.Year); }
			set { SetColumnValue(Columns.Year, value); }
		}
		  
		[XmlAttribute("Day")]
		[Bindable(true)]
		public int Day 
		{
			get { return GetColumnValue<int>(Columns.Day); }
			set { SetColumnValue(Columns.Day, value); }
		}
		  
		[XmlAttribute("Isavailable")]
		[Bindable(true)]
		public bool Isavailable 
		{
			get { return GetColumnValue<bool>(Columns.Isavailable); }
			set { SetColumnValue(Columns.Isavailable, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Person ActiveRecord object related to this Availability
		/// 
		/// </summary>
		public TFS.OpCenter.Data.Person Person
		{
			get { return TFS.OpCenter.Data.Person.FetchByID(this.Personid); }
			set { SetColumnValue("personid", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varPersonid,int varMonth,int varYear,int varDay,bool varIsavailable)
		{
			Availability item = new Availability();
			
			item.Personid = varPersonid;
			
			item.Month = varMonth;
			
			item.Year = varYear;
			
			item.Day = varDay;
			
			item.Isavailable = varIsavailable;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varPersonid,int varMonth,int varYear,int varDay,bool varIsavailable)
		{
			Availability item = new Availability();
			
				item.Id = varId;
			
				item.Personid = varPersonid;
			
				item.Month = varMonth;
			
				item.Year = varYear;
			
				item.Day = varDay;
			
				item.Isavailable = varIsavailable;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PersonidColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MonthColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn YearColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DayColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IsavailableColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Personid = @"personid";
			 public static string Month = @"month";
			 public static string Year = @"year";
			 public static string Day = @"day";
			 public static string Isavailable = @"isavailable";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
