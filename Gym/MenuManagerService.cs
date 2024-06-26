namespace Gym;

public class MenuManagerService
{
    private readonly IOutputLogger _logger;
    private readonly CostCalculatorService _costCalculator = new ();

    public MenuManagerService(IOutputLogger logger)
    {
        _logger = logger;
    }

    public double ChooseGymMembership()
    {
        var plan = ChooseMembershipPlan();
        var features = ChooseFeatures().ToList();
        var totalCost =  _costCalculator.CalculateTotalMemberShipCost(plan, features);

        _logger.WriteLine($"You chose the {plan} plan and the following features:");

        foreach (var feature in features)
        {
            _logger.WriteLine(feature.DisplayName());
        }

        _logger.WriteLine($"For a total cost of {totalCost}. Confirm? (Y/N)");

        var confirm = _logger.ReadLine();

        if (confirm == "Y")
        {
            return totalCost;
        }

        return -1;
    }

    public MembershipPlan ChooseMembershipPlan()
    {
        while (true)
        {
            _logger.WriteLine("Choose a membership plan");
            _logger.WriteLine("1. Basic");
            _logger.WriteLine("2. Premium");
            _logger.WriteLine("3. Family");

            var choice = _logger.ReadLine();

            if (int.TryParse(choice, out var num))
            {
                if (num == 1) return MembershipPlan.Basic;
                if (num == 2) return MembershipPlan.Premium;
                if (num == 3) return MembershipPlan.Family;

                _logger.WriteLine("Invalid membership plan selected, please try again");
            }
            else
            {
                _logger.WriteLine("Please, enter a number");
            }
        }
    }

    public IEnumerable<IPlanFeature> ChooseFeatures()
    {
        var features = new List<IPlanFeature>();

        _logger.WriteLine("Choose additional features. Enter a comma separated list of numbers.");
        _logger.WriteLine("1. Personal training sessions");
        _logger.WriteLine("2. Group classes");

        var choices = _logger.ReadLine();
        var parts = choices.Split(",");

        foreach (var part in parts)
        {
            if (int.TryParse(part, out var num))
            {
                if (num == 1)
                {
                    features.Add(new PersonalTrainingSessionsFeature());
                }
                else if (num == 2)
                {
                    features.Add(new GroupClassesFeature());
                }
                else
                {
                    _logger.WriteLine("Invalid feature selected, skipping");
                }
            }
        }

        return features;
    }
}