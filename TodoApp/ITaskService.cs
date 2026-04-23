using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public interface ITaskService
    {
        //UIに公開する一覧
        BindingList<TaskItem> GetAll();

        //タスク追加
        void Add(string name);

        //削除
        void Delete(int index);

        //完了状態切り替え
        void ToggleComplete(int index);

        //保存
        void Save();
    }
}
