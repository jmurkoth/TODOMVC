using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace TodoMVCRC1.NewFolder
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        
        public LocalizedString this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #region Private methods
     
         #endregion
        }
}
