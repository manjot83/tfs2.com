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
	/// Strongly-typed collection for the Newspost class.
	/// </summary>
    [Serializable]
	public partial class NewspostCollection : ActiveList<Newspost, NewspostCollection>
	{	   
		public NewspostCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>NewspostCollection</returns>
		public NewspostCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Newspost o = this[i];
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
	/// This is an ActiveRecord class which wraps the newsposts table.
	/// </summary>
	[Serializable]
	public partial class Newspost : ActiveRecord<Newspost>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Newspost()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Newspost(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Newspost(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Newspost(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("newsposts", TableType.Table, DataService.GetInstance("OpCenter"));
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
				
				TableSchema.TableColumn colvarCategoryid = new TableSchema.TableColumn(schema);
				colvarCategoryid.ColumnName = "categoryid";
				colvarCategoryid.DataType = DbType.Int32;
				colvarCategoryid.MaxLength = 0;
				colvarCategoryid.AutoIncrement = false;
				colvarCategoryid.IsNullable = false;
				colvarCategoryid.IsPrimaryKey = false;
				colvarCategoryid.IsForeignKey = true;
				colvarCategoryid.IsReadOnly = false;
				colvarCategoryid.DefaultSetting = @"";
				
					colvarCategoryid.ForeignKeyTableName = "articlecategories";
				schema.Columns.Add(colvarCategoryid);
				
				TableSchema.TableColumn colvarSubject = new TableSchema.TableColumn(schema);
				colvarSubject.ColumnName = "subject";
				colvarSubject.DataType = DbType.AnsiString;
				colvarSubject.MaxLength = 100;
				colvarSubject.AutoIncrement = false;
				colvarSubject.IsNullable = false;
				colvarSubject.IsPrimaryKey = false;
				colvarSubject.IsForeignKey = false;
				colvarSubject.IsReadOnly = false;
				colvarSubject.DefaultSetting = @"";
				colvarSubject.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubject);
				
				TableSchema.TableColumn colvarContent = new TableSchema.TableColumn(schema);
				colvarContent.ColumnName = "content";
				colvarContent.DataType = DbType.String;
				colvarContent.MaxLength = 1073741823;
				colvarContent.AutoIncrement = false;
				colvarContent.IsNullable = false;
				colvarContent.IsPrimaryKey = false;
				colvarContent.IsForeignKey = false;
				colvarContent.IsReadOnly = false;
				colvarContent.DefaultSetting = @"";
				colvarContent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContent);
				
				TableSchema.TableColumn colvarIsurgent = new TableSchema.TableColumn(schema);
				colvarIsurgent.ColumnName = "isurgent";
				colvarIsurgent.DataType = DbType.Boolean;
				colvarIsurgent.MaxLength = 0;
				colvarIsurgent.AutoIncrement = false;
				colvarIsurgent.IsNullable = false;
				colvarIsurgent.IsPrimaryKey = false;
				colvarIsurgent.IsForeignKey = false;
				colvarIsurgent.IsReadOnly = false;
				
						colvarIsurgent.DefaultSetting = @"((0))";
				colvarIsurgent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsurgent);
				
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
				colvarCreatedon.IsNullable = false;
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
				DataService.Providers["OpCenter"].AddSchema("newsposts",schema);
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
		  
		[XmlAttribute("Categoryid")]
		[Bindable(true)]
		public int Categoryid 
		{
			get { return GetColumnValue<int>(Columns.Categoryid); }
			set { SetColumnValue(Columns.Categoryid, value); }
		}
		  
		[XmlAttribute("Subject")]
		[Bindable(true)]
		public string Subject 
		{
			get { return GetColumnValue<string>(Columns.Subject); }
			set { SetColumnValue(Columns.Subject, value); }
		}
		  
		[XmlAttribute("Content")]
		[Bindable(true)]
		public string Content 
		{
			get { return GetColumnValue<string>(Columns.Content); }
			set { SetColumnValue(Columns.Content, value); }
		}
		  
		[XmlAttribute("Isurgent")]
		[Bindable(true)]
		public bool Isurgent 
		{
			get { return GetColumnValue<bool>(Columns.Isurgent); }
			set { SetColumnValue(Columns.Isurgent, value); }
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
		public DateTime Createdon 
		{
			get { return GetColumnValue<DateTime>(Columns.Createdon); }
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
		
		/// <summary>
		/// Returns a Articlecategory ActiveRecord object related to this Newspost
		/// 
		/// </summary>
		public TFS.OpCenter.Data.Articlecategory Articlecategory
		{
			get { return TFS.OpCenter.Data.Articlecategory.FetchByID(this.Categoryid); }
			set { SetColumnValue("categoryid", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a Person ActiveRecord object related to this Newspost
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
		public static void Insert(int varPersonid,int varCategoryid,string varSubject,string varContent,bool varIsurgent,bool? varDeleted,DateTime varCreatedon,DateTime? varModifiedon,string varCreatedby,string varModifiedby)
		{
			Newspost item = new Newspost();
			
			item.Personid = varPersonid;
			
			item.Categoryid = varCategoryid;
			
			item.Subject = varSubject;
			
			item.Content = varContent;
			
			item.Isurgent = varIsurgent;
			
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
		public static void Update(int varId,int varPersonid,int varCategoryid,string varSubject,string varContent,bool varIsurgent,bool? varDeleted,DateTime varCreatedon,DateTime? varModifiedon,string varCreatedby,string varModifiedby)
		{
			Newspost item = new Newspost();
			
				item.Id = varId;
			
				item.Personid = varPersonid;
			
				item.Categoryid = varCategoryid;
			
				item.Subject = varSubject;
			
				item.Content = varContent;
			
				item.Isurgent = varIsurgent;
			
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
        
        
        
        public static TableSchema.TableColumn PersonidColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoryidColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SubjectColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ContentColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IsurgentColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DeletedColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedonColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedonColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedbyColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedbyColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Personid = @"personid";
			 public static string Categoryid = @"categoryid";
			 public static string Subject = @"subject";
			 public static string Content = @"content";
			 public static string Isurgent = @"isurgent";
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
