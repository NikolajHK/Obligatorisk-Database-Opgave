using System;
using System.Collections.Generic;
using System.Text;

namespace ModelKlasser
{
    public class Faciliteter
    {
        public int Facilitet_Nr { get; set; }

        public string Navn { get; set; }
        public TimeSpan Åbningstid { get; set; }
        public TimeSpan Lukketid { get; set; }

        public override string ToString()
        {
            return $"Facilitet_Nr: {Facilitet_Nr}, Navn: {Navn}, Åbningstid: {Åbningstid}, Lukketid: {Lukketid}";
        }

    }
}
