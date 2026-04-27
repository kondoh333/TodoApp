using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace TodoApp
{
    public partial class Form1 : Form
    {
        private readonly ITaskService _service;
        public Form1(ITaskService service)
        {
            InitializeComponent();

            _service = service;

            //★データとListBoxを直接つなぐ
            listBox1.DataSource = _service.GetAll();

            //優先度の選択肢をcomboboxに追加する
            priorityComboBox.Items.Add("低");
            priorityComboBox.Items.Add("中");
            priorityComboBox.Items.Add("高");

            //初期値は中
            priorityComboBox.SelectedIndex = 1;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _service.Delete(listBox1.SelectedIndex);
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
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            _service.ToggleComplete(listBox1.SelectedIndex);
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
    }

}
