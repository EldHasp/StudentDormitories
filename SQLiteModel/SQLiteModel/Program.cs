using StudentDormitories;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace SQLiteModel
{
    class Program
    {
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [STAThread()]
        [DebuggerNonUserCode()]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        static void Main(string[] args)
        {

            ModelSQLite model = new ModelSQLite("DefaultConnection");

            App app = new App(model);

            app.InitializeComponent();
            app.Run();
        }
    }
}
