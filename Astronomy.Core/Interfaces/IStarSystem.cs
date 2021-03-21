namespace Astronomy.Core.Interfaces
{
    public interface IStarSystem
    {
        int Id { get; set; }
        int? HipparcosId { get; }
        int? HenryDraperId { get; }
        int? HarvardRevisedId { get; }
        string ProperName { get; }
        string BayerFlamsteed { get; }
        string GlieseCatalogId { get; }
        string SpectralType { get; }
        double RightAscension { get; }
        double Declination { get; }
        double DistanceInParsecs { get; }
        double X { get; }
        double Y { get; }
        double Z { get; }
        double Xg { get; }
        double Yg { get; }
        double Zg { get; }
        double RightAscensionRadians { get; }
        double DeclinationRadians { get; }

        string ToHeaderSeparatorString();
        string ToHeaderString();
        string ToString();
    }
}