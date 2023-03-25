using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public static class Debugger
    {
        private static bool ShowLogs = true;
        
        public static void DebugLog(string simpleLog)
        {
            if (!ShowLogs)
            {
                return;
            }
            
            Debug.Log(simpleLog);
        }
        
        public static void DebugLogWarning(string warningLog)
        {
            if (!ShowLogs)
            {
                return;
            }
            
            Debug.LogWarning(warningLog);
        }
        
        public static void DebugLogError(string errorLog)
        {
            if (!ShowLogs)
            {
                return;
            }
            
            Debug.LogError(errorLog);
        }
    }
}
