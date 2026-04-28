namespace TodoApp
{
    public partial class Form1 : Form
    {
        private readonly ITaskService _service;
        private int _lastSelectedIndex = -1;

        public Form1(ITaskService service)
        {
            InitializeComponent();

            _service = service;


            //★データとListBoxを直接つなぐ
            listBox1.DataSource = _service.GetAll();

            //起動時に自動で選択されるのを防ぐ
            listBox1.ClearSelected();

            //優先度の選択肢をcomboboxに追加する
            priorityComboBox.Items.Add("低");
            priorityComboBox.Items.Add("中");
            priorityComboBox.Items.Add("高");

            //初期値は中
            priorityComboBox.SelectedIndex = 1;
        }

        //選択状態を解除するために実装
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //クリック位置の項目番号を取得
            int clickedIndex = listBox1.IndexFromPoint(e.Location);

            //余白をクリックしたら選択解除
            if(clickedIndex == ListBox.NoMatches)
            {
                listBox1.ClearSelected();
                _lastSelectedIndex = -1;
                return;
            }

            //同じ項目を再度クリックしたら選択解除
            if(clickedIndex == _lastSelectedIndex)
            {
                listBox1.ClearSelected();
                _lastSelectedIndex = -1;
            }
            else
            {
                //新しい選択として記録
                _lastSelectedIndex = clickedIndex;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _service.Save();
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                //入力されたタスク名と選ばれた優先度をserviceに渡す
                _service.Add(textBox1.Text, GetSelectedPriority());
                textBox1.Clear();
                listBox1.ClearSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("削除するタスクを選択してください。", "確認");
                return;
            }

            _service.Delete(listBox1.SelectedIndex);
            listBox1.ClearSelected();
            _lastSelectedIndex = -1;
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    _service.Add(textBox1.Text,GetSelectedPriority());
                    textBox1.Clear();
                    e.SuppressKeyPress = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "エラー");
                    e.SuppressKeyPress = true;
                }
            }
        }

        //検索欄に文字が入るたびに呼ばれる
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            _service.Search(searchTextBox.Text);
            listBox1.ClearSelected();
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("完了状態を変更するタスクを選択してください。", "確認");
                return;
            }

            //ボタンを押した際にそのタスクに選択状態を残すようにする
            int selectedIndex = listBox1.SelectedIndex;

            _service.ToggleComplete(listBox1.SelectedIndex);

            if (selectedIndex >= 0 && selectedIndex < listBox1.Items.Count)
            {
                listBox1.SelectedIndex = selectedIndex;
                _lastSelectedIndex = selectedIndex;
            }
            listBox1.Refresh();
        }

        //Comboboxで選ばれた文字をTaskPriorityに変換する
        private TaskPriority GetSelectedPriority()
        {
            return priorityComboBox.SelectedItem?.ToString() switch
            {
                "低" => TaskPriority.Low,
                "高" => TaskPriority.High,

                //中か未選択の場合はmedium扱いにする
                _ => TaskPriority.Medium
            };
        }

        //listboxの項目を一つずつ描画する処理
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //表示する項目がない場合は何もしない
            if (e.Index < 0)
                return;

            //listboxの中から描画対象のタスクを取り出す
            TaskItem task = (TaskItem)listBox1.Items[e.Index];

            //選択中かどうかで背景色を変える
            if((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
            }

            //文字色の初期値
            Brush textBrush = Brushes.Black;

            //優先度に応じて文字色を変える
            if(task.IsCompleted)
            {
                //完了済は灰色にする
                textBrush = Brushes.Gray;
            }
            else
            {
                switch (task.Priority)
                {
                    case TaskPriority.Low:
                        textBrush = Brushes.DarkBlue;
                        break;

                    case TaskPriority.Medium:
                        textBrush = Brushes.Black;
                        break;

                    case TaskPriority.High:
                        textBrush = Brushes.DarkRed;
                        break;
                }
            }

            //選択中は文字が見えるように白にする
            if((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                textBrush = Brushes.White;
            }

            //表示文字列を取得
            string text = task.ToString();

            //文字を描画する位置
            Point textLocation = new Point(e.Bounds.Left + 5, e.Bounds.Top + 3);

            //実際に文字を描画する
            e.Graphics.DrawString(text, e.Font, textBrush, textLocation);

            //選択中の枠を描画する
            e.DrawFocusRectangle();
        }
    }

}
