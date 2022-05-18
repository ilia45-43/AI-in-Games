using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject BuletPref;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private Text damageText;

    public int addDamage;
    public int damage;
    [SerializeField]
    private float speedBulet;
    [SerializeField]
    private float delayForShoot;

    private GameObject[] massEnemys;
    private WaitForSeconds waitForSeconds;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        waitForSeconds = new WaitForSeconds(delayForShoot);
        StartCoroutine(Attack_IEnum());
    }

    private IEnumerator Attack_IEnum()
    {
        bool anim = false;
        while (true)
        {
            massEnemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (massEnemys.Length == 0 || massEnemys == null)
            {
                if (anim)
                {
                    _animator.SetBool("attacking", !anim);
                }
                anim = false;
                yield return null;
            }
            var check = LookAtEnemy();
            if (!Input.anyKey && check != null)
            {
                if (!anim)
                {
                    _animator.SetBool("attacking", !anim);
                }
                anim = true;
                CreateAndShoot(check);
                yield return waitForSeconds;
            }
            else
            {
                if (anim)
                {
                    _animator.SetBool("attacking", !anim);
                }
                anim = false;
                //_animator.SetBool("attacking", false);
                yield return null;
            }
        }
    }

    private void CreateAndShoot(Transform check)
    {
        var enemyT = check;
        var a = new Vector3(enemyT.position.x, transform.position.y, enemyT.position.z);
        transform.LookAt(a);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * 1000);
        GameObject bulet = GameObject.Instantiate(BuletPref, firePoint.position, Quaternion.identity);
        bulet.GetComponent<Rigidbody>().AddForce(firePoint.forward * speedBulet, ForceMode.Impulse);
    }

    private Transform LookAtEnemy()
    {
        var min = 100f;
        float a;
        GameObject enemy = null;
        for (int i = 0; i < massEnemys.Length; i++)
        {
            if (massEnemys[i] != null)
            {
                a = Vector3.Distance(massEnemys[i].transform.position, firePoint.transform.position);
                if (a < min)
                {
                    min = a;
                    enemy = massEnemys[i];
                }
            }
            else
            {
                enemy = null;
            }
        }

        if (enemy == null)
            return null;

        if (Vector3.Distance(enemy.transform.position, firePoint.transform.position) > 20)
            return null;

        return enemy == null ? null : enemy.transform;
    }

    public void AddDamage()
    {
        damage += addDamage;
        damageText.text = "Damage = " + damage;
    }
}
