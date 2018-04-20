﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    private const string ProviderSuffix = "Provider";

    public IProvider GenerateProvider(IList<string> args)
    {
        string type = args[0];
        int id = int.Parse(args[1]);
        double energyOutput = double.Parse(args[2]);

        string typeFullName = type + ProviderSuffix;

        Type providerType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(typeFullName, StringComparison.OrdinalIgnoreCase));

        object[] ctorArgs = new object[] { id, energyOutput };

        IProvider provider = (IProvider)Activator.CreateInstance(providerType, ctorArgs);

        return provider;
    }
}