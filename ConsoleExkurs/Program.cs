using ConsoleExkurs.Pumpe;

namespace ConsoleExkurs;

internal class Program
{
    static void Main(string[] args)
    {
        //Einfacher Delegate
        //new EinfacherDelegate();

        //Funcs
        //new Funcs();

        //Pumpen
        PumpenBeispielDelegate();
    }

    private static void PumpenBeispielDelegate()
    {
        //Ohne Delegate Klassik
        //var monitor = new KraftwerkTemperaturMonitor();
        //var ep = new ElektrischePumpe();
        //var pp = new PneumatischePumpe();

        //monitor.Add(ep);
        //monitor.Add(pp);
        //monitor.AllePumpenEinschalten();

        //Mit Delegate
        var monitorReloaded = new KraftwerkTemperaturMonitorReloaded();
        var ep = new ElektrischePumpe();
        var pp = new PneumatischePumpe();
        var bp = new BeliebigePumpe();
        monitorReloaded.Add(ep.StarteElektrischePumpe); // Nam der Methode, die aufgerufen werden soll
        monitorReloaded.Add(pp.StartePneumatischePumpe);
        monitorReloaded.Add(new PumpenDelegate(bp.StarteBeliebigePumpe));

        monitorReloaded.AllePumpenEinschalten();
    }
}
