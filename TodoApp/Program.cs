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

            //ï€ë∂ï˚ñ@Ç™ç∑Çµë÷Ç¶ÇÁÇÍÇÈ
            ITaskRepository repository = new JsonTaskRepository();
            ITaskService service = new TaskService(repository);


            Application.Run(new Form1(service));
        }
    }
}