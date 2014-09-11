using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern2
{
    class Color
    {
        public string color;
    }

    class Red : Color
    {
        public Red()
        { this.color = "red"; }
    }

    class Blue : Color
    {
        public Blue()
        { this.color = "blue"; }
    }

    class Green : Color
    {
        public Green()
        { this.color = "green"; }
    }
}
