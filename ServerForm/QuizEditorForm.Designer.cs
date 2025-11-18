namespace ServerForm.Forms
{
    partial class QuizEditorForm
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.listQuestions = new System.Windows.Forms.ListBox();
            this.btnAddQ = new System.Windows.Forms.Button();
            this.btnEditQ = new System.Windows.Forms.Button();
            this.btnDeleteQ = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(58, 149);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(299, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // listQuestions
            // 
            this.listQuestions.FormattingEnabled = true;
            this.listQuestions.Location = new System.Drawing.Point(438, 132);
            this.listQuestions.Name = "listQuestions";
            this.listQuestions.Size = new System.Drawing.Size(239, 199);
            this.listQuestions.TabIndex = 1;
            // 
            // btnAddQ
            // 
            this.btnAddQ.Location = new System.Drawing.Point(27, 52);
            this.btnAddQ.Name = "btnAddQ";
            this.btnAddQ.Size = new System.Drawing.Size(75, 23);
            this.btnAddQ.TabIndex = 2;
            this.btnAddQ.Text = "Add";
            this.btnAddQ.UseVisualStyleBackColor = true;
            this.btnAddQ.Click += new System.EventHandler(this.btnAddQ_Click);
            // 
            // btnEditQ
            // 
            this.btnEditQ.Location = new System.Drawing.Point(165, 65);
            this.btnEditQ.Name = "btnEditQ";
            this.btnEditQ.Size = new System.Drawing.Size(75, 23);
            this.btnEditQ.TabIndex = 3;
            this.btnEditQ.Text = "Edit";
            this.btnEditQ.UseVisualStyleBackColor = true;
            this.btnEditQ.Click += new System.EventHandler(this.btnEditQ_Click);
            // 
            // btnDeleteQ
            // 
            this.btnDeleteQ.Location = new System.Drawing.Point(282, 65);
            this.btnDeleteQ.Name = "btnDeleteQ";
            this.btnDeleteQ.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteQ.TabIndex = 4;
            this.btnDeleteQ.Text = "Delete";
            this.btnDeleteQ.UseVisualStyleBackColor = true;
            this.btnDeleteQ.Click += new System.EventHandler(this.btnDeleteQ_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(438, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // QuizEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteQ);
            this.Controls.Add(this.btnEditQ);
            this.Controls.Add(this.btnAddQ);
            this.Controls.Add(this.listQuestions);
            this.Controls.Add(this.txtTitle);
            this.Name = "QuizEditorForm";
            this.Text = "QuizEditorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ListBox listQuestions;
        private System.Windows.Forms.Button btnAddQ;
        private System.Windows.Forms.Button btnEditQ;
        private System.Windows.Forms.Button btnDeleteQ;
        private System.Windows.Forms.Button btnSave;
    }
}