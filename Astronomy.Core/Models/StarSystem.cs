using System.IO;
using Astronomy.Core.Interfaces;

namespace Astronomy.Core.Models
{
    public class StarSystem : IStarSystem
    {
        public StarSystem() { }
        public int Id { get; set; }
        public int? HipparcosId { get; set; }
        public int? HenryDraperId { get; set; }
        public int? HarvardRevisedId { get; set; }
        public string ProperName { get; set; } // max len 24
        public string BayerFlamsteed { get; set; }
        public string GlieseCatalogId { get; set; }
        public string SpectralType { get; set; } //max len 12
        public double RightAscension { get; set; }
        public double Declination { get; set; }
        public double DistanceInParsecs { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Xg { get; set; }
        public double Yg { get; set; }
        public double Zg { get; set; }
        public double RightAscensionRadians { get; set; }
        public double DeclinationRadians { get; set; }

        public string ToHeaderString()
        {
            var result = new StringWriter();
            result.Write($"[ {nameof(StarSystem)} >> ");
            result.Write($"{nameof(Id),-7}");
            result.Write(" | ");
            result.Write($"{nameof(ProperName),-24}");
            result.Write(" | ");
            result.Write($"{nameof(SpectralType),-12}");
            result.Write(" | ");
            result.Write($"{nameof(DistanceInParsecs),-17}");
            result.Write(" | ");
            result.Write($"{nameof(Xg),-23}");
            result.Write(" | ");
            result.Write($"{nameof(Yg),-23}");
            result.Write(" | ");
            result.Write($"{nameof(Zg),-23}");
            result.Write(" | ");
            result.Write($"{nameof(RightAscensionRadians),-23}");
            result.Write(" | ");
            result.Write($"{nameof(DeclinationRadians),-23}");
            result.Write(" ]");

            return result.ToString();
        }

        public string ToHeaderSeparatorString()
        {
            var result = new string('-', ToHeaderString().Length);
            return result;
        }

        public override string ToString()
        {
            var result = new StringWriter();
            result.Write($"[ {nameof(StarSystem)} >> ");
            result.Write($"{Id,-7}");
            result.Write(" | ");
            result.Write($"{ProperName,-24}");
            result.Write(" | ");
            result.Write($"{SpectralType,-12}");
            result.Write(" | ");
            result.Write($"{DistanceInParsecs,-17}");
            result.Write(" | ");
            result.Write($"{Xg,-23}");
            result.Write(" | ");
            result.Write($"{Yg,-23}");
            result.Write(" | ");
            result.Write($"{Zg,-23}");
            result.Write(" | ");
            result.Write($"{RightAscensionRadians,-23}");
            result.Write(" | ");
            result.Write($"{DeclinationRadians,-23}");
            result.Write(" ]");

            return result.ToString();
        }
    }
}
