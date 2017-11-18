using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DevComponents.DotNetBar;
using System.IO;
using FunctionCtrlModel;
using MongoDB.Bson;
using System.Security.Cryptography;  //md5 

namespace WindowsFormsApplication1
{
    /**
     * 
     * MongoDB 数据库增删改查DEMO
     * 任意拷贝、修改       
     * 
     * */
    public partial class MainForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Model.ConfModel conf = new Model.ConfModel();
        private bool isFirst = true;
     
        private List<Model.AccountModel> accounts = new List<Model.AccountModel>();
        private FunctionCtrlModel.DBfunction<Model.AccountModel> client;
        public MainForm()
        {
            InitializeComponent();
            this.Activated += new EventHandler(Form2_Activated);
        }

        void Form2_Activated(object sender, EventArgs e)
        {
            if (isFirst)
            {
                init();
                
            }
        }

        void init()
        {
            /**
             * 
             * 获取 MongoDB 的配制信息
             * 
             * */
            conf.mongodb_dbAddr =ConfigurationSettings.AppSettings["DBAddress"];
            conf.mongodb_dbName = ConfigurationSettings.AppSettings["database"];
            conf.mongodb_port = Convert.ToInt16(ConfigurationSettings.AppSettings["port"]);
            conf.mongodb_uName = ConfigurationSettings.AppSettings["username"];
            conf.mongodb_uPwd = ConfigurationSettings.AppSettings["password"];
            conf.mongodb_Pool = Convert.ToInt16(ConfigurationSettings.AppSettings["connectionPool"]);
            conf.mongodb_minPool = Convert.ToInt16(ConfigurationSettings.AppSettings["minpool"]);
        }

      

        private void cmdInit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblMsg.ForeColor  = System.Drawing.Color.Blue;
            if (isFirst )
            {FunctionCtrlModel.DBfunction<Model.AccountModel>.Builder<Model.AccountModel> builder = new FunctionCtrlModel.DBfunction<Model.AccountModel>.Builder<Model.AccountModel>();
            builder.setConn(conf.mongodb_dbAddr);
            builder.setDbName(conf.mongodb_dbName);
            builder.setConnectionPool(conf.mongodb_Pool);
            builder.setport(conf.mongodb_port);
            builder.setMinPool(conf.mongodb_minPool);
            builder.setCollectionName("euserParam");
            client = builder.build();            
            }

            lblMsg.Text = "连接 Mongo DB 成功， 请验证下一步...";

            isFirst = false;
        }

        private void cmdInster_Click(object sender, EventArgs e)
        {
            //增加文档内容
            //1. check link MongoDB 
            //2. insert 
            lblMsg.Text = "";
            lblMsg.ForeColor = System.Drawing.Color.Blue;
            if (isFirst)
            {
                MessageBox.Show("请先初始化连接 MongoDB，再进行 增加文档内容 作业","ERROR");
            }
            else 
            {
                Model.AccountModel account = new Model.AccountModel();
                account.value = txtValue.Text;

                client.Insert("name", txtValue.Text );
              

                lblMsg.Text ="Insert 成功。";

                Model.AccountModel ress = client.Find(MongoDB.Driver.Builders.Query<Model.AccountModel>.EQ(xx => xx.name, account.value));

                dataGridView1.Rows.Add(ress.name, ress.id);
                
                txtValue.Text = "";
                txtNewV.Text = "";
                
            }

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //查询文档
            lblMsg.Text = "";
            lblMsg.ForeColor = System.Drawing.Color.Blue;
            if (isFirst)
            {
                MessageBox.Show("请先初始化连接 MongoDB，再进行 增加文档内容 作业", "Error:");
            }
            else
            {
                Model.AccountModel account = new Model.AccountModel();

                account.value = txtValue.Text;

                Model.AccountModel ress = client.Find(MongoDB.Driver.Builders.Query<Model.AccountModel>.EQ(xx => xx.name, account.value));

                try
                {

                    dataGridView1.Rows.Add(ress.name, ress.id);
                    
                }
                catch (Exception)
                {
                    lblMsg.Text = "沒有找到值：" + account.value;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            
        }
        private void cmdDel_Click(object sender, EventArgs e)
        {
            //删除文档
            lblMsg.Text = "";
            lblMsg.ForeColor = System.Drawing.Color.Blue;
            if (txtValue.Text=="")
            {
                lblMsg.Text = "請輸入 刪除 條件： File value" ;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (isFirst)
            {
                MessageBox.Show("请先初始化连接 MongoDB，再进行 增加文档内容 作业","Error:");
            }
            else
            {

                client.Delete("name", txtValue.Text);
                lblMsg.Text = "Delete 成功。";
                dataGridView1.Rows.Add(txtValue.Text, "Delete");
                txtValue.Text = "";
                txtNewV.Text = "";
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        { 
            //变更文档内容
            lblMsg.Text = "";
            lblMsg.ForeColor = System.Drawing.Color.Blue;
            if (isFirst)
            {
                MessageBox.Show("请先初始化连接 MongoDB，再进行 增加文档内容 作业", "Error:");
            }
            else
            {
                try
                {
                    client.Update("name", txtValue.Text, txtNewV.Text.ToString());
                    lblMsg.Text = "Update 成功。";

                    Model.AccountModel account = new Model.AccountModel();

                    account.value = txtNewV.Text;
                    Model.AccountModel ress = client.Find(MongoDB.Driver.Builders.Query<Model.AccountModel>.EQ(xx => xx.name, account.value));


                    dataGridView1.Rows.Add(ress.name, ress.id);
                    
                    txtValue.Text = "";
                    txtNewV.Text = "";
                }
                catch(Exception)
                {
                    lblMsg.Text = "沒有找到值：" + txtValue.Text;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            

        }

       

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void cmdMD5_Click(object sender, EventArgs e)
        {
try
{
    FileStream file = new FileStream("F:\\MES_GIT\\poc_project\\MongoDB_PoC\\C#\\readme.txt", FileMode.Open);
    System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
    byte[] retVal = md5.ComputeHash(file);
    file.Close();
 
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < retVal.Length; i++)
    {
        sb.Append(retVal[i].ToString("x2"));
    }
    lblMsg.Text = sb.ToString().ToUpper();
}
catch (Exception ex)
{
    lblMsg.Text="Get MD5 fail,error:" + ex.Message;
}
        }

       
    }
}