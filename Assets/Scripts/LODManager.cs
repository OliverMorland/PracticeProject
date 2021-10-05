using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODManager : MonoBehaviour
{
    [SerializeField] LODGroup m_lodGrp;
    [SerializeField][Range(0, 1f)] float[] m_transitionHeights;
    
    [ContextMenu("UpdateTransitionHeights")]
    void UpdateTransitionHeights()
    {
        if (m_lodGrp.lodCount != m_transitionHeights.Length)
        {
            Debug.LogError("Transition heights and lod count are not equal");
            return;
        }

        LOD[] lods = m_lodGrp.GetLODs();
        LOD[] newLods = new LOD[lods.Length];
        for (int i = 0; i < lods.Length; i++)
        {
            LOD lod = lods[i];
            lod.screenRelativeTransitionHeight = m_transitionHeights[i];
            newLods[i] = lod;
        }
        m_lodGrp.SetLODs(newLods);
        m_lodGrp.RecalculateBounds();

    }
}
