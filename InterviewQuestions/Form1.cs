using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterviewQuestions
{
    public partial class Form1 : Form
    {
        // declare delegates
        private delegate string UpdateProgressBarDelegate(bool progress);
        private UpdateProgressBarDelegate updateProgressBarDelegate = null;

        private string OnProgressChanged(bool working)
        {
            if (working)
            {
                ProgBar.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                ProgBar.Style = ProgressBarStyle.Blocks;
            }
            populateTopics();
            return "";
        }

        // declare worker thread
        private Thread workerThread = null;

        //static variables
        static Dictionary<string, DataTable> dict = new Dictionary<string, DataTable>();
        static bool processRunning = false;

        public Form1()
        {
            InitializeComponent();
            this.updateProgressBarDelegate = new UpdateProgressBarDelegate(OnProgressChanged);
            populateTopics();
        }

        private void populateTopics()
        {
            SQLdata dat = new SQLdata();
            try
            {
                TopicsList.DataSource=null;
            }
            finally
            {
                TopicsList.DataSource = dat.getTopics();
                TopicsList.ClearSelected();
            }
        }

        private void updateQuestions_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Update Topics ?", "Caution", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                GetUpdatedData();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void GetUpdatedData()
        {
            if (processRunning == true)
            {
                MessageBox.Show("Still updating.");
                return;
            }
            processRunning = true;
            
            // create new worker thread for this

            workerThread = new Thread(new ThreadStart(setUpdateData));
            this.workerThread.Start();
        }

        private void setUpdateData()
        {
            this.Invoke(updateProgressBarDelegate, true);
            GetQuestions quest = new GetQuestions();
            quest.startGetQuestions();
            this.Invoke(updateProgressBarDelegate, false);
        }

        private void RefreshTopics_Click(object sender, EventArgs e)
        {
            populateTopics();
        }

        private void TopicsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            SQLdata sql = new SQLdata();
            string topic = TopicsList.GetItemText(TopicsList.SelectedItem);
            List<Question> questions = sql.getSqlData(topic);
            foreach(Question quest in questions)
            {
                string ans = quest.getAnswer();
                string[] splitAns = ans.Split('\n');
                List<TreeNode> childNodes = new List<TreeNode>();
                foreach(string subAns in splitAns)
                {
                    string tmpAns = subAns.TrimStart('\n','\r');
                    tmpAns = tmpAns.Trim();
                    if (string.IsNullOrWhiteSpace(subAns)) { continue; }
                    TreeNode childe = new TreeNode(tmpAns);
                    childNodes.Add(childe);
                }
                TreeNode parent = new TreeNode(quest.getQuestion(), childNodes.ToArray());
                treeView1.Nodes.Add(parent);
            }
        }

        private void clearListSelection_Click(object sender, EventArgs e)
        {
            TopicsList.ClearSelected();
            treeView1.Nodes.Clear();
        }
    }
}
