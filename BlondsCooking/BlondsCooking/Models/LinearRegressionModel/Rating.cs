namespace BlondsCooking.Models.LinearRegressionModel
{
    public class Rating
    {
        public string UserId { get; set; }

        public int DishId { get; set; }

        public double Rate { get; set; }

        public double[] DishParameters { get; set; }
    }
}