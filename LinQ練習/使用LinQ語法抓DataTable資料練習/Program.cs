using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace 使用LinQ語法抓DataTable資料練習
{
    class Program
    {
        static void Main( string[] args )
        {
            DataTable PracticeTable = new DataTable();

            PracticeTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID", typeof(int)),
                new DataColumn("Name", typeof(string))
            });

            for (int i = 0 ; i < PracticeTable.Columns.Count ; i++)
            {
                DataRow PracticeRow = PracticeTable.NewRow();

                i += 1;
                PracticeRow["ID"] = i;
                i -= 1;
                PracticeRow["Name"] = i.ToString() + "號機";

                PracticeTable.Rows.Add(PracticeRow);
            }

            var LinQPractice = from ID in PracticeTable.AsEnumerable()
                               where ID.Field<int>("ID") == 1
                               select new
                               {
                                   ID = ID.Field<int>("ID"),
                                   Name = ID.Field<string>("Name")
                               };

            foreach (var item in LinQPractice)
            {
                Console.WriteLine("ID : " + item.ID);
                Console.WriteLine("Name : " + item.Name);
                Console.ReadLine();
            }
        }
    }
}
