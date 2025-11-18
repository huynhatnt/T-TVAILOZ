namespace ServerForm.Forms
{
    partial class QuestionEditorForm
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
            this.components = new System.ComponentModel.Container();
            this.txtQuestionText = new System.Windows.Forms.TextBox();
            this.txtA1 = new System.Windows.Forms.TextBox();
            this.txtA2 = new System.Windows.Forms.TextBox();
            this.txtA3 = new System.Windows.Forms.TextBox();
            this.txtA4 = new System.Windows.Forms.TextBox();
            this.cbCorrect = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.Location = new System.Drawing.Point(212, 43);
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.Size = new System.Drawing.Size(303, 20);
            this.txtQuestionText.TabIndex = 0;
            // 
            // txtA1
            // 
            this.txtA1.Location = new System.Drawing.Point(73, 165);
            this.txtA1.Name = "txtA1";
            this.txtA1.Size = new System.Drawing.Size(100, 20);
            this.txtA1.TabIndex = 1;
            this.txtA1.TextChanged += new System.EventHandler(this.txtA1_TextChanged);
            // 
            // txtA2
            // 
            this.txtA2.Location = new System.Drawing.Point(223, 165);
            this.txtA2.Name = "txtA2";
            this.txtA2.Size = new System.Drawing.Size(100, 20);
            this.txtA2.TabIndex = 2;
            this.txtA2.TextChanged += new System.EventHandler(this.txtA2_TextChanged);
            // 
            // txtA3
            // 
            this.txtA3.Location = new System.Drawing.Point(361, 165);
            this.txtA3.Name = "txtA3";
            this.txtA3.Size = new System.Drawing.Size(100, 20);
            this.txtA3.TabIndex = 3;
            this.txtA3.TextChanged += new System.EventHandler(this.txtA3_TextChanged);
            // 
            // txtA4
            // 
            this.txtA4.Location = new System.Drawing.Point(500, 165);
            this.txtA4.Name = "txtA4";
            this.txtA4.Size = new System.Drawing.Size(100, 20);
            this.txtA4.TabIndex = 4;
            this.txtA4.TextChanged += new System.EventHandler(this.txtA4_TextChanged);
            // 
            // cbCorrect
            // 
            this.cbCorrect.FormattingEnabled = true;
            this.cbCorrect.Location = new System.Drawing.Point(271, 261);
            this.cbCorrect.Name = "cbCorrect";
            this.cbCorrect.Size = new System.Drawing.Size(234, 21);
            this.cbCorrect.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(73, 308);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // QuestionEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbCorrect);
            this.Controls.Add(this.txtA4);
            this.Controls.Add(this.txtA3);
            this.Controls.Add(this.txtA2);
            this.Controls.Add(this.txtA1);
            this.Controls.Add(this.txtQuestionText);
            this.Name = "QuestionEditorForm";
            this.Text = "QuestionEditorForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestionText;
        private System.Windows.Forms.TextBox txtA1;
        private System.Windows.Forms.TextBox txtA2;
        private System.Windows.Forms.TextBox txtA3;
        private System.Windows.Forms.TextBox txtA4;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox cbCorrect;
        private System.Windows.Forms.Button btnSave;
    }
}