using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Wrappers;
using MongoDB.Driver.Internal;
using WindowsFormsApplication1;



namespace FunctionCtrlModel
{
    public class DBfunction<T> where T : WindowsFormsApplication1.Model.MongoModel
    {
        public string conn;
        public string dbName;
        public string collectionName;
        public int port;
        public int connectionPool;
        public int minPool;

        private MongoCollection<T> collection;

        private DBfunction()
        {

        }

        /// <summary>
        /// 设置你的collection
        /// </summary>
        public void SetCollection(string DBAddress, int port, int connectionPool, int minpool, string dbName)
        {

            MongoServerAddress ipaddress = new MongoServerAddress(DBAddress, port);//设置服务器的ip和端口  
            
            MongoClientSettings settingsclient = new MongoClientSettings();//实例化客户端设置类  


            settingsclient.Server = ipaddress;//端口赋值  

            settingsclient.MaxConnectionPoolSize = connectionPool;

            settingsclient.MinConnectionPoolSize = minpool;

            settingsclient.ConnectionMode = 0;//链接模式设置  
            
            MongoClient client = new MongoClient(settingsclient);//调用客户端类构造函数设置参数  


            MongoServer server = client.GetServer();//服务端获取客户端参数  


            var database = server.GetDatabase(dbName);//获取数据库名称  

            collection = database.GetCollection<T>(collectionName);

        }

        /// <summary>
        /// 你用linq的时候会用到
        /// </summary>
        public void getCollection()
        {
            MongoClient client = new MongoClient(conn);
            var server = client.GetServer();
            var database = server.GetDatabase(dbName);
            collection = database.GetCollection<T>(collectionName);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T Find(IMongoQuery query)
        {
            return this.collection.FindOne(query);
            
        }
                
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public long Update(string FileName, string FileValue, string NewFileName)
        {

            var update = new UpdateDocument {
                                                { "$set", new BsonDocument(FileName, NewFileName)   }
                                            };

            var query = Query.EQ(FileName, FileValue);

            WriteConcernResult res = this.collection.Update(query, update);
            
            return res.DocumentsAffected;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="FileName","filevalue"></param>
        /// <returns></returns>        
        public bool Insert(string FileName, string FileValue)
        {
            //使用BsonDocument格式插入
            BsonDocument doc = new BsonDocument();
            doc.Add(FileName, FileValue);
            //BsonDocument doc = new BsonDocument { { "name1", "value1" }, { "name2", "value2" } };  //使用 Json 字符串 insert 记录
            WriteConcernResult res = this.collection.Insert(doc);
            return res.Ok;

        }      

        /// <summary>
        /// 删除
        /// </summary>
        ///<param name="FileName","filevalue"></param>
        /// <returns></returns>
        public bool Delete(string FileName, string FileValue)
        {
            var query = Query.EQ(FileName, FileValue);  

            WriteConcernResult res = this.collection.Remove(query);
            return res.Ok;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Builder<T> where T : WindowsFormsApplication1.Model.MongoModel
        {
            private DBfunction<T> client;

            public Builder()
            {
                client = new DBfunction<T>();
            }

            public void setConn(string conn)
            {
                client.conn = conn;
            }

            public void setDbName(string dbName)
            {
                client.dbName = dbName;
            }

            public void setCollectionName(string collectionName)
            {
                client.collectionName = collectionName;
            }

            public void setport(int port)
            {
                client.port = port;
            }

            public void setConnectionPool(int connectionPool)
            {
                client.connectionPool = connectionPool;
            }

            public void setMinPool(int minPool)
            {
                client.minPool = minPool;
            }


            public DBfunction<T> build()
            {
                client.SetCollection(client.conn, client.port, client.connectionPool, client.minPool, client.dbName);
                return client;
            }

            
        }
    }
}
