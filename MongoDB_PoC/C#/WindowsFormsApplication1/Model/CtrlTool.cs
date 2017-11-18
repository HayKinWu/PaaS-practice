/*using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionCtrlModel;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Test.MongoDB
{
    class Program
    {
        /// <summary>
        /// 數據庫連接
        /// </summary>
        private const string conn = "mongodb://192.168.200.184:27017";
        /// <summary>
        /// 指定的數據庫
        /// </summary>
        private const string dbName = "mlog";
        /// <summary>
        /// 指定的表
        /// </summary>
        private const string tbName = "log_table";
        //創建數據連接
        private static MongoServer server = MongoServer.Create(conn);
        //獲取指定數據庫
        private static MongoDatabase db = server.GetDatabase(dbName);

        static void Main(string[] args)
        {
 //for (var index = 0; index < 2; index++)
 //{
 //    Student stu = new Student;
 //    stu.Name = "name" + index;
 //    stu.Age = index;
 //    stu.CreateDateTime = DateTime.Now.ToMillisecond;
 //    stu.Ques = new List<Ques>;
 //    stu.Ques.Add(new Ques { Name = "qname" + index });
 //    Add(stu);
 //}
 Console.WriteLine("獲取學生數據列表");
 var list = GetStudentList;
 foreach (var item in list)
 {
 Console.WriteLine(item.Name + " " + item.Age);
 }
 Console.WriteLine("獲取學生姓名分組和數量");
 Dictionary<string, int> group = GetStudentGroup;
 foreach (var item in group)
 {
 Console.WriteLine(item.Key + " " + item.Value);
 }
 Console.Read;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="text">內容</param>
        /// <param name="articleId">文章ID</param>
        /// <param name="channelId">頻道ID</param>
        /// <returns></returns>
        public static void Add(Student t)
        {
 //獲取表
 MongoCollection col = db.GetCollection(tbName);
 //插入
 col.Insert(t);

        }
        public static List<Student> GetStudentList
        {
 //創建數據連接
 MongoServer server = MongoServer.Create(conn);
 //獲取指定數據庫
 MongoDatabase db = server.GetDatabase(dbName);
 //獲取表
 MongoCollection<Student> col = db.GetCollection<Student>(tbName);
 //條件查詢 
 var query = Query.And(Query.LTE("Age", 5));  
 MongoCursor<Student> mongoCursor = col.FindAs<Student>(query);
 //總數
 Console.WriteLine(mongoCursor.Count);
 mongoCursor = col.FindAs<Student>(query);
 //排序
 mongoCursor.SetSortOrder(SortBy.Descending("Age"));
 //分頁
 mongoCursor.SetSkip(2);
 mongoCursor.SetLimit(2);
 List<Student> result = mongoCursor.ToList; 
 return result;
        }
        public static Dictionary<string, int> GetStudentGroup
        {
 Dictionary<string, int> result = new Dictionary<string, int>;
 result["num"] = 0;
 //創建數據連接
 MongoServer server = MongoServer.Create(conn);
 //獲取指定數據庫
 MongoDatabase db = server.GetDatabase(dbName);
 //獲取表
 MongoCollection<Student> col = db.GetCollection<Student>(tbName);
 GroupByBuilder groupbyBuilder = new GroupByBuilder(new string[] { "Name" });
 var query = Query.And(Query.LTE("Age", 5));
 var result_R = col.Group(query, groupbyBuilder, BsonDocument.Create(result), BsonJavaScript.Create("function(doc,prev){prev.num++;}"),
 BsonJavaScript.Create("function(doc){ doc.count=doc.num;delete doc.num; }")).ToList;
 if (result_R.Count != 0)
 {
 result = new Dictionary<string, int>;
 for (int i = 1; i < result_R.Count; i++)
 {
 result.Add(result_R[i]["Name"].ToString, Convert.ToInt32(result_R[i]["count"]));

 }
 }
 return result;
        }
    }
    [BsonIgnoreExtraElements]
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Ques> Ques { get; set; }
        public long CreateDateTime { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Ques
    {
        public string Name { get; set; }
    }
}*/