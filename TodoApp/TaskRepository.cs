using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class FileTaskRepository : ITaskRepository
    {

        public void Save(List<TaskItem> tasks)
        {

            //File.WriteAllLinesはstring[]を要求するためToArrayで変換している
            var lines = tasks
                .Select(task => $"{task.Name}|{task.IsCompleted}|{task.CreatedDate:o}")
                .ToArray();

            File.WriteAllLines("tasks.txt", lines);
        }

        public List<TaskItem> Load()
        {
            //例外処理をここに書くのは、読み込み時のエラーはここで起こることなので
            //発生した層で処理しなければならないため
            try
            {
                //ファイルの有無チェック。なければ空のリストを返している
                if (!File.Exists("tasks.txt"))
                    return new List<TaskItem>();

                var tasks = File.ReadAllLines("tasks.txt")
                    .Select(line =>
                    {
                        var parts = line.Split('|');

                        return new TaskItem(parts[0])
                        {
                            IsCompleted = bool.Parse(parts[1]),
                            CreatedDate = DateTime.Parse(parts[2])
                        };
                    })
                    .ToList();

                return tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine("読み込み中にエラーが発生しました。");
                Console.WriteLine(ex.Message);
                return new List<TaskItem>();
            }
        }
    }
}
