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
    /// Strongly-typed collection for the BillingDefaultCityRate class.
    /// </summary>
    [Serializable]
    public partial class BillingDefaultCityRateCollection : ActiveList<BillingDefaultCityRate, BillingDefaultCityRateCollection>
    {
        public BillingDefaultCityRateCollection() { }

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vw_BillingDefaultCityRate view.
    /// </summary>
    [Serializable]
    public partial class BillingDefaultCityRate : ActiveRecord<BillingDefaultCityRate>
    {

        		#region .ctors and Default Settings
		
		public BillingDefaultCityRate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public BillingDefaultCityRate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public BillingDefaultCityRate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}


        public BillingDefaultCityRate(string columnName, object columnValue)
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
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }


        private static void GetTableSchema()
        {
            if (!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("BillingDefaultCityRates", TableType.Table, DataService.GetInstance("Billing"));
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

                TableSchema.TableColumn colvarAccountId = new TableSchema.TableColumn(schema);
                colvarAccountId.ColumnName = "AccountId";
                colvarAccountId.DataType = DbType.Int32;
                colvarAccountId.MaxLength = 0;
                colvarAccountId.AutoIncrement = false;
                colvarAccountId.IsNullable = false;
                colvarAccountId.IsPrimaryKey = false;
                colvarAccountId.IsForeignKey = true;
                colvarAccountId.IsReadOnly = false;
                colvarAccountId.DefaultSetting = @"";

                colvarAccountId.ForeignKeyTableName = "BillingAccounts";
                schema.Columns.Add(colvarAccountId);

                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 250;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = false;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;
                colvarCity.DefaultSetting = @"";
                colvarCity.ForeignKeyTableName = "";
                schema.Columns.Add(colvarCity);

                TableSchema.TableColumn colvarDefaultPerDiemRate = new TableSchema.TableColumn(schema);
                colvarDefaultPerDiemRate.ColumnName = "DefaultPerDiemRate";
                colvarDefaultPerDiemRate.DataType = DbType.Double;
                colvarDefaultPerDiemRate.MaxLength = 0;
                colvarDefaultPerDiemRate.AutoIncrement = false;
                colvarDefaultPerDiemRate.IsNullable = false;
                colvarDefaultPerDiemRate.IsPrimaryKey = false;
                colvarDefaultPerDiemRate.IsForeignKey = false;
                colvarDefaultPerDiemRate.IsReadOnly = false;

                schema.Columns.Add(colvarDefaultPerDiemRate);

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

                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Billing"].AddSchema("BillingDefaultCityRates", schema);
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

        [XmlAttribute("AccountId")]
        public int AccountId
        {
            get { return GetColumnValue<int>("AccountId"); }

            set { SetColumnValue("AccountId", value); }

        }

        [XmlAttribute("City")]
        public string City
        {
            get { return GetColumnValue<string>("City"); }

            set { SetColumnValue("City", value); }

        }

        [XmlAttribute("DefaultPerDiemRate")]
        public double DefaultPerDiemRate
        {
            get { return GetColumnValue<int>("DefaultPerDiemRate"); }

            set { SetColumnValue("DefaultPerDiemRate", value); }

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

        [XmlAttribute("IsDeleted")]
        public bool IsDeleted
        {
            get { return GetColumnValue<bool>("IsDeleted"); }

            set { SetColumnValue("IsDeleted", value); }

        }


        #endregion

        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"id";
            public static string AccountId = @"AccountId";
            public static string DefaultPerDiemRate = @"DefaultPerDiemRate";
            public static string City = @"City";
            public static string CreatedOn = @"CreatedOn";
            public static string CreatedBy = @"CreatedBy";
            public static string ModifiedOn = @"ModifiedOn";
            public static string ModifiedBy = @"ModifiedBy";
            public static string IsDeleted = @"IsDeleted";

        }

        #endregion
    }

}

