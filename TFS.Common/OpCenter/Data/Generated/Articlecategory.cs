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
	/// Strongly-typed collection for the Articlecategory class.
	/// </summary>
    [Serializable]
	public partial class ArticlecategoryCollection : ActiveList<Articlecategory, ArticlecategoryCollection>
	{	   
		public ArticlecategoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ArticlecategoryCollection</returns>
		public ArticlecategoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Articlecategory o = this[i];
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
	/// This is an ActiveRecord class which wraps the articlecategories table.
	/// </summary>
	[Serializable]
	public partial class Articlecategory : ActiveRecord<Articlecategory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Articlecategory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Articlecategory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Articlecategory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Articlecategory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("articlecategories", TableType.Table, DataService.GetInstance("OpCenter"));
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
				colvarName.DataType = DbType.AnsiString;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "description";
				colvarDescription.DataType = DbType.AnsiString;
				colvarDescription.MaxLength = 100;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = false;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
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
				DataService.Providers["OpCenter"].AddSchema("articlecategories",schema);
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
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
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
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public TFS.OpCenter.Data.NewspostCollection Newsposts()
		{
			return new TFS.OpCenter.Data.NewspostCollection().Where(Newspost.Columns.Categoryid, Id).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varDescription,bool? varDeleted,DateTime? varCreatedon,DateTime? varModifiedon,string varCreatedby,string varModifiedby)
		{
			Articlecategory item = new Articlecategory();
			
			item.Name = varName;
			
			item.Description = varDescription;
			
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
		public static void Update(int varId,string varName,string varDescription,bool? varDeleted,DateTime? varCreatedon,DateTime? varModifiedon,string varCreatedby,string varModifiedby)
		{
			Articlecategory item = new Articlecategory();
			
				item.Id = varId;
			
				item.Name = varName;
			
				item.Description = varDescription;
			
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
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DeletedColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedonColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedonColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedbyColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedbyColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Name = @"name";
			 public static string Description = @"description";
			 public static string Deleted = @"deleted";
			 public static string Createdon = @"createdon";
			 public static string Modifiedon = @"modifiedon";
			 public static string Createdby = @"createdby";
			 public static string Modifiedby = @"modifiedby";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
