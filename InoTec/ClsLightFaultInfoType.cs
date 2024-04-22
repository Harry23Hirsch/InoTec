namespace InoTec
{
    public class ClsLightFaultInfoType
    {
        private int _cls;
        private int _slot;
        private string _text;
        private int _adr;

        public int Cls => _cls;
        public int Slot => _slot;
        public int Adr => _adr;
        public string Text => _text;

        public ClsLightFaultInfoType(int cls, int slt, int adr, string text)
        {
            _cls = cls;
            _slot = slt;
            _adr = adr;
            _text = text;
        }
    }
}