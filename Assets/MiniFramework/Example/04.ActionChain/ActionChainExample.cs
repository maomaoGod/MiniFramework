using UnityEngine;
using MiniFramework;
public class ActionChainExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //简易的延迟时间
        this.Delay(1f, () => { Debug.Log(transform.name + Time.time); });
        //复杂的队列逻辑
        this.Sequence()
            .Delay(2)
            .Event(() => { Debug.Log("我是1：" + Time.time); })
            .Until(() => Time.time >= 3f)
            .Event(() => { Debug.Log("我是2：" + Time.time); })
            .Until(() => { return Input.GetKeyDown(KeyCode.Space); })
            .Event(() => Debug.Log("按下了空格"))
            .Start();
    }
}
