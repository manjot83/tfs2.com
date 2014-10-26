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

namespace TFS.Intranet.Data.Billing{
    /// <summary>
    /// Strongly-typed collection for the User class.
    /// </summary>
    [Serializable]
    public partial class UserCollection : ReadOnlyList<User, UserCollection>
    {        
        public UserCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_Users view.
    /// </summary>
    [Serializable]
    public partial class User : ReadOnlyRecord<User> 
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("vw_Users", TableType.View, DataService.GetInstance("Billing"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "id";
                colvarId.DataType = DbType.Int32;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(schema);
                colvarUsername.ColumnName = "username";
                colvarUsername.DataType = DbType.String;
                colvarUsername.MaxLength = 50;
                colvarUsername.AutoIncrement = false;
                colvarUsername.IsNullable = false;
                colvarUsername.IsPrimaryKey = false;
                colvarUsername.IsForeignKey = false;
                colvarUsername.IsReadOnly = false;
                
                schema.Columns.Add(colvarUsername);
                
                TableSchema.TableColumn colvarFirstname = new TableSchema.TableColumn(schema);
                colvarFirstname.ColumnName = "firstname";
                colvarFirstname.DataType = DbType.String;
                colvarFirstname.MaxLength = 50;
                colvarFirstname.AutoIncrement = false;
                colvarFirstname.IsNullable = false;
                colvarFirstname.IsPrimaryKey = false;
                colvarFirstname.IsForeignKey = false;
                colvarFirstname.IsReadOnly = false;
                
                schema.Columns.Add(colvarFirstname);
                
                TableSchema.TableColumn colvarLastname = new TableSchema.TableColumn(schema);
                colvarLastname.ColumnName = "lastname";
                colvarLastname.DataType = DbType.String;
                colvarLastname.MaxLength = 50;
                colvarLastname.AutoIncrement = false;
                colvarLastname.IsNullable = false;
                colvarLastname.IsPrimaryKey = false;
                colvarLastname.IsForeignKey = false;
                colvarLastname.IsReadOnly = false;
                
                schema.Columns.Add(colvarLastname);
                
                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 50;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = false;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                
                schema.Columns.Add(colvarTitle);
                
                TableSchema.TableColumn colvarRategroup = new TableSchema.TableColumn(schema);
                colvarRategroup.ColumnName = "rategroup";
                colvarRategroup.DataType = DbType.Int32;
                colvarRategroup.MaxLength = 0;
                colvarRategroup.AutoIncrement = false;
                colvarRategroup.IsNullable = false;
                colvarRategroup.IsPrimaryKey = false;
                colvarRategroup.IsForeignKey = false;
                colvarRategroup.IsReadOnly = false;
                
                schema.Columns.Add(colvarRategroup);
                
                TableSchema.TableColumn colvarRategroupname = new TableSchema.TableColumn(schema);
                colvarRategroupname.ColumnName = "rategroupname";
                colvarRategroupname.DataType = DbType.String;
                colvarRategroupname.MaxLength = 100;
                colvarRategroupname.AutoIncrement = false;
                colvarRategroupname.IsNullable = false;
                colvarRategroupname.IsPrimaryKey = false;
                colvarRategroupname.IsForeignKey = false;
                colvarRategroupname.IsReadOnly = false;
                
                schema.Columns.Add(colvarRategroupname);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Billing"].AddSchema("vw_Users",schema);
            }

        }

        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    
	    #region .ctors
	    public User()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public User(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public User(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public User(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        public int Id 
	    {
		    get
		    {
			    return GetColumnValue<int>("id");
		    }

            set 
		    {
			    SetColumnValue("id", value);
            }

        }

	      
        [XmlAttribute("Username")]
        public string Username 
	    {
		    get
		    {
			    return GetColumnValue<string>("username");
		    }

            set 
		    {
			    SetColumnValue("username", value);
            }

        }

	      
        [XmlAttribute("Firstname")]
        public string Firstname 
	    {
		    get
		    {
			    return GetColumnValue<string>("firstname");
		    }

            set 
		    {
			    SetColumnValue("firstname", value);
            }

        }

	      
        [XmlAttribute("Lastname")]
        public string Lastname 
	    {
		    get
		    {
			    return GetColumnValue<string>("lastname");
		    }

            set 
		    {
			    SetColumnValue("lastname", value);
            }

        }

	      
        [XmlAttribute("Title")]
        public string Title 
	    {
		    get
		    {
			    return GetColumnValue<string>("title");
		    }

            set 
		    {
			    SetColumnValue("title", value);
            }

        }

	      
        [XmlAttribute("Rategroup")]
        public int Rategroup 
	    {
		    get
		    {
			    return GetColumnValue<int>("rategroup");
		    }

            set 
		    {
			    SetColumnValue("rategroup", value);
            }

        }

	      
        [XmlAttribute("Rategroupname")]
        public string Rategroupname 
	    {
		    get
		    {
			    return GetColumnValue<string>("rategroupname");
		    }

            set 
		    {
			    SetColumnValue("rategroupname", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"id";
            
            public static string Username = @"username";
            
            public static string Firstname = @"firstname";
            
            public static string Lastname = @"lastname";
            
            public static string Title = @"title";
            
            public static string Rategroup = @"rategroup";
            
            public static string Rategroupname = @"rategroupname";
            
	    }

	    #endregion
    }

}

