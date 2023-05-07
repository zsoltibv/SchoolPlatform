using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Data
{
    public class DataContextSingleton
    {
        private static DataContext _instance;

        private DataContextSingleton() { }

        public static DataContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataContext();
                }
                return _instance;
            }
        }
    }
}
