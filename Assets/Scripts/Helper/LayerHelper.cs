using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meltdown
{
    public static class LayerHelper
    {
        public static int GetGroundLayerMask()
        {
            return 1 << LayerMask.NameToLayer("Ground");
        }
    }
}
