using Gym;

IOutputLogger logger = new ConsoleLogger();
MenuManagerService menuManager = new(logger);

var result = menuManager.ChooseGymMembership();

if (result == -1)
{
    logger.WriteLine("Canceled");
}
else
{
    logger.WriteLine("Purchased!");
}