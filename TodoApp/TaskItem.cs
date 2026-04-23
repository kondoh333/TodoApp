using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    //タスク一つの設計図
    //INotifyPropertyChangedはプロパティが変わったことを通知するためのもの
    public class TaskItem : INotifyPropertyChanged
    {
        private string _name;
        private bool _isCompleted;

        //作成日時は基本的に変更しないのでそのまま
        public DateTime CreatedDate { get; set; }

        //イベント（変更通知）
        public event PropertyChangedEventHandler PropertyChanged;

        public TaskItem(string name)
        {
            _name = name;
            _isCompleted = false;
            CreatedDate = DateTime.Now;
        }

        //Nameプロパティ
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        //完了フラグ
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        //変更通知を送るメソッド
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            string status =  IsCompleted ? "✓" : "□";
            return $"{status}{Name}({CreatedDate.ToShortDateString()})";
        }
    }
}
