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
        //保存、読み込みを担当する
        private readonly ITaskRepository _repository;

        //本物の全データを持つリスト
        private List<TaskItem> _allTasks;

        //これは中身が変わったら通知するリスト
        //役割は画面に表示するためのリスト
        private BindingList<TaskItem> _visibleTasks;

        //現在の検索文字
        private string _currentKeyword = string.Empty;

        
        public TaskService(ITaskRepository repository )
        {
            _repository = repository;

            //ファイルから読み込んだデータを本物の一覧として保持する
            _allTasks = _repository.Load();

            //最初は全件表示にする
            _visibleTasks = new BindingList<TaskItem>(new List<TaskItem>(_allTasks));

        }


        //UIに公開する一覧
        public BindingList<TaskItem> GetAll()
        {
            return _visibleTasks;
        }


        //タスク追加
        //名前と選ばれた優先度
        public void Add(string name, TaskPriority priority)
        {
            //何も入力していないのに保存できないようにする
            //バリデーションチェックという
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("タスク名が空です");

            //前後の空白を除去して、優先度もセットしてから追加する
            var task = new TaskItem(name.Trim(), priority);

            //本物の一覧に追加
            _allTasks.Add(task);

            //今の検索条件で表示を作り直す
            ApplyFilter();
        }

        //削除
        public void Delete(int index)
        {
            //表示用リストの範囲外なら何もしない
            if (index < 0 || index >= _visibleTasks.Count)
                return;

            //画面で選ばれたタスク本体を取得
            var taskToDelete = _visibleTasks[index];

            //本物の一覧から削除
            _allTasks.Remove(taskToDelete);

            //検索条件に合わせて表示を更新
            ApplyFilter();
        }

        //完了状態切り替え
        public void ToggleComplete(int index)
        {
            //表示用リストの範囲外なら何もしない
            if (index < 0 || index >= _visibleTasks.Count)
                return;


            //画面で選ばれたタスク本体を取得
            var task = _visibleTasks[index];

            //完了状態を変更
            task.IsCompleted = !task.IsCompleted;

            //検索条件に合わせて表示を更新
            //今回は必要ないが拡張に備えて更新しておく
            ApplyFilter();
        }

        //検索
        public void Search(string keyword)
        {
            //null対策、検索文字を保存しておく
            _currentKeyword = keyword ?? string.Empty;

            //今の検索条件で表示を更新
            ApplyFilter();
        }



        //保存
        public void Save()
        {
            //保存は画面表示用ではなく本物のデータ
            _repository.Save(_allTasks);
        }

        //表示用リストを今の検索条件で作り直す
        private void ApplyFilter()
        {
            //検索文字の前後の空白を無視する
            string keyword = _currentKeyword.Trim();

            //一度表示用リストを空にする
            _visibleTasks.Clear();

            //検索文字が空白なら全件表示する
            if (string.IsNullOrEmpty(keyword))
            {
                foreach(var task in _allTasks)
                {
                    _visibleTasks.Add(task);
                }

                return;
            }

            //名前に部分一致するするものだけを表示
            foreach(var task in _allTasks)
            {
                if(task.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    _visibleTasks.Add(task);
                }
            }
        }
    }
}
