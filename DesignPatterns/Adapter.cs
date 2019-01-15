using System;
using static System.Console;

namespace DesignPatterns
{
    // Allows two incompatible interfaces to work together

    public interface EnemyAttacker
    {
        void FireWeapon();
        void DriveForward();
        void AssignDriver(string driver);
    }

    public class EnemyTank : EnemyAttacker
    {
        Random generator = new Random();

        public void AssignDriver(string driver)
        {
            Write($"{driver} is driving the tank.");
        }

        public void DriveForward()
        {
            Write($"Enemey tank moves {generator.Next(1, 10)} spaces.");
        }

        public void FireWeapon()
        {
            Write($"Enemy tank destroys {generator.Next(1,5)} enemies.");
        }
    }

    public class EnemyRobot
    {
        Random generator = new Random();

        public void SmashWitHands()
        {
            Write($"Enemy robot destroys {generator.Next(1, 5)} enemies with its hands.");
        }

        public void WalkForward()
        {
            Write($"Enemey robot moves {generator.Next(1, 10)} spaces.");
        }

        public void ReactToHuman(string driverName)
        {
            Write($"Enemy Robot tramps on {driverName}");
        }
    }

    public class EnemyRobotAdapter : EnemyAttacker
    {
        EnemyRobot theRobot;
        public EnemyRobotAdapter(EnemyRobot enemyRobot)
        {
            theRobot = enemyRobot;
        }
        public void AssignDriver(string driver)
        {
            theRobot.ReactToHuman(driver);
        }

        public void DriveForward()
        {
            theRobot.WalkForward();
        }

        public void FireWeapon()
        {
            theRobot.SmashWitHands();
        }
    }


    public class TestEnemyAdapter
    {
        static void Main()
        {
            EnemyTank tx3Tank = new EnemyTank();
            EnemyRobot amyTheRobot = new EnemyRobot();
            EnemyAttacker robotAdapter = new EnemyRobotAdapter(amyTheRobot);

            Write("The Robot:");
            amyTheRobot.ReactToHuman("Bishnu");
            amyTheRobot.WalkForward();
            amyTheRobot.SmashWitHands();

            Write("The Enemy Tank");
            tx3Tank.AssignDriver("Bishnu");
            tx3Tank.DriveForward();
            tx3Tank.FireWeapon();

            Write("The Robot with Adapter");
            robotAdapter.AssignDriver("Samir");
            robotAdapter.DriveForward();
            robotAdapter.FireWeapon();
        }
    }
}
