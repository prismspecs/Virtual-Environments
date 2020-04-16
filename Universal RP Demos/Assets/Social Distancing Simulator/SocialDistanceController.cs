using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialDistanceController : MonoBehaviour
{
    // reference to the UI text
    public Text PercentageText;
    public Text TimeText;

    // a method to expose this script to the UI event system
    // if you use an argument here (bool value) then you can use
    // the dynamic feature of the UI event system to pass the value
    // of the toggle itself to the method below
    public void EnableSocialDistancing(bool value)
    {
        // we want to toggle the social distancing value to all Agents in the scene,
        // so first create an array to store all of the agents
        // its a long line but its just saying find all of type SocialDistanceAgent (which is the
        // name of the script we created) and store them in an array called agents
        SocialDistanceAgent[] agents = FindObjectsOfType(typeof(SocialDistanceAgent)) as SocialDistanceAgent[];

        // a little debug to make sure we are finding agents in the scene
        Debug.Log("Found " + agents.Length + " instances with agent script attached");

        // now we can do something to each agent in the scene
        // the foreach loop will loop thru every instance of agent in the array
        foreach (SocialDistanceAgent myAgent in agents)
        {
            // now just pass each ag
            myAgent.isDistancing = value;
        }
    }

    
    private void Update()
    {

        // again, use an array of every agent in the scene
        SocialDistanceAgent[] agents = FindObjectsOfType(typeof(SocialDistanceAgent)) as SocialDistanceAgent[];
        
        // find out what percentage are sick by dividing by total number of agents
        int totalAgents = agents.Length;
        int totalSick = 0;
        int totalRecovered = 0;

        // loop thru all agents to make a tally on sick, recovered, etc
        foreach (SocialDistanceAgent myAgent in agents)
        {
            if(myAgent.isSick)
            {
                totalSick++;    // add one to the sick tally
            }
            if (myAgent.isRecovered)
            {
                totalRecovered++;
            }
        }

        // you need to convert the ints to floats so it calculates properly
        float percentageSick = (float)totalSick / (float)totalAgents * 100f;
        Debug.Log(percentageSick);

        // change the UI text to match
        // the "#.00" means convert it to two decimal places
        PercentageText.text = percentageSick.ToString("#.00") + "% sick";

        TimeText.text = Time.time.ToString("#.00") + " seconds have passed";
    }
}