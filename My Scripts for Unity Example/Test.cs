using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    [System.Serializable]
    public class SettingPool {
        public GameObject Prefab;
        public int Size;
        public string ID;
    }
    // Use this for initialization
    public List<SettingPool> pooling;
    public List<GameObject> TreeID;
    public List<GameObject> PaintID;
    public List<GameObject> OreID;
    public List<GameObject> MagicID;
    public static Test sharedinstance;
    void Awake() {
        sharedinstance = this;
    }

    void Start () {
        foreach  (SettingPool pool in pooling)
        {
            for (int i = 0; i < pool.Size; i++)
            {
                GameObject _tree = Instantiate(pool.Prefab, new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
                _tree.SetActive(false);
                if (_tree.tag==pooling[0].ID)
                {
                    TreeID.Add(_tree);
                }
                if (_tree.tag == pooling[1].ID)
                {
                    PaintID.Add(_tree);
                }
                if (_tree.tag == pooling[2].ID)
                {
                    OreID.Add(_tree);
                }
                if (_tree.tag == pooling[3].ID)
                {
                    MagicID.Add(_tree);
                }

            }
        }
	}
    public GameObject GetPooledObject() {
        switch (ManagerUI.StoreSeed) {
            case 1://елка
                for (int i = 0; i < TreeID.Count; i++)
                {
                    if (!TreeID[i].activeInHierarchy)
                    {
                        return TreeID[i];
                    }
                }
                break;
            case 2:
                for (int i = 0; i < PaintID.Count; i++)
                {
                    if (!PaintID[i].activeInHierarchy)
                    {
                        return PaintID[i];
                    }
                }
                break;
            case 3:
                for (int i = 0; i < OreID.Count; i++)
                {
                    if (!OreID[i].activeInHierarchy)
                    {
                        return OreID[i];
                    }
                }
                break;
            case 4:
                for (int i = 0; i < MagicID.Count; i++)
                {
                    if (!MagicID[i].activeInHierarchy)
                    {
                        return MagicID[i];
                    }
                }
                break;
        }
       /* if (ManagerUI.StoreSeed == 1)
        {
            for (int i = 0; i < PaintID.Count; i++)
            {
              if (!PaintID[i].activeInHierarchy) {
                        return PaintID[i];
              }
            }
        }
        /* for (int i = 0; i < PoolID.Count; i++)
         {
             if (!PoolID[i].activeInHierarchy)
             {
                // PoolID.Add(PoolID[i]);
                 return PoolID[i];
             }
             /*else if (PoolID[i].activeInHierarchy) {
                 PoolID.Remove(PoolID[i]);
             }*/
        //}
         return null;
    }
}
