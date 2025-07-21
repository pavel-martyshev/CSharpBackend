using Topshelf;

namespace TopShelfJob;

internal class Program
{
    static void Main(string[] args)
    {
        var rc = HostFactory.Run(x =>                               
        {
            x.Service<HelloWorldPrinter>(s =>                                
            {
                s.ConstructUsing(name => new HelloWorldPrinter());              
                s.WhenStarted(tc => tc.Start());                       
                s.WhenStopped(tc => tc.Stop());                        
            });
            x.RunAsLocalSystem();                                     

            x.SetDescription("Sample Topshelf Host");                  
            x.SetDisplayName("Stuff");                                
            x.SetServiceName("Stuff");                                 
        });                                                            

        var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
        Environment.ExitCode = exitCode;
    }
}
