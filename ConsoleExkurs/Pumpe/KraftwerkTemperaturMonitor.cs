using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExkurs.Pumpe;

public class KraftwerkTemperaturMonitor
{
    private readonly ArrayList _pumps = new();

    public void Add(object pump)
    {
        _pumps.Add(pump);
    }

    public void AllePumpenEinschalten()
    {
        foreach (var pump in _pumps)
        {
            switch (pump)
            {
                case ElektrischePumpe pumpe: pumpe.StarteElektrischePumpe();break;
                case PneumatischePumpe pneumatischePumpe: pneumatischePumpe.StartePneumatischePumpe();break;
            }
        }
    }
}