using System.Collections.Generic;

namespace InoTec
{
    public class ClsFaultInfo
    {
        private IEnumerable<string> _geraeteInfo;
        private IEnumerable<ClsLightFaultInfo> _stromkreise;
        private IEnumerable<string> _batterie;
        private IEnumerable<string> _externe;

        public IEnumerable<string> GeaeteInfo => _geraeteInfo;
        public IEnumerable<ClsLightFaultInfo> Stromkreise => _stromkreise;
        public IEnumerable<string> Batterie => _batterie;
        public IEnumerable<string> Externe => _externe;
        
        public ClsFaultInfo(IEnumerable<string> geraeteInfo, IEnumerable<ClsLightFaultInfo> stromkreise, IEnumerable<string> batterie, IEnumerable<string> externe)
        {
            _geraeteInfo = geraeteInfo;
            _stromkreise = stromkreise;
            _batterie = batterie;
            _externe = externe;
        }
    }
}
