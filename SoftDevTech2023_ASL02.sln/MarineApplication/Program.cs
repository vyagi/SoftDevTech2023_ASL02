using FluentBuilderPattern;

var boat = MarineUnitBuilder
    .Initialize()
    .WithName("Maria")
    .WithIntendedUse(new UnitIntendedUse(TypeOfUse.MarineCommercial, "Fishing", "Sharks"))
    .WithDimensions(new Dimensions(100, 100, 200))
    .WithMechanicalInstallation(new MechanicalInstallation())
    .WithVersatileInstallation(new VersatileInstallation())
    .WithElectricalInstallation(new ElectricalInstallation())
    .WithElectricalInstallation(new ElectricalInstallation())
    .WithNoMoreElectricalInstallations()
    .WithBrandAndModel("Volvo", "Penta")
    .Build();

Console.WriteLine(boat.Model);
Console.WriteLine(boat.Brand);


