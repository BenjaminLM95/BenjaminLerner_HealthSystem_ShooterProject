using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTests : MonoBehaviour
{
    HealthSystem healthSystem = new HealthSystem();

    // Start is called before the first frame update
    void Start()
    {
        Tests(); 
    }
    
    public void Tests()
    {
        Test_TakeDamage_OnlyShield();
        Test_TakeDamage_BothShieldHealth();
        Test_TakeDamage_shieldDepleted();
        Test_TakeDamage_healthToZero();
        Test_TakeDamage_ShieldHealthToZero();
        Test_TakeDamage_NegativeDamage();
        Test_Heal_NormalHealing();
        Test_Heal_HealingWhenAtMax();
        Test_Heal_NegativeHealing();
        Test_ShieldRegenerate_NormalRegeneration();
        Test_ShieldRegenerate_RegenerationAtMax();
        Test_ShieldRegenerate_NegativeInput();
        Test_Revive();
    }

    public void Test_TakeDamage_OnlyShield()
    {
        //Test damage to shield only
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;

        system.TakeDamage(10);

        Debug.Assert(90 == system.shield, "shield is 90");
        Debug.Assert(100 == system.health, "health is 100");
        Debug.Assert(3 == system.lives, "lives is 3");
    }

    public void Test_TakeDamage_BothShieldHealth()
    {
        //Test damage to both shield and health
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;

        system.TakeDamage(150);

        Debug.Assert(0 == system.shield, "Shield is 0");
        Debug.Assert(50 == system.health, "The health is 50");
        Debug.Assert(3 == system.lives, "three lives");
    }

    public void Test_TakeDamage_shieldDepleted()
    {
        //Test damage to health only (when shield is depleted)
        HealthSystem system = new HealthSystem();
        system.shield = 0;
        system.health = 100;
        system.lives = 3;

        system.TakeDamage(80);

        Debug.Assert(0 == system.shield, "Shield is 0");
        Debug.Assert(20 == system.health, "Health should be 20");
        Debug.Assert(3 == system.lives, "Lives is 3");
    }

    public void Test_TakeDamage_healthToZero()
    {
        //Test damage that reduces health to zero
        HealthSystem system = new HealthSystem();
        system.shield = 0;
        system.health = 50;
        system.lives = 3;

        system.TakeDamage(70);

        Debug.Assert(0 == system.shield, "error shield");
        Debug.Assert(0 == system.health, "error health");
        Debug.Assert(3 == system.lives, "error lives");
    }

    public void Test_TakeDamage_ShieldHealthToZero()
    {
        //Test damage that depletes shield and reduces health to zero
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;

        system.TakeDamage(130);

        Debug.Assert(0 == system.shield, "Shield should be depleted");
        Debug.Assert(70 == system.health, "Health should be 70");
        Debug.Assert(3 == system.lives, "Lives should be 3");
    }

    public void Test_TakeDamage_NegativeDamage()
    {
        //Test with negative damage input (should not change values)
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;

        system.TakeDamage(-10);

        Debug.Assert(100 == system.shield, "There should be no change in shield");
        Debug.Assert(100 == system.health, "There should be no change in health");
        Debug.Assert(3 == system.lives, "There should be no change in lives");
    }

    public void Test_Heal_NormalHealing()
    {
        //Test normal healing
        HealthSystem system = new HealthSystem();
        system.shield = 0;
        system.health = 30;
        system.lives = 3;

        system.Heal(20);

        Debug.Assert(0 == system.shield, "Shield should be 0");
        Debug.Assert(50 == system.health, "Shield should be 50");
        Debug.Assert(3 == system.lives, "lives should be 3");
    }

    public void Test_Heal_HealingWhenAtMax()
    {
        //Test healing when already at max health
        HealthSystem system = new HealthSystem();
        system.shield = 10;
        system.health = 100;
        system.lives = 2;

        system.Heal(70);

        Debug.Assert(10 == system.shield, "Shield should be 10");
        Debug.Assert(100 == system.health, "Health should be 100");
        Debug.Assert(2 == system.lives, "Lives should be 2");
    }

    public void Test_Heal_NegativeHealing()
    {
        //Test with negative healing input (should not change values)
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 60;
        system.lives = 3;

        system.Heal(-30);

        Debug.Assert(100 == system.shield, "There should be no change in shield");
        Debug.Assert(60 == system.health, "There should be no change in health");
        Debug.Assert(3 == system.lives, "There should be no change in health");

    }

    public void Test_ShieldRegenerate_NormalRegeneration()
    {
        //Test normal shield regeneration
        HealthSystem system = new HealthSystem();
        system.shield = 0;
        system.health = 100;
        system.lives = 3;

        system.RegenerateShield(40);

        Debug.Assert(40 == system.shield, "Shield should be 40");
        Debug.Assert(100 == system.health, "Health should be 100");
        Debug.Assert(3 == system.lives, "Lives should be 3");
    }

    public void Test_ShieldRegenerate_RegenerationAtMax()
    {
        //Test regeneration when shield is already at max
        HealthSystem system = new HealthSystem();
        system.shield = 100;
        system.health = 100;
        system.lives = 3;

        system.RegenerateShield(30);

        Debug.Assert(100 == system.shield, "Shield should be 100");
        Debug.Assert(100 == system.health, "Health should be 100");
        Debug.Assert(3 == system.lives, "Lives should be 3");
    }

    public void Test_ShieldRegenerate_NegativeInput()
    {
        //Test with negative regeneration input (should not change values)
        HealthSystem system = new HealthSystem();
        system.shield = 50;
        system.health = 100;
        system.lives = 1;

        system.RegenerateShield(-40);

        Debug.Assert(50 == system.shield, "Shield should be 50");
        Debug.Assert(100 == system.health, "Health should be 100");
        Debug.Assert(1 == system.lives, "Live should be 1");
    }

    public void Test_Revive()
    {
        //Test revive functionality (should reset health and shield, and decrease lives)
        HealthSystem system = new HealthSystem();
        system.shield = 0;
        system.health = 70;
        system.lives = 3;

        system.TakeDamage(90);
        system.Revive();

        Debug.Assert(100 == system.shield, "Shield should return to 100");
        Debug.Assert(100 == system.health, "Health should return to 100");
        Debug.Assert(2 == system.lives, "Live should be reduce to 2");
    }


}
