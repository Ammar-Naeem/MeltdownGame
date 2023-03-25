using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meltdown
{
    public static class LayerHelper
    {
        public static int GetStandLayerMask()
        {
            return 1 << LayerMask.NameToLayer("Stand");
        }
    }
}
