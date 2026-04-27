using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    //優先度を表すenum
    public enum TaskPriority
    {
        Low,    //低
        Medium, //中
        High    //高
    }

    //タスク一つの設計図
    //INotifyPropertyChangedはプロパティが変わったことを通知するためのもの
    public class TaskItem : INotifyPropertyChanged
    {
        private string _name;
        private bool _isCompleted;

        //優先度の初期値は中にしておく
        private TaskPriority _priority = TaskPriority.Medium;

        //作成日時は基本的に変更しないのでそのまま
        public DateTime CreatedDate { get; set; }

        //イベント（変更通知）
        public event PropertyChangedEventHandler PropertyChanged;



        //タスク生成時に名前と優先度を受け取る
        //優先度を指定しなかった場合は中になる
        public TaskItem(string name, TaskPriority priority = TaskPriority.Medium)
        {
            _name = name;
            _isCompleted = false;
            _priority = priority;
            CreatedDate = DateTime.Now;
        }

        //読み込み時に必要な引数なしコンストラクタ
        public TaskItem()
        {
            _name = string.Empty;
            _isCompleted = false;
            _priority = TaskPriority.Medium;
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

        //優先度
        public TaskPriority Priority
        {
            get { return _priority; }
            set
            {
                if( _priority != value)
                {
                    _priority = value;

                    //priorityが変わったことをUIに通知する
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }


        //変更通知を送るメソッド
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //ListBoxに表示される文字列
        public override string ToString()
        {
            string status =  IsCompleted ? "✓" : "□";

            //enumの値を日本語に変換する
            string priorityText = Priority switch
            {
                TaskPriority.Low => "低",
                TaskPriority.Medium => "中",
                TaskPriority.High => "高",

                //万が一想定外の値が来た場合は中として表示する
                _ => "中"
            };

            return $"[{priorityText}]{status}{Name}({CreatedDate.ToShortDateString()})";
        }
    }
}
