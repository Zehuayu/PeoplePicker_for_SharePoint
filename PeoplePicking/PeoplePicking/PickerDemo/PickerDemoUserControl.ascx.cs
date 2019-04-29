using Microsoft.SharePoint;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace PeoplePicking.PickerDemo
{


   
    public partial class PickerDemoUserControl : UserControl
    {
        private string item;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!this.IsPostBack)
                {
                    BuildTree();
                    ListBox1.Items.Clear();
                    ListBox1.Items.Add("王一");      //仅用于测试专用
                    ListBox1.Items.Add("王二");
                    ListBox1.Items.Add("王三");
                    ListBox1.Items.Add("李二");
                    ListBox1.Items.Add("李三");
                    ListBox1.Items.Add("张二");
                    ListBox1.Items.Add("张三");
                }
            }


        }








        private void BuildTree()
        {


            this.TreeView1.Dispose();//清理
            TreeNodeCollection tnc = this.TreeView1.Nodes;//表示根结点集合 
            SPWeb web = SPContext.Current.Web;           
            SPList list = web.Lists["CategoryDetails"];

            SPQuery q = new SPQuery();
                          q.Query = @"<Where>
                                        <Eq>
                                            <FieldRef Name='k3ll' />
                                            <Value Type='Text'>0</Value>
                                        </Eq>
                                    </Where> ";        
            
            SPListItemCollection items = list.GetItems(q);
            foreach (SPListItem item in items)
            {
                TreeNode tnNodel = new TreeNode();               
                tnNodel.Text = item["Title"].ToString();
                tnc.Add(tnNodel);

                if (items != null && items.Count != 0)
                {
                    Addsubnode(item, list, tnNodel);
                }

            }


        }

        private void Addsubnode(SPListItem item, SPList list, TreeNode tnNodel)
        {
            SPQuery qs = new SPQuery();
            string qsstr = @"<Where>
                                <Eq>
                                    <FieldRef Name='k3ll' />
                                    <Value Type='Text'>{0}</Value>
                                </Eq>
                            </Where> ";

            qs.Query = string.Format(qsstr, item.ID - 1 );          // 有问题 item.id - 1
            SPListItemCollection sitems = list.GetItems(qs);
            if (sitems != null && sitems.Count != 0)
            {
                foreach (SPListItem sitem in sitems)
                {
                    TreeNode t2 = new TreeNode();
                    t2.Text = sitem.Title;
                    tnNodel.ChildNodes.Add(t2);

                    Addsubnode(sitem, list, t2);
                }

            }

           
        }   //递归循环获取node节点



        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeView1.SelectedNode.Selected = false;
            TreeNode node = ((TreeView)sender).SelectedNode;
            TreeNode NewNode = new TreeNode();
            NewNode.Text = node.Text;
            NewNode.Value = node.Value;
            string SelectText = node.Text;

            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists["CategoryDetails"];
            SPQuery q = new SPQuery();
            string qsr = @"<Where>                       
                              <Eq>
                                 <FieldRef Name='_x006c_pr1' />
                                 <Value Type='Text'>{0}</Value>
                              </Eq>   
                        </Where> ";
            q.Query = string.Format(qsr, SelectText);
            SPListItemCollection items = list.GetItems(q);

            
            doSomethingToNode(ID);   //.................
        } // TreeView点击事件

        private void doSomethingToNode(string input)
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists["Stufftable"];            //连表问题...
            SPQuery que = new SPQuery();                        //node 问题....
            string qsstr = @"<Where>                            
                              <Eq>
                                 <FieldRef Name='cusm' />
                                 <Value Type='Text'>4</Value>
                              </Eq>
                           </Where> ";
            que.Query = string.Format(qsstr, input);     

            SPListItemCollection items = list.GetItems(que);
            foreach (SPListItem item in items)
            {

            }

        }




        protected void Pick1_Click(object sender, EventArgs e)
        {

                    ListItem item = ListBox1.SelectedItem;
                    
                    ListBox2.Items.Add(item);
                   // ListBox1.Items.Remove(item);
                            
        }

        protected void allpick_Click(object sender, EventArgs e)
        {
            int count = ListBox1.Items.Count;
            int index = 0;
            for (int i = 0; i < count; i++)
            {

                ListItem item = ListBox1.SelectedItem;
                ListBox2.Items.Add(item);

            }
            index++;
        }



        //Delete functionality for list box
        //protected void Delete_Click(object sender, EventArgs e)
        //{
        //    ListBox1.Items.Remove(ListBox1.SelectedItem); //listBox1.SelectedItem和listBox1.Text
            
          
        //}
    }
 }

