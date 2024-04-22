using System.Collections.Generic;

namespace InoTec
{
    public class ClsFaultInfoType
    {
        private IEnumerable<string> _geraeteInfo;
        private IEnumerable<ClsLightFaultInfoType> _stromkreise;
        private IEnumerable<string> _batterie;
        private IEnumerable<string> _externe;

        public IEnumerable<string> GeaeteInfo => _geraeteInfo;
        public IEnumerable<ClsLightFaultInfoType> Stromkreise => _stromkreise;
        public IEnumerable<string> Batterie => _batterie;
        public IEnumerable<string> Externe => _externe;
        
        public ClsFaultInfoType(IEnumerable<string> geraeteInfo, IEnumerable<ClsLightFaultInfoType> stromkreise, IEnumerable<string> batterie, IEnumerable<string> externe)
        {
            _geraeteInfo = geraeteInfo;
            _stromkreise = stromkreise;
            _batterie = batterie;
            _externe = externe;
        }
    }
}
