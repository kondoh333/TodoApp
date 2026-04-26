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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            AddButton = new Button();
            listBox1 = new ListBox();
            DeleteButton = new Button();
            CompleteButton = new Button();
            searchLabel = new Label();
            searchTextBox = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(51, 61);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(233, 27);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(343, 61);
            AddButton.Margin = new Padding(3, 4, 3, 4);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(86, 31);
            AddButton.TabIndex = 1;
            AddButton.Text = "追加";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(51, 200);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(233, 244);
            listBox1.TabIndex = 2;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(343, 415);
            DeleteButton.Margin = new Padding(3, 4, 3, 4);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(86, 31);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "削除";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // CompleteButton
            // 
            CompleteButton.Location = new Point(343, 200);
            CompleteButton.Margin = new Padding(3, 4, 3, 4);
            CompleteButton.Name = "CompleteButton";
            CompleteButton.Size = new Size(86, 31);
            CompleteButton.TabIndex = 4;
            CompleteButton.Text = "完了切替";
            CompleteButton.UseVisualStyleBackColor = true;
            CompleteButton.Click += CompleteButton_Click;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(51, 133);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(54, 20);
            searchLabel.TabIndex = 5;
            searchLabel.Text = "検索：";
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(107, 129);
            searchTextBox.Margin = new Padding(3, 4, 3, 4);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(177, 27);
            searchTextBox.TabIndex = 6;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(searchTextBox);
            Controls.Add(searchLabel);
            Controls.Add(CompleteButton);
            Controls.Add(DeleteButton);
            Controls.Add(listBox1);
            Controls.Add(AddButton);
            Controls.Add(textBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "TodoApp";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button AddButton;
        private ListBox listBox1;
        private Button DeleteButton;
        private Button CompleteButton;
        private Label searchLabel;
        private TextBox searchTextBox;
    }
}