using InvOps.UI.Pub;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvOps.UI.Sub
{
    internal class ResultadoHurwiczSub : ISubscriber
    {
        System.Windows.Forms.Label widget = null;
        public ResultadoHurwiczSub(ref System.Windows.Forms.Label _widget)
        {
            widget = _widget;
        }
        public void Update(IPublisher publisher)
        {
            widget.Text = (publisher as ResultadosPub).desHurwicz;
        }
    }
}
