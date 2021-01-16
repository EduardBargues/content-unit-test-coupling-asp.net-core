using System;

using TestImplementationCoupling.Services.Abstractions;

namespace TestImplementationCoupling.Services
{
    public class CountCharactersService : ICountCharactersService
    {
        public int CountCharacters(string word) => word != null ? word.Length : 0;
    }
}
