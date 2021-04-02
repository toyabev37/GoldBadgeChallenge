using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepo
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, BadgeItem> _badgeDatabase = new Dictionary<int, BadgeItem>();

        int _count;
        


        public bool AddBadgeToDatabase(BadgeItem badge)
        {
            int StartingCount = _badgeDatabase.Count;
            _count++;
            _badgeDatabase.Add(_count, badge);
            if (StartingCount < _badgeDatabase.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      

        public Dictionary<int, BadgeItem> ListBadges()
        {
            return _badgeDatabase;
        }

        public BadgeItem GetBadge(int badgeId)
        {
            foreach (var badge in _badgeDatabase)

            {
                if (badgeId == badge.Key) 
                {
                    return badge.Value;
                }

            }
            return null;
        }

        public bool UpdateBadge(int oldBadgeItem, BadgeItem newBadgeItem)
        {
            BadgeItem oldBadge = GetBadge(oldBadgeItem);
            if (oldBadge == null)
            {
                return false;
            }
            else
            {
                oldBadge.BadgeId = newBadgeItem.BadgeId;
                oldBadge.DoorNames = newBadgeItem.DoorNames;
                return true;
            }
        }

        public bool DeleteDoors(int badgeId, string door)
            
        {
            
            foreach (var badge in _badgeDatabase)
            {
                if (badgeId == badge.Key)
                {
                    if (badge.Value.DoorNames.Contains(door))
                    {
                        badge.Value.DoorNames.Remove(door);
                        return true;
                    }
                    
                }
            }
            return false;
        }


    }

}
