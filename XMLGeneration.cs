using System.Data;
using System;

namespace ConsoleApp2
{
    
    public class XMLGeneration
    {
        DataSet ds;
        public void generate() {
            ds.Tables.Add(new DataTable("Чеки"));
            ds.Tables["Чеки"].Columns.Add(new DataColumn("НомерЧека", Type.GetType("System.Int32")));
            ds.Tables["Чеки"].Columns.Add(new DataColumn("ДатаЧека", Type.GetType("System.DateTime")));
            ds.Tables["Чеки"].Columns.Add(new DataColumn("Магазин", Type.GetType("System.String")));
            ds.Tables["Чеки"].Columns.Add(new DataColumn("ФИОКассира", Type.GetType("System.String")));
            ds.Tables["Чеки"].Columns.Add(new DataColumn("ОбщаяСтоимость", Type.GetType("System.Int32")));


            ds.Tables["Чеки"].PrimaryKey = new DataColumn[2]
            {
                ds.Tables["Чеки"].Columns["НомерЧека"],
                ds.Tables["Чеки"].Columns["ДатаЧека"]
            };

            ds.Tables.Add(new DataTable("ЗаписьЧека"));
            ds.Tables["ЗаписьЧека"].Columns.Add(new DataColumn("НомерЗаписиЧека", Type.GetType("System.Int32")));
            ds.Tables["ЗаписьЧека"].Columns.Add(new DataColumn("НомерЧека", Type.GetType("System.Int32")));
            ds.Tables["ЗаписьЧека"].Columns.Add(new DataColumn("ДатаЧека", Type.GetType("System.DateTime")));
            ds.Tables["ЗаписьЧека"].Columns.Add(new DataColumn("Товар", Type.GetType("System.String")));
            ds.Tables["ЗаписьЧека"].Columns.Add(new DataColumn("ЦенаТовара", Type.GetType("System.Int32")));
            ds.Tables["ЗаписьЧека"].Columns.Add(new DataColumn("Количество", Type.GetType("System.Int32")));


            ds.Tables["ЗаписьЧека"].Columns.Add(new DataColumn("Стоимость", Type.GetType("System.Int32")));

            ds.Tables["ЗаписьЧека"].PrimaryKey = new DataColumn[3]
            {
                ds.Tables["ЗаписьЧека"].Columns["НомерЗаписиЧека"],
                ds.Tables["ЗаписьЧека"].Columns["НомерЧека"],
                ds.Tables["ЗаписьЧека"].Columns["ДатаЧека"]
            };



            ds.Relations.Add
            (
                new DataRelation
                (
                    "СвязьЧека",
                    new DataColumn[]
                    {
                        ds.Tables["Чеки"].Columns["НомерЧека"],
                        ds.Tables["Чеки"].Columns["ДатаЧека"]
                    },
                    new DataColumn[]
                    {
                        ds.Tables["ЗаписьЧека"].Columns["НомерЧека"],
                        ds.Tables["ЗаписьЧека"].Columns["ДатаЧека"]
                    }
                )
            );

        }
        public void write() {
            ds.WriteXml("check.xml", XmlWriteMode.WriteSchema);
        }
        public DataSet read() {
            DataSet readDataSet = new DataSet();
            readDataSet.ReadXml("check.xml", XmlReadMode.ReadSchema);
            return readDataSet;
        }

        public XMLGeneration() 
        {

            ds = new DataSet();



        }
    }
}
