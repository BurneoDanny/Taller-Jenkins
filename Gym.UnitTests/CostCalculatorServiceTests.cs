namespace Gym.UnitTests;

public class CostCalculatorServiceTests
{
    [Fact]
    public void TestCalculatingMembershipPlanWorksAsExpected()
    {
        // Arrange
        CostCalculatorService costCalculator = new();

        // Act
        var basicCost = costCalculator.CalculateBaseMembershipCost(MembershipPlan.Basic);
        var premiumCost = costCalculator.CalculateBaseMembershipCost(MembershipPlan.Premium);
        var familyCost = costCalculator.CalculateBaseMembershipCost(MembershipPlan.Family);

        // Assert
        Assert.Equal(10, basicCost);
        Assert.Equal(20, premiumCost);
        Assert.Equal(30, familyCost);
    }

    [Fact]
    public void TestCalculatingFeaturesCostWorksAsExpected()
    {
        // Arrange
        var feature1 = new GroupClassesFeature();
        var feature2 = new PersonalTrainingSessionsFeature();
        var totalFeaturesCost = feature1.CalculateCost() + feature2.CalculateCost();
        var costCalculator = new CostCalculatorService();

        // Act
        var featuresCost = costCalculator.CalculateAdditionalFeaturesCost([feature1, feature2]);

        // Assert
        Assert.Equal(totalFeaturesCost, featuresCost);
    }

    [Fact]
    public void TestCalculatingTheTotalMembershipCostWorksAsExpected()
    {
        // Arrange
        var plan = MembershipPlan.Premium;
        List<IPlanFeature> features = [new GroupClassesFeature()];
        var costCalculator = new CostCalculatorService();
        var expectedCost = costCalculator.CalculateBaseMembershipCost(plan) + features[0].CalculateCost();

        // Act
        var actualCost = costCalculator.CalculateTotalMemberShipCost(plan, features);

        // Assert
        Assert.Equal(expectedCost, actualCost);
    }
}