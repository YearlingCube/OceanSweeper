using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationHandler : MonoBehaviour
{
    public Animator Title;
    public Animator Play;
    public Animator Settings;
    public Animator Quit;
    public Animator Credits;

    public IEnumerator PlayOpening()
    {
        yield return new WaitForSeconds(0.8f);
        Title.Play("TitleOpening");
        yield return new WaitForSeconds(0.9f);
        Play.Play("PlayButtonOpening");
        yield return new WaitForSeconds(0.25f);
        Settings.Play("SettingsButtonOpening");
        yield return new WaitForSeconds(0.25f);
        Quit.Play("QuitButtonOpening");
        yield return new WaitForSeconds(0.25f);
        Credits.Play("CreditsButtonOpening");
        yield return new WaitForSeconds(0.25f);
    }
}
