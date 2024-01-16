using HCL_AssignMent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCL_AssignMent.Constants;
using System.Net.WebSockets;

namespace HCL_AssignMent.Service
{
    public class ApplicationService
    {
        public int CalculateMinimunCopies(List<ApplicationModel> installations, int targetApplicationId)
        {
            var x = installations.GroupBy(x => new { x.ComputerId, x.UserId, ComputerType = x.ComputerType.ToUpper() }).Select(group => new
            {
                Key = group.Key,
                Count = group.Count(),
            }).ToList();
            var y = x.GroupBy(x => new { x.Key.UserId, count = 0 }).ToList(); // 0= Lpatop. 1=Desktop
            List<UserCount> userCounts = new List<UserCount>();
            foreach (var item in y) {
                var s = 1;
                Dictionary<string, int> l = new Dictionary<string, int>();
                foreach (var _item in item) {
                    if (l.ContainsKey(_item.Key.ComputerType))
                    {
                        if (_item.Key.ComputerType == _Constants.DesktopType) {
                            l[_item.Key.ComputerType]++;
                        }
                    }
                    else {
                        l[_item.Key.ComputerType] = 1;
                    }
                }
                if (l.ContainsKey(_Constants.DesktopType)){
                    if (l[_Constants.DesktopType] > 1)
                    {
                        s = l[_Constants.DesktopType];
                    }
                }
                UserCount newUserCount = new UserCount
                {
                    UserId = item.Key.UserId, // replace with the actual UserId
                    Count = s
                };
                userCounts.Add(newUserCount);
            }
            int installeApplication = userCounts.Sum(item => item.Count);
            return installeApplication;
        }
    }
}
