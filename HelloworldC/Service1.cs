using System;
using System.IO;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Win32.TaskScheduler;

namespace HelloworldC
{
    public partial class Service1 : ServiceBase
    {
        private Thread _a;
        readonly AutoResetEvent _m = new AutoResetEvent(false);
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
           
            using (TextWriter a = new StreamWriter(File.OpenWrite(@"c:\Onstart.txt")))
            {
                a.WriteLine("OnStart!");
            }
            _a = new Thread(Start);

            _a.Start(_m);

        }

        private void Start(object o)
        {
           
            while (true)
            {
                if (WaitHandle.WaitAll(new WaitHandle[] { _m }, new TimeSpan(0, 0, 0, 2)))
                {
                    break;
                }
                A();
            }
          
        }

        public void A()
        {
            using (TextWriter a = new StreamWriter(File.OpenWrite(@"c:\work.txt")))
            {
                a.WriteLine("Start A!");


                try
                {
                    using (var ts = new TaskService())
                    {
                        //// Create a new task definition and assign properties
                        //TaskDefinition td = ts.NewTask();
                        //td.RegistrationInfo.Description = "Does something";

                        //// Create a trigger that will fire the task at this time every other day
                        //td.Triggers.Add(new DailyTrigger { DaysInterval = 2 });

                        //// Create an action that will launch Notepad whenever the trigger fires
                        //td.Actions.Add(new ExecAction("calc.exe", "c:\\test.log", null));

                        //// Register the task in the root folder
                        //ts.RootFolder.RegisterTaskDefinition(@"Test", td);

                        //// Remove the task we just created
                        //ts.RootFolder.DeleteTask("Test");
                        if (ts.Connected)
                        {
                            a.WriteLine("OK");

                            var task = ts.GetTask(@"\Helloworld");
                            if (task != null)
                            {
                                  task.RunEx(TaskRunFlags.NoFlags,1,"ecos");
                            }
                        }

                    }
                }
                catch (Exception e)
                {


                    a.WriteLine("some wrong!!" + e.Message);


                }
            }

        }

        protected override void OnStop()
        {
            using (TextWriter a = new StreamWriter(File.OpenWrite(@"c:\OnStop.txt")))
            {
                a.WriteLine("OnStop!");
            }
            _m.Set();
            _a.Join();
        }
    }
}
