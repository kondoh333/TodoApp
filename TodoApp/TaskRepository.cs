using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class FIleTaskRepository : ITaskRepository
    {
        private const string FilePath = "tasks.txt";

        public void Save(List<TaskItem> tasks)
        {

            //File.WriteAllLinesはstring[]を要求するためToArrayで変換している
            var lines = tasks
                .Select(task => $"{task.Name}|{task.IsCompleted}|{task.CreatedDate:o}|{task.Priority}")
                .ToArray();

            File.WriteAllLines(FilePath, lines);
        }

        public List<TaskItem> Load()
        {
            //例外処理をここに書くのは、読み込み時のエラーはここで起こることなので
            //発生した層で処理しなければならないため
            try
            {
                //ファイルの有無チェック。なければ空のリストを返している
                if (!File.Exists(FilePath))
                    return new List<TaskItem>();

                var tasks = File.ReadAllLines(FilePath)
                    .Select(line =>
                    {
                        var parts = line.Split('|');

                        TaskPriority priority = TaskPriority.Medium;

                        if(parts.Length >= 4)
                        {
                            priority = Enum.Parse<TaskPriority>(parts[3]);
                        }

                        return new TaskItem(parts[0],priority)
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
