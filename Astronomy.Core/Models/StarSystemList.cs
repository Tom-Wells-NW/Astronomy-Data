using System.Collections.Generic;
using Astronomy.Core.Interfaces;
using ConsoleTables;

namespace Astronomy.Core.Models
{
    public class StarSystemList : List<IStarSystem>, IList<IStarSystem>, IStarSystemList
    {
        public override string ToString()
        {
            var table = ToConsoleTable();
            return table.ToMarkDownString();
        }

        public string ToTableString()
        {
            var table = ToConsoleTable();
            return table.ToString();
        }

        public string ToAlternativeTableString()
        {
            var table = ToConsoleTable();
            return table.ToStringAlternative();
        }

        public string ToMarkdownString()
        {
            var table = ToConsoleTable();
            return table.ToMarkDownString();
        }

        public string ToMinimalString()
        {
            var table = ToConsoleTable();
            return table.ToMinimalString();
        }

        public ConsoleTable ToConsoleTable()
        {
            var firstRow = this[0];
            var table = new ConsoleTable
                (
                    nameof(firstRow.Id),
                    nameof(firstRow.ProperName),
                    nameof(firstRow.SpectralType),
                    nameof(firstRow.DistanceInParsecs),
                    nameof(firstRow.Xg),
                    nameof(firstRow.Yg),
                    nameof(firstRow.Zg),
                    nameof(firstRow.RightAscensionRadians),
                    nameof(firstRow.DeclinationRadians)
                );
            foreach (var starSystem in this)
            {
                table.AddRow
                    (
                        starSystem.Id,
                        starSystem.ProperName,
                        starSystem.SpectralType,
                        starSystem.DistanceInParsecs,
                        starSystem.Xg,
                        starSystem.Yg,
                        starSystem.Zg,
                        starSystem.RightAscensionRadians,
                        starSystem.DeclinationRadians
                    );
            }

            return table;
        }
    }
}