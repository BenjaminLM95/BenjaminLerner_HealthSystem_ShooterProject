using System;
using System.Diagnostics;

public class HealthSystem
{
    // Variables
    public int health = 0;
    public string healthStatus;
    public int shield;
    public int lives = 3;   
    

    // Optional XP system variables
    public int xp;
    public int level = 1;

    public HealthSystem()
    {
        ResetGame();
    }

    public string ShowHUD()
    {
        // Implement HUD display
        //healthStatus is left
        healthStatus = GetStatusHealth(health);                
        return "Lives: " + lives.ToString() + "  Health: " + health.ToString() +  " (" + healthStatus + ") Shield: " + shield.ToString() + " Exp: " + xp + " Level: " + level.ToString(); 
    }

    public void TakeDamage(int damage)
    {
        // Implement damage logic
        //Get the player o enemy current hp, decrease that hp with the damage and return with the updated hp
        if (damage < 0) { damage = 0; }


       if(shield > 0) 
        {
            if(shield < damage) 
            {
                health = health - (damage - shield);
                shield = 0;
            }
            else 
            {
                shield = shield - damage; 
            }
        }
        else 
        {
            if (damage < health) { health = health -= damage; }
            else { health = 0; }
        }       
       
             
    }

    public void Heal(int hp)
    {
        // Implement healing logic
        //Get the player current hp, increase that hp with the heal ammount and return with the updated hp
        if (hp < 0) { hp = 0; } 

        health = health + hp;
        if (health > 100) { health = 100; }

    }

    public void RegenerateShield(int hp)
    {
        // Implement shield regeneration logic
        //Get the player shield hp, increase that shield hp with the heal ammount and return with the updated shield hp
        if (hp < 0) { hp = 0; }

        shield = shield + hp;
        if (shield > 100) { shield = 100; }
    }

    public void Revive()
    {
        // Implement revive logic
        
        lives--;
        if(lives > 0) 
        {
            ResetGame();
        }
                           
    }

    public void ResetGame()
    {
        // Reset all variables to default values
        health = 100;
        shield = 100;        

    }

    // Optional XP system methods
    public void IncreaseXP(int exp)
    {
        // Implement XP increase and level-up logic
        xp = xp + exp;

        if (xp >= 100) 
        {
            xp = xp - 100; 
            if(level < 99) 
            {
                level++;
            }
                         
        }
    }

    public string GetStatusHealth(int health) 
    {
        string status;

        if (health <= 10)
        {
            status = "Imminent Danger";            
        }
        else if (health > 10 && health <= 50)
        {
            status = "Badly Hurt";            
        }
        else if (health > 50 && health <= 75)
        {
            status = "Hurt";            
        }
        else if (health > 75 && health <= 90)
        {
            status = "Heathy";          
        }
        else 
        {
            status = "Perfect Health";
        }

        return status; 
    }

}