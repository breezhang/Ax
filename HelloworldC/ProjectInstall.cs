using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace HelloworldC
{
    [RunInstaller(true)]
    public class ProjectInstall:Installer
    {
        private ServiceProcessInstaller _serviceProcessInstaller1;
      //  private AssemblyInstaller _assemblyInstaller1;

        private ServiceInstaller _serviceInstaller1;

        public ProjectInstall()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _serviceInstaller1 = new ServiceInstaller();
            _serviceProcessInstaller1 = new ServiceProcessInstaller();
            //_assemblyInstaller1 = new AssemblyInstaller();

            _serviceInstaller1.DisplayName = "Helloworld AS ";
            _serviceInstaller1.ServiceName = "Helloworld";
            _serviceInstaller1.StartType = ServiceStartMode.Automatic;
            // 
            // serviceProcessInstaller1
            // 
            _serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
            //_serviceProcessInstaller1.Password = "greeteaecos";
            //_serviceProcessInstaller1.Username = "ecos";
            // 
            // assemblyInstaller1
            // 
            //_assemblyInstaller1.Assembly = null;
            //_assemblyInstaller1.CommandLine = null;
            //_assemblyInstaller1.Path = null;
            //_assemblyInstaller1.UseNewContext = false;
            // 
            // ProjectInstall
            // 
            Installers.AddRange(new Installer[] {
            _serviceInstaller1,_serviceProcessInstaller1});

        }
    }
}