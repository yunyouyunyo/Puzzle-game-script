using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering.Universal; // 使用 Light2D
using Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    public Light2D redLight; // 绑定 Light2D 组件
    private bool isShaking = false;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.5f;
    public float hp;
    public float hp_max;
    public Image hp_bar;
    private bool isInPill = false; // 检查玩家是否在 pill 中

    public float cuthp=0.1f;
    public float addhp=0.1f;
    void Start()
    {
        hp = hp_max;
        redLight.enabled = false; // 初始时红光关闭
        StartCoroutine(CutHp()); // 游戏一开始就开始扣 hp
    }

    void Update()
    {
        if (hp_bar.transform.localScale.x >= 0)
        {
            hp_bar.transform.localScale = new Vector3((float)hp / (float)hp_max, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
        }
    }
    // 调用此方法当玩家进入 pill
    public void EnterPill()
    {
        if (!isInPill)
        {
            isInPill = true;
            StopAllCoroutines(); // 停止扣写 hp
            StartCoroutine(AddHp()); // 开始加写 hp
        }
    }

    // 调用此方法当玩家离开 pill
    public void ExitPill()
    {
        if (isInPill)
        {
            isInPill = false;
            StopAllCoroutines(); // 停止加写 hp
            StartCoroutine(CutHp()); // 恢复扣写 hp
        }
    }

    private IEnumerator AddHp()
    {
        while (true)
        {
            if (hp >= hp_max)
            {
                hp = hp_max;
                yield break;
            }
            else
            {
                hp += addhp;
                if (hp >= hp_max / 2)
                {
                    redLight.enabled = false; // 初始时红光关闭
                }
            }

            // 等待 1.5 秒
            yield return new WaitForSeconds(1.5f);
        }
    }
    public CinemachineImpulseSource impulseSource;
    private IEnumerator CutHp()
    {
        while (true)
        {
            if (hp < 0.2f)
            {
                hp = 0f;
                redLight.enabled = true; // 激活红光
                if (!isShaking)
                {
                    impulseSource.GenerateImpulse();
                    isShaking = true; // 防止重复触发
                }

            }
            else
            {
                // 扣写 hp
                hp -= cuthp;
                redLight.enabled = false; // 关闭红光
                isShaking = false;
            }

            yield return new WaitForSeconds(1.5f);
        }
    }
}
