using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zbx1425.BveCSRegistry.Utilities;

namespace Zbx1425.BveCSRegistry.Models {

    public class File {

        public string Platform { get; set; }

        public bool NeedValidation { get; set; }
        public bool Validated { get; set; }

        public XmlVersion Version { get; set; }
        public string Size { get; set; }

        public string FetchURL { get; set; }

    }
}
