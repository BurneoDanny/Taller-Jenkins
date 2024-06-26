namespace Gym;

public class CostCalculatorService
{
    public double CalculateBaseMembershipCost(MembershipPlan plan)
    {
        return plan switch
        {
            MembershipPlan.Basic => 10,
            MembershipPlan.Premium => 20,
            MembershipPlan.Family => 30,
        };
    }

    public double CalculateAdditionalFeaturesCost(IEnumerable<IPlanFeature> features)
    {
        return features.Sum(x => x.CalculateCost());
    }

    public double CalculateTotalMemberShipCost(MembershipPlan plan, IEnumerable<IPlanFeature> features)
    {
        return CalculateBaseMembershipCost(plan) + CalculateAdditionalFeaturesCost(features);
    }
}