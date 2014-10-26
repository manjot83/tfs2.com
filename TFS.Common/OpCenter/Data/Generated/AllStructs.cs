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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Articlecategory = @"articlecategories";
        
		public static string Availability = @"availability";
        
		public static string Dbversion = @"dbversion";
        
		public static string Externallink = @"externallinks";
        
		public static string Formcode = @"formcodes";
        
		public static string Formfield = @"formfields";
        
		public static string Formfile = @"formfiles";
        
		public static string Formrecord = @"formrecords";
        
		public static string Form = @"forms";
        
		public static string Helparticle = @"helparticles";
        
		public static string Newspost = @"newsposts";
        
		public static string Person = @"persons";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table Articlecategory{
            get { return DataService.GetSchema("articlecategories","OpCenter"); }
		}
        
		public static TableSchema.Table Availability{
            get { return DataService.GetSchema("availability","OpCenter"); }
		}
        
		public static TableSchema.Table Dbversion{
            get { return DataService.GetSchema("dbversion","OpCenter"); }
		}
        
		public static TableSchema.Table Externallink{
            get { return DataService.GetSchema("externallinks","OpCenter"); }
		}
        
		public static TableSchema.Table Formcode{
            get { return DataService.GetSchema("formcodes","OpCenter"); }
		}
        
		public static TableSchema.Table Formfield{
            get { return DataService.GetSchema("formfields","OpCenter"); }
		}
        
		public static TableSchema.Table Formfile{
            get { return DataService.GetSchema("formfiles","OpCenter"); }
		}
        
		public static TableSchema.Table Formrecord{
            get { return DataService.GetSchema("formrecords","OpCenter"); }
		}
        
		public static TableSchema.Table Form{
            get { return DataService.GetSchema("forms","OpCenter"); }
		}
        
		public static TableSchema.Table Helparticle{
            get { return DataService.GetSchema("helparticles","OpCenter"); }
		}
        
		public static TableSchema.Table Newspost{
            get { return DataService.GetSchema("newsposts","OpCenter"); }
		}
        
		public static TableSchema.Table Person{
            get { return DataService.GetSchema("persons","OpCenter"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["OpCenter"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository {
            get {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
	
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
            
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
     
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static string OpCenter = @"OpCenter";
    
}
#endregion