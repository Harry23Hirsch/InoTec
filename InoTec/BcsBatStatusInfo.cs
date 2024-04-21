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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;


            return Equals((BcsBatStatusInfo)obj);
        }
        public bool Equals(BcsBatStatusInfo obj)
        {
            if (_bcsBatInfo == null ||
                obj.BcsBatInfo == null)
                return false;

            if(_bcsBatInfo.N == obj.BcsBatInfo.N)
                return true;

            return false;
        }
        public override int GetHashCode() 
        {
            return base.GetHashCode();
        }
    }
}
