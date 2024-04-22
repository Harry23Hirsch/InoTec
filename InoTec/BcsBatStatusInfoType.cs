using InoTec;
using System.Collections.Generic;

namespace InoTec
{
    public class BcsBatStatusInfoType
    {
        private BatInfo _bcsBatInfo;
        private IEnumerable<BatStatusType> _bcsBatStatus;

        public BatInfo BcsBatInfo => _bcsBatInfo;
        public IEnumerable<BatStatusType> BcsBatStatus
        {
            get => _bcsBatStatus;
            set => _bcsBatStatus = value;
        }

        public BcsBatStatusInfoType(BatInfo bcsInfo, IEnumerable<BatStatusType> bcsStatus)
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


            return Equals((BcsBatStatusInfoType)obj);
        }
        public bool Equals(BcsBatStatusInfoType obj)
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
