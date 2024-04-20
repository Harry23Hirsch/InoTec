using InoTec;
using System.Collections.Generic;

namespace InoTec
{
    public class BcsBatStatusInfo
    {
        private BatInfo _bcsInfo;
        private IEnumerable<BatStatus> _bcsStatus;

        public BatInfo BcsBatInfo => _bcsInfo;
        public IEnumerable<BatStatus> BcsBatStatus => _bcsStatus;

        public BcsBatStatusInfo(BatInfo bcsInfo, IEnumerable<BatStatus> bcsStatus)
        {
            _bcsInfo = bcsInfo;
            _bcsStatus = bcsStatus;
        }
    }
}
