using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExkurs.Pumpe;

public delegate void PumpenDelegate();

public class KraftwerkTemperaturMonitorReloaded
{
    private readonly List<PumpenDelegate> _pumps = new();

    public void Add(PumpenDelegate pumpenDelegate)
    {
        _pumps.Add(pumpenDelegate);
    }

    public void AllePumpenEinschalten()
    {
        foreach (PumpenDelegate pumpenDelegate in _pumps)
        {
            pumpenDelegate();
        }
    }
}