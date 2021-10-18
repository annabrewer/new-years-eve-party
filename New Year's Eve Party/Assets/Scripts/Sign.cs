
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class Sign : UdonSharpBehaviour
{
    public GameObject[] questions;
    public bool spicy = false;

    // TODO make format consistent (include "what's" or not) ??
    private string[] mildQuestions = {"Trolley problem: do you pull the lever?", "Cringiest phase you went through while growing up?", "Most embarrassing work moment?", "What's the most scared you’ve ever been?",
        "Tell us about the worst date you’ve been on.", "Show us the most embarrassing photo of you on your phone.", "Biggest lie that your parents believe about you?", "Biggest misconception about you?",
        "What's something you like that people wouldn’t expect you to?", "Who here would you swap lives with for a week?", "Tell us your 3 biggest turn-offs.", "Tell us your 3 biggest turn-ons.",
        "One thing you’d like to change about yourself?", "Tell us an unpopular opinion of yours.", "If you could redo one thing in your life, what would it be?", "What's something you’ve never told anyone in this room?",
        "What have you done to try to be “cool”?", "Most useless piece of knowledge you know?", "If you could turn invisible, what would you do?", "Tell us a book/movie/song/etc. you're embarrassed to admit you like.",
        "Tell us about a weird dream you’ve had.", "Favorite possession?", "What's the hardest decision you’ve had to make?", "What do you spend too much time thinking about?", "What’s a childish thing you still do?",
        "Do you want kids? Why or why not?", "Would you rather randomly time travel +/- 20 years every time you fart or teleport to a different place on earth (on land, not water) every time you sneeze?" , 
        "Would you rather be born a rich 1% in 1800 or an extreme poor person in 2000?", "What’s your Patronus?", "What bender would you be in Avatar The Last Airbender?", "What’s your Harry Potter house?", 
        "Illvermorny or Hogwarts?", "You’re stuck in the world of the last movie, video game or TV show you watched. Where you stuck at?",  "What’s the biggest romantic fail you’ve ever experienced?", 
        "What’s the craziest thing you’ve done to attract a crush?", "What’s your worst romantic fail?", "What’s you’re go-to move to get attention from someone you're attracted to?", 
        "What would the perfect day look like to you?", "Who do you look up to the most and why?", "What's the killer use case of AR/VR that you would like to see in the future?", "Tell us about your weirdest college memory."};

    private string[] spicyQuestions = {"Body count?", "Song/artist that would be on your sex playlist?", "Hardest drug you’ve done?", "Hardest drug you would do?",
        "Who/what was your sexual awakening?", "Tell us about a sexual fantasy.", "Most illegal thing you’ve done?", "Most regrettable thing you’ve done while inebriated?",
        "Craziest sex thing you’ve done?", "Tell us about your worst sex experience.", "What’s your favorite sex position?", "What’s your go-to Pornhub category?", "Last category of porn you masturbated to?", 
        "Of the people in this room, who would you feel most comfortable being naked with?", "Thoughts on anal sex?", "Would you rather have nipples the size of your genitals or have genitals the size of your nipples?",
        "If you were to commit a crime, what would it be and why?", "Body count?", "Song/artist that would be on your sex playlist?", "Hardest drug you’ve done?", "Hardest drug you would do?",
        "Who/what was your sexual awakening?", "Tell us about a sexual fantasy.", "Most illegal thing you’ve done?", "Most regrettable thing you’ve done while inebriated?",
        "Craziest sex thing you’ve done?", "Tell us about your worst sex experience.", "What’s your favorite sex position?", "What’s your go-to Pornhub category?", "Last category of porn you masturbated to?", 
        "Of the people in this room, who would you feel most comfortable being naked with?", "Thoughts on anal sex?", "Would you rather have nipples the size of your genitals or have genitals the size of your nipples?",
        "If you were to commit a crime, what would it be and why?", "Body count?", "Song/artist that would be on your sex playlist?", "Hardest drug you’ve done?", "Hardest drug you would do?",
        "Who/what was your sexual awakening?", "Tell us about a sexual fantasy.", "Most illegal thing you’ve done?", "Most regrettable thing you’ve done while inebriated?",
        "Craziest sex thing you’ve done?", "Tell us about your worst sex experience.", "What’s your favorite sex position?", "What’s your go-to Pornhub category?", "Last category of porn you masturbated to?",
        "Of the people in this room, who would you feel most comfortable being naked with?", "Thoughts on anal sex?", "Would you rather have nipples the size of your genitals or have genitals the size of your nipples?",
        "If you were to commit a crime, what would it be and why?"};

    public void NextQuestions()
    {
        // Select random indices
        int[] indices = new int[2];
        indices[0] = RandomIndex();
        indices[1] = RandomIndex();
        while (indices[1] == indices[0]) {
            indices[1] = RandomIndex();
        }

        // Set questions based on indices
        for (int i = 0; i < questions.Length; i++)
        {
            int index = indices[i];
            if (index >= mildQuestions.Length)
            {
                questions[i].GetComponent<Text>().text = spicyQuestions[index - mildQuestions.Length];
            }
            else
            {
                questions[i].GetComponent<Text>().text = mildQuestions[index];
            }
        }
    }

    int RandomIndex()
    {
        int mildMax = mildQuestions.Length - 1;
        int spicyMax = mildMax + spicyQuestions.Length;

        if (spicy)
        {
            return Random.Range(0, spicyMax);
        }
        else
        {
            return Random.Range(0, mildMax);
        }
    }
}
