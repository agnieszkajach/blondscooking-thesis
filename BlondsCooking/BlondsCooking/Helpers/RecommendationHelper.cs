using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Db;

namespace BlondsCooking.Helpers
{
    public class RecommendationHelper
    {
        public bool CanGetRecommendation(string userId)
        {
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                var countOfRates = context.UserRatings.Count(rating => rating.UserId.CompareTo(userId) == 0);
                if (countOfRates > 5)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}