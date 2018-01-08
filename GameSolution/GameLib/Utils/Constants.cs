using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLib.Utils
{
    public enum SkillType : byte
    {
        Weapon = 1,     //武器
        Item = 2        //道具
    }

    public enum SkillNature : byte
    {
        Chop = 1,       //斩击
        Hit = 2,        //打击
        Shoot = 3       //射击
    }
    public enum SkillExtra : byte
    {
        Physical = 1,
        Fire = 2,
        Wind = 3,
        Water = 4,
        Soil = 5,
        Holy = 6,
        Dark = 7
    }
    public enum SkillTarget : byte
    {
        Friendly = 1,
        Enemy = 2
    }
    public enum SkillEffect : byte
    {
        Stun = 1,       //晕眩
        Poision = 2     //中毒
    }

}
