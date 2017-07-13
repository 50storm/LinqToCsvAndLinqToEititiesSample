using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace ConsoleAppReadCsv
{
    class LinqToCsv
    {
        /// <summary>
        /// LINQ to CSVを使ったサンプル
        /// </summary>
        public void ExecuteByLinqToCsv()
        {
            //
            // LINQ to CSVのサンプル.
            //   元ネタ： http://www.codeproject.com/Articles/25133/LINQ-to-CSV-library
            //
            // LINQ to CSVはNuGetでインストールできる.
            //   Install-Package LINQToCSV
            //

            // 
            // ヘッダー無しのCSVファイル読み込み.
            //


            string testCsv  = @"..\..\CSV\Test.csv";
            string test2Csv = @"..\..\CSV\Test2.csv";
            string WithHeader = @"..\..\CSV\WithHeader.csv";


            // コンテキストを構築.
            var context = new CsvContext();

            //
            // CSVの情報を示すオブジェクトを構築.
            //
            var description = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = false,
                EnforceCsvColumnAttribute = true,
                TextEncoding = Encoding.UTF8
            };


            //
            // 読み取り.
            //
            var nameAndBirthDays = from aData in context.Read<CSVData>(testCsv, description)
                                   select new
                                   {
                                       aData.Name,
                                       aData.BirthDay
                                   };

            foreach (var data in nameAndBirthDays)
            {
                Console.WriteLine(data);
            }

            Console.ReadLine();

            //
            // 書き込み.
            //
            var dataList = context.Read<CSVData>(testCsv, description).ToList();

            dataList.Add(new CSVData
            {
                Id = 3,
                Name = "name3",
                Age = 35,
                BirthDay = DateTime.Now.AddDays(-100).Date
            });

            context.Write<CSVData>(dataList, test2Csv, description);

            //
            // 確認.
            //
            foreach (var data in context.Read<CSVData>(test2Csv, description).Select(_ => new { _.Name, _.BirthDay }))
            {
                Console.WriteLine(data);
            }

            Console.ReadLine();


            //
            // ヘッダー付きのCSVファイルを読み込み.
            //
            description = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true,
                TextEncoding = Encoding.UTF8
            };

            var query = from data in context.Read<WithHeaderCSVData>(WithHeader, description)
                        orderby data.Id
                        select new
                        {
                            data.Name,
                            data.BirthDay
                        };

            foreach (var data in query)
            {
                Console.WriteLine(data);
            }


        }
    }



    /// <summary>
    /// HeaderなしCSVの定義
    /// </summary>
    class CSVData
    {
        [CsvColumn(FieldIndex = 1)]
        public int Id { get; set; }
        [CsvColumn(FieldIndex = 2)]
        public string Name { get; set; }
        [CsvColumn(FieldIndex = 3)]
        public int Age { get; set; }
        [CsvColumn(FieldIndex = 4)]
        public DateTime BirthDay { get; set; }

    }

    /// <summary>
    /// HeaderありCSVの定義
    /// </summary>
    class WithHeaderCSVData
    {
        [CsvColumn(Name = "DataId", FieldIndex = 1)]
        public int Id { get; set; }
        [CsvColumn(Name = "PersonName", FieldIndex = 2)]
        public string Name { get; set; }
        [CsvColumn(Name = "PersonAge", FieldIndex = 3)]
        public int Age { get; set; }
        [CsvColumn(Name = "Day", FieldIndex = 4)]
        public DateTime BirthDay { get; set; }

    }

}

