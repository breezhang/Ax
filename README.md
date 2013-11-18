Ax
==

windows service call  GUI  client 
  
  
  show demo 
  1 cmd /c  SCHTASKS /Create /SC ONSTART /TN Helloworld /TR calc
  2 InstallUtil install .net assembly 
  3 net start xxxxx
  
Key step:

  task.RunEx(TaskRunFlags.NoFlags,1,"logonname");
  
  ProcessInstaller1.Account = ServiceAccount.LocalSystem;
  
  
