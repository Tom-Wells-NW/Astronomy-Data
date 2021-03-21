using System.Collections.Generic;
using ConsoleTables;

namespace Astronomy.Core.Interfaces
{
    public interface IStarSystemList : IList<IStarSystem>
    {
        string ToString();
        string ToTableString();
        string ToAlternativeTableString();
        string ToMarkdownString();
        string ToMinimalString();
        ConsoleTable ToConsoleTable();
    }
}