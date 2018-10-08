using System;

namespace Memory.API
{
    public class APIObject: IDisposable
    {
        private object _state;
        
        public APIObject(int x)
        {
            _state = x;
            MagicAPI.Allocate(x);
        }

        ~APIObject()
        {
            MyOwnDispose();
        }

        public void Dispose()
        {
            MyOwnDispose();
        }

        private void MyOwnDispose()
        {
            if (_state != null)
            {
                MagicAPI.Free((int)_state);
                _state = null;
            }
        }
    }
}
