using M2C.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Data.Abstractions
{
    public class DataPage : IPage
    {
        public int Count
        {
            get
            {
                int numberofPages = 0;
                if (Total > 0 && Size > 0)
                {
                    numberofPages = (int)Math.Ceiling(Total / (double)Size);
                }
                return numberofPages;
            }
        }

        public int Size{ get; set;}

        public int Index { get; set; }

        public int Total { get; set; }

        public string Marker { get; set; }

        public string Sort { get; set; }

        public DataPage()
        {

        }
        public DataPage(int total)
        {
            Size = Total = total;
            Index = 0;
        }
    }
}
