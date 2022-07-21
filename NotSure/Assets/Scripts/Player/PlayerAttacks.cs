using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;

public class PlayerAttacks : MonoBehaviour
{
    public Canvas damageTextCanvas;
    public TMP_Text damageText;
    public PlayableDirector damageTextAnim;
    public Transform attackPoint;

    public float attackRange;
    public float attackDamage;
    public float defaultAttackDamage;
    public float textRemoveTime;
    public float defaultYOffset;
    public float yOffset;

    public void Attack(int combo)
    {
        if (combo == 3)
        {
            attackDamage *= 2;
        }
        else
        {
            attackDamage = defaultAttackDamage;
        }

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        if (hitObjects.Length > 0)
        {
            foreach (Collider2D col in hitObjects)
            {
                if (col.GetComponent<Enemy>())
                {
                    Enemy enemy = col.GetComponent<Enemy>();
                    enemy.TakeDamage(attackDamage);

                    yOffset += 0.2f;

                    damageTextCanvas.gameObject.SetActive(true);
                    damageTextCanvas.transform.localPosition = new Vector2(enemy.transform.localPosition.x, enemy.transform.localPosition.y + yOffset);
                    damageText.text = attackDamage.ToString();

                    damageTextAnim.Play();

                    StartCoroutine(WaitToRemoveDamageText());
                }
            }
        }
    }

    IEnumerator WaitToRemoveDamageText()
    {
        yield return new WaitForSeconds(textRemoveTime);
        damageTextCanvas.gameObject.SetActive(false);
        yOffset = defaultYOffset;
    }
}
