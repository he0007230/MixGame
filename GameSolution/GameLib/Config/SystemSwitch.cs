using System;
using System.IO;
using GameLib.Utils;

public class SystemSwitch
{
    private static bool m_releaseMode = true;

    public static bool ReleaseMode
    {
        get { return m_releaseMode; }
        private set { m_releaseMode = value; }
    }
}
