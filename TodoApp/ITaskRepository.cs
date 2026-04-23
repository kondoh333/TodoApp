using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    //保存処理をファイルのみにせず将来的に偏光する可能性があるため、
    //interfaceでtaskrepositoryを保存できる人としてメインに説明している。
    //interfaceで抽象化している。
    public interface ITaskRepository
    {
        void Save(List<TaskItem> tasks);
        List<TaskItem> Load();
    }
}
