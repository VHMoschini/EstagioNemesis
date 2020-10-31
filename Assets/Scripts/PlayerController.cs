using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public ObjectPooler objectPooler;
    public int selectedBullet = 0;
    public BulletsManager bulletsManager;
    [HideInInspector] public GameObject projectile;
    public GameObject aim;
    [HideInInspector] public GameObject bulletInst;
    public float throwForce;
    public float throwYDir;
    public float throwXDir;
    private LineRenderer lineRenderer;
    private AudioSource audioSource;
    public CharacterStats characterStats;
    public SoundBank soundBank;
    private bool droneFailStarted;
    private bool deathlSFXplayed;

    [Header("When Hit")]
    public float CameraShakeAmplitude;
    public float CameraShakeTime;

    public BoolVariable shouldMoveCamera;

    public Camera cam;

    public static bool isAiming;
    public static bool shouldShoot;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();

        shouldMoveCamera.Value = true;
        characterStats.currentLife = characterStats.maxLife;
        shouldShoot = true;
    }


    void Update()
    {
        Vector3 aimPos = cam.WorldToScreenPoint(aim.transform.position);
        throwXDir = (aimPos.x - Input.mousePosition.x) / 1000;
        throwYDir = (aimPos.y - Input.mousePosition.y) / 1000;

        if (characterStats.currentLife <= 0 && !deathlSFXplayed)
        {
            audioSource.clip = soundBank.defeatFanfarre.audioClip[Random.Range(0, soundBank.defeatFanfarre.audioClip.Length)];
            audioSource.volume = soundBank.defeatFanfarre.volume;
            audioSource.Play();
            deathlSFXplayed = true;
        }

        if (characterStats.currentLife <= 20 && characterStats.currentLife > 0 )
        {
            if (!droneFailStarted)
            {
                audioSource.clip = soundBank.droneFail.audioClip[Random.Range(0, soundBank.takeDamage.audioClip.Length)];
                audioSource.volume = soundBank.droneFail.volume;
                audioSource.Play();
                droneFailStarted = true;
            }
            audioSource.loop = true;
        }
        else
            audioSource.loop = false;

    }

    public void PlotTrajectory(Vector3 start, Vector3 startVelocity, float timestep, float maxTime)
    {

        int index = 0;

        Vector3 prev = start;
        for (int i = 1; ; i++)
        {
            float t = timestep * i;
            if (t > maxTime) break;
            Vector3 pos = PlotTrajectoryAtTime(start, startVelocity, t);
            lineRenderer.positionCount = ((int)(maxTime / timestep));

            if (Physics.Linecast(prev, pos))
            {
                lineRenderer.positionCount = index;
                break;
            }
            else
            {
                lineRenderer.SetPosition(index, pos);
                Debug.DrawLine(prev, pos, Color.red);
                prev = pos;
                index++;
            }
        }
    }

    public Vector3 PlotTrajectoryAtTime(Vector3 start, Vector3 startVelocity, float time)
    {
        return start + startVelocity * time + Physics.gravity * time * time * 0.5f;
    }

    private void OnMouseDown()
    {
        shouldMoveCamera.Value = false;
        isAiming = true;
        if (bulletsManager.bullets[selectedBullet].currentBulletNum > 0)
        {
            bulletInst = Instantiate(projectile, aim.transform.position + (transform.forward * 2), transform.rotation);
            bulletInst.transform.SetParent(transform);
            bulletInst.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnMouseUp()
    {
        shouldMoveCamera.Value = true;
        isAiming = false;
        if (bulletsManager.bullets[selectedBullet].currentBulletNum > 0)
        {
            if (shouldShoot)
            {
                ShootSFX();
                lineRenderer.positionCount = 0;
                bulletInst.transform.SetParent(null);
                bulletInst.GetComponent<Rigidbody>().isKinematic = false;
                bulletInst.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(throwXDir, throwYDir, 1) * throwForce, ForceMode.VelocityChange);
                bulletsManager.bullets[selectedBullet].currentBulletNum--;
            }
            else
            {
                lineRenderer.positionCount = 0;
                Destroy(bulletInst);
            }
        }
    }

    private void OnMouseDrag()
    {
        if (bulletsManager.bullets[selectedBullet].currentBulletNum > 0)
        {
            PlotTrajectory(aim.transform.position + (transform.forward * 2), (transform.rotation * new Vector3(throwXDir, throwYDir, 1)) * throwForce, 0.02f, 5f);
        }
    }

    public void TakeDamage(int damageTaken)
    {
        characterStats.currentLife -= damageTaken;
        audioSource.PlayOneShot(soundBank.takeDamage.audioClip[Random.Range(0, soundBank.takeDamage.audioClip.Length)]);
        audioSource.volume = soundBank.takeDamage.volume;

        CameraShakeHandler.Instance.ShakeCamera(CameraShakeAmplitude, CameraShakeTime);
    }

    private void ShootSFX()
    {
        switch (selectedBullet)
        {
            case 0:
                audioSource.PlayOneShot(soundBank.shot1.audioClip[Random.Range(0, soundBank.takeDamage.audioClip.Length)]);
                audioSource.volume = soundBank.shot1.volume;

                break;
            case 1:
                audioSource.PlayOneShot(soundBank.shot2.audioClip[Random.Range(0, soundBank.takeDamage.audioClip.Length)]);
                audioSource.volume = soundBank.shot2.volume;

                break;
            case 2:
                audioSource.PlayOneShot(soundBank.shot3.audioClip[Random.Range(0, soundBank.takeDamage.audioClip.Length)]);
                audioSource.volume = soundBank.shot3.volume;

                break;



        }
    }


}
