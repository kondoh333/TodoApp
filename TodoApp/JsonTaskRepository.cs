using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace TodoApp
{
    public class JsonTaskRepository : ITaskRepository
    {
        private const string FilePath = "tasks.json";

        public void Save(List<TaskItem> tasks)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(FilePath, json);
        }

        public List<TaskItem> Load()
        {
            //ファイルの有無チェック。なければ空のリストを返している
            if (!File.Exists(FilePath))
                return new List<TaskItem>();

            string json = File.ReadAllText(FilePath);

            var tasks = JsonSerializer.Deserialize<List<TaskItem>>(json);
            //上記のデシリアライズでtasksがnullになった場合にクラッシュしないよう、
            //以下のコードでエラーの場合に空のリストを返すようにしている
            return tasks ?? new List<TaskItem>();
        }
    }
}
