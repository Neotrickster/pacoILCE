using System;
using System.Collections.Generic;
using System.Text;

namespace pacoILCE.Models
{
    public enum MenuType
    {
        AcercaDe,
        Facebook,
        Twitter,
        CanalIberoamericano,
        SummaSaberes,
        RadioIlce
    }
    public class HomeMenuItem : BaseModel
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.AcercaDe;
        }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}
