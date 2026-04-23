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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _service.Save();
        }


        private void AddButton_Click(object sender, EventArgs e)
        {

            try
            {
                _service.Add(textBox1.Text);
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"エラー");
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
                    _service.Add(textBox1.Text);
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

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            _service.ToggleComplete(listBox1.SelectedIndex);
        }
    }

}
