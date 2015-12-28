using System;
using System.Collections.Generic;
using Migrator.Framework;
using System.Text;
using System.Data;
using System.Globalization;

namespace Facturanet.DbMigration
{
    public abstract class FacturanetMigration : Migration
    {
        public string[] CurrentColumns { get; set; }
        public string CurrentTable;

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <param name="columns">The columns.</param>
        public void CreateTable(params Column[] columns)
        {
            Database.AddTable(CurrentTable, columns);
            List<string> tmp = new List<string>();
            foreach (Column col in columns)
                tmp.Add(col.Name);
            CurrentColumns = tmp.ToArray();
        }

        public void CreateTable(string tableName, params Column[] columns)
        {
            CurrentTable = tableName;
            CreateTable(columns);
        }

        public void Insert(params string[] data)
        {
            Database.Insert(CurrentTable, CurrentColumns, data);
        }

        public Column CColId()
        {
            return new Column("id", DbType.Guid, ColumnProperty.PrimaryKey);
        }

        public Column CColIsDeleted()
        {
            return new Column("IsDeleted", DbType.Guid, ColumnProperty.Null);
        }

        public Column CColDeletedMark()
        {
            return new Column("DeletedMark", DbType.Guid, ColumnProperty.Null);
        }

        public Column CColActive()
        {
            return new Column("Active", DbType.Boolean, 1, ColumnProperty.NotNull, true);
        }

        public Column CColFK(string name, bool allowNull)
        {
            return new Column(
                name,
                DbType.Guid,
                allowNull
                    ? ColumnProperty.Null
                    : ColumnProperty.NotNull);
        }

        public Column CColString(string name, int size)
        {
            return new Column(name, DbType.String, size, ColumnProperty.NotNull);
        }

        public Column CColText(string name)
        {
            return new Column(name, DbType.String, 65535, ColumnProperty.Null);
        }

        public Column CColColor()
        {
            return new Column("Color", DbType.StringFixedLength, 7, ColumnProperty.NotNull, "#FFFFFF");
        }

        public Column CColChar(string name, string defaultvalue)
        {
            return new Column(name, DbType.StringFixedLength, 1, ColumnProperty.NotNull, defaultvalue);
        }

        public Column CColDateTime(string name, bool allowNull)
        {
            return new Column(
                name, 
                DbType.DateTime, 
                allowNull
                    ? ColumnProperty.Null
                    : ColumnProperty.NotNull);
        }

        public Column CColBool(string name, bool defaultvalue)
        {
            return new Column(name, DbType.Boolean, ColumnProperty.NotNull, defaultvalue);
        }

        public Column CColPercent(string name, decimal defaultvalue)
        {
            return new Column(name, DbType.Decimal, ColumnProperty.NotNull, defaultvalue.ToString("G", CultureInfo.InvariantCulture));
        }

        public Column CColVersion()
        {
            return new Column("Version", DbType.Int32, ColumnProperty.NotNull, 0);
        }

        public void AddColumn(Column column)
        {
            Database.AddColumn(CurrentTable, column);
        }

        public void AddForeignKey(string forenKey, string forenTable)
        {
            Database.AddForeignKey(
                string.Format("fk_{0}_{1}", CurrentTable, forenKey), 
                CurrentTable,
                forenKey,
                forenTable,
                "Id");
        }

        public void RemoveForenKey(string tableName, string forenKey)
        {
            Database.RemoveForeignKey(
                tableName,
                string.Format("fk_{0}_{1}", tableName, forenKey));
        }

        public void RemoveForenKey(string forenKey)
        {
            RemoveForenKey(CurrentTable, forenKey);
        }
    }
}
