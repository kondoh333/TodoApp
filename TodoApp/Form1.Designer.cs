namespace TodoApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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

            // 優先度用のラベルとComboBox
            priorityLabel = new Label();
            priorityComboBox = new ComboBox();

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
            listBox1.Location = new Point(45, 150);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(300, 184);
            listBox1.TabIndex = 2;

            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(390, 311);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "削除";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;

            // 
            // CompleteButton
            // 
            CompleteButton.Location = new Point(390, 150);
            CompleteButton.Name = "CompleteButton";
            CompleteButton.Size = new Size(75, 23);
            CompleteButton.TabIndex = 4;
            CompleteButton.Text = "完了切替";
            CompleteButton.UseVisualStyleBackColor = true;
            CompleteButton.Click += CompleteButton_Click;

            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(45, 100);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(43, 15);
            searchLabel.TabIndex = 5;
            searchLabel.Text = "検索：";

            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(94, 97);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(251, 23);
            searchTextBox.TabIndex = 6;
            searchTextBox.TextChanged += searchTextBox_TextChanged;

            // 
            // priorityLabel
            // 
            priorityLabel.AutoSize = true;
            priorityLabel.Location = new Point(390, 50);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new Size(55, 15);
            priorityLabel.TabIndex = 7;
            priorityLabel.Text = "優先度：";

            // 
            // priorityComboBox
            // 
            // DropDownListにすることで、ユーザーが自由入力できないようにする
            // つまり「低・中・高」以外を選べない
            priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            priorityComboBox.Location = new Point(450, 46);
            priorityComboBox.Name = "priorityComboBox";
            priorityComboBox.Size = new Size(80, 23);
            priorityComboBox.TabIndex = 8;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);

            // 画面に部品を追加する
            Controls.Add(priorityComboBox);
            Controls.Add(priorityLabel);
            Controls.Add(searchTextBox);
            Controls.Add(searchLabel);
            Controls.Add(CompleteButton);
            Controls.Add(DeleteButton);
            Controls.Add(listBox1);
            Controls.Add(AddButton);
            Controls.Add(textBox1);

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

        // 優先度用の部品
        private Label priorityLabel;
        private ComboBox priorityComboBox;
    }
}