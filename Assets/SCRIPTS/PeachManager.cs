using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PeachManager : MonoBehaviour {

    public GameObject PeachPrefab;
    public int PeachNaumber;
	public Text PeachText;
	public Text Message;

	public List<Peach> PeachList = new List<Peach>();

    void Start() {
        
        for (int i = 0; i < PeachNaumber; i++) {

            Vector3 position = new Vector3(Random.Range(-10f,20f), 0.5f, Random.Range(-20f, 20f));
			GameObject newPeach = Instantiate(PeachPrefab, position, Quaternion.identity);

            PeachList.Add(newPeach.GetComponent<Peach>());
			UpdateText();

		}

    }

    public void CollectPeach(Peach peach) {
        PeachList.Remove(peach);
        Destroy(peach.gameObject);

        if (PeachList.Count == 0) Win();


		UpdateText();
	}

    void Win() {
		Message.text= "You did it!";

	}

    public Peach GetClosest (Vector3 point) {

        float shortestDistance = Mathf.Infinity;
        Peach closestPeach = null;

		for (int i = 0; i < PeachList.Count; i++) {

            float distance = Vector3.Distance(point, PeachList[i].transform.position);

            if (distance < shortestDistance) {
                shortestDistance = distance;
                closestPeach = PeachList[i];
			}

		}

        return closestPeach;
	}

	void UpdateText() {
		PeachText.text = PeachList.Count.ToString();
	}

}
