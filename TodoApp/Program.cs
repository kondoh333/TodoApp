namespace TodoApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                //保存方法が差し替えられる
                ITaskRepository repository = new JsonTaskRepository();
                //ITaskRepository repository = new FIleTaskRepository();

                ITaskService service = new TaskService(repository);


                Application.Run(new Form1(service));
            }
            catch (Exception ex)
            {
                MessageBox.Show("データの読み込みに失敗しました。\n保存ファイルが破損している可能性があります。"
                    , "エラー");
                Console.WriteLine(ex.Message);
            }
        }
    }
}