using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepo
{
    public class BadgeItem
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        public BadgeItem()
        {

        }

        public BadgeItem(int badgeId, List<string> doorNames)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;

        }
    }
}
