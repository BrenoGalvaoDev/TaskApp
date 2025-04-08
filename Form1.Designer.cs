namespace TaskApp
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.AddTaskBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.Label();
            this.deleteTaskBtn = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the Task Manager";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tasks";
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAdd.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAdd.Location = new System.Drawing.Point(292, 86);
            this.textBoxAdd.Multiline = true;
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(194, 20);
            this.textBoxAdd.TabIndex = 3;
            // 
            // AddTaskBtn
            // 
            this.AddTaskBtn.BackColor = System.Drawing.Color.Transparent;
            this.AddTaskBtn.FlatAppearance.BorderSize = 0;
            this.AddTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTaskBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTaskBtn.ForeColor = System.Drawing.Color.RoyalBlue;
            this.AddTaskBtn.ImageKey = "AddBtn.png";
            this.AddTaskBtn.Location = new System.Drawing.Point(492, 86);
            this.AddTaskBtn.Name = "AddTaskBtn";
            this.AddTaskBtn.Size = new System.Drawing.Size(67, 20);
            this.AddTaskBtn.TabIndex = 4;
            this.AddTaskBtn.Text = "Add Task";
            this.AddTaskBtn.UseVisualStyleBackColor = false;
            this.AddTaskBtn.Click += new System.EventHandler(this.AddTaskBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.Red;
            this.ExitBtn.Location = new System.Drawing.Point(511, 297);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(61, 29);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // messageBox
            // 
            this.messageBox.AutoSize = true;
            this.messageBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(289, 128);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(0, 16);
            this.messageBox.TabIndex = 6;
            // 
            // deleteTaskBtn
            // 
            this.deleteTaskBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.deleteTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteTaskBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteTaskBtn.ForeColor = System.Drawing.Color.Red;
            this.deleteTaskBtn.Location = new System.Drawing.Point(292, 263);
            this.deleteTaskBtn.Name = "deleteTaskBtn";
            this.deleteTaskBtn.Size = new System.Drawing.Size(164, 63);
            this.deleteTaskBtn.TabIndex = 7;
            this.deleteTaskBtn.Text = "        Delete Tasks          Marked as Completed";
            this.deleteTaskBtn.UseVisualStyleBackColor = false;
            this.deleteTaskBtn.Click += new System.EventHandler(this.deleteTaskBtn_Click);
            // 
            // checkedListBox
            // 
            this.checkedListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkedListBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.checkedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox.ForeColor = System.Drawing.Color.Black;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(8, 86);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(239, 240);
            this.checkedListBox.TabIndex = 8;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.ForeColor = System.Drawing.Color.Red;
            this.BackBtn.Location = new System.Drawing.Point(511, 262);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(61, 29);
            this.BackBtn.TabIndex = 5;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackToMain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.deleteTaskBtn);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.AddTaskBtn);
            this.Controls.Add(this.textBoxAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "Task Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAdd;
        private System.Windows.Forms.Button AddTaskBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label messageBox;
        private System.Windows.Forms.Button deleteTaskBtn;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button BackBtn;
    }
}

