using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace berek
{
    internal class ber
    {
        public string Nev { get; set; }
        public bool Neme { get; set; }
        public string Reszleg { get; set; }
        public int Belepes { get; set; }
        public int Fizetes { get; set; }

        public ber(string sorok)
        {
            var s=sorok.Split(';');
            Nev=s[0];
            Neme = s[1]=="nő";
            Reszleg=s[2];
            Belepes=Convert.ToInt32(s[3]);
            Fizetes=Convert.ToInt32(s[4]);
        }
    }
}