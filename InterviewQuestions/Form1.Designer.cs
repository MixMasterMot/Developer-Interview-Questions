namespace InterviewQuestions
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.TopicsList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.updateQuestions = new System.Windows.Forms.ToolStripButton();
            this.RefreshTopics = new System.Windows.Forms.ToolStripButton();
            this.clearListSelection = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressLabel,
            this.ProgBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(979, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(144, 17);
            this.ProgressLabel.Text = "Question Update Progress";
            // 
            // ProgBar
            // 
            this.ProgBar.Name = "ProgBar";
            this.ProgBar.Size = new System.Drawing.Size(100, 16);
            // 
            // TopicsList
            // 
            this.TopicsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TopicsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopicsList.FormattingEnabled = true;
            this.TopicsList.ItemHeight = 16;
            this.TopicsList.Location = new System.Drawing.Point(15, 76);
            this.TopicsList.Name = "TopicsList";
            this.TopicsList.Size = new System.Drawing.Size(223, 420);
            this.TopicsList.TabIndex = 3;
            this.TopicsList.SelectedIndexChanged += new System.EventHandler(this.TopicsList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Topics";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(462, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Questions And Answers";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateQuestions,
            this.RefreshTopics,
            this.clearListSelection});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(979, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // updateQuestions
            // 
            this.updateQuestions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.updateQuestions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateQuestions.Name = "updateQuestions";
            this.updateQuestions.Size = new System.Drawing.Size(87, 22);
            this.updateQuestions.Text = "Update Topics";
            this.updateQuestions.Click += new System.EventHandler(this.updateQuestions_Click);
            // 
            // RefreshTopics
            // 
            this.RefreshTopics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RefreshTopics.Image = ((System.Drawing.Image)(resources.GetObject("RefreshTopics.Image")));
            this.RefreshTopics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshTopics.Name = "RefreshTopics";
            this.RefreshTopics.Size = new System.Drawing.Size(109, 22);
            this.RefreshTopics.Text = "Refresh Topics List";
            this.RefreshTopics.Click += new System.EventHandler(this.RefreshTopics_Click);
            // 
            // clearListSelection
            // 
            this.clearListSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearListSelection.Image = ((System.Drawing.Image)(resources.GetObject("clearListSelection.Image")));
            this.clearListSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearListSelection.Name = "clearListSelection";
            this.clearListSelection.Size = new System.Drawing.Size(89, 22);
            this.clearListSelection.Text = "Clear Selection";
            this.clearListSelection.Click += new System.EventHandler(this.clearListSelection_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(259, 76);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(708, 420);
            this.treeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 548);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TopicsList);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ProgressLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgBar;
        private System.Windows.Forms.ListBox TopicsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton updateQuestions;
        private System.Windows.Forms.ToolStripButton RefreshTopics;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripButton clearListSelection;
    }
}

