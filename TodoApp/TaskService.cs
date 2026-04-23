using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TodoApp
{
    public class TaskService : ITaskService
    {
        //状態をserviceに集約して、保存状態をカプセル化している

        private readonly ITaskRepository _repository;

        //UIと連動させるためのコレクション
        //これは中身が変わったら通知するリスト
        private BindingList<TaskItem> _tasks;

        //private List<TaskItem> _tasks;
        
        public TaskService(ITaskRepository repository )
        {
            _repository = repository;

            //repositoryから読み込んだlistをbindinglistに変換
            _tasks = new BindingList<TaskItem>(_repository.Load());

        }


        //UIに公開する一覧
        //

        public BindingList<TaskItem> GetAll()
        {
            return _tasks;
        }


        //タスク追加
        public void Add(string name)
        {
            //何も入力していないのに保存できないようにする
            //バリデーションチェックという
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("タスク名が空です");

            _tasks.Add(new TaskItem(name));
            //BindingListなのでUIが自動的に更新される
        }

        //削除
        public void Delete(int index)
        {
            if (index >= 0 && index < _tasks.Count)
                _tasks.RemoveAt(index);
        }

        //完了状態切り替え
        public void ToggleComplete(int index)
        {
            if(index >= 0 && index < _tasks.Count)
            {
                _tasks[index].IsCompleted = !_tasks[index].IsCompleted; 

                //状態変更をUIに通知するため
             
            }
        }



        //保存
        public void Save()
        {
            //BindinListをListに変換して保存
            _repository.Save(_tasks.ToList());
        }
    }
}
