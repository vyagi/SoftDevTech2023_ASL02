namespace FluentBuilderPattern
{
    public class MarineUnitBuilder : 
        INameSetter, 
        IIntendedUseSetter, 
        IDimensionsSetter, 
        IMechanicalInstallationSetter, 
        IVersatileInstallationSetter, 
        IElectricalInstallationSetter,
        IBrandAndModelSetter,
        IMarineUnitBuilder
    {
        private readonly MarineUnit _unit = new();

        private readonly List<ElectricalInstallation> _electricalInstallations = new ();

        private MarineUnitBuilder() { }

        public static INameSetter Initialize() => new MarineUnitBuilder();

        public IIntendedUseSetter WithName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name is required");

            _unit.UnitName = name;

            return this;
        }

        public IDimensionsSetter WithIntendedUse(UnitIntendedUse unitIntendedUse)
        {
            _unit.UnitIntendedUse = unitIntendedUse;
            return this;
        }

        public IMechanicalInstallationSetter WithDimensions(Dimensions dimensions)
        {
            _unit.Dimensions = dimensions;
            return this;
        }

        public IVersatileInstallationSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation)
        {
            _unit.MechanicalInstallation = mechanicalInstallation;
            return this;
        }

        public IElectricalInstallationSetter WithVersatileInstallation(VersatileInstallation versatileInstallation)
        {
            _unit.VersatileInstallation = versatileInstallation;
            return this;
        }

        public IElectricalInstallationSetter WithElectricalInstallation(ElectricalInstallation electricalInstallation)
        {
            _electricalInstallations.Add(electricalInstallation);
            return this;
        }

        public IBrandAndModelSetter WithNoMoreElectricalInstallations()
        {
            _unit.ElectricalInstallation = _electricalInstallations.ToArray();
            return this;
        }

        public IMarineUnitBuilder WithBrandAndModel(string brand, string model)
        {
            _unit.Brand = brand;
            _unit.Model = model;
            return this;
        }

        public MarineUnit Build()
        {
            return _unit;
        }
    }

    public interface IMarineUnitBuilder
    {
        MarineUnit Build();
    }

    public interface IBrandAndModelSetter
    {
        IMarineUnitBuilder WithBrandAndModel(string brand, string model);
    }

    public interface IElectricalInstallationSetter
    {
        IElectricalInstallationSetter WithElectricalInstallation(ElectricalInstallation electricalInstallation);
        IBrandAndModelSetter WithNoMoreElectricalInstallations();
    }

    public interface IVersatileInstallationSetter
    {
        IElectricalInstallationSetter WithVersatileInstallation(VersatileInstallation versatileInstallation);
    }

    public interface IMechanicalInstallationSetter
    {
        IVersatileInstallationSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation);
    }

    public interface IDimensionsSetter
    {
        IMechanicalInstallationSetter WithDimensions(Dimensions dimensions);
    }

    public interface IIntendedUseSetter
    {
        IDimensionsSetter WithIntendedUse(UnitIntendedUse unitIntendedUse);
    }

    public interface INameSetter
    {
        IIntendedUseSetter WithName(string name);
    }

    public class MarineUnit
    {
        internal MarineUnit() { }

        public string UnitName { get; internal set; }

        public UnitIntendedUse UnitIntendedUse { get; internal set; }

        public Dimensions Dimensions { get; internal set; }

        public MechanicalInstallation MechanicalInstallation { get; internal set; }

        public VersatileInstallation VersatileInstallation { get; internal set; }

        public ElectricalInstallation[] ElectricalInstallation { get; internal set; }

        public string Brand { get; internal set; }

        public string Model { get; internal set; }

        //Other methods...
    }

    public class UnitIntendedUse
    {
        public UnitIntendedUse(TypeOfUse typeOfUse, string lineOfBusiness, string unitPurpose)
        {
            TypeOfUse = typeOfUse;
            LineOfBusiness = lineOfBusiness;
            UnitPurpose = unitPurpose;
        }

        public TypeOfUse TypeOfUse { get; internal set; }
        public string LineOfBusiness { get; internal set; }
        public string UnitPurpose { get; internal set; }
    }

    public enum TypeOfUse
    {
        MarineCommercial,
        MarineLeisure
    }

    public struct Dimensions
    {
        public Dimensions(int length, int width, int weight)
        {
            Length = length;
            Width = width;
            Weight = weight;
        }
        public int Length { get; internal set; }
        public int Width { get; internal set; }
        public int Weight { get; internal set; }
    }

    public class MechanicalInstallation : Installation { }

    public class ElectricalInstallation : Installation { }

    public class VersatileInstallation : Installation { }

    public abstract class Installation
    {
        public IList<Driveline> Drivelines { get; internal set; }
    }

    public class Driveline
    {
        public Engine Engine { get; set; }
    }

    public class Engine { }
}