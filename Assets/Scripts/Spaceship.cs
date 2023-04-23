using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class Spaceship : NetworkBehaviour 
{
    private Rigidbody rb;
    private Slider _sliderR;
    private Slider _sliderL;
    public GameObject[] switches;
    private Panel panel;
    [SerializeField] private GameObject[] spaceshipsColors;
    [SerializeField] private Gradient[] trailsColors;
    
    public float multiplierSpeed;
    [SerializeField] private float boostSpeedValue = 2f;
    private float boostSpeed = 1f;
    public float smoothSpeed = 0.125f;
    private float vR = 0f;
    private float vL = 0f;
    private float average = 0f;
    public float fuel = 1f;
    private float maxFuel = 1f;
    private  float fuelMultiplier = 0.001f;

    public bool canRecharge = false;
    public bool canBoost = false;
    private bool leftReactorBroke = false;
    private bool rightReactorBroke = false;
    public bool shieldActivated = false;

    public override void OnStartClient()
    {
        base.OnStartClient();
        uint netID = GetComponent<NetworkIdentity>().netId;
        string netIdString = netID.ToString();
        Spaceship clientSpaceship = GetComponent<Spaceship>();
        GameManager.RegisterPlayer(netIdString, clientSpaceship);

        // spawn the good ship
        GameObject spaceship = Instantiate(spaceshipsColors[(netID - 2) % 4], transform.position, transform.rotation, gameObject.transform);
        spaceship.transform.Rotate( new Vector3(0, 180, 0)); // returns it
        transform.GetComponentInChildren<TrailRenderer>().colorGradient = trailsColors[(netID - 2) % 4];

    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        GameManager.UnregisterPlayer(transform.name);
    }

    private void Awake() 
    {
        panel = GameObject.Find("validPannel").GetComponent<Panel>();
        switches = GameObject.Find("v2 fuse box")?.GetComponent<FuseBox>().fuseBoxSwitches;
        _sliderL = GameObject.Find("SliderL")?.GetComponent<Slider>();
        _sliderR = GameObject.Find("SliderR")?.GetComponent<Slider>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        _sliderR?.onValueChanged.AddListener((v) => {
            vR = v;
            average = SetAverageSlidersValue(vR, vL);
        });
        _sliderL?.onValueChanged.AddListener((v) => {
            vL = v;
            average = SetAverageSlidersValue(vR, vL);
        });
    }

    private void Update() 
    { 
        if (!isLocalPlayer)
            this.enabled = false;

        if (canBoost)
            boostSpeed = boostSpeedValue;
        else 
            boostSpeed = 1f;

        if(shieldActivated)
            this.transform.Find("Shield").gameObject.SetActive(true);
        else
            this.transform.Find("Shield").gameObject.SetActive(false);

        panel.isFuseRight = rightReactorBroke;
        panel.isFuseLeft = leftReactorBroke;
    }

    private void FixedUpdate() 
    {
        FuelConsumer();
        MovePlayer(average, vR, vL);
    }

    void OnCollisionEnter(Collision collision) 
    {
        Vector3 relativePosition = transform.InverseTransformPoint(collision.transform.position);
        if(relativePosition.x < 0) 
        {
            DisableReactor(_sliderR);
            TurnOffSwitches(6, 11);
            rightReactorBroke = true;
        } 
        else 
        {
            DisableReactor(_sliderL);
            TurnOffSwitches(0, 5);
            leftReactorBroke = true;
        }
    }

    private void MovePlayer(float average, float vR, float vL) 
    {
        rb.AddRelativeForce(0f, 0f, multiplierSpeed * average * boostSpeed, ForceMode.Force);
        float diffSliders = (vL - vR);
        transform.Rotate(0f, diffSliders, 0f);
    }

    private void DisableReactor(Slider slider) 
    {
        slider.value = 0;
        slider.interactable = false;
    }

    private float GetAverageSlidersValue() 
    {
        return (_sliderL.value + _sliderR.value) / 2;
    }

    private bool IsSwitchesOn(int startIndex, int stopIndex) 
    {
        for (int i = startIndex; i <= stopIndex; i++) 
        {
            if (!switches[i].GetComponent<fuse>().GetState())
                return false;
        }
        return true;
    }

    private float SetAverageSlidersValue(float vR, float vL) 
    {
        return (vR + vL) / 2;
    }

    private void TurnOffSwitches(int startIndex, int stopIndex) 
    {
        for (int i = startIndex; i <= stopIndex; i++) 
        {
            if (switches[i].transform.position.z != -180) // if is down
                switches[i]?.GetComponent<fuse>().Rotation();
        }
    }

    private void FuelConsumer() 
    {
        float slidersPower = GetAverageSlidersValue();
        Debug.Log(GameManager.instance.hasRaceStarted);

        if(!GameManager.instance.hasRaceStarted) 
        {
            SetInteractableSliders(false);
            return;
        }

        if (fuel > 0.0) 
        {
            panel.isGauge = false;
            if (leftReactorBroke && rightReactorBroke) 
            {
                if (IsSwitchesOn(0, 5)) 
                {
                    _sliderL.interactable = true;
                    leftReactorBroke = false;
                }
                if (IsSwitchesOn(6, 11)) 
                {
                    _sliderR.interactable = true;
                    rightReactorBroke = false;
                }
            } 
            else if (leftReactorBroke) 
            {
                if (IsSwitchesOn(0, 5)) 
                {
                    _sliderL.interactable = true;
                    leftReactorBroke = false;
                }
            } 
            else if (rightReactorBroke) 
            {
                if (IsSwitchesOn(6, 11)) 
                {
                    _sliderR.interactable = true;
                    rightReactorBroke = false;
                }
            } 
            else 
            {
                SetInteractableSliders(true);
            }
            fuel = fuel - (slidersPower * fuelMultiplier);
        } 
        else 
        {
            panel.isGauge = true;
            fuel = 0f; 
            DisableReactor(_sliderL);
            DisableReactor(_sliderR);
        }
    }

    public float GetFuelLevel() 
    {
        return fuel;
    }

    private void RechargeFuel(float value) 
    {
        if(fuel < maxFuel)
            fuel += value;
    }

    public void RechargeGauge() 
    {
        if (canRecharge)
            RechargeFuel(0.01f);
    }

    public void FullyRechargeGauge()
    {
        RechargeFuel(maxFuel-fuel);
    }

    public void SetInteractableSliders(bool isInteractable)
    {
        _sliderR.interactable = isInteractable;
        _sliderL.interactable = isInteractable;
    }

    public void SetSlidersValue(float newValue)
    {
        _sliderR.value = newValue;
        _sliderL.value = newValue;
    }
}
