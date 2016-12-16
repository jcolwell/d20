using UnityEngine;
using System.Collections;

//============================================================
// Class FrontEndMenu
//============================================================
public class FrontEndMenu : MonoBehaviour
{
    public GameObject campaignSubMenu;
    public GameObject encounterSubMenu;
    public GameObject settingsSubMenu;

    private FiniteStateMachine<State> mFSM;
    
    enum MenuStates : int
    {
        none = 0,
        campaign,
        encounter,
        settings
    };

    //------------------------------------------------------------

    public void Start()
    {
        mFSM = new FiniteStateMachine<State>( 4, new StateNone());
        mFSM.AddState(new CampaignMenuState("CampaignSubMenu",   campaignSubMenu));
        mFSM.AddState(new EncounterMenuState("EncounterSubMenu", encounterSubMenu));
        mFSM.AddState(new SettingsMenuState("SettingSubMenu",    settingsSubMenu));

        mFSM.ChangeState( (int)MenuStates.none );
    }

    //------------------------------------------------------------

    public void OnCampaignClick()
    {
        mFSM.ChangeState((int)MenuStates.campaign);
    }

    public void OnEncounterClick()
    {
        mFSM.ChangeState((int)MenuStates.encounter);
    }

    public void OnSettingsClick()
    {
        mFSM.ChangeState((int)MenuStates.settings);
    }

    //------------------------------------------------------------

    public void OnCampaignCreate()
    {
        Debug.Log("[FrontEndMenu] OnCampaignCreate() is not yet implemented! ");
    }

    public void OnCampaignLoad()
    {
        Debug.Log("[FrontEndMenu] OnCampaignLoad() is not yet implemented! ");
    }

    public void OnCampaignConnect()
    {
        Debug.Log("[FrontEndMenu] OnCampaignConnect() is not yet implemented! ");
    }

    //------------------------------------------------------------

    public void OnEncounterCreate()
    {
        Debug.Log("[FrontEndMenu] OnEncounterCreate() is not yet implemented! ");
    }

    public void OnEncounterLoad()
    {
        Debug.Log("[FrontEndMenu] OnEncounterLoad() is not yet implemented! ");
    }

    //------------------------------------------------------------

    public void OnExitClick()
    {
        Application.Quit();
    }
}
//============================================================

//============================================================
// Front End Menu States
//============================================================

public class CampaignMenuState : State
{
    GameObject campaignSubMenu;

    public CampaignMenuState( string tag, GameObject gameObject ) : base( tag )
    {
        campaignSubMenu = gameObject;
    }

    public override void Enter()
    {
        campaignSubMenu.SetActive( !campaignSubMenu.activeInHierarchy );
    }

    public override void Exit()
    {
        campaignSubMenu.SetActive(false);
    }
}

//------------------------------------------------------------

public class EncounterMenuState : State
{
    public GameObject encounterSubMenu;

    public EncounterMenuState(string tag, GameObject gameObject) : base(tag)
    {
        encounterSubMenu = gameObject;
    }

    public override void Enter()
    {
        encounterSubMenu.SetActive(!encounterSubMenu.activeInHierarchy);
    }

    public override void Exit()
    {
        encounterSubMenu.SetActive(false);
    }
}

//------------------------------------------------------------

public class SettingsMenuState : State
{
    GameObject settingSubMenu;

    public SettingsMenuState(string tag, GameObject gameObject) : base(tag)
    {
        settingSubMenu = gameObject;
    }

    public override void Enter()
    {
        settingSubMenu.SetActive(!settingSubMenu.activeInHierarchy);
    }

    public override void Exit()
    {
        settingSubMenu.SetActive(false);
    }
}

//============================================================