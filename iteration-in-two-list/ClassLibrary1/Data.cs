using System;

namespace ClassLibrary1
{
    public class Data
    {
        public string Abbrv { get; set; }

        public DateTime Date { get; set; }

        public string Desc { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is Data data
                && Abbrv == data.Abbrv)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Abbrv.GetHashCode();
            return hash;
        }
    }
}