namespace TodoApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            AddButton = new Button();
            listBox1 = new ListBox();
            DeleteButton = new Button();
            CompleteButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(45, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(204, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(300, 46);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 1;
            AddButton.Text = "追加";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(45, 119);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(204, 184);
            listBox1.TabIndex = 2;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(300, 280);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "削除";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // CompleteButton
            // 
            CompleteButton.Location = new Point(300, 119);
            CompleteButton.Name = "CompleteButton";
            CompleteButton.Size = new Size(75, 23);
            CompleteButton.TabIndex = 4;
            CompleteButton.Text = "完了切替";
            CompleteButton.UseVisualStyleBackColor = true;
            CompleteButton.Click += CompleteButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CompleteButton);
            Controls.Add(DeleteButton);
            Controls.Add(listBox1);
            Controls.Add(AddButton);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button AddButton;
        private ListBox listBox1;
        private Button DeleteButton;
        private Button CompleteButton;
    }
}
