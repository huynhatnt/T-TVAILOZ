namespace ServerForm.Forms
{
    partial class RoomManagerForm
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
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.cmbQuizList = new System.Windows.Forms.ComboBox();
            this.txtRoomIdResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(65, 117);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(75, 23);
            this.btnCreateRoom.TabIndex = 0;
            this.btnCreateRoom.Text = "Create Room";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // cmbQuizList
            // 
            this.cmbQuizList.FormattingEnabled = true;
            this.cmbQuizList.Location = new System.Drawing.Point(306, 119);
            this.cmbQuizList.Name = "cmbQuizList";
            this.cmbQuizList.Size = new System.Drawing.Size(121, 21);
            this.cmbQuizList.TabIndex = 1;
            // 
            // txtRoomIdResult
            // 
            this.txtRoomIdResult.Location = new System.Drawing.Point(489, 133);
            this.txtRoomIdResult.Name = "txtRoomIdResult";
            this.txtRoomIdResult.Size = new System.Drawing.Size(100, 20);
            this.txtRoomIdResult.TabIndex = 2;
            // 
            // RoomManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRoomIdResult);
            this.Controls.Add(this.cmbQuizList);
            this.Controls.Add(this.btnCreateRoom);
            this.Name = "RoomManagerForm";
            this.Text = "RoomManagerForm";
            this.Load += new System.EventHandler(this.RoomManagerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.ComboBox cmbQuizList;
        private System.Windows.Forms.TextBox txtRoomIdResult;
    }
}