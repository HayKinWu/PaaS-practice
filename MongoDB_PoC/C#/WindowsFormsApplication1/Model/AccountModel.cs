using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace WindowsFormsApplication1.Model
{
    public class AccountModel : MongoModel
    {
        public AccountModel()
        { 
        }
         
        public string name { get; set; }
        public string value { get; set; }
        public int Age { get; set; }
        public List<AccountModel> Ques { get; set; }
        public long CreateDateTime { get; set; }
        
    }
}
