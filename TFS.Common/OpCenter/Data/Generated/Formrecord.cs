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
	/// Strongly-typed collection for the Formrecord class.
	/// </summary>
    [Serializable]
	public partial class FormrecordCollection : ActiveList<Formrecord, FormrecordCollection>
	{	   
		public FormrecordCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>FormrecordCollection</returns>
		public FormrecordCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Formrecord o = this[i];
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
	/// This is an ActiveRecord class which wraps the formrecords table.
	/// </summary>
	[Serializable]
	public partial class Formrecord : ActiveRecord<Formrecord>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Formrecord()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Formrecord(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Formrecord(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Formrecord(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("formrecords", TableType.Table, DataService.GetInstance("OpCenter"));
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
				
				TableSchema.TableColumn colvarFileid = new TableSchema.TableColumn(schema);
				colvarFileid.ColumnName = "fileid";
				colvarFileid.DataType = DbType.Int32;
				colvarFileid.MaxLength = 0;
				colvarFileid.AutoIncrement = false;
				colvarFileid.IsNullable = false;
				colvarFileid.IsPrimaryKey = false;
				colvarFileid.IsForeignKey = true;
				colvarFileid.IsReadOnly = false;
				colvarFileid.DefaultSetting = @"";
				
					colvarFileid.ForeignKeyTableName = "formfiles";
				schema.Columns.Add(colvarFileid);
				
				TableSchema.TableColumn colvarFieldid = new TableSchema.TableColumn(schema);
				colvarFieldid.ColumnName = "fieldid";
				colvarFieldid.DataType = DbType.Int32;
				colvarFieldid.MaxLength = 0;
				colvarFieldid.AutoIncrement = false;
				colvarFieldid.IsNullable = false;
				colvarFieldid.IsPrimaryKey = false;
				colvarFieldid.IsForeignKey = true;
				colvarFieldid.IsReadOnly = false;
				colvarFieldid.DefaultSetting = @"";
				
					colvarFieldid.ForeignKeyTableName = "formfields";
				schema.Columns.Add(colvarFieldid);
				
				TableSchema.TableColumn colvarCodeid = new TableSchema.TableColumn(schema);
				colvarCodeid.ColumnName = "codeid";
				colvarCodeid.DataType = DbType.Int32;
				colvarCodeid.MaxLength = 0;
				colvarCodeid.AutoIncrement = false;
				colvarCodeid.IsNullable = true;
				colvarCodeid.IsPrimaryKey = false;
				colvarCodeid.IsForeignKey = true;
				colvarCodeid.IsReadOnly = false;
				colvarCodeid.DefaultSetting = @"";
				
					colvarCodeid.ForeignKeyTableName = "formcodes";
				schema.Columns.Add(colvarCodeid);
				
				TableSchema.TableColumn colvarStoredvalue = new TableSchema.TableColumn(schema);
				colvarStoredvalue.ColumnName = "storedvalue";
				colvarStoredvalue.DataType = DbType.AnsiString;
				colvarStoredvalue.MaxLength = 2147483647;
				colvarStoredvalue.AutoIncrement = false;
				colvarStoredvalue.IsNullable = true;
				colvarStoredvalue.IsPrimaryKey = false;
				colvarStoredvalue.IsForeignKey = false;
				colvarStoredvalue.IsReadOnly = false;
				colvarStoredvalue.DefaultSetting = @"";
				colvarStoredvalue.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStoredvalue);
				
				TableSchema.TableColumn colvarDeleted = new TableSchema.TableColumn(schema);
				colvarDeleted.ColumnName = "deleted";
				colvarDeleted.DataType = DbType.Boolean;
				colvarDeleted.MaxLength = 0;
				colvarDeleted.AutoIncrement = false;
				colvarDeleted.IsNullable = true;
				colvarDeleted.IsPrimaryKey = false;
				colvarDeleted.IsForeignKey = false;
				colvarDeleted.IsReadOnly = false;
				
						colvarDeleted.DefaultSetting = @"((0))";
				colvarDeleted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDeleted);
				
				TableSchema.TableColumn colvarCreatedon = new TableSchema.TableColumn(schema);
				colvarCreatedon.ColumnName = "createdon";
				colvarCreatedon.DataType = DbType.DateTime;
				colvarCreatedon.MaxLength = 0;
				colvarCreatedon.AutoIncrement = false;
				colvarCreatedon.IsNullable = true;
				colvarCreatedon.IsPrimaryKey = false;
				colvarCreatedon.IsForeignKey = false;
				colvarCreatedon.IsReadOnly = false;
				colvarCreatedon.DefaultSetting = @"";
				colvarCreatedon.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedon);
				
				TableSchema.TableColumn colvarModifiedon = new TableSchema.TableColumn(schema);
				colvarModifiedon.ColumnName = "modifiedon";
				colvarModifiedon.DataType = DbType.DateTime;
				colvarModifiedon.MaxLength = 0;
				colvarModifiedon.AutoIncrement = false;
				colvarModifiedon.IsNullable = true;
				colvarModifiedon.IsPrimaryKey = false;
				colvarModifiedon.IsForeignKey = false;
				colvarModifiedon.IsReadOnly = false;
				colvarModifiedon.DefaultSetting = @"";
				colvarModifiedon.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedon);
				
				TableSchema.TableColumn colvarCreatedby = new TableSchema.TableColumn(schema);
				colvarCreatedby.ColumnName = "createdby";
				colvarCreatedby.DataType = DbType.AnsiString;
				colvarCreatedby.MaxLength = 50;
				colvarCreatedby.AutoIncrement = false;
				colvarCreatedby.IsNullable = true;
				colvarCreatedby.IsPrimaryKey = false;
				colvarCreatedby.IsForeignKey = false;
				colvarCreatedby.IsReadOnly = false;
				colvarCreatedby.DefaultSetting = @"";
				colvarCreatedby.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedby);
				
				TableSchema.TableColumn colvarModifiedby = new TableSchema.TableColumn(schema);
				colvarModifiedby.ColumnName = "modifiedby";
				colvarModifiedby.DataType = DbType.AnsiString;
				colvarModifiedby.MaxLength = 50;
				colvarModifiedby.AutoIncrement = false;
				colvarModifiedby.IsNullable = true;
				colvarModifiedby.IsPrimaryKey = false;
				colvarModifiedby.IsForeignKey = false;
				colvarModifiedby.IsReadOnly = false;
				colvarModifiedby.DefaultSetting = @"";
				colvarModifiedby.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedby);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["OpCenter"].AddSchema("formrecords",schema);
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
		  
		[XmlAttribute("Fileid")]
		[Bindable(true)]
		public int Fileid 
		{
			get { return GetColumnValue<int>(Columns.Fileid); }
			set { SetColumnValue(Columns.Fileid, value); }
		}
		  
		[XmlAttribute("Fieldid")]
		[Bindable(true)]
		public int Fieldid 
		{
			get { return GetColumnValue<int>(Columns.Fieldid); }
			set { SetColumnValue(Columns.Fieldid, value); }
		}
		  
		[XmlAttribute("Codeid")]
		[Bindable(true)]
		public int? Codeid 
		{
			get { return GetColumnValue<int?>(Columns.Codeid); }
			set { SetColumnValue(Columns.Codeid, value); }
		}
		  
		[XmlAttribute("Storedvalue")]
		[Bindable(true)]
		public string Storedvalue 
		{
			get { return GetColumnValue<string>(Columns.Storedvalue); }
			set { SetColumnValue(Columns.Storedvalue, value); }
		}
		  
		[XmlAttribute("Deleted")]
		[Bindable(true)]
		public bool? Deleted 
		{
			get { return GetColumnValue<bool?>(Columns.Deleted); }
			set { SetColumnValue(Columns.Deleted, value); }
		}
		  
		[XmlAttribute("Createdon")]
		[Bindable(true)]
		public DateTime? Createdon 
		{
			get { return GetColumnValue<DateTime?>(Columns.Createdon); }
			set { SetColumnValue(Columns.Createdon, value); }
		}
		  
		[XmlAttribute("Modifiedon")]
		[Bindable(true)]
		public DateTime? Modifiedon 
		{
			get { return GetColumnValue<DateTime?>(Columns.Modifiedon); }
			set { SetColumnValue(Columns.Modifiedon, value); }
		}
		  
		[XmlAttribute("Createdby")]
		[Bindable(true)]
		public string Createdby 
		{
			get { return GetColumnValue<string>(Columns.Createdby); }
			set { SetColumnValue(Columns.Createdby, value); }
		}
		  
		[XmlAttribute("Modifiedby")]
		[Bindable(true)]
		public string Modifiedby 
		{
			get { return GetColumnValue<string>(Columns.Modifiedby); }
			set { SetColumnValue(Columns.Modifiedby, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties

        public TFS.OpCenter.Data.Formfile CachedFormfile;
		/// <summary>
		/// Returns a Formfile ActiveRecord object related to this Formrecord
		/// 
		/// </summary>
		public TFS.OpCenter.Data.Formfile Formfile
		{
            get
            {
                if (CachedFormfile == null)
                {
                    CachedFormfile = TFS.OpCenter.Data.Formfile.FetchByID(this.Fileid);
                }
                return CachedFormfile;
            }
            set { SetColumnValue("fileid", value.Id); }
		}


        private TFS.OpCenter.Data.Formcode CachedFormcode;
		/// <summary>
		/// Returns a Formcode ActiveRecord object related to this Formrecord
		/// 
		/// </summary>
		public TFS.OpCenter.Data.Formcode Formcode
		{
            get
            {
                if (CachedFormcode == null)
                {
                    CachedFormcode = TFS.OpCenter.Data.Formcode.FetchByID(this.Codeid);
                }
                return CachedFormcode;
            }
			set { SetColumnValue("codeid", value.Id); }
		}


        private TFS.OpCenter.Data.Formfield CachedFormfield;
		/// <summary>
		/// Returns a Formfield ActiveRecord object related to this Formrecord
		/// 
		/// </summary>
		public TFS.OpCenter.Data.Formfield Formfield
		{
            get
            {
                if (CachedFormfield == null)
                {
                    CachedFormfield = TFS.OpCenter.Data.Formfield.FetchByID(this.Fieldid);
                }
                return CachedFormfield;
            }
			set { SetColumnValue("fieldid", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varFileid,int varFieldid,int? varCodeid,string varStoredvalue,bool? varDeleted,DateTime? varCreatedon,DateTime? varModifiedon,string varCreatedby,string varModifiedby)
		{
			Formrecord item = new Formrecord();
			
			item.Fileid = varFileid;
			
			item.Fieldid = varFieldid;
			
			item.Codeid = varCodeid;
			
			item.Storedvalue = varStoredvalue;
			
			item.Deleted = varDeleted;
			
			item.Createdon = varCreatedon;
			
			item.Modifiedon = varModifiedon;
			
			item.Createdby = varCreatedby;
			
			item.Modifiedby = varModifiedby;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varFileid,int varFieldid,int? varCodeid,string varStoredvalue,bool? varDeleted,DateTime? varCreatedon,DateTime? varModifiedon,string varCreatedby,string varModifiedby)
		{
			Formrecord item = new Formrecord();
			
				item.Id = varId;
			
				item.Fileid = varFileid;
			
				item.Fieldid = varFieldid;
			
				item.Codeid = varCodeid;
			
				item.Storedvalue = varStoredvalue;
			
				item.Deleted = varDeleted;
			
				item.Createdon = varCreatedon;
			
				item.Modifiedon = varModifiedon;
			
				item.Createdby = varCreatedby;
			
				item.Modifiedby = varModifiedby;
			
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
        
        
        
        public static TableSchema.TableColumn FileidColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FieldidColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CodeidColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn StoredvalueColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DeletedColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedonColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedonColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedbyColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedbyColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Fileid = @"fileid";
			 public static string Fieldid = @"fieldid";
			 public static string Codeid = @"codeid";
			 public static string Storedvalue = @"storedvalue";
			 public static string Deleted = @"deleted";
			 public static string Createdon = @"createdon";
			 public static string Modifiedon = @"modifiedon";
			 public static string Createdby = @"createdby";
			 public static string Modifiedby = @"modifiedby";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
