using System;

public class EstimateDetails
{
    public float ConstructionArea { get; set; }
    public float SiteArea { get; set; }
}

public class ConstructionEstimateException : Exception
{
    public ConstructionEstimateException() : base("Sorry your Construction Estimate is not approved")
    {
    }
}

public class Program
{
    public static EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea)
    {
        if (constructionArea <= siteArea)
        {
            return new EstimateDetails
            {
                ConstructionArea = constructionArea,
                SiteArea = siteArea
            };
        }
        else
        {
            throw new ConstructionEstimateException();
        }
    }

    public static void Main(string[] args)
    {
        float constructionArea = Convert.ToSingle(Console.ReadLine());
        float siteArea = Convert.ToSingle(Console.ReadLine());

        try
        {
            EstimateDetails result = ValidateConstructionEstimate(constructionArea, siteArea);
            Console.WriteLine("Construction Estimate Approved");
        }
        catch (ConstructionEstimateException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
