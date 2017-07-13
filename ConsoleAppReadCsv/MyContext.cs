namespace ConsoleAppReadCsv
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyContext : DbContext
    {

        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで接続文字列を変更してください。
        public MyContext()
            : base("name=MyContext")//App.configの接続文字列を取得
        {
        }

        // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。

        public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class MyEntity
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }

    }
}