using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder
{
    public class FinderCore
    {
        public static FinderEntities connection = new FinderEntities();
        public static ObservableCollection<Country> Countries { get; set; }

        public ObservableCollection<Country> Enter()
        {
            return Countries = new ObservableCollection<Country>(connection.Country.ToList());
        }
    }
}
