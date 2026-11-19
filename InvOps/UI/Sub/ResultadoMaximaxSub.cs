using InvOps.UI.Pub;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvOps.UI.Sub
{
    internal class ResultadoMaximaxSub : ISubscriber
    {
        System.Windows.Forms.Label widget = null;
        public ResultadoMaximaxSub(ref System.Windows.Forms.Label _widget) { 
            widget = _widget;
        }
        public void Update(IPublisher publisher)
        {
            widget.Text = (publisher as ResultadosPub).desMaximax;
        }
    }
}
