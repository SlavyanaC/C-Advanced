﻿using System;
using System.Text;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get => this.id;
        protected set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.Id)}");
            }

            this.id = value;
        }
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0.0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0.0 || value > 20000.0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var typeName = GetType().Name.Equals("SonicHarvester") ? "Sonic" : "Hammer";

        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{typeName} Harvester - {this.Id}");
        builder.AppendLine($"Ore Output: {(int)this.OreOutput}");
        builder.AppendLine($"Energy Requirement: {(int)this.EnergyRequirement}");

        return builder.ToString().TrimEnd();
    }
}
