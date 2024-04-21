using InoTec;
using System.Collections.Generic;

namespace InoTec
{
    public class BcsBatStatusInfo
    {
        private BatInfo _bcsBatInfo;
        private IEnumerable<BatStatus> _bcsBatStatus;

        public BatInfo BcsBatInfo => _bcsBatInfo;
        public IEnumerable<BatStatus> BcsBatStatus
        {
            get => _bcsBatStatus;
            set => _bcsBatStatus = value;
        }

        public BcsBatStatusInfo(BatInfo bcsInfo, IEnumerable<BatStatus> bcsStatus)
        {
            _bcsBatInfo = bcsInfo;
            _bcsBatStatus = bcsStatus;
        }
    }
}
